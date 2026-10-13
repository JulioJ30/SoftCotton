-- =====================================================================================
-- Cierre de Periodo - Script 06: uspSetOSEspecial
-- =====================================================================================
-- Opciones 1 Insertar, 2 Actualizar, 3 Anular, 4/5 Registrar detalle y tallas, 6 Eliminar
-- detalle, 7 Eliminar OS. En 1 y 2 valida tambien la fecha nueva.
--
-- Requiere los scripts 1 (fnPeriodoCerrado) y 2 (fnPeriodoBloqueado).
-- El cuerpo de cada procedimiento es el vigente en la base (copia de produccion); el
-- unico cambio es el bloque "Cierre de periodo" antes de "begin transaction".
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER PROCEDURE [dbo].[uspSetOSEspecial]
	@opcion				int,
		
	@idEmpresa			int,
	@idOS				int,
	@fechaEmision		varchar(8),
	@fechaEntrega		varchar(8),
	@codigoPC			char(15),
	@idTipoMoneda		int,
	@tipoCompra			char(1),
	@idCondPago			int,

	@idTipoAprobacion	int,

	@idTipoAnulado		int,
	@fechaAnulado		varchar(8),
	@usuarioAnulado		varchar(50),

	@usuarioRegistro	varchar(50),
	@observacion		varchar(350),

	@codPrograma		varchar(10),
	@codServicio		varchar(10),

	@secuencia			int = null,
	@idpedidocolor		int = null,
	@precio				decimal(18,5) = null,
	@codtalla			varchar(10) = null,	
	@cantidad			int = null
as
set nocount on
begin
	begin try
	
		declare @idResponse int;
		declare @messageResponse varchar(250);
		declare @typeMessage varchar(250);
		declare @idOSGenerado int;

		select @idResponse = 0;
		select @messageResponse = 'No procesado';
		select @typeMessage = 'ERROR';

		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		declare @fechaEmisionNueva date = case when @opcion in (1, 2) then try_convert(date, nullif(@fechaEmision, ''), 112) end;

		if (@opcion in (1, 2, 3, 4, 5, 6, 7)
			and (dbo.fnPeriodoBloqueado(@fechaEmisionNueva) = 1
				or exists (select 1 from osCabEspecial where idEmpresa = @idEmpresa and idOS = @idOS and dbo.fnPeriodoBloqueado(fechaEmision) = 1)))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar
		begin
			select @idOSGenerado = [dbo].[ufnGenerarID] ('OSCABESPECIAL');
			
			insert into osCabEspecial  (idEmpresa,				
								idOS,
								fechaEmision,
								fechaEntrega,
								codigoPC,
								idTipoMoneda,
								tipoCompra,
								idCondPago,
								idTipoAprobacion,
								idTipoAnulado,
								fechaAnulado,
								usuarioAnulado,
								usuCreacionReg,
								usuFechaReg,
								observacion,
								codPrograma,
								codServicio)
			values	(@idEmpresa,
					 @idOSGenerado,
					 case when isnull(@fechaEmision,'') = '' then null else cast(@fechaEmision as date) end,
					 case when isnull(@fechaEntrega,'') = '' then null else cast(@fechaEntrega as date) end,
					 @codigoPC,
					 @idTipoMoneda,
					 @tipoCompra,
					 @idCondPago,
					 @idTipoAprobacion,
					 @idTipoAnulado,
					 case when isnull(@fechaAnulado,'') = '' then cast('19700101' as date) else cast(@fechaAnulado as date) end,
					 @usuarioAnulado,
					 @usuarioRegistro,
					 GETDATE(),
					 @observacion,
					 @codPrograma,
					 @codServicio);

			select	@idResponse = @idOSGenerado,
					@messageResponse = 'Registrado Correctamente',
					@typeMessage = 'INFORMATION';
		end
		else if (@opcion = 2) -- Actualizar
		begin
			update osCabEspecial set
				fechaEmision = cast(@fechaEmision as date),
				fechaEntrega = cast(@fechaEntrega as date),
				codigoPC = @codigoPC,
				idTipoMoneda = @idTipoMoneda,
				tipoCompra = @tipoCompra,
				idCondPago = @idCondPago,
				idTipoAprobacion = @idTipoAprobacion,
				idTipoAnulado = @idTipoAnulado,
				fechaAnulado = @fechaAnulado,
				usuCreacionReg = @usuarioRegistro,
				usuFechaReg = GETDATE(),
				observacion = @observacion,
				codPrograma = @codPrograma,
				codServicio = @codServicio
			where	idEmpresa = @idEmpresa
				and	idOS = @idOS;
			
			select	@idResponse = @idOS,
					@messageResponse = 'Actualizado Correctamente',
					@typeMessage = 'INFORMATION';

		end
		else if  (@opcion = 3) -- Anular / Habilitar
		begin
			update	osCabEspecial 
			set		idTipoAnulado = @idTipoAnulado, 
					fechaAnulado  = GETDATE(),
					usuarioAnulado = @usuarioRegistro		
			where	idEmpresa = @idEmpresa
				and	idOS = @idOS;
			
			select	@idResponse = 1,
					@messageResponse = 'Estado de orden de compra Actualizada',
					@typeMessage = 'INFORMATION';

		end	
		else if  (@opcion = 4) -- REGISTRAR DETALLE
		begin
			
				--select * from osDetEspecial

				insert into osDetEspecial(
					idEmpresa,idOS,secuencia,idPedidoColor,precio
				)values(
					@idEmpresa,@idOS,@secuencia,@idpedidocolor,@precio
				)
			


		end
		else if (@opcion = 5) -- REGISTRAR DETALLE DE TALLA
		begin
				
				insert into osDetTallasEspecial(
					idEmpresa,idOS,secuencia,codTalla,cantidad
				)values(
					@idEmpresa,@idOS,@secuencia,@codtalla,@cantidad
				)
				--select * from osDetTallasEspecial

		end
		-- ELIMINAR DETALLE
		else if (@opcion = 6)
		begin
			
			-- ELIMINAMOS DETALLE TALLA
			delete from osDetTallasEspecial where idEmpresa = @idEmpresa and idOS = @idOS
			-- ELIMINAMOS DETALLE
			delete from osDetEspecial where  idEmpresa = @idEmpresa and idOS = @idOS
		end

		-- ELIMINAR GENERAL
		else if (@opcion =7)
		begin
			
			-- ELIMINAMOS DETALLE TALLA
			delete from osDetTallasEspecial where idEmpresa = @idEmpresa and idOS = @idOS
			-- ELIMINAMOS DETALLE
			delete from osDetEspecial where  idEmpresa = @idEmpresa and idOS = @idOS
			-- CABECERA
			delete from osCabEspecial where  idEmpresa = @idEmpresa and idOS = @idOS
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
