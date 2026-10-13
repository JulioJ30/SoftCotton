-- =====================================================================================
-- Cierre de Periodo - Script 04: uspSetOC / uspSetOCDetalle
-- =====================================================================================
-- uspSetOC: opciones 1 Insertar, 2 Actualizar, 3 Anular, 4 Eliminar. En 1 y 2 valida la fecha
-- nueva y, en 2 a 4, la fecha guardada (evita mover una OC de un periodo cerrado a uno abierto).
-- uspSetOCDetalle: opciones 1 Insertar/Actualizar y 2 Eliminar, con la fecha de la cabecera.
--
-- Requiere los scripts 1 (fnPeriodoCerrado) y 2 (fnPeriodoBloqueado).
-- El cuerpo de cada procedimiento es el vigente en la base (copia de produccion); el
-- unico cambio es el bloque "Cierre de periodo" antes de "begin transaction".
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER PROCEDURE [dbo].[uspSetOC]
	@opcion				int,
		
	@idEmpresa			int,
	@idOC				int,
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
	@codServicio		varchar(10)
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

		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		declare @fechaEmisionNueva date = case when @opcion in (1, 2) then try_convert(date, nullif(@fechaEmision, ''), 112) end;

		if (@opcion in (1, 2, 3, 4)
			and (dbo.fnPeriodoBloqueado(@fechaEmisionNueva) = 1
				or exists (select 1 from ocCab where idEmpresa = @idEmpresa and idOC = @idOC and dbo.fnPeriodoBloqueado(fechaEmision) = 1)))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar
		begin
			select @idOCGenerado = [dbo].[ufnGenerarID] ('OCCAB');
			
			insert into ocCab  (idEmpresa,				
								idOC,
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
					 @idOCGenerado,
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

			select	@idResponse = @idOCGenerado,
					@messageResponse = 'Registrado Correctamente',
					@typeMessage = 'INFORMATION';
		end
		else if (@opcion = 2) -- Actualizar
		begin
			update ocCab set
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
				and	idOC = @idOC;
			
			select	@idResponse = 1,
					@messageResponse = 'Actualizado Correctamente',
					@typeMessage = 'INFORMATION';

		end
		else if  (@opcion = 3) -- Anular / Habilitar
		begin
			update	ocCab 
			set		idTipoAnulado = @idTipoAnulado, 
					fechaAnulado  = GETDATE(),
					usuarioAnulado = @usuarioRegistro		
			where	idEmpresa = @idEmpresa
				and	idOC = @idOC;
			
			select	@idResponse = 1,
					@messageResponse = 'Estado de orden de compra Actualizada',
					@typeMessage = 'INFORMATION';

		end	
		else if  (@opcion = 4) -- Eliminar
		begin
			
			if exists (select 1 from grDet where idEmpresa = @idEmpresa and idDet = @idOC)
			begin
				select	@idResponse = 0,
						@messageResponse = 'Elimine primero este item de la Guía de Remisión para desasociar',
						@typeMessage = 'INFORMATION';
			end
			else
			begin
					
--				insert into ocDetBackup 
--				select
--					idEmpresa,
--					idOC,
--					secuencia,
--					codNivel,
--					codGrupo,
--					codTalla,
--					codColor,
--					cantidad,
--					igv,
--					precioUnitario,
--					obs1,
--					obs2,
--					obs3,
--					obs4,
--					obs5
--				from ocDet where idEmpresa = @idEmpresa and idOC = @idOC;

--				insert into ocCabBackup 
--				select idEmpresa,
--idOC,
--fechaEmision,
--fechaEntrega,
--codigoPC,
--idTipoMoneda,
--tipoCompra,
--idCondPago,
--idTipoAprobacion,
--idTipoAnulado,
--fechaAnulado,
--usuarioAnulado,
--usuCreacionReg,
--usuFechaReg,
--observacion,
--codPrograma,
--codServicio,
--@usuarioRegistro from ocCab where idEmpresa = @idEmpresa and idOC = @idOC;

				delete from ocDet where idEmpresa = @idEmpresa and idOC = @idOC;
				delete from ocCab where idEmpresa = @idEmpresa and idOC = @idOC;

				select	@idResponse = 1,
						@messageResponse = 'Se eliminó correctamente',
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

ALTER PROCEDURE [dbo].[uspSetOCDetalle]
	@opcion					int,
	
	@idEmpresa				int,
	@idOC					int,
	@secuencia				int,
	@codNivel				char(2),
	@codGrupo				char(5),
	@codTalla				char(3),
	@codColor				char(6),
	@cantidad				decimal(18,5),
	@igv					decimal(12,2),
	@precioUnitario			decimal(19,6),

	@obs1					varchar(200),
	@obs2					varchar(200),
	@obs3					varchar(200),
	@obs4					varchar(200),
	@obs5					varchar(200)
as
set nocount on
begin
	begin try
	
		declare @idResponse int;
		declare @messageResponse varchar(250);
		declare @typeMessage varchar(250);

		select @idResponse = 0;
		select @messageResponse = 'No procesado';
		select @typeMessage = 'ERROR';

		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		if (@opcion in (1, 2)
			and exists (select 1 from ocCab where idEmpresa = @idEmpresa and idOC = @idOC and dbo.fnPeriodoBloqueado(fechaEmision) = 1))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar / Actualizar.
		begin
			if not exists (select 1 from ocDet where idEmpresa = @idEmpresa and idOC = @idOC and secuencia = @secuencia)
			begin
				insert into ocDet (idEmpresa, idOC, secuencia, codNivel, codGrupo, codTalla, codColor, cantidad, igv, precioUnitario, obs1, obs2, obs3, obs4, obs5)
				values (@idEmpresa,
						@idOC,
						isnull((select MAX(secuencia) from ocDet where idOC = @idOC),0) + 1,
						@codNivel,
						@codGrupo,
						@codTalla,
						@codColor,
						@cantidad,
						@igv,
						@precioUnitario,
						@obs1,
						@obs2,
						@obs3,
						@obs4,
						@obs5);
			end
			else
			begin
				update	ocDet 
				set		idEmpresa = @idEmpresa,
						idOC = @idOC,
						secuencia = @secuencia,
						codNivel = @codNivel,
						codGrupo = @codGrupo,
						codTalla = @codTalla,
						codColor = @codColor,
						cantidad = @cantidad,
						igv = @igv,
						precioUnitario = @precioUnitario,
						obs1 = @obs1,
						obs2 = @obs2,
						obs3 = @obs3,
						obs4 = @obs4,
						obs5 = @obs5
				where	idEmpresa = @idEmpresa
					and idOC = @idOC
					and secuencia = @secuencia;
			end
			
			select	@idResponse = 1,
					@messageResponse = 'Se guardo correctamente',
					@typeMessage = 'INFORMATION';
		
		end
		else if  (@opcion = 2) -- Eliminar
		begin
			delete from ocDet 
			where	idEmpresa = @idEmpresa
				and idOC = @idOC
				and secuencia = @secuencia;

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
