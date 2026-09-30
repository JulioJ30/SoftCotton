-- =====================================================================================
-- Cuadre de Kardex - Script 4 de 5: procedimiento de escritura / eliminacion
-- =====================================================================================
-- @opcion = 1 (Registrar): dado un producto REAL existente (@codNivel/@codGrupo/@codTalla/
--            @codColor), crea -si no existe todavia- una Orden de Compra placeholder que
--            ancla ese producto especifico (se reutiliza en cuadres futuros del mismo
--            producto), y siempre crea una Guia de Remision placeholder NUEVA (cabecera +
--            una linea) fechada en @fechaMovimiento -puede ser un periodo anterior a hoy-,
--            usando los procedimientos ya existentes uspSetOC, uspSetOCDetalle,
--            uspSetGRCabecera y uspSetGRDetalle (no se modifican). tipoAjuste 'E' = sumar
--            (entrada), 'S' = restar (salida). No usa el signo de la cantidad:
--            uspGetkardexPrincipal aplica ABS() a la cantidad y decide sumar/restar solo
--            por tipoMovimiento.
--
-- @opcion = 4 (Eliminar): dado un @idCuadre, elimina directamente la Guia de Remision
--            placeholder de ese cuadre (cabecera + linea, via uspSetGRCabecera opcion=2,
--            que ya existe y no se modifica) y el registro de CuadreKardex. No crea ningun
--            movimiento inverso: al recalcular el reporte, el efecto de ese cuadre
--            simplemente desaparece.
--
-- No modifica uspGetkardexPrincipal ni ningun otro procedimiento del calculo de Kardex.
-- =====================================================================================

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.uspSetCuadreKardex', 'P') IS NOT NULL
	DROP PROCEDURE dbo.uspSetCuadreKardex;
GO

