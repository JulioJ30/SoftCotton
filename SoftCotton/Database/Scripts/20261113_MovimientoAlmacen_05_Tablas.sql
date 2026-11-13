-- =====================================================================================
-- Movimientos de Almacen - Script 5 de 8: tablas, tipo tabla (TVP) y funcion de despachos
-- =====================================================================================
-- Modelo:
--
--   AreasAlmacen (Codigo PK)
--        ^
--        |  FK CodAlmacen
--   MovimientoAlmacenCab (IdMovimiento PK identity)
--        ^
--        |  FK IdMovimiento
--   MovimientoAlmacenDet (IdMovimientoDet PK identity)
--        |-- FK producto -> productoServicios (nivel/grupo/talla/color)
--        |-- referencia a la linea de guia despachada (grDet): solo en ingresos
--
-- Reglas de negocio:
--   * TipoMovimiento 'I' INGRESO: devolucion de stock DESPACHADO con guia de remision
--     (grDet con tipoMovimiento 'S'). Cada linea referencia la linea de guia de la que sale
--     y no puede superar lo despachado menos lo ya ingresado de esa misma linea.
--   * TipoMovimiento 'S' SALIDA: despacho de stock de un almacen. Solo puede salir lo que
--     entro a ese almacen por ingresos (el saldo del almacen nunca queda negativo).
--   * Ya no hay transferencias entre almacenes.
--   * Estos movimientos NO se muestran en el Kardex ni lo afectan: es un control de stock
--     por almacen, solo cantidades (sin precio).
--   * Estado: 'A' activo, 'N' anulado. No se borran registros: se anulan (trazabilidad).
--   * La cantidad usa el mismo tipo que grDet.cantidadIngresada (decimal(12,3)).
--
-- Requiere el script 4 (PK de AreasAlmacen).
-- Idempotente.
-- =====================================================================================

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.MovimientoAlmacenCab', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.MovimientoAlmacenCab (
		IdMovimiento		int IDENTITY(1,1)	NOT NULL,
		TipoMovimiento		char(1)				NOT NULL,
		FechaMovimiento		date				NOT NULL,
		CodAlmacen			varchar(3)			NOT NULL,
		Observacion			varchar(500)		NULL,
		Estado				char(1)				NOT NULL CONSTRAINT DF_MovimientoAlmacenCab_Estado DEFAULT ('A'),
		IdUsuarioRegistro	int					NOT NULL,
		FechaRegistro		datetime			NOT NULL CONSTRAINT DF_MovimientoAlmacenCab_FechaRegistro DEFAULT (GETDATE()),
		IdUsuarioAnulacion	int					NULL,
		FechaAnulacion		datetime			NULL,
		MotivoAnulacion		varchar(250)		NULL,

		CONSTRAINT PK_MovimientoAlmacenCab PRIMARY KEY CLUSTERED (IdMovimiento),
		CONSTRAINT FK_MovimientoAlmacenCab_Almacen FOREIGN KEY (CodAlmacen) REFERENCES dbo.AreasAlmacen (Codigo),
		CONSTRAINT FK_MovimientoAlmacenCab_UsuarioRegistro  FOREIGN KEY (IdUsuarioRegistro)  REFERENCES dbo.usuarios (id),
		CONSTRAINT FK_MovimientoAlmacenCab_UsuarioAnulacion FOREIGN KEY (IdUsuarioAnulacion) REFERENCES dbo.usuarios (id),
		CONSTRAINT CK_MovimientoAlmacenCab_Tipo   CHECK (TipoMovimiento IN ('I', 'S')),
		CONSTRAINT CK_MovimientoAlmacenCab_Estado CHECK (Estado IN ('A', 'N')),
		CONSTRAINT CK_MovimientoAlmacenCab_Anulacion CHECK (
			(Estado = 'A' AND IdUsuarioAnulacion IS NULL AND FechaAnulacion IS NULL)
			OR (Estado = 'N' AND IdUsuarioAnulacion IS NOT NULL AND FechaAnulacion IS NOT NULL)
		)
	);

	CREATE NONCLUSTERED INDEX IX_MovimientoAlmacenCab_Fecha
		ON dbo.MovimientoAlmacenCab (FechaMovimiento, Estado)
		INCLUDE (CodAlmacen, TipoMovimiento);

	CREATE NONCLUSTERED INDEX IX_MovimientoAlmacenCab_Almacen
		ON dbo.MovimientoAlmacenCab (CodAlmacen, Estado)
		INCLUDE (FechaMovimiento, TipoMovimiento);
