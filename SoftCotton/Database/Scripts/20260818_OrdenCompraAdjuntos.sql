/*
    Adjuntos (cotizaciones) de Orden de Compra
    -------------------------------------------
    Agrega la tabla y los procedimientos necesarios para poder adjuntar, listar,
    visualizar y eliminar archivos (p.ej. cotizaciones) desde RegistroOCView.

    Analogo al script 20260818_OrdenServicioAdjuntos.sql (mismo diseño, aplicado a OC).

    Ejecutar una sola vez contra la base de datos de SoftCotton (bdsoftcotton).
    El script es re-ejecutable: la tabla solo se crea si no existe y los
    procedimientos usan CREATE OR ALTER.
*/

-- ============================================================
-- 1. TABLA
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'OrdenCompraAdjunto')
BEGIN
    CREATE TABLE dbo.OrdenCompraAdjunto
    (
        idAdjunto     INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        idEmpresa     INT NOT NULL,
        idOC          INT NOT NULL,
        nombreArchivo VARCHAR(255) NOT NULL,
        extension     VARCHAR(10) NOT NULL,
        contenido     VARBINARY(MAX) NOT NULL,
        tamanioKB     DECIMAL(10, 2) NOT NULL DEFAULT 0,
        tipoAdjunto   VARCHAR(20) NOT NULL DEFAULT 'COTIZACION',
        estado        BIT NOT NULL DEFAULT 1, -- 1 = activo, 0 = eliminado (borrado logico)
        usuarioReg    VARCHAR(50) NOT NULL,
        fechaReg      DATETIME NOT NULL DEFAULT GETDATE()
    );

    CREATE INDEX IX_OrdenCompraAdjunto_OC ON dbo.OrdenCompraAdjunto (idEmpresa, idOC, estado);
END
GO

-- ============================================================
-- 2. uspGetOCAdjunto
--    @opcion = 1 -> listar adjuntos activos de una OC (sin el binario)
--    @opcion = 2 -> obtener un adjunto puntual (con el binario) por idAdjunto
-- ============================================================
CREATE OR ALTER PROCEDURE dbo.uspGetOCAdjunto
    @opcion     INT,
    @idEmpresa  INT = 0,
    @idOC       INT = 0,
    @idAdjunto  INT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @opcion = 1
    BEGIN
        SELECT
            idAdjunto,
            idEmpresa,
            idOC,
            nombreArchivo,
            extension,
            tipoAdjunto,
            tamanioKB,
            usuarioReg,
            fechaReg
        FROM dbo.OrdenCompraAdjunto
        WHERE idEmpresa = @idEmpresa
          AND idOC = @idOC
          AND estado = 1
        ORDER BY fechaReg DESC;
    END

    IF @opcion = 2
    BEGIN
        SELECT
            idAdjunto,
            idEmpresa,
            idOC,
            nombreArchivo,
            extension,
            contenido,
            tipoAdjunto,
            tamanioKB,
            usuarioReg,
            fechaReg
        FROM dbo.OrdenCompraAdjunto
        WHERE idAdjunto = @idAdjunto
          AND estado = 1;
    END
END
GO

-- ============================================================
-- 3. uspSetOCAdjunto
--    @opcion = 1 -> insertar adjunto
--    @opcion = 2 -> eliminar (logico) adjunto
--    Devuelve: idResponse, messageResponse, typeMessage (INFORMATION | WARNING | ERROR)
-- ============================================================
CREATE OR ALTER PROCEDURE dbo.uspSetOCAdjunto
    @opcion         INT,
    @idAdjunto      INT = 0,
    @idEmpresa      INT = 0,
    @idOC           INT = 0,
    @nombreArchivo  VARCHAR(255) = '',
    @extension      VARCHAR(10) = '',
    @contenido      VARBINARY(MAX) = NULL,
    @tipoAdjunto    VARCHAR(20) = 'COTIZACION',
    @usuarioReg     VARCHAR(50) = ''
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idResponse INT = 0;
    DECLARE @messageResponse VARCHAR(200) = '';
    DECLARE @typeMessage VARCHAR(20) = 'WARNING';

    IF @opcion = 1
    BEGIN
        BEGIN TRY
            IF @contenido IS NULL OR DATALENGTH(@contenido) = 0
            BEGIN
                SET @idResponse = 0;
                SET @messageResponse = 'El archivo no tiene contenido';
                SET @typeMessage = 'WARNING';
            END
            ELSE
            BEGIN
                INSERT INTO dbo.OrdenCompraAdjunto
                    (idEmpresa, idOC, nombreArchivo, extension, contenido, tamanioKB, tipoAdjunto, estado, usuarioReg, fechaReg)
                VALUES
                    (@idEmpresa, @idOC, @nombreArchivo, @extension, @contenido,
                     CAST(DATALENGTH(@contenido) / 1024.0 AS DECIMAL(10, 2)), @tipoAdjunto, 1, @usuarioReg, GETDATE());

                SET @idResponse = SCOPE_IDENTITY();
                SET @messageResponse = 'Archivo adjuntado correctamente';
                SET @typeMessage = 'INFORMATION';
            END
        END TRY
        BEGIN CATCH
            SET @idResponse = 0;
            SET @messageResponse = ERROR_MESSAGE();
            SET @typeMessage = 'ERROR';
        END CATCH
    END

    IF @opcion = 2
    BEGIN
        BEGIN TRY
            IF NOT EXISTS (SELECT 1 FROM dbo.OrdenCompraAdjunto WHERE idAdjunto = @idAdjunto AND estado = 1)
            BEGIN
                SET @idResponse = 0;
                SET @messageResponse = 'El adjunto no existe o ya fue eliminado';
                SET @typeMessage = 'WARNING';
            END
            ELSE
            BEGIN
                UPDATE dbo.OrdenCompraAdjunto
                   SET estado = 0
                 WHERE idAdjunto = @idAdjunto;

                SET @idResponse = @idAdjunto;
                SET @messageResponse = 'Archivo eliminado correctamente';
                SET @typeMessage = 'INFORMATION';
            END
        END TRY
        BEGIN CATCH
            SET @idResponse = 0;
            SET @messageResponse = ERROR_MESSAGE();
            SET @typeMessage = 'ERROR';
        END CATCH
    END

    SELECT @idResponse AS idResponse, @messageResponse AS messageResponse, @typeMessage AS typeMessage;
END
GO
