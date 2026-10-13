-- =====================================================================================
-- Cierre de Periodo - Script 10: uspSetFacCab / uspSetFacDet
-- =====================================================================================
-- uspSetFacCab: opciones 1 Insertar/Actualizar (fecha nueva y guardada) y 2 Eliminar.
-- uspSetFacDet: opciones 1 Insertar/Actualizar y 2 Eliminar, con la fecha de la cabecera.
--
-- Requiere los scripts 1 (fnPeriodoCerrado) y 2 (fnPeriodoBloqueado).
-- El cuerpo de cada procedimiento es el vigente en la base (copia de produccion); el
-- unico cambio es el bloque "Cierre de periodo" antes de "begin transaction".
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER PROCEDURE [dbo].[uspSetFacCab]
	@opcion			int,
	@idEmpresa		int,
	@serie			char(4),
	@numero			int,
	@fechaEmision	varchar(8),
	@codigoPC		char(15),
	@idTipoMoneda	int,
	@usuarioReg		varchar(30),
	
	
	@tipoCambio		decimal(8,3) = null,
	@mes			int = null,
	@anio			int = null,
	-- agregado
	@codTipoCpte	char(2) = null,
	@serieNotaCredito	char(4) = null,
	@numeroNotaCredito	int = null,
	@observacionNotaCredito	varchar(255) = null,
	@OP						varchar(1000) = null
as
set nocount on
begin
	begin try
		-- select * from facCab
		declare @idResponse int;
		declare @messageResponse varchar(250);
		declare @typeMessage varchar(250);
		declare @idOCGenerado int;

		select @idResponse = 0;
		select @messageResponse = 'No procesado';
		select @typeMessage = 'ERROR';

		-- Cierre de periodo: no se registra, modifica, anula ni elimina en un periodo cerrado.
		-- dbo.fnPeriodoBloqueado deja pasar al usuario ADMIN.
		declare @fechaEmisionNueva date = case when @opcion in (1) then try_convert(date, nullif(@fechaEmision, ''), 112) end;

		if (@opcion in (1, 2)
			and (dbo.fnPeriodoBloqueado(@fechaEmisionNueva) = 1
				or exists (select 1 from facCab where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and codigoPC = @codigoPC and dbo.fnPeriodoBloqueado(fechaEmision) = 1)))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar / Actualizar
		begin
				
			if exists (select 1 from facCab where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and codigoPC = @codigoPC and serieNotaCredito = @serieNotaCredito and numeroNotaCredito = @numeroNotaCredito)
			begin
				update facCab set
					fechaEmision = case when isnull(@fechaEmision,'') = '' then null else cast(@fechaEmision as date) end,
					codigoPC = @codigoPC,
					idTipoMoneda = @idTipoMoneda,

					tipoCambio = @tipoCambio,
					mes =  @mes,
					anio = @anio,
					--codTipoCpte = @codTipoCpte,
					observacionNotaCredito = @observacionNotaCredito,
					Op = @OP,
					Usuario = @usuarioReg
				where	idEmpresa = @idEmpresa
					and serie = @serie
					and	numero = @numero
					and codigoPC = @codigoPC
					and serieNotaCredito = @serieNotaCredito
					and numeroNotaCredito = @numeroNotaCredito
			end
			else
			begin
				insert into facCab (
					idEmpresa,				
					serie,
					numero,
					fechaEmision,
					codigoPC,
					idTipoMoneda,

					tipoCambio,
					mes,
					anio,
					codTipoCpte,serieNotaCredito,numeroNotaCredito,observacionNotaCredito,
					Op,
					Usuario
				)
				values	(
					@idEmpresa,
					@serie,
					@numero,
					case when isnull(@fechaEmision,'') = '' then null else cast(@fechaEmision as date) end,
					@codigoPC,
					@idTipoMoneda,
					@tipoCambio,
					@mes,
					@anio,
					@codTipoCpte,@serieNotaCredito,@numeroNotaCredito,@observacionNotaCredito,
					@OP,
					@usuarioReg
				);
			end

			select	@idResponse = 1,
					@messageResponse = 'Guardado Correctamente',
					@typeMessage = 'INFORMATION';
		end
		else if (@opcion = 2) -- Eliminar
		begin
			-- En el caso de factura basta con los parametro q se le asignado
			if (@codTipoCpte = '01')
			begin
				delete from	facDet where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and codigoPC = @codigoPC;
				delete from	facCab where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and codigoPC = @codigoPC;
			end
			else 
			begin
				delete from	facDet 
				where idEmpresa = @idEmpresa 
					and serie = @serie 
					and numero = @numero 
					and codigoPC = @codigoPC
					and codTipoCpte = @codTipoCpte 
					and serieNotaCredito = @serieNotaCredito 
					and numeroNotaCredito = @numeroNotaCredito;
				delete from	facCab 
				where	idEmpresa = @idEmpresa 
					and serie = @serie 
					and numero = @numero 
					and codigoPC = @codigoPC
					and codTipoCpte = @codTipoCpte 
					and serieNotaCredito = @serieNotaCredito 
					and numeroNotaCredito = @numeroNotaCredito;
			end

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

