-- =====================================================================================
-- Transferencia entre Almacenes - Script 3 de 9: stock global del Kardex (cantidad)
-- =====================================================================================
-- Devuelve, por producto, el saldo de CANTIDAD del Kardex a una fecha de corte, con los
-- mismos origenes y filtros que usan uspGetkardexPrincipal / uspGetkardexPrincipalOs:
--
--   * Niveles por OC (todos menos 06,07,08,11,12,17): grCab/grDet tipoOrden 'C' + ocDet/ocCab.
--   * Niveles por OS (06,07,08,11,12,17): grCab/grDet tipoOrden 'S' + osDet/osCab, mas las
--     salidas por guias de exportacion (grCabExportacion/grDetExportacion).
--   * Solo cuentas con FlgMostrarKardex = 1 (en guias normales), mismas uniones INNER con
--     proveedor y catalogo, y la misma exclusion puntual de la guia 0003-2150.
--   * 'E' suma, cualquier otro tipo de movimiento resta (igual que el bucle del Kardex).
--
-- Es solo la parte de cantidades (no valoriza). Se usa para validar el stock disponible
-- del almacen central y para el reporte de stock por almacen.
--
-- Ademas devuelve codCuentaUltima: la cuenta contable del ultimo movimiento del producto,
-- que se usa por defecto en el detalle de la transferencia (el Kardex filtra por cuenta).
--
-- Filtros opcionales @codNivel / @codGrupo (NULL = todos), igual que el Kardex. Quien la
-- llama con variables debe usar OPTION (RECOMPILE) para que el filtro se aplique dentro de
-- cada rama y no recorra todo el Kardex. No filtrar con EXISTS/IN contra una tabla
-- variable: el plan se degrada (probado: > 2 minutos contra ~1 s con parametros).
-- =====================================================================================

SET NOCOUNT ON;
GO

