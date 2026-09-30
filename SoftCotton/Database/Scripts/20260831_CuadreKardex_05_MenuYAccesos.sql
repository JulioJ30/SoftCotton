-- =====================================================================================
-- Cuadre de Kardex - Script 5 de 5: opcion de menu (hijo de Kardex) y accesos
-- =====================================================================================
-- Da de alta "Cuadre Kardex" como submodulo hijo del modulo Kardex (id=10), apuntando al
-- formulario Views.Kardex.CuadreKardexView, usando el procedimiento ya existente
-- uspSetSubModulo (no se modifica). El menu de la aplicacion es 100% data-driven
-- (PrincipalView.cs lo arma leyendo modulos/submodulos/accesos), asi que no requiere
-- ningun cambio de codigo.
--
-- Ademas otorga acceso al nuevo submodulo a todos los usuarios que ya tienen acceso a
-- "Movimiento Kardex" (submodulo 46), para que lo vean de inmediato sin tener que volver
-- a configurar permisos uno por uno.
--
-- Idempotente: puede ejecutarse mas de una vez sin duplicar el submodulo ni los accesos.
-- =====================================================================================

SET NOCOUNT ON;

DECLARE @idModuloKardex int = 10;
DECLARE @idSubModuloCuadre int;

IF NOT EXISTS (SELECT 1 FROM submodulos WHERE idModulo = @idModuloKardex AND rutaForm = 'Views.Kardex.CuadreKardexView')
BEGIN
	DECLARE @respSub TABLE (idResponse int, messageResponse varchar(250), typeMessage varchar(250));

	INSERT INTO @respSub
	EXEC uspSetSubModulo
		@opcion			= 1,
		@idSubModulo	= 0,
		@idModulo		= @idModuloKardex,
		@subModulo		= 'Cuadre Kardex',
		@rutaForm		= 'Views.Kardex.CuadreKardexView',
		@iconPath		= '',
		@usuarioReg		= 'SISTEMA',
		@estado			= 1;
END

SELECT @idSubModuloCuadre = id FROM submodulos WHERE idModulo = @idModuloKardex AND rutaForm = 'Views.Kardex.CuadreKardexView';

-- Otorga acceso a todos los usuarios que ya ven "Movimiento Kardex" (submodulo 46)
INSERT INTO accesos (idUsuario, idSubModulo, usuarioReg, fechaReg)
SELECT a.idUsuario, @idSubModuloCuadre, 'SISTEMA', GETDATE()
FROM accesos a
WHERE a.idSubModulo = 46
	AND NOT EXISTS (
		SELECT 1 FROM accesos a2
		WHERE a2.idUsuario = a.idUsuario AND a2.idSubModulo = @idSubModuloCuadre
	);

PRINT 'Cuadre Kardex agregado al menu (submodulo ' + CAST(@idSubModuloCuadre AS varchar(10)) + ') y accesos otorgados.';
