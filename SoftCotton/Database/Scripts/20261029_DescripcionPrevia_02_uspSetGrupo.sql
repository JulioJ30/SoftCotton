/*
    Descripcion previa de grupos - Script 2 de 4: uspSetGrupo
    ---------------------------------------------------------
    Agrega el parametro @descripcionPrevia y lo guarda en grupos.descripcionPrevia
    al insertar (@opcion = 1) y al actualizar (@opcion = 2).

    El resto del procedimiento se deja exactamente igual al texto actual
    (obtenido via OBJECT_DEFINITION('uspSetGrupo') de bdsoftcotton al 29/10/2026).

    Requiere: 20261029_DescripcionPrevia_01_ColumnaGrupos.sql
*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER procedure [dbo].[uspSetGrupo]
	@opcion			int,

	@codNivel		char(2),
	@codGrupo		char(5),
	@codGrupoAlt	varchar(200),
	@grupo			varchar(150),
	@codUM			char(3),	
	@usuarioReg		varchar(50),
	@codCuenta		char(10),
	@descripcionPrevia	varchar(150) = null
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
			
			select @messageResponse = dbo.ufnGenerarCodGrupo(@codNivel);
			
			if trim(@usuarioReg) = 'MMENDEZ'
			begin
				set @codCuenta = null
			end

			insert into grupos (codNivel, codGrupo, codGrupoAlt, grupo, codUM, usuarioReg, fechaReg, codCuenta, descripcionPrevia) 
			values (@codNivel, 
					@messageResponse, 
					@codGrupoAlt,
					@grupo,
					@codUM,
					@usuarioReg,
					getdate(),
					@codCuenta,
					nullif(trim(@descripcionPrevia), ''));

			select	@idResponse = 1,
					@messageResponse = @messageResponse,
					@typeMessage = 'INFORMATION';
					
		end	
		else if (@opcion = 2) -- Actualizar
		begin
			update	grupos 
			set		codGrupoAlt = @codGrupoAlt,
					grupo = @grupo,
					codUM = @codUM,
					usuarioReg = @usuarioReg,
					fechaReg = GetDate(),
					codCuenta = iif(trim(@usuarioReg) = 'MMENDEZ',codCuenta , @codCuenta),
					descripcionPrevia = nullif(trim(@descripcionPrevia), '')
			where	codNivel = @codNivel
				and codGrupo = @codGrupo;

			select	@idResponse = 1,
					@messageResponse = @codGrupo,
					@typeMessage = 'INFORMATION';
		end	
		else if  (@opcion = 3) -- eliminar
		begin
			
			delete from productoServicios where codNivel = @codNivel and codGrupo = @codGrupo;
			delete from grupos where codNivel = @codNivel and codGrupo = @codGrupo;

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
