-- =====================================================================================
-- Cierre de Periodo - Script 09: uspSetGRCabeceraExportacion / uspSetGRDetalleExportacion
-- =====================================================================================
-- uspSetGRCabeceraExportacion: opciones 1 Insertar/Actualizar y 2 Eliminar. No se bloquea la 3
-- (respuesta de SUNAT).
-- uspSetGRDetalleExportacion: opciones 1 Insertar/Actualizar y 2 Eliminar, con la fecha de la cabecera.
--
-- Requiere los scripts 1 (fnPeriodoCerrado) y 2 (fnPeriodoBloqueado).
-- El cuerpo de cada procedimiento es el vigente en la base (copia de produccion); el
-- unico cambio es el bloque "Cierre de periodo" antes de "begin transaction".
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER PROCEDURE [dbo].[uspSetGRCabeceraExportacion]
	@opcion					int,
	@idEmpresa				int = null,
	@serie					char(4) = null,
	@numero					char(10) = null,
	@ruc					varchar(20) = null,	
	@fechaEmision			varchar(8) = null,
	@puntoPartida			varchar(max) = null,
	@puntoLlegada			varchar(max) = null,
	@fechaInicioTraslado	varchar(8) = null,
	@destCodigoPC			char(15) = null,
	@transCodigoPC			char(15) = null,
	@transMarca				varchar(100) = null,
	@transNumPlaca			varchar(100) = null,
	@transNumConstInscr		varchar(100) = null,
	@transNumLicConducir	varchar(100) = null,
	@usuarioReg				varchar(30) = null,

	@idnumerolicenciaconducir		int = null,
	@idconstanciainscripcion		int = null,

	@idMotivoTraslado		int = null,

	@numero_contenedor varchar(50) = null,
	@precinto_aduana varchar(50) = null,
	@precinto_linea varchar(50) = null,
	@precinto varchar(250) = null,

	@total decimal(7,2) = null,
	@gross_weight decimal(7,2) = null,
	@net_weight decimal(7,2) = null,

	@total_um char(3) = null,
	@gross_weight_um char(3) = null,
	@net_weight_um char(3) = null,
	
	-- AGREGADOS 
	@observaciones			varchar(500) = null,
	@fechavencimiento		date = null,
	@enviadosunat				bit = 0,
	@respuestasunat			varchar(500) = null,
	@otrosmotivotraslado	varchar(500) = null,
	@damds					varchar(1000) = null,
	@FacturaReferencia		varchar(1000) = null,
	@NumeroBultos			float = null
	
