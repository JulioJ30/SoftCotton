-- =====================================================================================
-- Movimientos de Almacen - Script 7 de 8: procedimiento de registro / anulacion
-- =====================================================================================
-- Un solo procedimiento y UNA sola transaccion para cabecera + detalle:
--
-- @opcion = 1  Registrar. La cabecera llega por parametros y el detalle completo en
--              @Detalle (tipo tabla dbo.MovimientoAlmacenDetTipo). Si algo falla, no
--              queda nada grabado.
--                * @TipoMovimiento 'I' INGRESO: cada linea trae la referencia a la linea
--                  de guia despachada (gr*). El producto se toma de la guia. La cantidad
--                  no puede superar lo despachado menos lo ya ingresado de esa linea, y la
--                  fecha del ingreso no puede ser anterior a la de la guia.
--                * @TipoMovimiento 'S' SALIDA: cada linea trae el producto (cod*). Solo
--                  puede salir el stock ingresado a ese almacen: el saldo del almacen no
--                  puede quedar negativo en ninguna fecha.
-- @opcion = 2  Anular (no se borra nada; queda la trazabilidad de quien y por que).
--                * Anular un ingreso: el saldo del almacen no puede quedar negativo (si ya
--                  salio ese stock, primero se anula la salida).
--
-- Los registros se serializan con sp_getapplock para que dos usuarios no consuman el
-- mismo stock / la misma linea de guia al mismo tiempo.
--
-- Respuesta: idResponse (id del movimiento o 0), messageResponse, typeMessage.
--
-- Requiere el script 5 y dbo.fnPeriodoBloqueado (scripts de Cierre de Periodo).
-- =====================================================================================

SET NOCOUNT ON;
GO

