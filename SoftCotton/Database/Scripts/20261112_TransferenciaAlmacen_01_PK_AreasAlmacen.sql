-- =====================================================================================
-- Transferencia entre Almacenes - Script 1 de 9: clave primaria de AreasAlmacen
-- =====================================================================================
-- AreasAlmacen no tiene clave primaria y su columna Codigo admite NULL. Las tablas nuevas
-- de transferencias referencian al almacen con FOREIGN KEY, asi que primero se asegura la
-- PK sobre Codigo.
--
-- uspSetAreasAlmacen ya genera siempre un Codigo (correlativo de 3 digitos) y nunca lo
-- actualiza ni elimina, por lo que la PK no cambia su comportamiento.
--
-- El script valida antes de alterar: si hay codigos NULL o duplicados, no hace nada y
-- lo informa (hay que corregir esos datos primero).
--
-- Idempotente: si la PK ya existe, no hace nada.
-- =====================================================================================

SET NOCOUNT ON;

IF EXISTS (SELECT 1 FROM sys.key_constraints WHERE parent_object_id = OBJECT_ID('dbo.AreasAlmacen') AND type = 'PK')
BEGIN
	PRINT 'AreasAlmacen ya tiene clave primaria. No se hace nada.';
END
ELSE IF EXISTS (SELECT 1 FROM dbo.AreasAlmacen WHERE Codigo IS NULL)
BEGIN
	RAISERROR('AreasAlmacen tiene filas con Codigo NULL. Corrijalas antes de ejecutar este script.', 16, 1);
END
ELSE IF EXISTS (SELECT Codigo FROM dbo.AreasAlmacen GROUP BY Codigo HAVING COUNT(*) > 1)
BEGIN
	RAISERROR('AreasAlmacen tiene codigos duplicados. Corrijalos antes de ejecutar este script.', 16, 1);
END
ELSE
BEGIN
	-- Se usa SQL dinamico para que el ALTER COLUMN quede aplicado antes de compilar el ADD CONSTRAINT
	EXEC ('ALTER TABLE dbo.AreasAlmacen ALTER COLUMN Codigo varchar(3) NOT NULL;');
	EXEC ('ALTER TABLE dbo.AreasAlmacen ADD CONSTRAINT PK_AreasAlmacen PRIMARY KEY CLUSTERED (Codigo);');

	PRINT 'Clave primaria PK_AreasAlmacen creada.';
END
