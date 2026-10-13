-- =====================================================================================
-- Cierre de Periodo - Script 3: uspSetCierrePeriodo opcion 7
-- =====================================================================================
-- Nueva opcion 7: indica si la fecha enviada en @fechaInicio cae en un periodo CERRADO
-- (idResponse = 1) o no (idResponse = 0). La usa la aplicacion para avisar al abrir o
-- antes de modificar / eliminar un documento existente.
--
-- A diferencia de la opcion 5 (usada al registrar), un mes sin periodo creado NO se
-- considera cerrado: solo bloquea el estado 'C'.
--
-- Requiere el script 1 (fnPeriodoCerrado). El resto del procedimiento no cambia.
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER PROCEDURE [dbo].[uspSetCierrePeriodo]
	@idCierrePeriodo	int,
	@opcion				int,
	@periodo			char(7),
	@fechaInicio		DATE,
	@fechaFin			DATE,
	@estado				char(1),
	@usuarioReg			varchar(50)

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

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar
		begin
			if not exists (select 1 from cierrePeriodo where periodo = @periodo)
			begin
				insert into cierrePeriodo (periodo, fechaInicio, fechaFin,estado, usuarioReg, fechaReg) 
				values (@periodo, 
						@fechaInicio,
						@fechaFin,
						'A',
						@usuarioReg, 
						getdate());

				select	@idResponse = 1,
						@messageResponse = 'Registrado Correctamente',
						@typeMessage = 'INFORMATION';
			end
			else
			begin
				select	@idResponse = 0,
						@messageResponse = 'El cierre del período ya existe',
						@typeMessage = 'WARNING';
			end
		end	
		else if (@opcion = 2) -- Actualizar
		begin
			update	cierrePeriodo 
			set		periodo = @periodo,
					fechaInicio = @fechaInicio,
					fechaFin = @fechaFin,
					estado = 'A',
					usuarioReg = @usuarioReg,
					fechaReg = getdate()
					where idCierrePeriodo=@idCierrePeriodo

			select	@idResponse = 1,
					@messageResponse = 'Actualizado Correctamente',
					@typeMessage = 'INFORMATION';
		end	
		else if  (@opcion = 3) -- Eliminar
		begin
			delete from cierrePeriodo where idCierrePeriodo = @idCierrePeriodo;

			select	@idResponse = 1,
					@messageResponse = 'Eliminado Correctamente',
					@typeMessage = 'INFORMATION';
		end	
		else if (@opcion = 4) -- Cerrar Periodo
		begin
			update	cierrePeriodo 
			set		estado = 'C',
					usuarioReg = @usuarioReg,
					fechaReg = getdate()
					where idCierrePeriodo=@idCierrePeriodo
			
			UPDATE D SET D.Periodo= 'C'
			from [dbo].[grDet] D INNER JOIN [dbo].[grCab] C ON D.idEmpresa = C.idEmpresa AND D.serie = C.serie AND D.numero = C.numero
			where 
			(C.fechaEmision >= @fechainicio) AND
			(C.fechaEmision <= @fechafin)

			select	@idResponse = 1,
					@messageResponse = 'El período se cerro Correctamente',
					@typeMessage = 'INFORMATION';
		end	
		else if (@opcion = 5) -- Validar Periodo
		begin
			declare @finicio DATE = NULL;
			declare @ffin DATE = NULL;
			declare @exist INT = 0;

			set @finicio=  dateadd(d,1,EOMONTH(@fechaInicio,-1))
			set @ffin =  EOMONTH(@fechaInicio)
		
			set @exist = (select count(*) from dbo.cierrePeriodo where (fechaInicio >= @finicio) AND (fechaFin <= @ffin) AND estado='C')
		
			if @exist > 0
				begin
					select	@idResponse = 1,
							@messageResponse = 'El Periodo se encuentra cerrado',
							@typeMessage = 'WARNING';
				end
			else
				begin
					set @exist = (select count(*) from dbo.cierrePeriodo where (fechaInicio >= @finicio) AND (fechaFin <= @ffin) AND estado='A')
					if @exist > 0
						begin
							select	@idResponse = 0,
							@messageResponse = 'Periodo Abierto',
							@typeMessage = 'WARNING';
						end
					else 
						begin
							select	@idResponse = 1,
							@messageResponse = 'No existe periodo abierto para esta fecha',
							@typeMessage = 'WARNING';
						end
				end
		end	
		else if (@opcion = 6) -- ReAbrir Periodo
		begin
			update	cierrePeriodo 
			set		estado = 'A',
					usuarioReg = @usuarioReg,
					fechaReg = getdate()
					where idCierrePeriodo=@idCierrePeriodo
			
			UPDATE D SET D.Periodo= 'A'
			from [dbo].[grDet] D INNER JOIN [dbo].[grCab] C ON D.idEmpresa = C.idEmpresa AND D.serie = C.serie AND D.numero = C.numero
			where 
			(C.fechaEmision >= @fechainicio) AND
			(C.fechaEmision <= @fechafin)

			select	@idResponse = 1,
					@messageResponse = 'El período fue reabierto Correctamente',
					@typeMessage = 'INFORMATION';
		end	

		else if (@opcion = 7) -- Consultar si la fecha (@fechaInicio) cae en un periodo cerrado
		begin
			if (dbo.fnPeriodoCerrado(@fechaInicio) = 1)
			begin
				select	@idResponse = 1,
						@messageResponse = 'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.',
						@typeMessage = 'WARNING';
			end
			else
			begin
				select	@idResponse = 0,
						@messageResponse = 'Periodo Abierto',
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
