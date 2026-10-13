-- =====================================================================================
-- Cierre de Periodo - Script 2: funcion de bloqueo con excepcion para ADMIN
-- =====================================================================================
-- Igual que dbo.fnPeriodoCerrado, pero devuelve 0 cuando el usuario de la sesion es ADMIN.
-- Es la que usan los procedimientos de OC, OS, OS especial, orden de salida, guias y
-- facturas para cortar el registro / modificacion / eliminacion en periodos cerrados.
--
-- El usuario de la sesion lo registra la aplicacion al abrir cada conexion
-- (ConnectionBD.GetConnection -> sp_set_session_context 'usuario'). Si la llamada no
-- viene de la aplicacion, no hay usuario en la sesion y se aplica el bloqueo.
--
-- Requiere el script 1 (fnPeriodoCerrado) y SQL Server 2016 o superior (SESSION_CONTEXT).
-- =====================================================================================

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.fnPeriodoBloqueado', 'FN') IS NOT NULL
	DROP FUNCTION dbo.fnPeriodoBloqueado;
GO

CREATE FUNCTION dbo.fnPeriodoBloqueado(@fecha DATE)
RETURNS BIT
AS
BEGIN
	IF CONVERT(VARCHAR(50), SESSION_CONTEXT(N'usuario')) = 'ADMIN'
		RETURN 0;

	RETURN dbo.fnPeriodoCerrado(@fecha);
END
GO
