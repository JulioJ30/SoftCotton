-- =====================================================================================
-- Movimientos de Almacen - Script 3 de 8: eliminar las transferencias entre almacenes
-- =====================================================================================
-- Ya no hay transferencias entre almacenes: el modulo pasa a ser de ingresos (devoluciones
-- de lo despachado con guia) y salidas por almacen (scripts 5 a 7).
--
-- Elimina los objetos creados por la serie 20261112_TransferenciaAlmacen_02..06:
--   uspGetTransferenciaAlmacen, uspSetTransferenciaAlmacen, ufnStockAlmacen,
--   ufnStockKardexGlobal, tipo TransferenciaAlmacenDetTipo y las tablas
--   TransferenciaAlmacenDet / TransferenciaAlmacenCab (con sus datos de prueba).
--
-- Se conserva la clave primaria de AreasAlmacen (script 4).
--
-- Ejecutar DESPUES de los scripts 1 y 2 (el Kardex restaurado ya no lee estas tablas).
-- Idempotente: en una base donde nunca se crearon, no hace nada.
-- =====================================================================================

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.TransferenciaAlmacenCab', 'U') IS NOT NULL
BEGIN
	DECLARE @filas int;
	SELECT @filas = COUNT(*) FROM dbo.TransferenciaAlmacenCab;
	PRINT 'Se eliminan ' + CAST(@filas AS varchar(10)) + ' transferencia(s) registradas.';
END
GO

DROP PROCEDURE IF EXISTS dbo.uspGetTransferenciaAlmacen;
DROP PROCEDURE IF EXISTS dbo.uspSetTransferenciaAlmacen;
DROP FUNCTION IF EXISTS dbo.ufnStockAlmacen;
DROP FUNCTION IF EXISTS dbo.ufnStockKardexGlobal;
GO

IF TYPE_ID('dbo.TransferenciaAlmacenDetTipo') IS NOT NULL
	DROP TYPE dbo.TransferenciaAlmacenDetTipo;
GO

DROP TABLE IF EXISTS dbo.TransferenciaAlmacenDet;
DROP TABLE IF EXISTS dbo.TransferenciaAlmacenCab;
GO

PRINT 'Objetos de transferencias entre almacenes eliminados.';
