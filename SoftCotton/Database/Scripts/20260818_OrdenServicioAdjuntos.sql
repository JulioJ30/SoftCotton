/*
    Adjuntos (cotizaciones) de Orden de Servicio
    ---------------------------------------------
    Agrega la tabla y los procedimientos necesarios para poder adjuntar, listar,
    visualizar y eliminar archivos (p.ej. cotizaciones) desde RegistroOSView.

    Ejecutar una sola vez contra la base de datos de SoftCotton (bdsoftcotton).
    El script es re-ejecutable: la tabla solo se crea si no existe y los
    procedimientos usan CREATE OR ALTER.
*/

-- ============================================================
-- 1. TABLA
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'OrdenServicioAdjunto')
BEGIN
    CREATE TABLE dbo.OrdenServicioAdjunto
    (
        idAdjunto     INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        idEmpresa     INT NOT NULL,
        idOS          INT NOT NULL,
        nombreArchivo VARCHAR(255) NOT NULL,
        extension     VARCHAR(10) NOT NULL,
        contenido     VARBINARY(MAX) NOT NULL,
        tamanioKB     DECIMAL(10, 2) NOT NULL DEFAULT 0,
        tipoAdjunto   VARCHAR(20) NOT NULL DEFAULT 'COTIZACION',
        estado        BIT NOT NULL DEFAULT 1, -- 1 = activo, 0 = eliminado (borrado logico)
        usuarioReg    VARCHAR(50) NOT NULL,
        fechaReg      DATETIME NOT NULL DEFAULT GETDATE()
    );

    CREATE INDEX IX_OrdenServicioAdjunto_OS ON dbo.OrdenServicioAdjunto (idEmpresa, idOS, estado);
END
GO

-- ============================================================
-- 2. uspGetOSAdjunto
--    @opcion = 1 -> listar adjuntos activos de una OS (sin el binario)
--    @opcion = 2 -> obtener un adjunto puntual (con el binario) por idAdjunto
-- ============================================================
CREATE OR ALTER PROCEDURE dbo.uspGetOSAdjunto
    @opcion     INT,
    @idEmpresa  INT = 0,
    @idOS       INT = 0,
    @idAdjunto  INT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @opcion = 1
    BEGIN
        SELECT
            idAdjunto,
            idEmpresa,
            idOS,
            nombreArchivo,
            extension,
            tipoAdjunto,
            tamanioKB,
            usuarioReg,
            fechaReg
        FROM dbo.OrdenServicioAdjunto
        WHERE idEmpresa = @idEmpresa
          AND idOS = @idOS
          AND estado = 1
        ORDER BY fechaReg DESC;
    END

    IF @opcion = 2
    BEGIN
        SELECT
            idAdjunto,
            idEmpresa,
            idOS,
            nombreArchivo,
            extension,
            contenido,
            tipoAdjunto,
            tamanioKB,
            usuarioReg,
            fechaReg
        FROM dbo.OrdenServicioAdjunto
        WHERE idAdjunto = @idAdjunto
          AND estado = 1;
    END
END
GO

-- ============================================================
-- 3. uspSetOSAdjunto
--    @opcion = 1 -> insertar adjunto
--    @opcion = 2 -> eliminar (logico) adjunto
--    Devuelve: idResponse, messageResponse, typeMessage (INFORMATION | WARNING | ERROR)
-- ============================================================
CREATE OR ALTER PROCEDURE dbo.uspSetOSAdjunto
    @opcion         INT,
    @idAdjunto      INT = 0,
    @idEmpresa      INT = 0,
    @idOS           INT = 0,
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
                INSERT INTO dbo.OrdenServicioAdjunto
                    (idEmpresa, idOS, nombreArchivo, extension, contenido, tamanioKB, tipoAdjunto, estado, usuarioReg, fechaReg)
                VALUES
                    (@idEmpresa, @idOS, @nombreArchivo, @extension, @contenido,
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
            IF NOT EXISTS (SELECT 1 FROM dbo.OrdenServicioAdjunto WHERE idAdjunto = @idAdjunto AND estado = 1)
            BEGIN
                SET @idResponse = 0;
                SET @messageResponse = 'El adjunto no existe o ya fue eliminado';
                SET @typeMessage = 'WARNING';
            END
            ELSE
            BEGIN
                UPDATE dbo.OrdenServicioAdjunto
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
