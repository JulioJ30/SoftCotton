-- =====================================================================================
-- Transferencia entre Almacenes - Script 4 de 9: stock por almacen
-- =====================================================================================
-- Devuelve el stock (cantidad) por almacen y producto a una fecha de corte:
--
--   * Almacenes distintos de '000': solo se alimentan de transferencias activas
--       stock = ingresos (es destino) - salidas (es origen)
--
--   * Almacen '000' (ALMACEN CENTRAL, principal): es todo lo que esta en el Kardex y no
--     fue movido a otro almacen
--       stock = stock global del Kardex (dbo.ufnStockKardexGlobal)
--               + devoluciones recibidas - transferencias enviadas
--
-- Las transferencias NO cambian el stock global del Kardex (ver scripts 7 y 8: salen y
-- entran por la misma cantidad y al mismo costo promedio). Por eso, cuando un producto que
-- esta en otro almacen se despacha con una guia normal, primero debe devolverse al almacen
-- central; si no, el central quedaria en negativo (lo valida uspSetTransferenciaAlmacen y
-- lo muestra el reporte de stock).
--
-- codCuenta: cuenta contable con la que se mueve el producto (el Kardex filtra por cuenta).
--   central     -> la del ultimo movimiento del producto en el Kardex
--   secundarios -> la usada en sus transferencias
--
-- Filtros opcionales @codNivel / @codGrupo (NULL = todos). Usar OPTION (RECOMPILE) al
-- llamarla con variables (ver script 3).
--
-- Requiere los scripts 2 y 3.
-- =====================================================================================

SET NOCOUNT ON;
GO

CREATE OR ALTER FUNCTION dbo.ufnStockAlmacen (
	@fechaCorte	date,
	@codNivel	char(2),	-- NULL = todos
	@codGrupo	char(5)		-- NULL = todos
)
RETURNS TABLE
AS
RETURN
WITH movimientos AS (
	-- ingresos al almacen destino
	SELECT	c.CodAlmacenDestino AS CodAlmacen,
			d.codNivel, d.codGrupo, d.codTalla, d.codColor,
			d.Cantidad AS Cantidad,
			d.codCuenta,
			c.FechaTransferencia
	FROM dbo.TransferenciaAlmacenCab c
	INNER JOIN dbo.TransferenciaAlmacenDet d ON d.IdTransferencia = c.IdTransferencia
	WHERE c.Estado = 'A' AND c.FechaTransferencia <= @fechaCorte
		AND (@codNivel IS NULL OR d.codNivel = @codNivel)
		AND (@codGrupo IS NULL OR d.codGrupo = @codGrupo)

	UNION ALL

	-- salidas del almacen origen
	SELECT	c.CodAlmacenOrigen,
			d.codNivel, d.codGrupo, d.codTalla, d.codColor,
			-d.Cantidad,
			d.codCuenta,
			c.FechaTransferencia
	FROM dbo.TransferenciaAlmacenCab c
	INNER JOIN dbo.TransferenciaAlmacenDet d ON d.IdTransferencia = c.IdTransferencia
	WHERE c.Estado = 'A' AND c.FechaTransferencia <= @fechaCorte
		AND (@codNivel IS NULL OR d.codNivel = @codNivel)
		AND (@codGrupo IS NULL OR d.codGrupo = @codGrupo)
),
porAlmacen AS (
	SELECT	CodAlmacen, codNivel, codGrupo, codTalla, codColor,
			SUM(Cantidad) AS Stock,
			MAX(FechaTransferencia) AS FechaUltimoMovimiento,
			MAX(codCuenta) AS codCuenta
	FROM movimientos
	GROUP BY CodAlmacen, codNivel, codGrupo, codTalla, codColor
)
-- Almacenes secundarios
SELECT	CodAlmacen, codNivel, codGrupo, codTalla, codColor,
		CAST(Stock AS decimal(18,3)) AS Stock,
		FechaUltimoMovimiento,
		CAST(codCuenta AS char(10)) AS codCuenta
FROM porAlmacen
WHERE CodAlmacen <> '000'

UNION ALL

-- Almacen central = Kardex global +/- transferencias que lo tocan
SELECT	'000',
		COALESCE(k.codNivel, t.codNivel),
		COALESCE(k.codGrupo, t.codGrupo),
		COALESCE(k.codTalla, t.codTalla),
		COALESCE(k.codColor, t.codColor),
		CAST(ISNULL(k.Stock, 0) + ISNULL(t.Stock, 0) AS decimal(18,3)),
		CASE WHEN t.FechaUltimoMovimiento > k.FechaUltimoMovimiento OR k.FechaUltimoMovimiento IS NULL
			 THEN t.FechaUltimoMovimiento ELSE k.FechaUltimoMovimiento END,
		CAST(COALESCE(k.codCuentaUltima, t.codCuenta) AS char(10))
FROM dbo.ufnStockKardexGlobal(@fechaCorte, @codNivel, @codGrupo) k
FULL OUTER JOIN (SELECT * FROM porAlmacen WHERE CodAlmacen = '000') t
	ON  t.codNivel = k.codNivel
	AND t.codGrupo = k.codGrupo
	AND t.codTalla = k.codTalla
	AND t.codColor = k.codColor;
GO
