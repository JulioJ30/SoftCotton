-- =====================================================================================
-- Permisos de movimiento en Guias - Script 2 de 3: uspSetAcceso
-- =====================================================================================
-- Agrega los parametros @permiteEntrada / @permiteSalida / @permiteDevolucion. Son
-- opcionales (default 1) para no romper llamadas anteriores.
--
-- Cambio de comportamiento: antes, si el acceso ya existia y @activo = 1, no hacia nada.
-- Ahora actualiza los tres permisos de ese acceso.
--
-- Requiere el script 1 (columnas en accesos).
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER procedure [dbo].[uspSetAcceso]
	@idUsuario			int,
	@idSubModulo		int,
	@usuarioReg			varchar(30),
	@activo				bit,
	@permiteEntrada		bit = 1,
	@permiteSalida		bit = 1,
	@permiteDevolucion	bit = 1
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

		if @activo = 1
		begin
			if not exists (select 1 from accesos where idUsuario = @idUsuario and idSubModulo = @idSubModulo)
			begin
				insert into accesos (idUsuario, idSubModulo, usuarioReg, fechaReg, permiteEntrada, permiteSalida, permiteDevolucion)
				values (@idUsuario, @idSubModulo, @usuarioReg, getdate(), @permiteEntrada, @permiteSalida, @permiteDevolucion)
			end
			else
			begin
				-- Solo toca la fila si cambio algun permiso, para conservar usuarioReg / fechaReg originales.
				update	accesos
				set		permiteEntrada = @permiteEntrada,
						permiteSalida = @permiteSalida,
						permiteDevolucion = @permiteDevolucion,
						usuarioReg = @usuarioReg,
						fechaReg = getdate()
				where	idUsuario = @idUsuario
					and idSubModulo = @idSubModulo
					and (permiteEntrada <> @permiteEntrada
						or permiteSalida <> @permiteSalida
						or permiteDevolucion <> @permiteDevolucion);
			end
		end
		else
		begin
			delete from accesos where idUsuario = @idUsuario and idSubModulo = @idSubModulo;
		end

		select	@idResponse = 1,
				@messageResponse = 'Registrado Correctamente',
				@typeMessage = 'INFORMATION';

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
