-- =====================================================================================
-- Cierre de Periodo - Script 08: uspSetGRCabecera / uspSetGRDetalle
-- =====================================================================================
-- uspSetGRCabecera: opciones 1 Insertar/Actualizar (fecha nueva y guardada) y 2 Eliminar.
-- No se bloquean la 3 (validar cuenta) ni la 4 (respuesta de SUNAT).
-- uspSetGRDetalle: opciones 1 Insertar/Actualizar y 2 Eliminar, con la fecha de la cabecera.
--
-- Requiere los scripts 1 (fnPeriodoCerrado) y 2 (fnPeriodoBloqueado).
-- El cuerpo de cada procedimiento es el vigente en la base (copia de produccion); el
-- unico cambio es el bloque "Cierre de periodo" antes de "begin transaction".
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER PROCEDURE [dbo].[uspSetGRCabecera]
	@opcion					int,
		
	@idEmpresa				int,
	@serie					char(4),
	@numero					char(10),
	@fechaEmision			varchar(8),
	@puntoPartida			varchar(max),
	@puntoLlegada			varchar(max),
	@fechaInicioTraslado	varchar(8),
	@destCodigoPC			char(15),
	@transCodigoPC			char(15),

	@transMarca				varchar(100),
	@transNumPlaca			varchar(100),
	@transNumConstInscr		varchar(100),
	@transNumLicConducir	varchar(100),
	@codTipoCpte			char(2),
	@numCptePago			varchar(20),
	@usuarioReg				varchar(30),
	@voucher				int,
	@tipoOrden				char(1),
	@codCuenta				varchar(10),

	-- AGREGADOS
	@idMotivoTraslado		int = null,
	@observaciones			varchar(500) = null,
	@enviadosunat				bit = 0,
	@respuestasunat			varchar(500) = null,
	@otrosmotivotraslado	varchar(500) = null,
	@codTipoTransporte		char(2) = '01',

	@CodigoNivel			varchar(10) = null,
	@IdMovimientoCabecera	int = null,
	@JsonDetalle			nvarchar(max) = null,
	@IdUsuario				int = null,

	@PesoBruto				float = null,
	@NumeroBultos			float = null

