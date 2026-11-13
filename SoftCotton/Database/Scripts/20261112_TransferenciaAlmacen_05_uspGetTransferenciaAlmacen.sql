-- =====================================================================================
-- Transferencia entre Almacenes - Script 5 de 9: procedimiento de consultas
-- =====================================================================================
-- @opcion = 1  Almacenes activos para los combos (excluye '999 DESPACHO / SALIDA': los
--              despachos se hacen con guia de remision normal).
-- @opcion = 2  Listado de transferencias (cabeceras) con filtros.
-- @opcion = 3  Detalle de una transferencia.
-- @opcion = 4  Productos con stock disponible en un almacen a una fecha (buscador del
--              formulario de registro).
-- @opcion = 5  Reporte de stock por almacen.
--
-- Requiere los scripts 2, 3 y 4.
-- =====================================================================================

SET NOCOUNT ON;
GO

CREATE OR ALTER PROCEDURE dbo.uspGetTransferenciaAlmacen
	@opcion				int,
	@IdTransferencia	int			= NULL,
	@FechaIni			date		= NULL,
	@FechaFin			date		= NULL,
	@FechaCorte			date		= NULL,
	@CodAlmacen			varchar(3)	= NULL,	-- NULL o '' = todos
	@Estado				char(1)		= NULL,	-- NULL o '' = todos
	@codNivel			char(2)		= NULL,	-- NULL o '' = todos
	@Texto				varchar(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SET @CodAlmacen = NULLIF(LTRIM(RTRIM(@CodAlmacen)), '');
	SET @Estado		= NULLIF(LTRIM(RTRIM(@Estado)), '');
	SET @codNivel	= NULLIF(LTRIM(RTRIM(@codNivel)), '');
	SET @Texto		= NULLIF(LTRIM(RTRIM(@Texto)), '');
	SET @FechaCorte = ISNULL(@FechaCorte, CAST(GETDATE() AS date));

	-- ---------------------------------------------------------------------------
	-- 1) Almacenes
	-- ---------------------------------------------------------------------------
	IF @opcion = 1
	BEGIN
		SELECT	a.Codigo,
				a.Descripcion,
				a.tResumido,
				CAST(CASE WHEN a.Codigo = '000' THEN 1 ELSE 0 END AS bit) AS EsCentral
		FROM dbo.AreasAlmacen a
		WHERE a.lActivo = 1
			AND a.Codigo <> '999'
		ORDER BY a.Codigo;
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 2) Listado de transferencias
	-- ---------------------------------------------------------------------------
	IF @opcion = 2
	BEGIN
		SELECT	c.IdTransferencia,
				RIGHT('000000' + CAST(c.IdTransferencia AS varchar(10)), 6) AS Numero,
				c.TipoTransferencia,
				CASE c.TipoTransferencia WHEN 'D' THEN 'DEVOLUCION' ELSE 'TRANSFERENCIA' END AS TipoDescripcion,
				c.FechaTransferencia,
				c.CodAlmacenOrigen,
				ao.Descripcion AS AlmacenOrigen,
				c.CodAlmacenDestino,
				ad.Descripcion AS AlmacenDestino,
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
		FROM dbo.TransferenciaAlmacenCab c
		INNER JOIN dbo.AreasAlmacen ao ON ao.Codigo = c.CodAlmacenOrigen
		INNER JOIN dbo.AreasAlmacen ad ON ad.Codigo = c.CodAlmacenDestino
		INNER JOIN dbo.usuarios ur ON ur.id = c.IdUsuarioRegistro
		LEFT JOIN dbo.usuarios ua ON ua.id = c.IdUsuarioAnulacion
		CROSS APPLY (
			SELECT	COUNT(*) AS Items,
					CAST(ISNULL(SUM(d.Cantidad), 0) AS decimal(18,3)) AS CantidadTotal
			FROM dbo.TransferenciaAlmacenDet d
			WHERE d.IdTransferencia = c.IdTransferencia
		) det
		WHERE (@FechaIni IS NULL OR c.FechaTransferencia >= @FechaIni)
			AND (@FechaFin IS NULL OR c.FechaTransferencia <= @FechaFin)
			AND (@CodAlmacen IS NULL OR c.CodAlmacenOrigen = @CodAlmacen OR c.CodAlmacenDestino = @CodAlmacen)
			AND (@Estado IS NULL OR c.Estado = @Estado)
			AND (@Texto IS NULL
				OR RIGHT('000000' + CAST(c.IdTransferencia AS varchar(10)), 6) LIKE '%' + @Texto + '%'
				OR c.Observacion LIKE '%' + @Texto + '%'
				OR EXISTS (
					SELECT 1
					FROM dbo.TransferenciaAlmacenDet d
					INNER JOIN dbo.grupos g ON g.codNivel = d.codNivel AND g.codGrupo = d.codGrupo
					WHERE d.IdTransferencia = c.IdTransferencia
						AND (g.grupo LIKE '%' + @Texto + '%'
							OR (d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor) LIKE '%' + @Texto + '%')
				))
		ORDER BY c.FechaTransferencia DESC, c.IdTransferencia DESC;
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 3) Detalle de una transferencia
	-- ---------------------------------------------------------------------------
	IF @opcion = 3
	BEGIN
		SELECT	d.IdTransferenciaDet,
				d.IdTransferencia,
				d.codNivel, d.codGrupo, d.codTalla, d.codColor,
				(d.codNivel + '.' + d.codGrupo + '.' + d.codTalla + '.' + d.codColor) AS Codigo,
				n.nivel AS Nivel,
				RTRIM(LTRIM(g.grupo)) AS Articulo,
				t.descripcion AS Talla,
				co.descripcion AS Color,
				g.codUM AS UM,
				d.codCuenta,
				d.Cantidad,
				ISNULL(d.Comentario, '') AS Comentario
		FROM dbo.TransferenciaAlmacenDet d
		INNER JOIN dbo.grupos g ON g.codNivel = d.codNivel AND g.codGrupo = d.codGrupo
		INNER JOIN dbo.niveles n ON n.codNivel = d.codNivel
		INNER JOIN dbo.tallas t ON t.codTalla = d.codTalla
		INNER JOIN dbo.colores co ON co.codColor = d.codColor
		WHERE d.IdTransferencia = @IdTransferencia
		ORDER BY d.IdTransferenciaDet;
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 4) Productos con stock disponible en un almacen (buscador)
	-- ---------------------------------------------------------------------------
	IF @opcion = 4
	BEGIN
		SELECT TOP (500)
				s.codNivel, s.codGrupo, s.codTalla, s.codColor,
				(s.codNivel + '.' + s.codGrupo + '.' + s.codTalla + '.' + s.codColor) AS Codigo,
				n.nivel AS Nivel,
				RTRIM(LTRIM(g.grupo)) AS Articulo,
				t.descripcion AS Talla,
				co.descripcion AS Color,
				g.codUM AS UM,
				s.Stock,
				s.codCuenta
		FROM dbo.ufnStockAlmacen(@FechaCorte, @codNivel, NULL) s
		INNER JOIN dbo.grupos g ON g.codNivel = s.codNivel AND g.codGrupo = s.codGrupo
		INNER JOIN dbo.niveles n ON n.codNivel = s.codNivel
		INNER JOIN dbo.tallas t ON t.codTalla = s.codTalla
		INNER JOIN dbo.colores co ON co.codColor = s.codColor
		WHERE s.CodAlmacen = @CodAlmacen
			AND s.Stock > 0
			AND (@codNivel IS NULL OR s.codNivel = @codNivel)
			AND (@Texto IS NULL
				OR g.grupo LIKE '%' + @Texto + '%'
				OR co.descripcion LIKE '%' + @Texto + '%'
				OR (s.codNivel + '.' + s.codGrupo + '.' + s.codTalla + '.' + s.codColor) LIKE '%' + @Texto + '%')
		ORDER BY g.grupo, t.descripcion, co.descripcion
		OPTION (RECOMPILE);	-- aplica los filtros dentro del calculo del Kardex (ver script 3)
		RETURN;
	END

	-- ---------------------------------------------------------------------------
	-- 5) Reporte de stock por almacen
	--    Sin @CodAlmacen: todos los almacenes secundarios (el central solo si se pide,
	--    porque es todo el Kardex).
	--    StockCentral: stock del mismo producto en el almacen central, para detectar
	--    sobrantes que se despacharon con guia sin devolverlos antes (central negativo).
	-- ---------------------------------------------------------------------------
	IF @opcion = 5
	BEGIN
		-- Se evalua el stock UNA sola vez (el central implica recorrer el Kardex)
		SELECT	s.CodAlmacen, s.codNivel, s.codGrupo, s.codTalla, s.codColor, s.Stock, s.FechaUltimoMovimiento
		INTO #todo
		FROM dbo.ufnStockAlmacen(@FechaCorte, @codNivel, NULL) s
		OPTION (RECOMPILE);	-- aplica los filtros dentro del calculo del Kardex (ver script 3)

		SELECT	s.CodAlmacen,
				a.Descripcion AS Almacen,
				s.codNivel, s.codGrupo, s.codTalla, s.codColor,
				(s.codNivel + '.' + s.codGrupo + '.' + s.codTalla + '.' + s.codColor) AS Codigo,
				n.nivel AS Nivel,
				RTRIM(LTRIM(g.grupo)) AS Articulo,
				t.descripcion AS Talla,
				co.descripcion AS Color,
				g.codUM AS UM,
				s.Stock,
				CAST(ISNULL(central.Stock, 0) AS decimal(18,3)) AS StockCentral,
				s.FechaUltimoMovimiento
		FROM #todo s
		INNER JOIN dbo.AreasAlmacen a ON a.Codigo = s.CodAlmacen
		INNER JOIN dbo.grupos g ON g.codNivel = s.codNivel AND g.codGrupo = s.codGrupo
		INNER JOIN dbo.niveles n ON n.codNivel = s.codNivel
		INNER JOIN dbo.tallas t ON t.codTalla = s.codTalla
		INNER JOIN dbo.colores co ON co.codColor = s.codColor
		LEFT JOIN #todo central ON central.CodAlmacen = '000'
								AND central.codNivel = s.codNivel AND central.codGrupo = s.codGrupo
								AND central.codTalla = s.codTalla AND central.codColor = s.codColor
		WHERE s.Stock <> 0
			AND ((@CodAlmacen IS NULL AND s.CodAlmacen <> '000') OR s.CodAlmacen = @CodAlmacen)
			AND (@Texto IS NULL
				OR g.grupo LIKE '%' + @Texto + '%'
				OR co.descripcion LIKE '%' + @Texto + '%'
				OR (s.codNivel + '.' + s.codGrupo + '.' + s.codTalla + '.' + s.codColor) LIKE '%' + @Texto + '%')
		ORDER BY a.Descripcion, g.grupo, t.descripcion, co.descripcion;

		DROP TABLE #todo;
		RETURN;
	END
END
GO
