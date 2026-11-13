-- =====================================================================================
-- Transferencia entre Almacenes - Script 6 de 9: procedimiento de registro / anulacion
-- =====================================================================================
-- Un solo procedimiento y UNA sola transaccion para cabecera + detalle:
--
-- @opcion = 1  Registrar. La cabecera llega por parametros y el detalle completo en
--              @Detalle (tipo tabla dbo.TransferenciaAlmacenDetTipo). Si algo falla, no
--              queda nada grabado.
--                * TipoTransferencia se asigna solo: destino '000' = 'D' (devolucion),
--                  cualquier otro destino = 'T' (transferencia).
--                * codCuenta NULL en el detalle: se toma la del producto en el almacen
--                  origen (ultimo movimiento en Kardex para el central).
-- @opcion = 2  Anular (no se borra nada; queda la trazabilidad de quien y por que).
--
-- Validaciones de stock (dbo.ufnStockAlmacen):
--   * Origen central: stock disponible a la fecha de la transferencia y, si la fecha es
--     pasada, tambien al dia de hoy (para no dejar en negativo despachos posteriores).
--   * Origen secundario: el saldo del almacen no puede quedar negativo en ninguna fecha.
--   * Anular: el almacen destino no puede quedar negativo (si ya se movio ese stock,
--     primero se anula o devuelve lo posterior).
--
-- Respuesta: idResponse (id de la transferencia o 0), messageResponse, typeMessage.
--
-- Requiere los scripts 2, 3 y 4, y dbo.fnPeriodoBloqueado (scripts de Cierre de Periodo).
-- =====================================================================================

SET NOCOUNT ON;
GO

