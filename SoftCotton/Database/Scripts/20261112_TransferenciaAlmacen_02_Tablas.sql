-- =====================================================================================
-- Transferencia entre Almacenes - Script 2 de 9: tablas y tipo tabla (TVP)
-- =====================================================================================
-- Modelo propio, sin depender de OC / OS / guias:
--
--   AreasAlmacen (Codigo PK)
--        ^   ^
--        |   |  FK origen / FK destino
--   TransferenciaAlmacenCab (IdTransferencia PK identity)
--        ^
--        |  FK IdTransferencia (una sola columna)
--   TransferenciaAlmacenDet (IdTransferenciaDet PK identity)
--        |-- FK producto  -> productoServicios (su PK es nivel/grupo/talla/color)
--        |-- FK codCuenta -> cuentas
--
-- Reglas de negocio:
--   * El almacen '000' (ALMACEN CENTRAL) es el almacen principal: alli esta todo el stock
--     que muestra el Kardex y que no fue transferido a otro almacen.
--   * TipoTransferencia: 'T' transferencia (destino distinto de central),
--                        'D' devolucion (destino = central). Lo asigna el procedimiento.
--   * Estado: 'A' activo, 'N' anulado. No se borran registros: se anulan (trazabilidad).
--   * La cantidad usa el mismo tipo que grDet.cantidadIngresada (decimal(12,3)).
--
-- Requiere el script 1 (PK de AreasAlmacen).
-- Idempotente.
-- =====================================================================================

SET NOCOUNT ON;
GO

IF OBJECT_ID('dbo.TransferenciaAlmacenCab', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.TransferenciaAlmacenCab (
		IdTransferencia		int IDENTITY(1,1)	NOT NULL,
		TipoTransferencia	char(1)				NOT NULL,
		FechaTransferencia	date				NOT NULL,
		CodAlmacenOrigen	varchar(3)			NOT NULL,
		CodAlmacenDestino	varchar(3)			NOT NULL,
		Observacion			varchar(500)		NULL,
		Estado				char(1)				NOT NULL CONSTRAINT DF_TransferenciaAlmacenCab_Estado DEFAULT ('A'),
		IdUsuarioRegistro	int					NOT NULL,
		FechaRegistro		datetime			NOT NULL CONSTRAINT DF_TransferenciaAlmacenCab_FechaRegistro DEFAULT (GETDATE()),
		IdUsuarioAnulacion	int					NULL,
		FechaAnulacion		datetime			NULL,
		MotivoAnulacion		varchar(250)		NULL,

		CONSTRAINT PK_TransferenciaAlmacenCab PRIMARY KEY CLUSTERED (IdTransferencia),
		CONSTRAINT FK_TransferenciaAlmacenCab_Origen  FOREIGN KEY (CodAlmacenOrigen)  REFERENCES dbo.AreasAlmacen (Codigo),
		CONSTRAINT FK_TransferenciaAlmacenCab_Destino FOREIGN KEY (CodAlmacenDestino) REFERENCES dbo.AreasAlmacen (Codigo),
		CONSTRAINT FK_TransferenciaAlmacenCab_UsuarioRegistro  FOREIGN KEY (IdUsuarioRegistro)  REFERENCES dbo.usuarios (id),
		CONSTRAINT FK_TransferenciaAlmacenCab_UsuarioAnulacion FOREIGN KEY (IdUsuarioAnulacion) REFERENCES dbo.usuarios (id),
		CONSTRAINT CK_TransferenciaAlmacenCab_Tipo    CHECK (TipoTransferencia IN ('T', 'D')),
		CONSTRAINT CK_TransferenciaAlmacenCab_Estado  CHECK (Estado IN ('A', 'N')),
		CONSTRAINT CK_TransferenciaAlmacenCab_Almacenes CHECK (CodAlmacenOrigen <> CodAlmacenDestino),
		CONSTRAINT CK_TransferenciaAlmacenCab_Anulacion CHECK (
			(Estado = 'A' AND IdUsuarioAnulacion IS NULL AND FechaAnulacion IS NULL)
			OR (Estado = 'N' AND IdUsuarioAnulacion IS NOT NULL AND FechaAnulacion IS NOT NULL)
		)
	);

	CREATE NONCLUSTERED INDEX IX_TransferenciaAlmacenCab_Fecha
		ON dbo.TransferenciaAlmacenCab (FechaTransferencia, Estado)
		INCLUDE (CodAlmacenOrigen, CodAlmacenDestino, TipoTransferencia);
END
GO

IF OBJECT_ID('dbo.TransferenciaAlmacenDet', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.TransferenciaAlmacenDet (
		IdTransferenciaDet	int IDENTITY(1,1)	NOT NULL,
		IdTransferencia		int					NOT NULL,
		codNivel			char(2)				NOT NULL,
		codGrupo			char(5)				NOT NULL,
		codTalla			char(3)				NOT NULL,
		codColor			char(6)				NOT NULL,
		codCuenta			char(10)			NOT NULL,
		Cantidad			decimal(12,3)		NOT NULL,
		Comentario			varchar(250)		NULL,

		CONSTRAINT PK_TransferenciaAlmacenDet PRIMARY KEY CLUSTERED (IdTransferenciaDet),
		CONSTRAINT FK_TransferenciaAlmacenDet_Cab FOREIGN KEY (IdTransferencia) REFERENCES dbo.TransferenciaAlmacenCab (IdTransferencia),
		CONSTRAINT FK_TransferenciaAlmacenDet_Producto FOREIGN KEY (codNivel, codGrupo, codTalla, codColor)
			REFERENCES dbo.productoServicios (codNivel, codGrupo, codTalla, codColor),
		CONSTRAINT FK_TransferenciaAlmacenDet_Cuenta FOREIGN KEY (codCuenta) REFERENCES dbo.cuentas (codCuenta),
		CONSTRAINT CK_TransferenciaAlmacenDet_Cantidad CHECK (Cantidad > 0),
		-- un producto no se repite dentro de la misma transferencia
		CONSTRAINT UQ_TransferenciaAlmacenDet_Producto UNIQUE (IdTransferencia, codNivel, codGrupo, codTalla, codColor)
	);

	CREATE NONCLUSTERED INDEX IX_TransferenciaAlmacenDet_Producto
		ON dbo.TransferenciaAlmacenDet (codNivel, codGrupo, codTalla, codColor)
		INCLUDE (IdTransferencia, Cantidad, codCuenta);
END
GO

-- Tipo tabla para enviar el detalle completo en la MISMA llamada que la cabecera
IF TYPE_ID('dbo.TransferenciaAlmacenDetTipo') IS NULL
BEGIN
	CREATE TYPE dbo.TransferenciaAlmacenDetTipo AS TABLE (
		codNivel	char(2)			NOT NULL,
		codGrupo	char(5)			NOT NULL,
		codTalla	char(3)			NOT NULL,
		codColor	char(6)			NOT NULL,
		codCuenta	char(10)		NULL,		-- NULL: se toma la cuenta del ultimo movimiento del producto en Kardex
		Cantidad	decimal(12,3)	NOT NULL,
		Comentario	varchar(250)	NULL
	);
END
GO

PRINT 'Tablas de Transferencia entre Almacenes listas.';
