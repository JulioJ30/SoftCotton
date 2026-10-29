-- =====================================================================================
-- Descripcion previa de grupos - Script 1 de 4: columna en grupos
-- =====================================================================================
-- Agrega a la tabla grupos la columna descripcionPrevia, que se registra desde
-- RegistroProductoView (obligatoria para los niveles 06, 07, 08, 10, 11, 13, 15, 16, 17)
-- y que en la impresion de la Orden de Servicio sale antes de la descripcion del grupo.
--
-- Idempotente: puede ejecutarse mas de una vez.
-- =====================================================================================

SET NOCOUNT ON;
GO

IF COL_LENGTH('dbo.grupos', 'descripcionPrevia') IS NULL
	ALTER TABLE dbo.grupos ADD descripcionPrevia varchar(150) NULL;
GO
