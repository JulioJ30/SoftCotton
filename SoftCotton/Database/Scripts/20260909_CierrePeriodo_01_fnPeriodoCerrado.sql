-- =====================================================================================
-- Cierre de Periodo - Script 1: funcion de validacion reutilizable
-- =====================================================================================
-- Centraliza la regla "la fecha cae dentro de un periodo cerrado" para que los
-- procedimientos de OC, OS, Guia de Remision y Guia de Remision de Exportacion la
-- consulten en lugar de repetir el mismo SELECT contra cierrePeriodo en cada uno.
--
-- Uso: IF dbo.fnPeriodoCerrado(CONVERT(DATE, @fechaEmision, 112)) = 1 ...
-- =====================================================================================

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.fnPeriodoCerrado', 'FN') IS NOT NULL
	DROP FUNCTION dbo.fnPeriodoCerrado;
GO

CREATE FUNCTION dbo.fnPeriodoCerrado(@fecha DATE)
RETURNS BIT
AS
BEGIN
	DECLARE @resultado BIT = 0;

	IF @fecha IS NOT NULL AND EXISTS (
		SELECT 1
		FROM dbo.cierrePeriodo
		WHERE estado = 'C'
		  AND @fecha BETWEEN fechaInicio AND fechaFin
	)
		SET @resultado = 1;

	RETURN @resultado;
END
GO