CREATE OR ALTER PROCEDURE dbo.uspSetTransferenciaAlmacen
	@opcion				int,
	@IdTransferencia	int				= NULL,	-- opcion 2
	@FechaTransferencia	date			= NULL,	-- opcion 1
	@CodAlmacenOrigen	varchar(3)		= NULL,	-- opcion 1
	@CodAlmacenDestino	varchar(3)		= NULL,	-- opcion 1
	@Observacion		varchar(500)	= NULL,	-- opcion 1
	@MotivoAnulacion	varchar(250)	= NULL,	-- opcion 2
	@IdUsuario			int,
	@Detalle			dbo.TransferenciaAlmacenDetTipo READONLY	-- opcion 1
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @CodCentral varchar(3) = '000';
	DECLARE @Hoy date = CAST(GETDATE() AS date);
	DECLARE @msg varchar(2000);
	DECLARE @FechaControl date;
	DECLARE @nivel char(2);

	-- productos/almacenes cuyo stock debe validarse despues de grabar
	DECLARE @Chequeo TABLE (
		CodAlmacen	varchar(3)	NOT NULL,
		codNivel	char(2)		NOT NULL,
		codGrupo	char(5)		NOT NULL,
		codTalla	char(3)		NOT NULL,
		codColor	char(6)		NOT NULL,
		PRIMARY KEY (CodAlmacen, codNivel, codGrupo, codTalla, codColor)
	);

	DECLARE @Errores TABLE (
		CodAlmacen	varchar(3),
		Codigo		varchar(30),
		Faltante	decimal(18,3)
	);

	CREATE TABLE #stock (
		Corte		date		NOT NULL,
		CodAlmacen	varchar(3)	NOT NULL,
		codNivel	char(2)		NOT NULL,
		codGrupo	char(5)		NOT NULL,
		codTalla	char(3)		NOT NULL,
		codColor	char(6)		NOT NULL,
		Stock		decimal(18,3) NOT NULL,
		codCuenta	char(10)	NULL,
		PRIMARY KEY (Corte, CodAlmacen, codNivel, codGrupo, codTalla, codColor)
	);

	BEGIN TRY

		IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE id = @IdUsuario AND estado = 1)
		BEGIN
			SELECT 0 AS idResponse, 'Usuario no valido.' AS messageResponse, 'ERROR' AS typeMessage;
			RETURN;
		END

		-- =========================================================================
		-- 1) REGISTRAR
		-- =========================================================================
		IF @opcion = 1
		BEGIN
			SET @CodAlmacenOrigen  = NULLIF(LTRIM(RTRIM(@CodAlmacenOrigen)), '');
			SET @CodAlmacenDestino = NULLIF(LTRIM(RTRIM(@CodAlmacenDestino)), '');
			SET @Observacion       = NULLIF(LTRIM(RTRIM(@Observacion)), '');

			-- ---- validaciones de cabecera ---------------------------------------
			IF @FechaTransferencia IS NULL
				SET @msg = 'Ingrese la fecha de la transferencia.';
			ELSE IF @FechaTransferencia > @Hoy
				SET @msg = 'La fecha de la transferencia no puede ser posterior a hoy.';
			ELSE IF dbo.fnPeriodoBloqueado(@FechaTransferencia) = 1
				SET @msg = 'El periodo se encuentra cerrado. No se puede registrar documentos de este periodo.';
			ELSE IF @CodAlmacenOrigen IS NULL OR @CodAlmacenDestino IS NULL
				SET @msg = 'Seleccione el almacen de origen y el de destino.';
			ELSE IF @CodAlmacenOrigen = @CodAlmacenDestino
				SET @msg = 'El almacen de origen y el de destino deben ser distintos.';
			ELSE IF NOT EXISTS (SELECT 1 FROM dbo.AreasAlmacen WHERE Codigo = @CodAlmacenOrigen AND lActivo = 1 AND Codigo <> '999')
				SET @msg = 'El almacen de origen no existe o esta inactivo.';
			ELSE IF NOT EXISTS (SELECT 1 FROM dbo.AreasAlmacen WHERE Codigo = @CodAlmacenDestino AND lActivo = 1 AND Codigo <> '999')
				SET @msg = 'El almacen de destino no existe o esta inactivo.';
			-- ---- validaciones de detalle ----------------------------------------
			ELSE IF NOT EXISTS (SELECT 1 FROM @Detalle)
				SET @msg = 'Agregue al menos un producto a la transferencia.';
			ELSE IF EXISTS (SELECT 1 FROM @Detalle WHERE Cantidad IS NULL OR Cantidad <= 0)
				SET @msg = 'Todas las cantidades deben ser mayores a cero.';
			ELSE IF EXISTS (SELECT 1 FROM @Detalle GROUP BY codNivel, codGrupo, codTalla, codColor HAVING COUNT(*) > 1)
				SET @msg = 'Hay productos repetidos en el detalle.';
			ELSE IF EXISTS (
				SELECT 1 FROM @Detalle d
				WHERE NOT EXISTS (SELECT 1 FROM dbo.productoServicios p
								  WHERE p.codNivel = d.codNivel AND p.codGrupo = d.codGrupo
									AND p.codTalla = d.codTalla AND p.codColor = d.codColor))
				SET @msg = 'Hay productos que no existen en el catalogo.';

			IF @msg IS NOT NULL
			BEGIN
				SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			-- ---- stock disponible en el origen a la fecha (por nivel) -----------
			DECLARE curNivel CURSOR LOCAL FAST_FORWARD FOR
				SELECT DISTINCT codNivel FROM @Detalle;
			OPEN curNivel;
			FETCH NEXT FROM curNivel INTO @nivel;
			WHILE @@FETCH_STATUS = 0
			BEGIN
				INSERT INTO #stock (Corte, CodAlmacen, codNivel, codGrupo, codTalla, codColor, Stock, codCuenta)
				SELECT @FechaTransferencia, s.CodAlmacen, s.codNivel, s.codGrupo, s.codTalla, s.codColor, s.Stock, s.codCuenta
				FROM dbo.ufnStockAlmacen(@FechaTransferencia, @nivel, NULL) s
				WHERE s.CodAlmacen = @CodAlmacenOrigen
				OPTION (RECOMPILE);

				FETCH NEXT FROM curNivel INTO @nivel;
			END
			CLOSE curNivel;
			DEALLOCATE curNivel;

			SELECT @msg = 'Stock insuficiente en el almacen de origen al ' + CONVERT(varchar(10), @FechaTransferencia, 103) + ': '
						+ STRING_AGG(CONVERT(varchar(max), x.Codigo + ' (disponible ' + CONVERT(varchar(30), x.Disponible) + ', solicitado ' + CONVERT(varchar(30), x.Cantidad) + ')'), '; ')
			FROM (
				SELECT TOP (10)
						d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor AS Codigo,
						CAST(ISNULL(s.Stock, 0) AS decimal(18,3)) AS Disponible,
						d.Cantidad
				FROM @Detalle d
				LEFT JOIN #stock s ON s.codNivel = d.codNivel AND s.codGrupo = d.codGrupo
								AND s.codTalla = d.codTalla AND s.codColor = d.codColor
				WHERE d.Cantidad > ISNULL(s.Stock, 0)
				ORDER BY d.codNivel, d.codGrupo, d.codTalla, d.codColor
			) x
			HAVING COUNT(*) > 0;

			IF @msg IS NOT NULL
			BEGIN
				SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			-- ---- cuenta contable de cada linea ----------------------------------
			DECLARE @DetalleFinal TABLE (
				codNivel char(2), codGrupo char(5), codTalla char(3), codColor char(6),
				codCuenta char(10), Cantidad decimal(12,3), Comentario varchar(250)
			);

			INSERT INTO @DetalleFinal (codNivel, codGrupo, codTalla, codColor, codCuenta, Cantidad, Comentario)
			SELECT	d.codNivel, d.codGrupo, d.codTalla, d.codColor,
					COALESCE(NULLIF(LTRIM(RTRIM(d.codCuenta)), ''), s.codCuenta),
					d.Cantidad,
					NULLIF(LTRIM(RTRIM(d.Comentario)), '')
			FROM @Detalle d
			LEFT JOIN #stock s ON s.codNivel = d.codNivel AND s.codGrupo = d.codGrupo
							AND s.codTalla = d.codTalla AND s.codColor = d.codColor;

			SELECT @msg = 'No se pudo determinar la cuenta contable de: '
						+ STRING_AGG(CONVERT(varchar(max), codNivel + '.' + codGrupo + '.' + codTalla + '.' + codColor), ', ')
			FROM @DetalleFinal
			WHERE codCuenta IS NULL
			HAVING COUNT(*) > 0;

			IF @msg IS NULL
				SELECT @msg = 'Las siguientes cuentas no se muestran en Kardex (FlgMostrarKardex): '
							+ STRING_AGG(CONVERT(varchar(max), RTRIM(d.codCuenta)), ', ')
				FROM (SELECT DISTINCT codCuenta FROM @DetalleFinal) d
				WHERE NOT EXISTS (SELECT 1 FROM dbo.cuentas c WHERE c.codCuenta = d.codCuenta AND c.estado = 1 AND c.FlgMostrarKardex = 1)
				HAVING COUNT(*) > 0;

			IF @msg IS NOT NULL
			BEGIN
				SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			-- ---- grabacion: cabecera + detalle en una transaccion ---------------
			BEGIN TRANSACTION;

			INSERT INTO dbo.TransferenciaAlmacenCab
				(TipoTransferencia, FechaTransferencia, CodAlmacenOrigen, CodAlmacenDestino, Observacion, Estado, IdUsuarioRegistro, FechaRegistro)
			VALUES
				(CASE WHEN @CodAlmacenDestino = @CodCentral THEN 'D' ELSE 'T' END,
				 @FechaTransferencia, @CodAlmacenOrigen, @CodAlmacenDestino, @Observacion, 'A', @IdUsuario, GETDATE());

			SET @IdTransferencia = SCOPE_IDENTITY();

			INSERT INTO dbo.TransferenciaAlmacenDet
				(IdTransferencia, codNivel, codGrupo, codTalla, codColor, codCuenta, Cantidad, Comentario)
			SELECT @IdTransferencia, codNivel, codGrupo, codTalla, codColor, codCuenta, Cantidad, Comentario
			FROM @DetalleFinal;

			-- a validar despues de grabar: el almacen origen
			INSERT INTO @Chequeo (CodAlmacen, codNivel, codGrupo, codTalla, codColor)
			SELECT @CodAlmacenOrigen, codNivel, codGrupo, codTalla, codColor FROM @DetalleFinal;

			SET @FechaControl = @FechaTransferencia;
		END

		-- =========================================================================
		-- 2) ANULAR
		-- =========================================================================
		ELSE IF @opcion = 2
		BEGIN
			DECLARE @Estado char(1), @Fecha date, @Destino varchar(3);

			SELECT	@Estado = Estado, @Fecha = FechaTransferencia, @Destino = CodAlmacenDestino
			FROM dbo.TransferenciaAlmacenCab
			WHERE IdTransferencia = @IdTransferencia;

			SET @MotivoAnulacion = NULLIF(LTRIM(RTRIM(@MotivoAnulacion)), '');

			IF @Estado IS NULL
				SET @msg = 'La transferencia no existe.';
			ELSE IF @Estado = 'N'
				SET @msg = 'La transferencia ya se encuentra anulada.';
			ELSE IF @MotivoAnulacion IS NULL
				SET @msg = 'Ingrese el motivo de la anulacion.';
			ELSE IF dbo.fnPeriodoBloqueado(@Fecha) = 1
				SET @msg = 'El periodo se encuentra cerrado. No se puede anular documentos de este periodo.';

			IF @msg IS NOT NULL
			BEGIN
				SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			BEGIN TRANSACTION;

			UPDATE dbo.TransferenciaAlmacenCab
			SET		Estado = 'N',
					IdUsuarioAnulacion = @IdUsuario,
					FechaAnulacion = GETDATE(),
					MotivoAnulacion = @MotivoAnulacion
			WHERE IdTransferencia = @IdTransferencia
				AND Estado = 'A';

			-- a validar despues de anular: el almacen destino (pierde ese ingreso)
			INSERT INTO @Chequeo (CodAlmacen, codNivel, codGrupo, codTalla, codColor)
			SELECT @Destino, codNivel, codGrupo, codTalla, codColor
			FROM dbo.TransferenciaAlmacenDet
			WHERE IdTransferencia = @IdTransferencia;

			SET @FechaControl = @Fecha;
		END
		ELSE
		BEGIN
			SELECT 0 AS idResponse, 'Opcion no valida.' AS messageResponse, 'ERROR' AS typeMessage;
			RETURN;
		END

		-- =========================================================================
		-- Validacion de stock despues de grabar (dentro de la transaccion)
		-- =========================================================================

		-- a) Almacenes secundarios: el saldo acumulado no puede ser negativo en ninguna fecha
		;WITH mov AS (
			SELECT	ch.CodAlmacen, ch.codNivel, ch.codGrupo, ch.codTalla, ch.codColor,
					c.FechaTransferencia,
					SUM(CASE WHEN c.CodAlmacenDestino = ch.CodAlmacen THEN d.Cantidad ELSE -d.Cantidad END) AS Cantidad
			FROM @Chequeo ch
			INNER JOIN dbo.TransferenciaAlmacenDet d ON d.codNivel = ch.codNivel AND d.codGrupo = ch.codGrupo
													AND d.codTalla = ch.codTalla AND d.codColor = ch.codColor
			INNER JOIN dbo.TransferenciaAlmacenCab c ON c.IdTransferencia = d.IdTransferencia
													AND c.Estado = 'A'
													AND (c.CodAlmacenOrigen = ch.CodAlmacen OR c.CodAlmacenDestino = ch.CodAlmacen)
			WHERE ch.CodAlmacen <> @CodCentral
			GROUP BY ch.CodAlmacen, ch.codNivel, ch.codGrupo, ch.codTalla, ch.codColor, c.FechaTransferencia
		),
		saldo AS (
			SELECT	*,
					SUM(Cantidad) OVER (PARTITION BY CodAlmacen, codNivel, codGrupo, codTalla, codColor
										ORDER BY FechaTransferencia ROWS UNBOUNDED PRECEDING) AS Saldo
			FROM mov
		)
		INSERT INTO @Errores (CodAlmacen, Codigo, Faltante)
		SELECT	CodAlmacen, codNivel + '.' + codGrupo + '.' + codTalla + '.' + codColor, -MIN(Saldo)
		FROM saldo
		GROUP BY CodAlmacen, codNivel, codGrupo, codTalla, codColor
		HAVING MIN(Saldo) < 0;

		-- b) Almacen central: a la fecha del documento (solo en anulacion: al registrar ya se
		--    valido antes de grabar) y al dia de hoy (si el documento es de fecha pasada)
		IF EXISTS (SELECT 1 FROM @Chequeo WHERE CodAlmacen = @CodCentral)
		BEGIN
			DELETE FROM #stock;

			DECLARE curCentral CURSOR LOCAL FAST_FORWARD FOR
				SELECT DISTINCT codNivel FROM @Chequeo WHERE CodAlmacen = @CodCentral;
			OPEN curCentral;
			FETCH NEXT FROM curCentral INTO @nivel;
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @opcion = 2
					INSERT INTO #stock (Corte, CodAlmacen, codNivel, codGrupo, codTalla, codColor, Stock, codCuenta)
					SELECT @FechaControl, s.CodAlmacen, s.codNivel, s.codGrupo, s.codTalla, s.codColor, s.Stock, s.codCuenta
					FROM dbo.ufnStockAlmacen(@FechaControl, @nivel, NULL) s
					WHERE s.CodAlmacen = @CodCentral
					OPTION (RECOMPILE);

				IF @FechaControl < @Hoy
					INSERT INTO #stock (Corte, CodAlmacen, codNivel, codGrupo, codTalla, codColor, Stock, codCuenta)
					SELECT '99991231', s.CodAlmacen, s.codNivel, s.codGrupo, s.codTalla, s.codColor, s.Stock, s.codCuenta
					FROM dbo.ufnStockAlmacen('99991231', @nivel, NULL) s
					WHERE s.CodAlmacen = @CodCentral
					OPTION (RECOMPILE);

				FETCH NEXT FROM curCentral INTO @nivel;
			END
			CLOSE curCentral;
			DEALLOCATE curCentral;

			INSERT INTO @Errores (CodAlmacen, Codigo, Faltante)
			SELECT	@CodCentral, ch.codNivel + '.' + ch.codGrupo + '.' + ch.codTalla + '.' + ch.codColor, -MIN(s.Stock)
			FROM @Chequeo ch
			INNER JOIN #stock s ON s.codNivel = ch.codNivel AND s.codGrupo = ch.codGrupo
								AND s.codTalla = ch.codTalla AND s.codColor = ch.codColor
			WHERE ch.CodAlmacen = @CodCentral
				AND s.Stock < 0
			GROUP BY ch.codNivel, ch.codGrupo, ch.codTalla, ch.codColor;
		END

		IF EXISTS (SELECT 1 FROM @Errores)
		BEGIN
			ROLLBACK TRANSACTION;

			SELECT @msg = CASE WHEN @opcion = 1
							   THEN 'No se puede registrar: el almacen quedaria con stock negativo por movimientos posteriores. '
							   ELSE 'No se puede anular: ese stock ya fue movido o despachado desde el almacen destino. ' END
						+ STRING_AGG(CONVERT(varchar(max), x.Codigo + ' en ' + COALESCE(NULLIF(RTRIM(a.tResumido), ''), a.Descripcion, x.CodAlmacen) + ' (faltan ' + CONVERT(varchar(30), x.Faltante) + ')'), '; ')
			FROM (SELECT TOP (10) * FROM @Errores ORDER BY Codigo) x
			INNER JOIN dbo.AreasAlmacen a ON a.Codigo = x.CodAlmacen;

			SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
			RETURN;
		END

		COMMIT TRANSACTION;

		SELECT	@IdTransferencia AS idResponse,
				CASE WHEN @opcion = 1
					 THEN 'Transferencia N° ' + RIGHT('000000' + CAST(@IdTransferencia AS varchar(10)), 6) + ' registrada correctamente.'
					 ELSE 'Transferencia N° ' + RIGHT('000000' + CAST(@IdTransferencia AS varchar(10)), 6) + ' anulada correctamente.' END AS messageResponse,
				'INFORMATION' AS typeMessage;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		SELECT 0 AS idResponse, CAST(ERROR_MESSAGE() AS varchar(2000)) AS messageResponse, 'ERROR' AS typeMessage;
	END CATCH
END
GO