END
GO

IF OBJECT_ID('dbo.MovimientoAlmacenDet', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.MovimientoAlmacenDet (
		IdMovimientoDet		int IDENTITY(1,1)	NOT NULL,
		IdMovimiento		int					NOT NULL,
		codNivel			char(2)				NOT NULL,
		codGrupo			char(5)				NOT NULL,
		codTalla			char(3)				NOT NULL,
		codColor			char(6)				NOT NULL,
		Cantidad			decimal(12,3)		NOT NULL,
		Comentario			varchar(250)		NULL,
		-- linea de guia despachada de la que proviene el ingreso (NULL en salidas)
		grIdEmpresa			int					NULL,
		grSerie				varchar(50)			NULL,
		grNumero			varchar(50)			NULL,
		grDestCodigoPC		varchar(100)		NULL,
		grSecuencia			int					NULL,
		grTipoOrden			char(1)				NULL,

		CONSTRAINT PK_MovimientoAlmacenDet PRIMARY KEY CLUSTERED (IdMovimientoDet),
		CONSTRAINT FK_MovimientoAlmacenDet_Cab FOREIGN KEY (IdMovimiento) REFERENCES dbo.MovimientoAlmacenCab (IdMovimiento),
		CONSTRAINT FK_MovimientoAlmacenDet_Producto FOREIGN KEY (codNivel, codGrupo, codTalla, codColor)
			REFERENCES dbo.productoServicios (codNivel, codGrupo, codTalla, codColor),
		CONSTRAINT CK_MovimientoAlmacenDet_Cantidad CHECK (Cantidad > 0),
		-- la referencia a la guia va completa o no va
		CONSTRAINT CK_MovimientoAlmacenDet_Guia CHECK (
			(grIdEmpresa IS NULL AND grSerie IS NULL AND grNumero IS NULL AND grDestCodigoPC IS NULL AND grSecuencia IS NULL AND grTipoOrden IS NULL)
			OR (grIdEmpresa IS NOT NULL AND grSerie IS NOT NULL AND grNumero IS NOT NULL AND grDestCodigoPC IS NOT NULL AND grSecuencia IS NOT NULL AND grTipoOrden IS NOT NULL)
		)
	);

	CREATE NONCLUSTERED INDEX IX_MovimientoAlmacenDet_Movimiento
		ON dbo.MovimientoAlmacenDet (IdMovimiento)
		INCLUDE (codNivel, codGrupo, codTalla, codColor, Cantidad);

	CREATE NONCLUSTERED INDEX IX_MovimientoAlmacenDet_Producto
		ON dbo.MovimientoAlmacenDet (codNivel, codGrupo, codTalla, codColor)
		INCLUDE (IdMovimiento, Cantidad);

	CREATE NONCLUSTERED INDEX IX_MovimientoAlmacenDet_Guia
		ON dbo.MovimientoAlmacenDet (grSerie, grNumero, grSecuencia)
		INCLUDE (grIdEmpresa, grDestCodigoPC, grTipoOrden, IdMovimiento, Cantidad);
END
GO

-- Tipo tabla para enviar el detalle completo en la MISMA llamada que la cabecera.
--   Ingreso: se envia la referencia de la guia (gr*); el producto lo resuelve el proc.
--   Salida : se envia el producto (cod*); la referencia de guia va en NULL.
IF TYPE_ID('dbo.MovimientoAlmacenDetTipo') IS NULL
BEGIN
	CREATE TYPE dbo.MovimientoAlmacenDetTipo AS TABLE (
		grIdEmpresa		int				NULL,
		grSerie			varchar(50)		NULL,
		grNumero		varchar(50)		NULL,
		grDestCodigoPC	varchar(100)	NULL,
		grSecuencia		int				NULL,
		grTipoOrden		char(1)			NULL,
		codNivel		char(2)			NULL,
		codGrupo		char(5)			NULL,
		codTalla		char(3)			NULL,
		codColor		char(6)			NULL,
		Cantidad		decimal(12,3)	NOT NULL,
		Comentario		varchar(250)	NULL
	);
END
GO

-- =====================================================================================
-- Lineas de guia DESPACHADAS (grDet tipoMovimiento 'S') con su producto, lo ya ingresado
-- a almacenes (ingresos activos) y lo pendiente de ingresar.
-- El producto sale de la orden de la linea: ocDet (tipoOrden 'C') u osDet (tipoOrden 'S').
-- Se usa en el buscador de ingresos y en la validacion del registro.
-- =====================================================================================
CREATE OR ALTER FUNCTION dbo.ufnGuiaDespachoAlmacen ()
RETURNS TABLE
AS
RETURN
WITH ingresado AS (
	SELECT	d.grIdEmpresa, d.grSerie, d.grNumero, d.grDestCodigoPC, d.grSecuencia, d.grTipoOrden,
			SUM(d.Cantidad) AS Cantidad
	FROM dbo.MovimientoAlmacenDet d
	INNER JOIN dbo.MovimientoAlmacenCab c ON c.IdMovimiento = d.IdMovimiento
	WHERE c.Estado = 'A'
		AND c.TipoMovimiento = 'I'
		AND d.grSerie IS NOT NULL
	GROUP BY d.grIdEmpresa, d.grSerie, d.grNumero, d.grDestCodigoPC, d.grSecuencia, d.grTipoOrden
)
SELECT	gr.idEmpresa		AS grIdEmpresa,
		gr.serie			AS grSerie,
		gr.numero			AS grNumero,
		gr.destCodigoPC		AS grDestCodigoPC,
		gr.secuencia		AS grSecuencia,
		gr.tipoOrden		AS grTipoOrden,
		grc.fechaEmision	AS FechaGuia,
		p.codNivel, p.codGrupo, p.codTalla, p.codColor,
		CAST(ABS(gr.cantidadIngresada) AS decimal(18,3))						AS Despachado,
		CAST(ISNULL(i.Cantidad, 0) AS decimal(18,3))							AS Ingresado,
		CAST(ABS(gr.cantidadIngresada) - ISNULL(i.Cantidad, 0) AS decimal(18,3)) AS Pendiente
FROM dbo.grDet gr
INNER JOIN dbo.grCab grc ON grc.idEmpresa = gr.idEmpresa
						AND grc.serie = gr.serie
						AND grc.numero = gr.numero
						AND grc.destCodigoPC = gr.destCodigoPC
LEFT JOIN dbo.ocDet oc ON gr.tipoOrden = 'C'
						AND oc.idEmpresa = gr.idEmpresa
						AND oc.idOC = gr.idDet
						AND oc.secuencia = gr.idSecuenciaDet
LEFT JOIN dbo.osDet os ON gr.tipoOrden = 'S'
						AND os.idEmpresa = gr.idEmpresa
						AND os.idOS = gr.idDet
						AND os.secuencia = gr.idSecuenciaDet
CROSS APPLY (
	SELECT	COALESCE(oc.codNivel, os.codNivel) AS codNivel,
			COALESCE(oc.codGrupo, os.codGrupo) AS codGrupo,
			COALESCE(oc.codTalla, os.codTalla) AS codTalla,
			COALESCE(oc.codColor, os.codColor) AS codColor
) p
LEFT JOIN ingresado i ON i.grIdEmpresa = gr.idEmpresa
					AND i.grSerie = gr.serie
					AND i.grNumero = gr.numero
					AND i.grDestCodigoPC = gr.destCodigoPC
					AND i.grSecuencia = gr.secuencia
					AND i.grTipoOrden = gr.tipoOrden
WHERE gr.tipoMovimiento = 'S'
	AND gr.cantidadIngresada <> 0
	AND p.codNivel IS NOT NULL;
GO

PRINT 'Tablas de Movimientos de Almacen listas.';