as
set nocount on
begin
	begin try
		declare @idResponse int;
		declare @messageResponse varchar(250);
		declare @typeMessage varchar(250);
		declare @idOCGenerado int;

		select @idResponse = 0;
		select @messageResponse = 'No procesado';
		select @typeMessage = 'ERROR';

		--select * from grCabExportacion
		
		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		declare @fechaEmisionNueva date = case when @opcion in (1) then try_convert(date, nullif(@fechaEmision, ''), 112) end;

		if (@opcion in (1, 2)
			and (dbo.fnPeriodoBloqueado(@fechaEmisionNueva) = 1
				or exists (select 1 from grCabExportacion where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and ruc = @ruc and dbo.fnPeriodoBloqueado(fechaEmision) = 1)))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion


		-- #############################
		-- ### INSERTAR / ACTUALIZAR ###
		-- #############################
		if (@opcion = 1) -- Insertar / Actualizar
		begin
			if exists (select 1 from grCabExportacion where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and ruc = @ruc)
			begin
				update grCabExportacion set
					fechaEmision = case when isnull(@fechaEmision,'') = '' then null else cast(@fechaEmision as date) end,
					puntoPartida = @puntoPartida,
					puntoLlegada = @puntoLlegada,
					fechaInicioTraslado = case when isnull(@fechaInicioTraslado,'') = '' then null else cast(@fechaInicioTraslado as date) end,
					destCodigoPC = @destCodigoPC,
					transCodigoPC = @transCodigoPC,
					transMarca = @transMarca,
					transNumPlaca = @transNumPlaca,


					--transNumConstInscr = @transNumConstInscr,
					--transNumLicConducir = @transNumLicConducir,

					idNumeroLicenciaConducir	=	@idnumerolicenciaconducir,
					idConstanciaInscripcion		=	@idconstanciainscripcion,
					
					--codTipoCpte = @codTipoCpte,
					--numCptePago = @numCptePago,
					usuarioReg = @usuarioReg,
					fechaReg = getdate(),
					--,
					--voucher = @voucher,
					--tipoOrden = @tipoOrden

					idMotivoTraslado = @idMotivoTraslado,

					numero_contenedor = @numero_contenedor,
					precinto_aduana = @precinto_aduana,
					precinto_linea = @precinto_linea,
					precinto = @precinto,

					total =	@total,
					gross_weight = @gross_weight,
					net_weight = @net_weight,

					total_um = @total_um,
					gross_weight_um = @gross_weight_um,
					net_weight_um = @net_weight_um,
					fechaVencimiento = @fechavencimiento,
					observaciones = @observaciones,
					otrosMotivoTraslado =  @otrosmotivotraslado,
					DamDs =  @damds,
					FacturaReferencia = @FacturaReferencia,
					NumeroBultos = @NumeroBultos

				where	idEmpresa = @idEmpresa
					and serie = @serie
					and	numero = @numero
					and ruc = @ruc; 
			end
			else
			begin
				insert into grCabExportacion (
									idEmpresa,				
									serie,
									numero,
									ruc,
									fechaEmision,
									puntoPartida,
									puntoLlegada,
									fechaInicioTraslado,
									destCodigoPC,
									transCodigoPC,
									transMarca,
									transNumPlaca,
									idNumeroLicenciaConducir,
									idConstanciaInscripcion,
									usuarioReg,
									fechaReg,
									idMotivoTraslado,
									numero_contenedor,
									precinto_aduana,
									precinto_linea,
									precinto,
									total,
									gross_weight,
									net_weight,
									total_um,
									gross_weight_um,
									net_weight_um,
									fechaVencimiento,
									observaciones,
									otrosMotivoTraslado,
									DamDs,
									FacturaReferencia,
									NumeroBultos
								)

					values	(@idEmpresa,
							 @serie,
							 @numero,
							 @ruc,
							 case when isnull(@fechaEmision,'') = '' then null else cast(@fechaEmision as date) end,
							 @puntoPartida,
							 @puntoLlegada,
							 case when isnull(@fechaInicioTraslado,'') = '' then null else cast(@fechaInicioTraslado as date) end,
							 @destCodigoPC,
							 @transCodigoPC,
							 @transMarca,
							 @transNumPlaca,
							 @idnumerolicenciaconducir,
							 @idconstanciainscripcion,
							 @usuarioReg,
							 getdate(),
							 @idMotivoTraslado,
							 @numero_contenedor,
							 @precinto_aduana,
							 @precinto_linea,
							 @precinto,
							 @total,
							 @gross_weight,
							 @net_weight,
							 
							 @total_um,
							 @gross_weight_um,
							 @net_weight_um,
							 @fechavencimiento,
							 @observaciones,
							 @otrosmotivotraslado,
							 @damds,
							 @FacturaReferencia,
							 @NumeroBultos
							 );
			end

			--  ELIMINAMOS DETALLE PARA PODER REGISTRA LUEGO EL DETALLE
			delete from	grDetExportacion where	idEmpresa = @idEmpresa and serie = @serie and numero = @numero and ruc = @ruc;

			select	@idResponse = 1,
					@messageResponse = 'Guardado Correctamente',
					@typeMessage = 'INFORMATION';

		end
		else if (@opcion = 2) -- Eliminar
		begin
			
			delete from grDetExportacion where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and ruc = @ruc;
			delete from	grCabExportacion where	idEmpresa = @idEmpresa and serie = @serie and numero = @numero and ruc = @ruc;
			
			select	@idResponse = 1,
					@messageResponse = 'Eliminado correctamente',
					@typeMessage = 'INFORMATION';

		end	


		-- ########################
		-- ### ACTUALIZAR SUNAT ###
		-- ########################

		if (@opcion = 3)
		begin
			
			--select * from grCabExportacion
			update grCabExportacion set
				enviadoSunat = @enviadosunat,
				respuestaSunat = @respuestasunat
			where	idEmpresa = @idEmpresa
			and serie = @serie
			and	numero = @numero
			and ruc = @ruc; 

				select	@idResponse = 1,
					@messageResponse = 'Enviado Correctamente',
					@typeMessage = 'INFORMATION';

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

