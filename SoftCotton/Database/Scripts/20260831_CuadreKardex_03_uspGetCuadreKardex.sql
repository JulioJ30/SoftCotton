-- =====================================================================================
-- Cuadre de Kardex - Script 3 de 5: procedimiento de lectura
-- =====================================================================================
-- Lista los ajustes registrados (CuadreKardex) para la grilla del formulario "Cuadre de
-- Kardex", con la descripcion del producto exacto que se cuadro. No participa en el
-- calculo del Kardex.
-- =====================================================================================

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.uspGetCuadreKardex', 'P') IS NOT NULL
	DROP PROCEDURE dbo.uspGetCuadreKardex;
GO

CREATE PROCEDURE dbo.uspGetCuadreKardex
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		ck.idCuadre,
		ck.codNivel,
		n.nivel,
		ck.codGrupo,
		g.grupo,
		ck.codTalla,
		ck.codColor,
		c.descripcion AS color,
		ck.tipoAjuste,
		CASE ck.tipoAjuste WHEN 'E' THEN 'SUMAR' ELSE 'RESTAR' END AS tipoAjusteDescripcion,
		ck.cantidad,
		ck.fechaMovimiento,
		ck.serieGR,
		ck.numeroGR,
		ck.secuenciaGR,
		ck.usuarioReg,
		ck.fechaReg
	FROM dbo.CuadreKardex ck
	INNER JOIN dbo.niveles n ON n.codNivel = ck.codNivel
	LEFT JOIN dbo.grupos g ON g.codNivel = ck.codNivel AND g.codGrupo = ck.codGrupo
	LEFT JOIN dbo.colores c ON c.codColor = ck.codColor
	ORDER BY ck.fechaReg DESC, ck.idCuadre DESC;
END
GO