as
set nocount on
begin
	begin try
	
		declare @idResponse int;
		declare @messageResponse varchar(250);
		declare @typeMessage varchar(250);
		declare @idOCGenerado int;
		declare @cuo varchar(50);
		declare @peri varchar(50);
		declare @v_IdUsuario int = (/*select id from usuarios where usuario = @usuarioReg*/@IdUsuario)
		declare @v_Id int;
		declare @v_fechaEmision date

		select @idResponse = 0;
		select @messageResponse = 'No procesado';
		select @typeMessage = 'ERROR';

		create table #tmpMov(
			IdMovimientoCabecera		int
		)

		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		declare @fechaEmisionNueva date = case when @opcion in (1) then try_convert(date, nullif(@fechaEmision, ''), 112) end;

		if (@opcion in (1, 2)
			and (dbo.fnPeriodoBloqueado(@fechaEmisionNueva) = 1
				or exists (select 1 from grCab where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and tipoOrden = @tipoOrden and destCodigoPC = @destCodigoPC and dbo.fnPeriodoBloqueado(fechaEmision) = 1)))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar / Actualizar
		begin
			if exists (
					select 
						1
					from grCab 
					where idEmpresa = @idEmpresa and 
					serie = @serie and numero = @numero 
					and tipoOrden = @tipoOrden
					and destCodigoPC = @destCodigoPC
			)
			begin
				
				update grCab set
					fechaEmision = case when isnull(@fechaEmision,'') = '' then null else cast(@fechaEmision as date) end,
					puntoPartida = @puntoPartida,
					puntoLlegada = @puntoLlegada,
					fechaInicioTraslado = case when isnull(@fechaInicioTraslado,'') = '' then null else cast(@fechaInicioTraslado as date) end,
					destCodigoPC = @destCodigoPC,
					transCodigoPC = @transCodigoPC,
					transMarca = @transMarca,
					transNumPlaca = @transNumPlaca,
					transNumConstInscr = @transNumConstInscr,
					transNumLicConducir = @transNumLicConducir,
					codTipoCpte = @codTipoCpte,
					numCptePago = @numCptePago,
					usuarioReg = @usuarioReg,
					fechaReg = getdate(),
					voucher = @voucher,
					tipoOrden = @tipoOrden,
					idMotivoTraslado = @idMotivoTraslado,
					observaciones = @observaciones,
					otrosmotivotraslado = @otrosmotivotraslado,
					codTipoTransporte = @codTipoTransporte,
					PesoBruto = @PesoBruto,
					NumeroBultos = @NumeroBultos
				where	idEmpresa = @idEmpresa
					and serie = @serie
					and	numero = @numero
					and tipoOrden = @tipoOrden
					and destCodigoPC = @destCodigoPC
			end
			else
			begin

	 

			set @cuo= (select dbo.obtener_CUO(LEFT(@fechaEmision, 4) + '-' + SUBSTRING(@fechaEmision, 5, 2)))


				insert into grCab (idEmpresa,				
									serie,
									numero,
									fechaEmision,
									puntoPartida,
									puntoLlegada,
									fechaInicioTraslado,
									destCodigoPC,
									transCodigoPC,
									transMarca,
									transNumPlaca,
									transNumConstInscr,
									transNumLicConducir,
									codTipoCpte,
									numCptePago,
									usuarioReg,
									fechaReg,
									voucher,
									tipoOrden,
									idmotivotraslado,
									observaciones,
									otrosmotivotraslado,
									codTipoTransporte,
									cuo,
									Pesobruto,
									NumeroBultos
									)
					values	(@idEmpresa,
							 @serie,
							 @numero,
							 case when isnull(@fechaEmision,'') = '' then null else cast(@fechaEmision as date) end,
							 @puntoPartida,
							 @puntoLlegada,
							 case when isnull(@fechaInicioTraslado,'') = '' then null else cast(@fechaInicioTraslado as date) end,
							 @destCodigoPC,
							 @transCodigoPC,
							 @transMarca,
							 @transNumPlaca,
							 @transNumConstInscr,
							 @transNumLicConducir,
							 @codTipoCpte,
							 @numCptePago,
							 @usuarioReg,
							 getdate(),
							 @voucher,
							 @tipoOrden,
							 @idMotivoTraslado,
							 @observaciones,
							 @otrosmotivotraslado,
							 @codTipoTransporte,
							 @cuo,
							 @PesoBruto,
							 @NumeroBultos
							 );


			end

			-- INGRESO DE TELA POR COMPRA
			if @CodigoNivel = '03' and @idMotivoTraslado = 3
			begin

				SET @v_fechaEmision = cast(@fechaEmision as date)
				
				
				insert into #tmpMov
				exec [dbo].[uspSetMovimientosGeneral]
					@IdMovimientoCabecera		= @IdMovimientoCabecera,
					@IdTipoMovimiento			= 1,
					@FechaMovimiento			= @v_fechaEmision,
					@Comentario					= 'Ingreso automatico por guia de compra de tela',
					@IdUsuario					= @v_IdUsuario,
					@Estacion					= 'SQL',
					@JsonDetalle				= @JsonDetalle,
					@SerieGuia					= @serie,
					@NumeroGuia					= @numero,
					@CodigoProveedorGuia		= @destCodigoPC

			end


			-- DESPACHO DE TELA A CORTE PARA TRANSFORMACIÓN
			if @CodigoNivel = '03' and @idMotivoTraslado = 9
			begin

				SET @v_fechaEmision = cast(@fechaEmision as date)
			
				insert into #tmpMov
				exec [dbo].[uspSetMovimientosGeneral]
					@IdMovimientoCabecera		= @IdMovimientoCabecera,
					@IdTipoMovimiento			= 2,
					@FechaMovimiento			= @v_fechaEmision,
					@Comentario					= 'Salida automatica por guia de transformación a servicios de corte',
					@IdUsuario					= @v_IdUsuario,
					@Estacion					= 'SQL',
					@JsonDetalle				= @JsonDetalle,
					@SerieGuia					= @serie,
					@NumeroGuia					= @numero,
					@CodigoProveedorGuia		= @destCodigoPC

			end
			
			

			select	@idResponse = 1,
					@messageResponse = 'Guardado Correctamente',
					@typeMessage = 'INFORMATION',
					@v_Id = (select top 1 IdMovimientoCabecera from #tmpMov)

		end
		else if (@opcion = 2) -- Eliminar
		begin
			
			delete from grDet where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and tipoOrden = @tipoOrden
			and destCodigoPC = @destCodigoPC
			delete from	grCab where	idEmpresa = @idEmpresa and serie = @serie and numero = @numero and tipoOrden = @tipoOrden
			and destCodigoPC = @destCodigoPC
			
			select	@idResponse = 1,
					@messageResponse = 'Eliminado correctamente',
					@typeMessage = 'INFORMATION';

		end	
		else if (@opcion = 3) --Validar Cuena
		begin
			declare @exist INT = 0;
			set @exist = (select count(*) from dbo.cuentas where codCuenta=@codCuenta)
		
			if @exist > 0
				begin
					select	@idResponse = 1, @messageResponse = 'La cuenta contable existe',@typeMessage = 'INFORMATION';
				end
			else
				begin
					select	@idResponse = 0, @messageResponse = 'La cuenta contable no existe',@typeMessage = 'WARNING';
				end
		end

		-- ########################
		-- ### ACTUALIZAR SUNAT ###
		-- ########################

		if (@opcion = 4)
		begin
			
			--select * from grCabExportacion
			update grCab set
				enviadoSunat = @enviadosunat,
				respuestaSunat = @respuestasunat
			where	idEmpresa = @idEmpresa
			and serie = @serie
			and	numero = @numero
			--and ruc = @ruc; 

				select	@idResponse = 1,
					@messageResponse = 'Enviado Correctamente',
					@typeMessage = 'INFORMATION';

		end

		commit transaction procesarTransaccion

		select	@idResponse as idResponse,
				@messageResponse as messageResponse,
				@typeMessage as typeMessage,
				@v_Id as id;	

		drop table #tmpMov

	end try
	begin catch
		if @@trancount > 0
		begin
			rollback transaction procesarTransaccion
		end
		select	0 as idResponse,
				cast(error_message() as varchar) as messageResponse,
				'ERROR' as typeMessage
				
	end catch

end
GO

ALTER PROCEDURE [dbo].[uspSetGRDetalle]
	@opcion				int,
	
	@idEmpresa			int,
	@serie				VARchar(4),
	@numero				VARchar(10),
	@secuencia			int,
	@idEmpresaDet		int,
	@idDet				int,
	@idSecuenciaDet		int,
	
	@cantidadIngresada decimal(12,3),
	@pesoIngresado		decimal(18,4),
	@tipoMovimiento		char(1),

	@numeroPartida		varchar(50),

	@codCuenta			varchar(10),
	@tipoOrden			char(1),
	@OP					varchar(1000) = null,

	@IdPedidoColor					int = null,
	@PartidaProveedor				varchar(1000) = null,
	@destCodigoPC					varchar(100) = null,
	@Comentario						varchar(1000) = null,
	@precioGr						decimal (18,6) null 
as
set nocount on
begin
	begin try
	
		declare @idResponse int;
		declare @messageResponse varchar(250);
		declare @typeMessage varchar(250);
		declare @factura varchar(300);
		declare @nivel varchar(10);
		DECLARE @almacenDirecto varchar(10);


		declare @codigoProducto varchar(70);
		declare @monto float;
		declare @usuario varchar(100);
		declare @CORRE varchar(100);

		select @idResponse = 0;
		select @messageResponse = 'No procesado';
		select @typeMessage = 'ERROR';
		select @factura = '';

		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		if (@opcion in (1, 2)
			and exists (select 1 from grCab where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and (@destCodigoPC is null or destCodigoPC = @destCodigoPC) and dbo.fnPeriodoBloqueado(fechaEmision) = 1))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar / Actualizar.
		begin
			
			declare @v_rucosoc varchar(100) = ''

			if @tipoOrden = 'S'
			begin
				set @v_rucosoc = (select codigoPC from osCab where idOS = @idDet)
			end

			if @tipoOrden = 'C'
			begin
				set @v_rucosoc = (select codigoPC from ocCab where idOC = @idDet)
			end

			if not exists (
					select 
						1
					from grDet 
					where idEmpresa = @idEmpresa and serie = @serie 
					and numero = @numero and secuencia = @secuencia 
					and destCodigoPC = @destCodigoPC
				)
			begin
				
				

				insert into grDet (
					idEmpresa, serie, numero, secuencia, idEmpresaDet, idDet, idSecuenciaDet, cantidadIngresada, pesoIngresado, tipoMovimiento, numeroPartida,codCuenta, tipoOrden,Op,
					IdPedidoColor,	PartidaProveedor,destCodigoPC,Comentario,RucOsOc,PrecioGr
				)
				values (@idEmpresa,
						@serie,
						@numero,
						isnull((select MAX(secuencia) from grDet where tipoOrden = @tipoOrden and serie = @serie and numero = @numero),0) + 1,
						@idEmpresaDet,
						@idDet,
						@idSecuenciaDet,
						@cantidadIngresada,
						@pesoIngresado,
						@tipoMovimiento,
						@numeroPartida,
						@codCuenta,
						@tipoOrden,
						@OP,
						@IdPedidoColor,
						@PartidaProveedor,
						@destCodigoPC,
						@Comentario,
						@v_rucosoc,
						@precioGr
				);


				-- ORDEN DE COMPRA
				if (@tipoOrden = 'C')
					BEGIN
						set @codigoProducto = (SELECT CODNIVEL + '.' + CODGRUPO + '.' + CODTALLA + '.' + CODCOLOR FROM ocDet 
												where idOC = @idDet and secuencia = @idSecuenciaDet)
						set @monto = (SELECT cantidad * precioUnitario FROM ocDet 
										where idOC = @idDet and secuencia = @idSecuenciaDet)
						set @nivel = (SELECT CODNIVEL FROM ocDet where idOC = @idDet and secuencia = @idSecuenciaDet)
					END

				-- ORDEN DE SERVICIO
				if (@tipoOrden = 'S')
					BEGIN
						set @codigoProducto = (SELECT CODNIVEL + '.' + CODGRUPO + '.' + CODTALLA + '.' + CODCOLOR FROM oSDet 
												where idOS = @idDet and secuencia = @idSecuenciaDet)
						set @monto = (SELECT cantidad * precioUnitario FROM oSDet 
										where idOS = @idDet and secuencia = @idSecuenciaDet)
						set @nivel = (SELECT CODNIVEL FROM oSDet where idOS = @idDet and secuencia = @idSecuenciaDet)
					END

				set @almacenDirecto = '006'
			-- ORDEN DE SERVICIO
			-- P - ORDEN DE PRODUCCION
			-- E - ORDEN DE PEDIDO
				if (@tipoOrden = 'P' OR @tipoOrden = 'E')
					BEGIN
						set @codigoProducto = (SELECT CODNIVEL + '.' + CODGRUPO + '.' + CODTALLA + '.' + CODCOLOR FROM OrdenSalidaDet 
												where idOrdenSalida = @idDet and secuencia = @idSecuenciaDet)
						set @monto = (SELECT cantidad * precioUnitario FROM OrdenSalidaDet 
										where idOrdenSalida = @idDet and secuencia = @idSecuenciaDet)
						set @nivel = (SELECT CODNIVEL FROM OrdenSalidaDet where idOrdenSalida = @idDet and secuencia = @idSecuenciaDet)
						set @almacenDirecto = (SELECT idAlmacen FROM OrdenSalidaCab where idOrdenSalida = @idDet )
					END

				SET @usuario = (SELECT usuarioReg FROM grCab WHERE serie = @serie AND numero = @numero and tipoOrden = @tipoOrden and destCodigoPC =  @destCodigoPC)
				SET @CORRE = @serie + '-' + @numero
				
				if (select isnull(Activar_Transa_Kardex,0) from empresa) = 0
				begin
					-- SALIDA AL ALMACEN CENTRAL
					if @tipoMovimiento = 'S' AND @nivel <> 16 
						begin
							exec uspSet_MKARDEX @codigoProducto,'09','999',@CORRE , @cantidadIngresada, @monto,2,@usuario
						end

					-- INGRESOS AL ALMACEN CENTRAL
					else if @tipoMovimiento = 'E' AND @nivel <> 16 
						begin
						 -- set @cantidadIngresada = @cantidadIngresada * -1
							exec uspSet_MKARDEX @codigoProducto,'09','000',@CORRE , @cantidadIngresada , @monto,1,@usuario
						end

					--- INGRESOS AL ALMACEN DE APT
					else if @tipoMovimiento = 'E' AND @nivel = 16 
						begin
							exec uspSet_MSUBKARDEX @almacenDirecto,@codigoProducto,'09','999',@CORRE , @cantidadIngresada, @monto,1,@usuario
						end

					--- SALIDAS DEL ALMACEN DE APT
					else if @tipoMovimiento = 'S' AND @nivel = 16 
						begin
							exec uspSet_MSUBKARDEX @almacenDirecto,@codigoProducto,'09','999',@CORRE , @cantidadIngresada, @monto,2,@usuario
						end
				end
			end
			else
			begin
				update	grDet 
				set		idEmpresa = @idEmpresa,
						serie = @serie,
						numero = @numero,
						secuencia = @secuencia,
						idEmpresaDet = @idEmpresaDet,
						idDet = @idDet,
						idSecuenciaDet = @idSecuenciaDet,
						cantidadIngresada = @cantidadIngresada,
						pesoIngresado = @pesoIngresado,
						tipoMovimiento = @tipoMovimiento,
						numeroPartida = @numeroPartida,
						codCuenta = @codCuenta,
						tipoOrden = @tipoOrden,
						Op		= @OP,
						IdPedidoColor = @IdPedidoColor,
						PartidaProveedor = @PartidaProveedor,
						Comentario = @Comentario,
						RucOsOc = @v_rucosoc,
						PrecioGr = @precioGr
				where	idEmpresa = @idEmpresa
					and serie = @serie
					and numero = @numero
					and secuencia = @secuencia
					and destCodigoPC = @destCodigoPC

			end
			
			select	@idResponse = 1,
					@messageResponse = 'Se guardo correctamente',
					@typeMessage = 'INFORMATION';
		
		end
		else if (@opcion = 2) -- Eliminar
		begin
			if exists (select 1 
					 from facDet 
					 where grIdEmpresa = @idEmpresa 
						and grSerie = @serie
						and grNumero = @numero
						and grSecuencia = @secuencia
						and grTipoOrden = @tipoOrden)
			begin
				select @factura = d.codigoPC + ' | ' + serie + '-' + cast(numero as varchar)
				from facDet as d
				where	grIdEmpresa = @idEmpresa 
					and grSerie = @serie
					and grNumero = @numero
					and grSecuencia = @secuencia
					and grTipoOrden = @tipoOrden;

				select	@idResponse = 0,
						@messageResponse = 'Este Detalle tiene una factura asociada: ' + @factura,
						@typeMessage = 'INFORMATION';
			end
			else 
			begin
				delete from grDet 
				where	idEmpresa = @idEmpresa
					and serie = @serie
					and numero = @numero
					and secuencia = @secuencia
					and tipoOrden = @tipoOrden;

				select	@idResponse = 1,
						@messageResponse = 'Eliminado Correctamente',
						@typeMessage = 'INFORMATION';
			end
		end	
		
		commit transaction procesarTransaccion

		select	@idResponse as idResponse,
				@messageResponse as messageResponse,
				@typeMessage as typeMessage;	

	end try
	begin catch
		if @@trancount > 0
		begin
			rollback transaction procesarTransaccion
		end
		select	0 as idResponse,
				cast(error_message() as varchar) as messageResponse,
				'ERROR' as typeMessage;
	end catch

end
GO