ALTER PROCEDURE [dbo].[uspSetFacDet]
	@opcion				int,
	
	@idEmpresa			int,
	@serie				char(4),
	@numero				int,
	@secuencia			int,

	@grIdEmpresa		int,
	@grSerie			VARchar(4),
	@grNumero			VARchar(10),
	@grSecuencia		int,

	@codigo				varchar(20),
	@descripcion		varchar(150),
	@codUM				char(3),
	@cantidad			decimal(18,6),
	@igv				decimal(12,2),
	@precioUnitario		decimal(18,6),

	@codigoPC					char(15),
	@grTipoOrden				char(1),
	-- AGREGADO
	@cantidadNotaCredito			decimal(18,6) = 0,
	@serieNotaCredito				char(4) = null,
	@numeroNotaCredito				int = null,
	@codTipoCpte					char(2) = null
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
			and exists (select 1 from facCab where idEmpresa = @idEmpresa and serie = @serie and numero = @numero and codigoPC = @codigoPC and dbo.fnPeriodoBloqueado(fechaEmision) = 1))
		begin
			select	0 as idResponse,
					'El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.' as messageResponse,
					'WARNING' as typeMessage;
			return;
		end

		begin transaction procesarTransaccion

		if (@opcion = 1) -- Insertar / Actualizar.
		begin
			if not exists (select 1 
						   from facDet 
						   where	idEmpresa = @idEmpresa 
							and		codigoPC = @codigoPC 
							and		serie = @serie 
							and		numero = @numero 
							and		secuencia = @secuencia
							and		serieNotaCredito	= @serieNotaCredito
							and		numeroNotaCredito	= @numeroNotaCredito
							and		codTipoCpte		= @codTipoCpte)
			begin

				insert into facDet (
					idEmpresa,				serie,				numero,				secuencia, 
					grIdEmpresa,			grSerie,			grNumero,			grSecuencia,
					codigo,					descripcion,		codUM,				cantidad, 
					igv,					precioUnitario,		codigoPC,			grTipoOrden,
					--cantidadNotaCredito,	
					serieNotaCredito,	numeroNotaCredito,  codTipoCpte
				)
				values (
					@idEmpresa,				@serie,				@numero,			isnull((select MAX(secuencia) from facDet where codigoPC = @codigoPC and serie = @serie and numero = @numero and grTipoOrden = @grTipoOrden),0) + 1,
					@grIdEmpresa,			@grSerie,			@grNumero,			@grSecuencia,
					@codigo,				@descripcion,		@codUM,				@cantidad,
					@igv,					@precioUnitario,	@codigoPC,			@grTipoOrden,
					--@cantidadNotaCredito,	
					@serieNotaCredito,	@numeroNotaCredito,	@codTipoCpte
				);
			end
			else
			begin
				update	facDet  set
						idEmpresa = @idEmpresa,
						serie = @serie,
						numero = @numero,
						secuencia = @secuencia,
						grIdEmpresa = @grIdEmpresa,
						grSerie = @grSerie,
						grNumero = @grNumero,
						grSecuencia = @grSecuencia,
						codigo = @codigo,
						descripcion = @descripcion,
						codUM = @codUM,
						cantidad = @cantidad,
						igv = @igv,
						precioUnitario = @precioUnitario,
						grTipoOrden = @grTipoOrden--,
						--cantidadNotaCredito = @cantidadNotaCredito
				where	idEmpresa = @idEmpresa
					and serie = @serie
					and numero = @numero
					and secuencia = @secuencia
					and codigoPC = @codigoPC
					and serieNotaCredito = @serieNotaCredito
					and numeroNotaCredito = @numeroNotaCredito
					and codTipoCpte = @codTipoCpte
			end

			select	@idResponse = 1,
					@messageResponse = 'Se guardo correctamente',
					@typeMessage = 'INFORMATION';
		
		end
		else if  (@opcion = 2) -- Eliminar
		begin
			delete from facDet 
			where	idEmpresa = @idEmpresa
				and serie = @serie
				and numero = @numero
				and codigoPC = @codigoPC
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