ALTER PROCEDURE [dbo].[uspSetGRDetalleExportacion]
	@opcion				int,
	
	@idEmpresa			int,
	@serie				char(4),
	@numero				char(10),
	@ruc				varchar(20) = null,	
	@secuencia			int,
	@descripcion		varchar(500) = null,
	@cantidadingresada	decimal(12,3) = null,
	@codUM				char(3) = null,
	@codigoproducto		varchar(50) = null,
	@OP					varchar(1000) = null,
	@IdPedidoColor			int = null
as
set nocount on
begin
	begin try
	
		declare @idResponse int;
		declare @messageResponse varchar(250);
		declare @typeMessage varchar(250);
		declare @codProducto varchar(158)
		declare @CORRE varchar(100);
		declare @usuario varchar(100);


		select @idResponse = 0;
		select @messageResponse = 'No procesado';
		select @typeMessage = 'ERROR';

		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		if (@opcion in (1, 2)
			and exists (select 1 from grCabExportacion where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and ruc = @ruc and dbo.fnPeriodoBloqueado(fechaEmision) = 1))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar / Actualizar.
		begin
			if not exists (select 1 from grDetExportacion where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and ruc = @ruc and secuencia = @secuencia)
			begin
				
				declare @v_secuencia int;

				if @secuencia = 0 
				begin
					select 
						@v_secuencia =	MAX(secuencia)
					 from grDetExportacion
					 where idEmpresa =  @idEmpresa
					 and serie =  @serie
					 and numero =  @numero
					 and ruc = @ruc;

					 if @v_secuencia is null 
					 begin
						set @v_secuencia = 0
					 end

					 set @v_secuencia = @v_secuencia + 1;
				end
				else
				begin
					set @v_secuencia =  @secuencia
				end

				insert into grDetExportacion (idEmpresa, serie, numero,ruc, secuencia, descripcion, cantidadIngresada, codUM,codProducto,Op,IdPedidoColor)
				values (
						@idEmpresa,
						@serie,
						@numero,
						@ruc,
						@v_secuencia,
						@descripcion,
						@cantidadingresada,
						@codUM,
						@codigoproducto,
						@OP,
						@IdPedidoColor
					);

			if (select isnull(Activar_Transa_Kardex,0) from empresa) = 1
				begin
					SET @usuario = (SELECT usuarioReg FROM grCabExportacion WHERE serie = @serie AND numero = @numero )
					set @codProducto = (select codigo from vListaCodigoExterno where tCodigoSubArea='006' and codGrupoAlt = @codigoProducto)
					SET @CORRE = @serie + '-' + @numero

					exec uspSet_MSUBKARDEX  '006',@codProducto,'09','999',@CORRE , @cantidadIngresada, 100,2,@usuario
				end
			end
			else
			begin
				update	grDetExportacion set		
						idEmpresa = @idEmpresa,
						serie = @serie,
						numero = @numero,
						ruc = @ruc,
						--secuencia = @secuencia,
						descripcion = @descripcion,
						cantidadIngresada = @cantidadIngresada,
						codUM = @codUM,
						codProducto = @codigoproducto,
						Op		= @OP,
						IdPedidoColor = @IdPedidoColor
				where	idEmpresa = @idEmpresa
					and serie = @serie
					and numero = @numero
					and secuencia = @secuencia
					and ruc = @ruc

			end
			
			select	@idResponse = 1,
					@messageResponse = 'Se guardo correctamente',
					@typeMessage = 'INFORMATION';
		
		end
		else if  (@opcion = 2) -- Eliminar
		begin
			delete from grDetExportacion 
			where	idEmpresa = @idEmpresa
				and serie = @serie
				and numero = @numero
				and secuencia = @secuencia
				and ruc = @ruc

			select	@idResponse = 1,
					@messageResponse = 'Eliminado Correctamente',
					@typeMessage = 'INFORMATION';
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
