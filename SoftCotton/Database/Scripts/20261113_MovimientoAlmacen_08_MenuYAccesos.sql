-- =====================================================================================
-- Movimientos de Almacen - Script 8 de 8: opciones de menu y accesos
-- =====================================================================================
-- Opciones, como hijos del modulo Kardex (id=10):
--   * "Ingresos y Salidas de Almacen" -> Views.Almacen.MovimientoAlmacenView
--   * "Stock por Almacen"             -> Views.Almacen.StockAlmacenView
--
-- Si ya existe la opcion de transferencias (serie 20261112), se reutiliza: se le cambia el
-- nombre y el formulario, y conserva sus accesos. Si no existe, se crea con
-- uspSetSubModulo (no se modifica).
-- El menu es data-driven (PrincipalView), no requiere cambios de codigo.
--
-- Otorga acceso a ambas a los usuarios que ya ven "Movimiento Kardex" (submodulo 46).
--
-- Idempotente.
-- =====================================================================================

SET NOCOUNT ON;

DECLARE @idModuloKardex int = 10;

-- reutiliza la opcion de transferencias, si existe
UPDATE submodulos
SET		submodulo = 'Ingresos y Salidas de Almacen',
		rutaForm  = 'Views.Almacen.MovimientoAlmacenView'
WHERE idModulo = @idModuloKardex
	AND rutaForm = 'Views.Almacen.TransferenciaAlmacenView'
	AND NOT EXISTS (SELECT 1 FROM submodulos WHERE idModulo = @idModuloKardex AND rutaForm = 'Views.Almacen.MovimientoAlmacenView');

IF @@ROWCOUNT > 0
	PRINT 'Opcion "Transferencia entre Almacenes" renombrada a "Ingresos y Salidas de Almacen".';

DECLARE @opciones TABLE (subModulo varchar(100), rutaForm varchar(200));
DECLARE @respSub TABLE (idResponse int, messageResponse varchar(250), typeMessage varchar(250));

INSERT INTO @opciones VALUES
	('Ingresos y Salidas de Almacen', 'Views.Almacen.MovimientoAlmacenView'),
	('Stock por Almacen',             'Views.Almacen.StockAlmacenView');

DECLARE @subModulo varchar(100), @rutaForm varchar(200), @idSubModulo int;

DECLARE cur CURSOR LOCAL FAST_FORWARD FOR SELECT subModulo, rutaForm FROM @opciones;
OPEN cur;
FETCH NEXT FROM cur INTO @subModulo, @rutaForm;
WHILE @@FETCH_STATUS = 0
BEGIN
	IF NOT EXISTS (SELECT 1 FROM submodulos WHERE idModulo = @idModuloKardex AND rutaForm = @rutaForm)
	BEGIN
		INSERT INTO @respSub
		EXEC uspSetSubModulo
			@opcion			= 1,
			@idSubModulo	= 0,
			@idModulo		= @idModuloKardex,
			@subModulo		= @subModulo,
			@rutaForm		= @rutaForm,
			@iconPath		= '',
			@usuarioReg		= 'SISTEMA',
			@estado			= 1;
	END

	SELECT @idSubModulo = id FROM submodulos WHERE idModulo = @idModuloKardex AND rutaForm = @rutaForm;

	INSERT INTO accesos (idUsuario, idSubModulo, usuarioReg, fechaReg)
	SELECT a.idUsuario, @idSubModulo, 'SISTEMA', GETDATE()
	FROM accesos a
	WHERE a.idSubModulo = 46
		AND NOT EXISTS (SELECT 1 FROM accesos a2 WHERE a2.idUsuario = a.idUsuario AND a2.idSubModulo = @idSubModulo);

	PRINT @subModulo + ' -> submodulo ' + CAST(@idSubModulo AS varchar(10));

	FETCH NEXT FROM cur INTO @subModulo, @rutaForm;
END
CLOSE cur;
DEALLOCATE cur;
