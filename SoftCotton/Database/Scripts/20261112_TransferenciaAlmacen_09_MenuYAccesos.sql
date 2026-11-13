-- =====================================================================================
-- Transferencia entre Almacenes - Script 9 de 9: opciones de menu y accesos
-- =====================================================================================
-- Da de alta, como hijos del modulo Kardex (id=10), usando uspSetSubModulo (no se modifica):
--   * "Transferencia entre Almacenes" -> Views.Almacen.TransferenciaAlmacenView
--   * "Stock por Almacen"             -> Views.Almacen.StockAlmacenView
-- El menu es data-driven (PrincipalView), no requiere cambios de codigo.
--
-- Otorga acceso a ambos a los usuarios que ya ven "Movimiento Kardex" (submodulo 46).
--
-- Idempotente.
-- =====================================================================================

SET NOCOUNT ON;

DECLARE @idModuloKardex int = 10;
DECLARE @opciones TABLE (subModulo varchar(100), rutaForm varchar(200));
DECLARE @respSub TABLE (idResponse int, messageResponse varchar(250), typeMessage varchar(250));

INSERT INTO @opciones VALUES
	('Transferencia entre Almacenes', 'Views.Almacen.TransferenciaAlmacenView'),
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