CREATE OR ALTER FUNCTION dbo.ufnStockKardexGlobal (
	@fechaCorte	date,
	@codNivel	char(2),	-- NULL = todos
	@codGrupo	char(5)		-- NULL = todos
)
RETURNS TABLE
AS
RETURN
WITH movimientos AS (
	-- ---------------------------------------------------------------------------
	-- Niveles por Orden de Compra (logica de uspGetkardexPrincipal)
	-- ---------------------------------------------------------------------------
	SELECT	oc.codNivel, oc.codGrupo, oc.codTalla, oc.codColor,
			gr.codCuenta,
			grc.fechaEmision,
			gr.tipoMovimiento,
			ABS(gr.cantidadIngresada) AS cantidad,
			gr.serie, gr.numero
	FROM dbo.grCab grc
	INNER JOIN dbo.grDet gr ON gr.serie = grc.serie
							AND gr.numero = grc.numero
							AND gr.idEmpresa = grc.idEmpresa
							AND gr.destCodigoPC = grc.destCodigoPC
	LEFT JOIN dbo.ocDet oc ON gr.idEmpresa = oc.idEmpresa
							AND gr.idDet = oc.idOC
							AND gr.idSecuenciaDet = oc.secuencia
	LEFT JOIN dbo.facDet fact ON fact.grIdEmpresa = gr.idEmpresa
							AND fact.grSerie = gr.serie
							AND fact.grNumero = gr.numero
							AND fact.grSecuencia = gr.secuencia
							AND fact.grTipoOrden = gr.tipoOrden
							AND fact.codigoPC = grc.destCodigoPC
	INNER JOIN dbo.ocCab cab ON oc.idEmpresa = cab.idEmpresa
							AND oc.idOC = cab.idOC
	INNER JOIN dbo.provClientes pc ON IIF(gr.tipoMovimiento = 'E', cab.codigoPC, grc.destCodigoPC) = pc.codigo
	INNER JOIN dbo.productoServicios p ON oc.codNivel = p.codNivel
							AND oc.codGrupo = p.codGrupo
							AND oc.codTalla = p.codTalla
							AND oc.codColor = p.codColor
	INNER JOIN dbo.grupos g ON p.codNivel = g.codNivel AND p.codGrupo = g.codGrupo
	INNER JOIN dbo.niveles n ON g.codNivel = n.codNivel
	INNER JOIN dbo.tallas t ON p.codTalla = t.codTalla
	INNER JOIN dbo.colores c ON p.codColor = c.codColor
	WHERE grc.tipoOrden = 'C'
		AND n.codNivel NOT IN ('06', '07', '11', '12', '08', '17')
		AND grc.fechaEmision <= @fechaCorte
		AND (@codNivel IS NULL OR oc.codNivel = @codNivel)
		AND (@codGrupo IS NULL OR oc.codGrupo = @codGrupo)
		AND gr.codCuenta IN (SELECT codCuenta FROM dbo.cuentas WHERE estado = 1 AND FlgMostrarKardex = 1)

	UNION ALL

	-- ---------------------------------------------------------------------------
	-- Niveles por Orden de Servicio (logica de uspGetkardexPrincipalOs, guias)
	-- ---------------------------------------------------------------------------
	SELECT	oc.codNivel, oc.codGrupo, oc.codTalla, oc.codColor,
			gr.codCuenta,
			grc.fechaEmision,
			gr.tipoMovimiento,
			ABS(gr.cantidadIngresada),
			gr.serie, gr.numero
	FROM dbo.grCab grc
	INNER JOIN dbo.grDet gr ON gr.serie = grc.serie
							AND gr.numero = grc.numero
							AND gr.idEmpresa = grc.idEmpresa
							AND gr.destCodigoPC = grc.destCodigoPC
	LEFT JOIN dbo.osDet oc ON gr.idEmpresa = oc.idEmpresa
							AND gr.idDet = oc.idOs
							AND gr.idSecuenciaDet = oc.secuencia
	LEFT JOIN dbo.facDet fact ON fact.grIdEmpresa = gr.idEmpresa
							AND fact.grSerie = gr.serie
							AND fact.grNumero = gr.numero
							AND fact.grSecuencia = gr.secuencia
							AND fact.grTipoOrden = gr.tipoOrden
							AND fact.codigoPC = grc.destCodigoPC
	INNER JOIN dbo.osCab cab ON oc.idEmpresa = cab.idEmpresa
							AND oc.idOS = cab.idOS
	INNER JOIN dbo.provClientes pc ON IIF(gr.tipoMovimiento = 'E', cab.codigoPC, grc.destCodigoPC) = pc.codigo
	INNER JOIN dbo.productoServicios p ON oc.codNivel = p.codNivel
							AND oc.codGrupo = p.codGrupo
							AND oc.codTalla = p.codTalla
							AND oc.codColor = p.codColor
	INNER JOIN dbo.grupos g ON p.codNivel = g.codNivel AND p.codGrupo = g.codGrupo
	INNER JOIN dbo.niveles n ON g.codNivel = n.codNivel
	INNER JOIN dbo.tallas t ON p.codTalla = t.codTalla
	INNER JOIN dbo.colores c ON p.codColor = c.codColor
	WHERE grc.tipoOrden = 'S'
		AND n.codNivel IN ('06', '07', '11', '12', '08', '17')
		AND grc.fechaEmision <= @fechaCorte
		AND (@codNivel IS NULL OR oc.codNivel = @codNivel)
		AND (@codGrupo IS NULL OR oc.codGrupo = @codGrupo)
		AND gr.codCuenta IN (SELECT codCuenta FROM dbo.cuentas WHERE estado = 1 AND FlgMostrarKardex = 1)

	UNION ALL

	-- ---------------------------------------------------------------------------
	-- Salidas por guias de exportacion (logica de uspGetkardexPrincipalOs)
	-- ---------------------------------------------------------------------------
	SELECT	oc.codNivel, oc.codGrupo, oc.codTalla, oc.codColor,
			CAST(NULL AS varchar(10)),
			grc.fechaEmision,
			'S',
			ABS(gr.cantidadIngresada),
			gr.serie, gr.numero
	FROM dbo.grCabExportacion grc
	INNER JOIN dbo.grDetExportacion gr ON gr.serie = grc.serie
							AND gr.numero = grc.numero
							AND gr.idEmpresa = grc.idEmpresa
	LEFT JOIN dbo.TmpProductosCodigoExportacion tmp ON tmp.Serie = gr.Serie
							AND tmp.Numero = gr.numero
							AND TRIM(tmp.codSistema) = TRIM(gr.codProducto)
	LEFT JOIN dbo.colores col ON TRIM(col.descripcion) = tmp.Color
	LEFT JOIN dbo.grupos g ON g.codNivel = '07'
							AND SUBSTRING(g.grupo, CHARINDEX('SC-', g.grupo) + 3, CHARINDEX(' ', g.grupo + ' ', CHARINDEX('SC-', g.grupo) + 3) - CHARINDEX('SC-', g.grupo) - 3) = TRIM(tmp.Op)
	LEFT JOIN dbo.productoServicios p ON g.codNivel = p.codNivel
							AND g.codGrupo = p.codGrupo
							AND col.codColor = p.codColor
	LEFT JOIN dbo.osDet oc ON gr.idEmpresa = oc.idEmpresa
							AND oc.codNivel = p.codNivel
							AND oc.codGrupo = p.codGrupo
							AND oc.codTalla = p.codTalla
							AND oc.codColor = p.codColor
	INNER JOIN dbo.osCab cab ON oc.idEmpresa = cab.idEmpresa AND oc.idOS = cab.idOS
	INNER JOIN dbo.provClientes pc ON grc.destCodigoPC = pc.codigo
	INNER JOIN dbo.niveles n ON g.codNivel = n.codNivel
	INNER JOIN dbo.tallas t ON p.codTalla = t.codTalla
	INNER JOIN dbo.colores c ON p.codColor = c.codColor
	WHERE grc.fechaEmision <= @fechaCorte
		AND (@codNivel IS NULL OR oc.codNivel = @codNivel)
		AND (@codGrupo IS NULL OR oc.codGrupo = @codGrupo)
),
validos AS (
	SELECT *
	FROM movimientos
	-- misma exclusion puntual que hace el Kardex
	WHERE NOT (serie = '0003' AND TRY_CONVERT(int, numero) = 2150)
),
ultimaCuenta AS (
	SELECT	codNivel, codGrupo, codTalla, codColor, codCuenta,
			ROW_NUMBER() OVER (PARTITION BY codNivel, codGrupo, codTalla, codColor ORDER BY fechaEmision DESC) AS rn
	FROM validos
	WHERE codCuenta IS NOT NULL
)
SELECT	v.codNivel, v.codGrupo, v.codTalla, v.codColor,
		CAST(SUM(CASE WHEN v.tipoMovimiento = 'E' THEN v.cantidad ELSE -v.cantidad END) AS decimal(18,3)) AS Stock,
		MAX(v.fechaEmision) AS FechaUltimoMovimiento,
		MAX(u.codCuenta) AS codCuentaUltima
FROM validos v
LEFT JOIN ultimaCuenta u ON u.codNivel = v.codNivel
						AND u.codGrupo = v.codGrupo
						AND u.codTalla = v.codTalla
						AND u.codColor = v.codColor
						AND u.rn = 1
GROUP BY v.codNivel, v.codGrupo, v.codTalla, v.codColor;
GO
