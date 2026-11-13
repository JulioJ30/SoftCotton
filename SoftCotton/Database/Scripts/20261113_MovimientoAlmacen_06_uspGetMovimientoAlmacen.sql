-- =====================================================================================
-- Movimientos de Almacen - Script 6 de 8: procedimiento de consultas
-- =====================================================================================
-- @opcion = 1  Almacenes activos para los combos (excluye '999 DESPACHO / SALIDA').
-- @opcion = 2  Listado de movimientos (cabeceras) con filtros.
-- @opcion = 3  Detalle de un movimiento.
-- @opcion = 4  Lineas de guia despachadas con saldo pendiente de ingresar (buscador del
--              registro de INGRESO). Filtra por fecha de la guia y texto.
-- @opcion = 5  Productos con stock en un almacen a una fecha (buscador del registro de
--              SALIDA).
-- @opcion = 6  Reporte de stock por almacen tipo Kardex (solo cantidades): por almacen y
--              producto, saldo inicial + cada ingreso/salida del rango con su saldo.
--
-- Requiere el script 5.
-- =====================================================================================

SET NOCOUNT ON;
GO

CREATE OR ALTER PROCEDURE dbo.uspGetMovimientoAlmacen
	@opcion				int,
	@IdMovimiento		int			= NULL,
	@FechaIni			date		= NULL,
	@FechaFin			date		= NULL,
	@FechaCorte			date		= NULL,
	@CodAlmacen			varchar(3)	= NULL,	-- NULL o '' = todos
	@TipoMovimiento		char(1)		= NULL,	-- NULL o '' = todos
	@Estado				char(1)		= NULL,	-- NULL o '' = todos
	@codNivel			char(2)		= NULL,	-- NULL o '' = todos
	@Texto				varchar(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SET @CodAlmacen		= NULLIF(LTRIM(RTRIM(@CodAlmacen)), '');
	SET @TipoMovimiento	= NULLIF(LTRIM(RTRIM(@TipoMovimiento)), '');
	SET @Estado			= NULLIF(LTRIM(RTRIM(@Estado)), '');
	SET @codNivel		= NULLIF(LTRIM(RTRIM(@codNivel)), '');
	SET @Texto			= NULLIF(LTRIM(RTRIM(@Texto)), '');
	SET @FechaCorte		= ISNULL(@FechaCorte, CAST(GETDATE() AS date));

	-- ---------------------------------------------------------------------------
	-- 1) Almacenes
	-- ---------------------------------------------------------------------------
	IF @opcion = 1
	BEGIN
		SELECT	a.Codigo,
				a.Descripcion,
				a.tResumido
		FROM dbo.AreasAlmacen a
		WHERE a.lActivo = 1
			AND a.Codigo <> '999'
		ORDER BY a.Codigo;
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 2) Listado de movimientos
	-- ---------------------------------------------------------------------------
	IF @opcion = 2
	BEGIN
		SELECT	c.IdMovimiento,
				RIGHT('000000' + CAST(c.IdMovimiento AS varchar(10)), 6) AS Numero,
				c.TipoMovimiento,
				CASE c.TipoMovimiento WHEN 'I' THEN 'INGRESO' ELSE 'SALIDA' END AS TipoDescripcion,
				c.FechaMovimiento,
				c.CodAlmacen,
				a.Descripcion AS Almacen,
				ISNULL(det.Guias, '') AS Guias,
				ISNULL(c.Observacion, '') AS Observacion,
				c.Estado,
				CASE c.Estado WHEN 'A' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoDescripcion,
				det.Items,
				det.CantidadTotal,
				ur.usuario AS UsuarioRegistro,
				c.FechaRegistro,
				ISNULL(ua.usuario, '') AS UsuarioAnulacion,
				c.FechaAnulacion,
				ISNULL(c.MotivoAnulacion, '') AS MotivoAnulacion
		FROM dbo.MovimientoAlmacenCab c
		INNER JOIN dbo.AreasAlmacen a ON a.Codigo = c.CodAlmacen
		INNER JOIN dbo.usuarios ur ON ur.id = c.IdUsuarioRegistro
		LEFT JOIN dbo.usuarios ua ON ua.id = c.IdUsuarioAnulacion
		CROSS APPLY (
			SELECT	COUNT(*) AS Items,
					CAST(ISNULL(SUM(d.Cantidad), 0) AS decimal(18,3)) AS CantidadTotal,
					(SELECT STRING_AGG(CONVERT(varchar(max), g.Guia), ', ')
					 FROM (SELECT DISTINCT RTRIM(d2.grSerie) + '-' + RTRIM(d2.grNumero) AS Guia
						   FROM dbo.MovimientoAlmacenDet d2
						   WHERE d2.IdMovimiento = c.IdMovimiento AND d2.grSerie IS NOT NULL) g) AS Guias
			FROM dbo.MovimientoAlmacenDet d
			WHERE d.IdMovimiento = c.IdMovimiento
		) det
		WHERE (@FechaIni IS NULL OR c.FechaMovimiento >= @FechaIni)
			AND (@FechaFin IS NULL OR c.FechaMovimiento <= @FechaFin)
			AND (@CodAlmacen IS NULL OR c.CodAlmacen = @CodAlmacen)
			AND (@TipoMovimiento IS NULL OR c.TipoMovimiento = @TipoMovimiento)
			AND (@Estado IS NULL OR c.Estado = @Estado)
			AND (@Texto IS NULL
				OR RIGHT('000000' + CAST(c.IdMovimiento AS varchar(10)), 6) LIKE '%' + @Texto + '%'
				OR c.Observacion LIKE '%' + @Texto + '%'
				OR EXISTS (
					SELECT 1
					FROM dbo.MovimientoAlmacenDet d
					INNER JOIN dbo.grupos g ON g.codNivel = d.codNivel AND g.codGrupo = d.codGrupo
					WHERE d.IdMovimiento = c.IdMovimiento
						AND (g.grupo LIKE '%' + @Texto + '%'
							OR (d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor) LIKE '%' + @Texto + '%'
							OR (RTRIM(d.grSerie) + '-' + RTRIM(d.grNumero)) LIKE '%' + @Texto + '%')
				))
		ORDER BY c.FechaMovimiento DESC, c.IdMovimiento DESC;
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 3) Detalle de un movimiento
	-- ---------------------------------------------------------------------------
	IF @opcion = 3
	BEGIN
		SELECT	d.IdMovimientoDet,
				d.IdMovimiento,
				d.codNivel, d.codGrupo, d.codTalla, d.codColor,
				(d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor) AS Codigo,
				n.nivel AS Nivel,
				RTRIM(LTRIM(g.grupo)) AS Articulo,
				t.descripcion AS Talla,
				co.descripcion AS Color,
				g.codUM AS UM,
				d.Cantidad,
				ISNULL(RTRIM(d.grSerie) + '-' + RTRIM(d.grNumero), '') AS Guia,
				grc.fechaEmision AS FechaGuia,
				ISNULL(RTRIM(pc.razonSocial), '') AS Destinatario,
				ISNULL(d.Comentario, '') AS Comentario
		FROM dbo.MovimientoAlmacenDet d
		INNER JOIN dbo.grupos g ON g.codNivel = d.codNivel AND g.codGrupo = d.codGrupo
		INNER JOIN dbo.niveles n ON n.codNivel = d.codNivel
		INNER JOIN dbo.tallas t ON t.codTalla = d.codTalla
		INNER JOIN dbo.colores co ON co.codColor = d.codColor
		LEFT JOIN dbo.grCab grc ON grc.idEmpresa = d.grIdEmpresa
								AND grc.serie = d.grSerie
								AND grc.numero = d.grNumero
								AND grc.destCodigoPC = d.grDestCodigoPC
		LEFT JOIN dbo.provClientes pc ON pc.codigo = d.grDestCodigoPC
		WHERE d.IdMovimiento = @IdMovimiento
		ORDER BY d.IdMovimientoDet;
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 4) Lineas de guia despachadas pendientes de ingresar (buscador de ingresos)
	-- ---------------------------------------------------------------------------
	IF @opcion = 4
	BEGIN
		SELECT TOP (500)
				x.grIdEmpresa, x.grSerie, x.grNumero, x.grDestCodigoPC, x.grSecuencia, x.grTipoOrden,
				RTRIM(x.grSerie) + '-' + RTRIM(x.grNumero) AS Guia,
				x.FechaGuia,
				ISNULL(RTRIM(pc.razonSocial), '') AS Destinatario,
				x.codNivel, x.codGrupo, x.codTalla, x.codColor,
				(x.codNivel + '.' + x.codGrupo + '.' + x.codTalla + '.' + x.codColor) AS Codigo,
				n.nivel AS Nivel,
				RTRIM(LTRIM(g.grupo)) AS Articulo,
				t.descripcion AS Talla,
				co.descripcion AS Color,
				g.codUM AS UM,
				x.Despachado,
				x.Ingresado,
				x.Pendiente
		FROM dbo.ufnGuiaDespachoAlmacen() x
		INNER JOIN dbo.grupos g ON g.codNivel = x.codNivel AND g.codGrupo = x.codGrupo
		INNER JOIN dbo.niveles n ON n.codNivel = x.codNivel
		INNER JOIN dbo.tallas t ON t.codTalla = x.codTalla
		INNER JOIN dbo.colores co ON co.codColor = x.codColor
		LEFT JOIN dbo.provClientes pc ON pc.codigo = x.grDestCodigoPC
		WHERE x.Pendiente > 0
			AND (@FechaIni IS NULL OR x.FechaGuia >= @FechaIni)
			AND (@FechaFin IS NULL OR x.FechaGuia <= @FechaFin)
			AND (@codNivel IS NULL OR x.codNivel = @codNivel)
			AND (@Texto IS NULL
				OR (RTRIM(x.grSerie) + '-' + RTRIM(x.grNumero)) LIKE '%' + @Texto + '%'
				OR x.grNumero LIKE '%' + @Texto + '%'
				OR pc.razonSocial LIKE '%' + @Texto + '%'
				OR g.grupo LIKE '%' + @Texto + '%'
				OR co.descripcion LIKE '%' + @Texto + '%'
				OR (x.codNivel + '.' + x.codGrupo + '.' + x.codTalla + '.' + x.codColor) LIKE '%' + @Texto + '%')
		ORDER BY x.FechaGuia DESC, x.grSerie, x.grNumero, x.grSecuencia
		OPTION (RECOMPILE);
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 5) Productos con stock en un almacen (buscador de salidas)
	-- ---------------------------------------------------------------------------
	IF @opcion = 5
	BEGIN
		;WITH stock AS (
			SELECT	d.codNivel, d.codGrupo, d.codTalla, d.codColor,
					CAST(SUM(CASE c.TipoMovimiento WHEN 'I' THEN d.Cantidad ELSE -d.Cantidad END) AS decimal(18,3)) AS Stock
			FROM dbo.MovimientoAlmacenCab c
			INNER JOIN dbo.MovimientoAlmacenDet d ON d.IdMovimiento = c.IdMovimiento
			WHERE c.Estado = 'A'
				AND c.CodAlmacen = @CodAlmacen
				AND c.FechaMovimiento <= @FechaCorte
				AND (@codNivel IS NULL OR d.codNivel = @codNivel)
			GROUP BY d.codNivel, d.codGrupo, d.codTalla, d.codColor
		)
		SELECT TOP (500)
				s.codNivel, s.codGrupo, s.codTalla, s.codColor,
				(s.codNivel + '.' + s.codGrupo + '.' + s.codTalla + '.' + s.codColor) AS Codigo,
				n.nivel AS Nivel,
				RTRIM(LTRIM(g.grupo)) AS Articulo,
				t.descripcion AS Talla,
				co.descripcion AS Color,
				g.codUM AS UM,
				s.Stock
		FROM stock s
		INNER JOIN dbo.grupos g ON g.codNivel = s.codNivel AND g.codGrupo = s.codGrupo
		INNER JOIN dbo.niveles n ON n.codNivel = s.codNivel
		INNER JOIN dbo.tallas t ON t.codTalla = s.codTalla
		INNER JOIN dbo.colores co ON co.codColor = s.codColor
		WHERE s.Stock > 0
			AND (@Texto IS NULL
				OR g.grupo LIKE '%' + @Texto + '%'
				OR co.descripcion LIKE '%' + @Texto + '%'
				OR (s.codNivel + '.' + s.codGrupo + '.' + s.codTalla + '.' + s.codColor) LIKE '%' + @Texto + '%')
		ORDER BY g.grupo, t.descripcion, co.descripcion;
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 6) Reporte de stock por almacen tipo Kardex (solo cantidades)
	--    Por almacen + producto:
	--      * fila SALDO INICIAL con lo acumulado antes de @FechaIni (si es distinto de 0)
	--      * una fila por cada ingreso / salida activo entre @FechaIni y @FechaFin
	--      * Saldo: stock acumulado despues de cada fila (la ultima fila = stock final)
	-- ---------------------------------------------------------------------------
	IF @opcion = 6
	BEGIN
		SET @FechaFin = ISNULL(@FechaFin, CAST(GETDATE() AS date));

		SELECT	c.CodAlmacen,
				d.codNivel, d.codGrupo, d.codTalla, d.codColor,
				c.FechaMovimiento,
				c.IdMovimiento,
				d.IdMovimientoDet,
				c.TipoMovimiento,
				d.Cantidad,
				CASE c.TipoMovimiento WHEN 'I' THEN d.Cantidad ELSE -d.Cantidad END AS Neto,
				d.grIdEmpresa, d.grSerie, d.grNumero, d.grDestCodigoPC,
				LTRIM(RTRIM(ISNULL(c.Observacion, '') + CASE WHEN d.Comentario IS NULL THEN '' ELSE ' / ' + d.Comentario END)) AS Observacion
		INTO #mov
		FROM dbo.MovimientoAlmacenCab c
		INNER JOIN dbo.MovimientoAlmacenDet d ON d.IdMovimiento = c.IdMovimiento
		INNER JOIN dbo.grupos g ON g.codNivel = d.codNivel AND g.codGrupo = d.codGrupo
		INNER JOIN dbo.colores co ON co.codColor = d.codColor
		WHERE c.Estado = 'A'
			AND c.FechaMovimiento <= @FechaFin
			AND (@CodAlmacen IS NULL OR c.CodAlmacen = @CodAlmacen)
			AND (@codNivel IS NULL OR d.codNivel = @codNivel)
			AND (@Texto IS NULL
				OR g.grupo LIKE '%' + @Texto + '%'
				OR co.descripcion LIKE '%' + @Texto + '%'
				OR (d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor) LIKE '%' + @Texto + '%');

		;WITH saldoInicial AS (
			SELECT	CodAlmacen, codNivel, codGrupo, codTalla, codColor,
					CAST(SUM(Neto) AS decimal(18,3)) AS Saldo
			FROM #mov
			WHERE @FechaIni IS NOT NULL AND FechaMovimiento < @FechaIni
			GROUP BY CodAlmacen, codNivel, codGrupo, codTalla, codColor
		),
		filas AS (
			-- saldo inicial
			SELECT	s.CodAlmacen, s.codNivel, s.codGrupo, s.codTalla, s.codColor,
					0 AS Orden,
					@FechaIni AS Fecha,
					'SI' AS TipoFila,
					CAST(NULL AS int) AS IdMovimiento,
					CAST(NULL AS int) AS grIdEmpresa,
					CAST(NULL AS varchar(50)) AS grSerie,
					CAST(NULL AS varchar(50)) AS grNumero,
					CAST(NULL AS varchar(100)) AS grDestCodigoPC,
					CAST('' AS varchar(800)) AS Observacion,
					CAST(0 AS decimal(18,3)) AS Ingreso,
					CAST(0 AS decimal(18,3)) AS Salida,
					s.Saldo AS Neto
			FROM saldoInicial s
			WHERE s.Saldo <> 0

			UNION ALL

			-- movimientos del rango
			SELECT	m.CodAlmacen, m.codNivel, m.codGrupo, m.codTalla, m.codColor,
					ROW_NUMBER() OVER (PARTITION BY m.CodAlmacen, m.codNivel, m.codGrupo, m.codTalla, m.codColor
									   ORDER BY m.FechaMovimiento, m.IdMovimiento, m.IdMovimientoDet),
					m.FechaMovimiento,
					m.TipoMovimiento,
					m.IdMovimiento,
					m.grIdEmpresa, m.grSerie, m.grNumero, m.grDestCodigoPC,
					CAST(m.Observacion AS varchar(800)),
					CASE m.TipoMovimiento WHEN 'I' THEN m.Cantidad ELSE 0 END,
					CASE m.TipoMovimiento WHEN 'S' THEN m.Cantidad ELSE 0 END,
					m.Neto
			FROM #mov m
			WHERE @FechaIni IS NULL OR m.FechaMovimiento >= @FechaIni
		),
		conSaldo AS (
			SELECT	f.*,
					CAST(SUM(f.Neto) OVER (PARTITION BY f.CodAlmacen, f.codNivel, f.codGrupo, f.codTalla, f.codColor
										   ORDER BY f.Orden ROWS UNBOUNDED PRECEDING) AS decimal(18,3)) AS Saldo,
					CASE WHEN f.Orden = MAX(f.Orden) OVER (PARTITION BY f.CodAlmacen, f.codNivel, f.codGrupo, f.codTalla, f.codColor)
						 THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END AS EsUltima
			FROM filas f
		)
		SELECT	x.CodAlmacen,
				a.Descripcion AS Almacen,
				x.codNivel, x.codGrupo, x.codTalla, x.codColor,
				(x.codNivel + '.' + x.codGrupo + '.' + x.codTalla + '.' + x.codColor) AS Codigo,
				n.nivel AS Nivel,
				RTRIM(LTRIM(g.grupo)) AS Articulo,
				t.descripcion AS Talla,
				co.descripcion AS Color,
				g.codUM AS UM,
				x.Orden,
				x.Fecha,
				x.TipoFila,
				CASE x.TipoFila WHEN 'SI' THEN 'SALDO INICIAL' WHEN 'I' THEN 'INGRESO' ELSE 'SALIDA' END AS Movimiento,
				ISNULL(RIGHT('000000' + CAST(x.IdMovimiento AS varchar(10)), 6), '') AS Numero,
				ISNULL(RTRIM(x.grSerie) + '-' + RTRIM(x.grNumero), '') AS Guia,
				ISNULL(RTRIM(pc.razonSocial), '') AS Destinatario,
				x.Observacion,
				x.Ingreso,
				x.Salida,
				x.Saldo,
				x.EsUltima
		FROM conSaldo x
		INNER JOIN dbo.AreasAlmacen a ON a.Codigo = x.CodAlmacen
		INNER JOIN dbo.grupos g ON g.codNivel = x.codNivel AND g.codGrupo = x.codGrupo
		INNER JOIN dbo.niveles n ON n.codNivel = x.codNivel
		INNER JOIN dbo.tallas t ON t.codTalla = x.codTalla
		INNER JOIN dbo.colores co ON co.codColor = x.codColor
		LEFT JOIN dbo.provClientes pc ON pc.codigo = x.grDestCodigoPC
		ORDER BY a.Descripcion, g.grupo, t.descripcion, co.descripcion, x.codNivel, x.codGrupo, x.codTalla, x.codColor, x.Orden;

		DROP TABLE #mov;
		RETURN;
	END
END
GO