CREATE PROCEDURE dbo.uspSetCuadreKardex
	@opcion			int,
	@codNivel		char(2)        = NULL,   -- requerido en opcion 1
	@codGrupo		char(5)        = NULL,   -- requerido en opcion 1
	@codTalla		char(3)        = NULL,   -- requerido en opcion 1
	@codColor		char(6)        = NULL,   -- requerido en opcion 1
	@tipoAjuste		char(1)        = NULL,   -- requerido en opcion 1: 'E' sumar / 'S' restar
	@cantidad		decimal(18,3)  = NULL,   -- requerido en opcion 1
	@fechaMovimiento varchar(8)    = NULL,   -- requerido en opcion 1, formato yyyymmdd (puede ser un periodo anterior)
	@idCuadre		int            = NULL,   -- requerido en opcion 4 (cuadre a eliminar)
	@usuarioReg		varchar(30)
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		DECLARE @idResponse int = 0;
		DECLARE @messageResponse varchar(250) = 'No procesado';
		DECLARE @typeMessage varchar(250) = 'ERROR';

		DECLARE @idEmpresa int = 1;
		DECLARE @idOC int;
		DECLARE @secOC int;
		DECLARE @numeroGR char(10);
		DECLARE @secuenciaGenerada int;

		BEGIN TRANSACTION trCuadreKardex;

		IF (@opcion = 1) -- Registrar
		BEGIN
			IF @codNivel IS NULL OR @codGrupo IS NULL OR @codTalla IS NULL OR @codColor IS NULL
				OR @tipoAjuste NOT IN ('E','S') OR @cantidad IS NULL OR @cantidad <= 0 OR ISNULL(@fechaMovimiento,'') = ''
			BEGIN
				SELECT @idResponse = 0, @messageResponse = 'Datos incompletos para registrar el cuadre', @typeMessage = 'WARNING';
			END
			ELSE IF NOT EXISTS (SELECT 1 FROM dbo.productoServicios WHERE codNivel = @codNivel AND codGrupo = @codGrupo AND codTalla = @codTalla AND codColor = @codColor)
			BEGIN
				SELECT @idResponse = 0, @messageResponse = 'El producto ingresado no existe en el catalogo (nivel/grupo/talla/color)', @typeMessage = 'ERROR';
			END
			ELSE
			BEGIN
				-- Ancla de Orden de Compra placeholder para este producto exacto: se crea la primera vez, se reutiliza despues
				SELECT TOP 1 @idOC = od.idOC, @secOC = od.secuencia
				FROM dbo.ocDet od
				INNER JOIN dbo.ocCab oc ON oc.idEmpresa = od.idEmpresa AND oc.idOC = od.idOC
				WHERE oc.codigoPC = 'AJUSTE' AND od.codNivel = @codNivel AND od.codGrupo = @codGrupo
					AND od.codTalla = @codTalla AND od.codColor = @codColor;

				IF @idOC IS NULL
				BEGIN
					DECLARE @respOC TABLE (idResponse int, messageResponse varchar(250), typeMessage varchar(250));
					DECLARE @observacionOC varchar(350) = 'Ancla de Cuadre de Kardex para ' + @codNivel + '.' + @codGrupo + '.' + @codTalla + '.' + @codColor + ' - no es un documento real';

					INSERT INTO @respOC
					EXEC dbo.uspSetOC
						@opcion				= 1,
						@idEmpresa			= @idEmpresa,
						@idOC				= 0,
						@fechaEmision		= @fechaMovimiento,
						@fechaEntrega		= @fechaMovimiento,
						@codigoPC			= 'AJUSTE',
						@idTipoMoneda		= 1,
						@tipoCompra			= NULL,
						@idCondPago			= NULL,
						@idTipoAprobacion	= NULL,
						@idTipoAnulado		= NULL,
						@fechaAnulado		= NULL,
						@usuarioAnulado		= NULL,
						@usuarioRegistro	= @usuarioReg,
						@observacion		= @observacionOC,
						@codPrograma		= NULL,
						@codServicio		= NULL;

					SELECT @idOC = idResponse FROM @respOC;

					EXEC dbo.uspSetOCDetalle
						@opcion			= 1,
						@idEmpresa		= @idEmpresa,
						@idOC			= @idOC,
						@secuencia		= 0,
						@codNivel		= @codNivel,
						@codGrupo		= @codGrupo,
						@codTalla		= @codTalla,
						@codColor		= @codColor,
						@cantidad		= 999999999,
						@igv			= 0,
						@precioUnitario	= 1,
						@obs1			= 'AJUSTE KARDEX',
						@obs2			= NULL,
						@obs3			= NULL,
						@obs4			= NULL,
						@obs5			= NULL;

					SET @secOC = 1;
				END

				SELECT @numeroGR = RIGHT('0000000000' + CAST(ISNULL(MAX(TRY_CAST(numero AS INT)), 0) + 1 AS varchar(10)), 10)
				FROM dbo.grCab
				WHERE idEmpresa = @idEmpresa AND serie = 'AJUS';

				EXEC dbo.uspSetGRCabecera
					@opcion					= 1,
					@idEmpresa				= @idEmpresa,
					@serie					= 'AJUS',
					@numero					= @numeroGR,
					@fechaEmision			= @fechaMovimiento,
					@puntoPartida			= NULL,
					@puntoLlegada			= NULL,
					@fechaInicioTraslado	= NULL,
					@destCodigoPC			= 'AJUSTE',
					@transCodigoPC			= NULL,
					@transMarca				= NULL,
					@transNumPlaca			= NULL,
					@transNumConstInscr		= NULL,
					@transNumLicConducir	= NULL,
					@codTipoCpte			= '00',
					@numCptePago			= '',
					@usuarioReg				= @usuarioReg,
					@voucher				= 0,
					@tipoOrden				= 'C',
					@codCuenta				= 'AJUSTE',
					@idMotivoTraslado		= NULL,
					@observaciones			= 'Cuadre de Kardex - no es un despacho real';

				EXEC dbo.uspSetGRDetalle
					@opcion				= 1,
					@idEmpresa			= @idEmpresa,
					@serie				= 'AJUS',
					@numero				= @numeroGR,
					@secuencia			= 0,
					@idEmpresaDet		= @idEmpresa,
					@idDet				= @idOC,
					@idSecuenciaDet		= @secOC,
					@cantidadIngresada	= @cantidad,
					@pesoIngresado		= 0,
					@tipoMovimiento		= @tipoAjuste,
					@numeroPartida		= '',
					@codCuenta			= 'AJUSTE',
					@tipoOrden			= 'C',
					@destCodigoPC		= 'AJUSTE',
					@Comentario			= 'Cuadre de Kardex',
					@precioGr			= 1;

				SELECT @secuenciaGenerada = MAX(secuencia)
				FROM dbo.grDet
				WHERE idEmpresa = @idEmpresa AND serie = 'AJUS' AND numero = @numeroGR
					AND tipoOrden = 'C' AND destCodigoPC = 'AJUSTE';

				INSERT INTO dbo.CuadreKardex (codNivel, codGrupo, codTalla, codColor, tipoAjuste, cantidad, fechaMovimiento, idEmpresa, serieGR, numeroGR, secuenciaGR, usuarioReg, fechaReg)
				VALUES (@codNivel, @codGrupo, @codTalla, @codColor, @tipoAjuste, @cantidad, CONVERT(date, @fechaMovimiento, 112), @idEmpresa, 'AJUS', @numeroGR, @secuenciaGenerada, @usuarioReg, GETDATE());

				SELECT @idResponse = 1, @messageResponse = 'Cuadre registrado correctamente', @typeMessage = 'INFORMATION';
			END
		END
		ELSE IF (@opcion = 4) -- Eliminar
		BEGIN
			DECLARE @delIdEmpresa int, @delSerie varchar(4), @delNumero varchar(10);

			SELECT @delIdEmpresa = idEmpresa, @delSerie = serieGR, @delNumero = numeroGR
			FROM dbo.CuadreKardex
			WHERE idCuadre = @idCuadre;

			IF @delSerie IS NULL
			BEGIN
				SELECT @idResponse = 0, @messageResponse = 'El cuadre indicado no existe', @typeMessage = 'ERROR';
			END
			ELSE
			BEGIN
				EXEC dbo.uspSetGRCabecera
					@opcion					= 2,
					@idEmpresa				= @delIdEmpresa,
					@serie					= @delSerie,
					@numero					= @delNumero,
					@fechaEmision			= NULL,
					@puntoPartida			= NULL,
					@puntoLlegada			= NULL,
					@fechaInicioTraslado	= NULL,
					@destCodigoPC			= 'AJUSTE',
					@transCodigoPC			= NULL,
					@transMarca				= NULL,
					@transNumPlaca			= NULL,
					@transNumConstInscr		= NULL,
					@transNumLicConducir	= NULL,
					@codTipoCpte			= '00',
					@numCptePago			= '',
					@usuarioReg				= @usuarioReg,
					@voucher				= 0,
					@tipoOrden				= 'C',
					@codCuenta				= 'AJUSTE';

				DELETE FROM dbo.CuadreKardex WHERE idCuadre = @idCuadre;

				SELECT @idResponse = 1, @messageResponse = 'Cuadre eliminado correctamente', @typeMessage = 'INFORMATION';
			END
		END

		COMMIT TRANSACTION trCuadreKardex;

		SELECT @idResponse AS idResponse, @messageResponse AS messageResponse, @typeMessage AS typeMessage;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION trCuadreKardex;

		SELECT 0 AS idResponse, CAST(ERROR_MESSAGE() AS varchar(250)) AS messageResponse, 'ERROR' AS typeMessage;
	END CATCH
END
GO
