-- =====================================================================================
-- Permisos de movimiento en Guias - Script 1 de 3: columnas en accesos
-- =====================================================================================
-- Agrega a la tabla accesos los permisos por tipo de movimiento que se usan en la emision
-- de guias de remision (normal y exportacion):
--		permiteEntrada		-> lineas con tipo de movimiento ENTRADA (E)
--		permiteSalida		-> lineas con tipo de movimiento SALIDA (S) y guias de exportacion
--		permiteDevolucion	-> lineas con tipo de movimiento DEVOLUCION (D)
--
-- Las tres columnas nacen en 1 para que ningun usuario pierda lo que hoy puede hacer; la
-- restriccion se configura luego, usuario por usuario, desde "Registro de Acceso".
--
-- Idempotente: puede ejecutarse mas de una vez.
-- =====================================================================================

SET NOCOUNT ON;
GO

IF COL_LENGTH('dbo.accesos', 'permiteEntrada') IS NULL
	ALTER TABLE dbo.accesos ADD permiteEntrada bit NOT NULL CONSTRAINT DF_accesos_permiteEntrada DEFAULT (1);
GO

IF COL_LENGTH('dbo.accesos', 'permiteSalida') IS NULL
	ALTER TABLE dbo.accesos ADD permiteSalida bit NOT NULL CONSTRAINT DF_accesos_permiteSalida DEFAULT (1);
GO

IF COL_LENGTH('dbo.accesos', 'permiteDevolucion') IS NULL
	ALTER TABLE dbo.accesos ADD permiteDevolucion bit NOT NULL CONSTRAINT DF_accesos_permiteDevolucion DEFAULT (1);
GO

PRINT 'Columnas permiteEntrada / permiteSalida / permiteDevolucion disponibles en accesos.';
GO
