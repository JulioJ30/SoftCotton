-- =====================================================================================
-- Cuadre de Kardex - Script 2 de 5: tabla de trazabilidad
-- =====================================================================================
-- CuadreKardex NO participa en el calculo del Kardex (uspGetkardexPrincipal no la lee).
-- Es solo la bitacora que usa el formulario "Cuadre de Kardex" para listar los ajustes
-- registrados y saber que fila de grDet (dentro de la Guia de Remision placeholder de ese
-- cuadre, ver script 4) corresponde a cada ajuste, para poder eliminarlo despues.
--
-- Cada cuadre queda asociado al producto EXACTO que el usuario ingreso (codNivel, codGrupo,
-- codTalla, codColor) - no hay producto ficticio.
-- =====================================================================================

SET NOCOUNT ON;

IF OBJECT_ID('dbo.CuadreKardex', 'U') IS NULL
BEGIN
	CREATE TABLE dbo.CuadreKardex (
		idCuadre        int IDENTITY(1,1) NOT NULL PRIMARY KEY,
		codNivel        char(2)       NOT NULL,
		codGrupo        char(5)       NOT NULL,
		codTalla        char(3)       NOT NULL,
		codColor        char(6)       NOT NULL,
		tipoAjuste      char(1)       NOT NULL,   -- 'E' sumar (entrada) / 'S' restar (salida)
		cantidad        decimal(18,3) NOT NULL,
		fechaMovimiento date          NOT NULL,   -- fecha del periodo que se esta cuadrando (puede ser anterior a hoy)
		idEmpresa       int           NOT NULL,
		serieGR         varchar(4)    NOT NULL,
		numeroGR        varchar(10)   NOT NULL,
		secuenciaGR     int           NOT NULL,
		usuarioReg      varchar(30)   NOT NULL,
		fechaReg        datetime      NOT NULL DEFAULT GETDATE(),

		CONSTRAINT FK_CuadreKardex_Nivel FOREIGN KEY (codNivel) REFERENCES dbo.niveles(codNivel)
	);
END