CREATE OR ALTER PROCEDURE dbo.uspSetMovimientoAlmacen
	@opcion				int,
	@IdMovimiento		int				= NULL,	-- opcion 2
	@TipoMovimiento		char(1)			= NULL,	-- opcion 1: 'I' ingreso / 'S' salida
	@FechaMovimiento	date			= NULL,	-- opcion 1
	@CodAlmacen			varchar(3)		= NULL,	-- opcion 1
	@Observacion		varchar(500)	= NULL,	-- opcion 1
	@MotivoAnulacion	varchar(250)	= NULL,	-- opcion 2
	@IdUsuario			int,
	@Detalle			dbo.MovimientoAlmacenDetTipo READONLY	-- opcion 1
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @Hoy date = CAST(GETDATE() AS date);
	DECLARE @msg varchar(2000);
	DECLARE @lock int;
	DECLARE @Tipo char(1);
	DECLARE @Almacen varchar(3);

	-- productos cuyo saldo en el almacen debe validarse despues de grabar
	DECLARE @Chequeo TABLE (
		codNivel	char(2)		NOT NULL,
		codGrupo	char(5)		NOT NULL,
		codTalla	char(3)		NOT NULL,
		codColor	char(6)		NOT NULL,
		PRIMARY KEY (codNivel, codGrupo, codTalla, codColor)
	);

	-- detalle final a grabar (producto resuelto)
	DECLARE @DetalleFinal TABLE (
		Linea			int IDENTITY(1,1),
		codNivel		char(2),
		codGrupo		char(5),
		codTalla		char(3),
		codColor		char(6),
		Cantidad		decimal(12,3),
		Comentario		varchar(250),
		grIdEmpresa		int,
		grSerie			varchar(50),
		grNumero		varchar(50),
		grDestCodigoPC	varchar(100),
		grSecuencia		int,
		grTipoOrden		char(1)
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
			SET @TipoMovimiento = NULLIF(LTRIM(RTRIM(@TipoMovimiento)), '');
			SET @CodAlmacen     = NULLIF(LTRIM(RTRIM(@CodAlmacen)), '');
			SET @Observacion    = NULLIF(LTRIM(RTRIM(@Observacion)), '');
			SET @Tipo = @TipoMovimiento;
			SET @Almacen = @CodAlmacen;

			-- ---- validaciones de cabecera ---------------------------------------
			IF @TipoMovimiento IS NULL OR @TipoMovimiento NOT IN ('I', 'S')
				SET @msg = 'Tipo de movimiento no valido.';
			ELSE IF @FechaMovimiento IS NULL
				SET @msg = 'Ingrese la fecha del movimiento.';
			ELSE IF @FechaMovimiento > @Hoy
				SET @msg = 'La fecha del movimiento no puede ser posterior a hoy.';
			ELSE IF dbo.fnPeriodoBloqueado(@FechaMovimiento) = 1
				SET @msg = 'El periodo se encuentra cerrado. No se puede registrar documentos de este periodo.';
			ELSE IF @CodAlmacen IS NULL
				SET @msg = 'Seleccione el almacen.';
			ELSE IF NOT EXISTS (SELECT 1 FROM dbo.AreasAlmacen WHERE Codigo = @CodAlmacen AND lActivo = 1 AND Codigo <> '999')
				SET @msg = 'El almacen no existe o esta inactivo.';
			-- ---- validaciones de detalle ----------------------------------------
			ELSE IF NOT EXISTS (SELECT 1 FROM @Detalle)
				SET @msg = 'Agregue al menos una linea al detalle.';
			ELSE IF EXISTS (SELECT 1 FROM @Detalle WHERE Cantidad IS NULL OR Cantidad <= 0)
				SET @msg = 'Todas las cantidades deben ser mayores a cero.';
			-- ingreso: cada linea con su referencia de guia completa
			ELSE IF @TipoMovimiento = 'I' AND EXISTS (
				SELECT 1 FROM @Detalle
				WHERE grIdEmpresa IS NULL OR grSerie IS NULL OR grNumero IS NULL
					OR grDestCodigoPC IS NULL OR grSecuencia IS NULL OR grTipoOrden IS NULL)
				SET @msg = 'Cada linea del ingreso debe provenir de una guia despachada.';
			ELSE IF @TipoMovimiento = 'I' AND EXISTS (
				SELECT 1 FROM @Detalle
				GROUP BY grIdEmpresa, grSerie, grNumero, grDestCodigoPC, grSecuencia, grTipoOrden
				HAVING COUNT(*) > 1)
				SET @msg = 'Hay lineas de guia repetidas en el detalle.';
			-- salida: cada linea con su producto
			ELSE IF @TipoMovimiento = 'S' AND EXISTS (
				SELECT 1 FROM @Detalle
				WHERE codNivel IS NULL OR codGrupo IS NULL OR codTalla IS NULL OR codColor IS NULL)
				SET @msg = 'Cada linea de la salida debe indicar el producto.';
			ELSE IF @TipoMovimiento = 'S' AND EXISTS (
				SELECT 1 FROM @Detalle GROUP BY codNivel, codGrupo, codTalla, codColor HAVING COUNT(*) > 1)
				SET @msg = 'Hay productos repetidos en el detalle.';

			IF @msg IS NOT NULL
			BEGIN
				SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			BEGIN TRANSACTION;

			-- un registro / anulacion a la vez (lo pendiente de cada guia y el stock dependen
			-- de lo que se graba)
			EXEC @lock = sp_getapplock @Resource = 'MovimientoAlmacen', @LockMode = 'Exclusive',
									   @LockOwner = 'Transaction', @LockTimeout = 30000;
			IF @lock < 0
			BEGIN
				ROLLBACK TRANSACTION;
				SELECT 0 AS idResponse, 'El sistema esta ocupado registrando otro movimiento. Intente nuevamente.' AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			IF @TipoMovimiento = 'I'
			BEGIN
				-- ---- ingreso: producto, pendiente y fecha desde la guia -----------
				INSERT INTO @DetalleFinal (codNivel, codGrupo, codTalla, codColor, Cantidad, Comentario,
										   grIdEmpresa, grSerie, grNumero, grDestCodigoPC, grSecuencia, grTipoOrden)
				SELECT	g.codNivel, g.codGrupo, g.codTalla, g.codColor, d.Cantidad, NULLIF(LTRIM(RTRIM(d.Comentario)), ''),
						d.grIdEmpresa, d.grSerie, d.grNumero, d.grDestCodigoPC, d.grSecuencia, d.grTipoOrden
				FROM @Detalle d
				LEFT JOIN dbo.ufnGuiaDespachoAlmacen() g ON g.grIdEmpresa = d.grIdEmpresa
														AND g.grSerie = d.grSerie
														AND g.grNumero = d.grNumero
														AND g.grDestCodigoPC = d.grDestCodigoPC
														AND g.grSecuencia = d.grSecuencia
														AND g.grTipoOrden = d.grTipoOrden;

				SELECT @msg = 'Estas lineas ya no existen en las guias o no son un despacho: '
							+ STRING_AGG(CONVERT(varchar(max), RTRIM(grSerie) + '-' + RTRIM(grNumero) + ' item ' + CAST(grSecuencia AS varchar(10))), ', ')
				FROM @DetalleFinal
				WHERE codNivel IS NULL
				HAVING COUNT(*) > 0;

				IF @msg IS NULL
					SELECT @msg = 'La fecha del ingreso (' + CONVERT(varchar(10), @FechaMovimiento, 103) + ') no puede ser anterior a la guia: '
								+ STRING_AGG(CONVERT(varchar(max), x.Guia + ' del ' + CONVERT(varchar(10), x.FechaGuia, 103)), ', ')
					FROM (
						SELECT DISTINCT RTRIM(g.grSerie) + '-' + RTRIM(g.grNumero) AS Guia, g.FechaGuia
						FROM @DetalleFinal d
						INNER JOIN dbo.ufnGuiaDespachoAlmacen() g ON g.grIdEmpresa = d.grIdEmpresa
																AND g.grSerie = d.grSerie
																AND g.grNumero = d.grNumero
																AND g.grDestCodigoPC = d.grDestCodigoPC
																AND g.grSecuencia = d.grSecuencia
																AND g.grTipoOrden = d.grTipoOrden
						WHERE g.FechaGuia > @FechaMovimiento
					) x
					HAVING COUNT(*) > 0;

				IF @msg IS NULL
					SELECT @msg = 'La cantidad supera lo pendiente de ingresar de la guia: '
								+ STRING_AGG(CONVERT(varchar(max), x.Texto), '; ')
					FROM (
						SELECT TOP (10)
								RTRIM(d.grSerie) + '-' + RTRIM(d.grNumero) + ' ' + d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor
								+ ' (pendiente ' + CONVERT(varchar(30), g.Pendiente) + ', solicitado ' + CONVERT(varchar(30), d.Cantidad) + ')' AS Texto
						FROM @DetalleFinal d
						INNER JOIN dbo.ufnGuiaDespachoAlmacen() g ON g.grIdEmpresa = d.grIdEmpresa
																AND g.grSerie = d.grSerie
																AND g.grNumero = d.grNumero
																AND g.grDestCodigoPC = d.grDestCodigoPC
																AND g.grSecuencia = d.grSecuencia
																AND g.grTipoOrden = d.grTipoOrden
						WHERE d.Cantidad > g.Pendiente
						ORDER BY d.Linea
					) x
					HAVING COUNT(*) > 0;
			END
			ELSE
			BEGIN
				-- ---- salida: producto tal cual, el stock se valida despues --------
				INSERT INTO @DetalleFinal (codNivel, codGrupo, codTalla, codColor, Cantidad, Comentario)
				SELECT d.codNivel, d.codGrupo, d.codTalla, d.codColor, d.Cantidad, NULLIF(LTRIM(RTRIM(d.Comentario)), '')
				FROM @Detalle d;

				SELECT @msg = 'Hay productos que no existen en el catalogo: '
							+ STRING_AGG(CONVERT(varchar(max), d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor), ', ')
				FROM @DetalleFinal d
				WHERE NOT EXISTS (SELECT 1 FROM dbo.productoServicios p
								  WHERE p.codNivel = d.codNivel AND p.codGrupo = d.codGrupo
									AND p.codTalla = d.codTalla AND p.codColor = d.codColor)
				HAVING COUNT(*) > 0;

				-- se valida el saldo de estos productos despues de grabar
				INSERT INTO @Chequeo (codNivel, codGrupo, codTalla, codColor)
				SELECT DISTINCT codNivel, codGrupo, codTalla, codColor FROM @DetalleFinal;
			END

			IF @msg IS NOT NULL
			BEGIN
				ROLLBACK TRANSACTION;
				SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			-- ---- grabacion: cabecera + detalle ----------------------------------
			INSERT INTO dbo.MovimientoAlmacenCab
				(TipoMovimiento, FechaMovimiento, CodAlmacen, Observacion, Estado, IdUsuarioRegistro, FechaRegistro)
			VALUES
				(@TipoMovimiento, @FechaMovimiento, @CodAlmacen, @Observacion, 'A', @IdUsuario, GETDATE());

			SET @IdMovimiento = SCOPE_IDENTITY();

			INSERT INTO dbo.MovimientoAlmacenDet
				(IdMovimiento, codNivel, codGrupo, codTalla, codColor, Cantidad, Comentario,
				 grIdEmpresa, grSerie, grNumero, grDestCodigoPC, grSecuencia, grTipoOrden)
			SELECT	@IdMovimiento, codNivel, codGrupo, codTalla, codColor, Cantidad, Comentario,
					grIdEmpresa, grSerie, grNumero, grDestCodigoPC, grSecuencia, grTipoOrden
			FROM @DetalleFinal
			ORDER BY Linea;
		END

		-- =========================================================================
		-- 2) ANULAR
		-- =========================================================================
		ELSE IF @opcion = 2
		BEGIN
			DECLARE @Estado char(1), @Fecha date;

			SELECT	@Estado = Estado, @Fecha = FechaMovimiento, @Tipo = TipoMovimiento, @Almacen = CodAlmacen
			FROM dbo.MovimientoAlmacenCab
			WHERE IdMovimiento = @IdMovimiento;

			SET @MotivoAnulacion = NULLIF(LTRIM(RTRIM(@MotivoAnulacion)), '');

			IF @Estado IS NULL
				SET @msg = 'El movimiento no existe.';
			ELSE IF @Estado = 'N'
				SET @msg = 'El movimiento ya se encuentra anulado.';
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

			EXEC @lock = sp_getapplock @Resource = 'MovimientoAlmacen', @LockMode = 'Exclusive',
									   @LockOwner = 'Transaction', @LockTimeout = 30000;
			IF @lock < 0
			BEGIN
				ROLLBACK TRANSACTION;
				SELECT 0 AS idResponse, 'El sistema esta ocupado registrando otro movimiento. Intente nuevamente.' AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END

			UPDATE dbo.MovimientoAlmacenCab
			SET		Estado = 'N',
					IdUsuarioAnulacion = @IdUsuario,
					FechaAnulacion = GETDATE(),
					MotivoAnulacion = @MotivoAnulacion
			WHERE IdMovimiento = @IdMovimiento
				AND Estado = 'A';

			-- anular un ingreso quita stock: se valida el saldo de sus productos
			IF @Tipo = 'I'
				INSERT INTO @Chequeo (codNivel, codGrupo, codTalla, codColor)
				SELECT DISTINCT codNivel, codGrupo, codTalla, codColor
				FROM dbo.MovimientoAlmacenDet
				WHERE IdMovimiento = @IdMovimiento;
		END
		ELSE
		BEGIN
			SELECT 0 AS idResponse, 'Opcion no valida.' AS messageResponse, 'ERROR' AS typeMessage;
			RETURN;
		END

		-- =========================================================================
		-- Validacion de stock despues de grabar (dentro de la transaccion):
		-- el saldo acumulado del almacen no puede ser negativo en ninguna fecha
		-- =========================================================================
		IF EXISTS (SELECT 1 FROM @Chequeo)
		BEGIN
			;WITH mov AS (
				SELECT	d.codNivel, d.codGrupo, d.codTalla, d.codColor,
						c.FechaMovimiento,
						SUM(CASE c.TipoMovimiento WHEN 'I' THEN d.Cantidad ELSE -d.Cantidad END) AS Cantidad
				FROM @Chequeo ch
				INNER JOIN dbo.MovimientoAlmacenDet d ON d.codNivel = ch.codNivel AND d.codGrupo = ch.codGrupo
													AND d.codTalla = ch.codTalla AND d.codColor = ch.codColor
				INNER JOIN dbo.MovimientoAlmacenCab c ON c.IdMovimiento = d.IdMovimiento
													AND c.Estado = 'A'
													AND c.CodAlmacen = @Almacen
				GROUP BY d.codNivel, d.codGrupo, d.codTalla, d.codColor, c.FechaMovimiento
			),
			saldo AS (
				SELECT	*,
						SUM(Cantidad) OVER (PARTITION BY codNivel, codGrupo, codTalla, codColor
											ORDER BY FechaMovimiento ROWS UNBOUNDED PRECEDING) AS Saldo
				FROM mov
			),
			errores AS (
				SELECT	codNivel + '.' + codGrupo + '.' + codTalla + '.' + codColor AS Codigo,
						CAST(-MIN(Saldo) AS decimal(18,3)) AS Faltante,
						MIN(CASE WHEN Saldo < 0 THEN FechaMovimiento END) AS FechaNegativo
				FROM saldo
				GROUP BY codNivel, codGrupo, codTalla, codColor
				HAVING MIN(Saldo) < 0
			)
			SELECT @msg = CASE WHEN @opcion = 1
							   THEN 'Stock insuficiente en el almacen (solo puede salir lo ingresado): '
							   ELSE 'No se puede anular: ese stock ya salio del almacen. Anule primero la salida. ' END
						+ STRING_AGG(CONVERT(varchar(max), x.Codigo + ' (faltan ' + CONVERT(varchar(30), x.Faltante) + ' al ' + CONVERT(varchar(10), x.FechaNegativo, 103) + ')'), '; ')
			FROM (SELECT TOP (10) * FROM errores ORDER BY Codigo) x
			HAVING COUNT(*) > 0;

			IF @msg IS NOT NULL
			BEGIN
				ROLLBACK TRANSACTION;
				SELECT 0 AS idResponse, @msg AS messageResponse, 'WARNING' AS typeMessage;
				RETURN;
			END
		END

		COMMIT TRANSACTION;

		SELECT	@IdMovimiento AS idResponse,
				CASE @Tipo WHEN 'I' THEN 'Ingreso' ELSE 'Salida' END
				+ ' N° ' + RIGHT('000000' + CAST(@IdMovimiento AS varchar(10)), 6)
				+ CASE WHEN @opcion = 1 THEN ' registrad' ELSE ' anulad' END
				+ CASE @Tipo WHEN 'I' THEN 'o' ELSE 'a' END + ' correctamente.' AS messageResponse,
				'INFORMATION' AS typeMessage;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		SELECT 0 AS idResponse, CAST(ERROR_MESSAGE() AS varchar(2000)) AS messageResponse, 'ERROR' AS typeMessage;
	END CATCH
END
GO
