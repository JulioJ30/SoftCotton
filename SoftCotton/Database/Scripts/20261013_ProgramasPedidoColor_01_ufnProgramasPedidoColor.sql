/*
    Programas de los pedidos en la cabecera de los formatos de OC / OS
    -------------------------------------------------------------------------
    Cuando el detalle de una OC (ocDet), OS (osDet) u OS especial (osDetEspecial)
    tiene IdPedidoColor, se llega hasta el pedido:
        detalle.IdPedidoColor -> pedidosColor.idPedido -> pedidos.idPrograma -> programas.programa
    y se devuelven los programas distintos concatenados (separados por ' / ').

    Devuelve NULL si ningun item del detalle tiene IdPedidoColor (o sus pedidos
    no tienen programa); en ese caso los procs mantienen el programa de la cabecera.

    @tipoDocumento: 'OC'  -> ocDet
                    'OS'  -> osDet
                    'OSE' -> osDetEspecial

    Usada por uspGetOC @opcion = 9 y uspGetOS @opcion = 9 / 22
    (ver scripts 20261013_ProgramasPedidoColor_02 y _03).

    Ejecutar una sola vez contra la base de datos de SoftCotton (bdsoftcotton),
    ANTES de los scripts _02 y _03.
*/

-- FOR XML PATH(...).value(...) requiere QUOTED_IDENTIFIER ON al crear la funcion
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION [dbo].[ufnProgramasPedidoColor]
(
    @tipoDocumento varchar(3),
    @idEmpresa int,
    @idDocumento int
)
RETURNS varchar(1000)
AS
BEGIN
    DECLARE @programas varchar(1000);

    ;WITH pedidoColorDetalle AS
    (
        SELECT det.IdPedidoColor
        FROM   ocDet det
        WHERE  @tipoDocumento = 'OC'
               AND det.idEmpresa = @idEmpresa
               AND det.idOC = @idDocumento
               AND det.IdPedidoColor IS NOT NULL
        UNION
        SELECT det.IdPedidoColor
        FROM   osDet det
        WHERE  @tipoDocumento = 'OS'
               AND det.idEmpresa = @idEmpresa
               AND det.idOS = @idDocumento
               AND det.IdPedidoColor IS NOT NULL
        UNION
        SELECT det.idPedidoColor
        FROM   osDetEspecial det
        WHERE  @tipoDocumento = 'OSE'
               AND det.idEmpresa = @idEmpresa
               AND det.idOS = @idDocumento
               AND det.idPedidoColor IS NOT NULL
    ),
    programasPedido AS
    (
        SELECT DISTINCT LTRIM(RTRIM(pr.programa)) AS programa
        FROM   pedidoColorDetalle d
               INNER JOIN pedidosColor pc ON pc.idPedidoColor = d.IdPedidoColor
               INNER JOIN pedidos pe ON pe.idPedido = pc.idPedido
               INNER JOIN programas pr ON pr.idPrograma = pe.idPrograma
        WHERE  LTRIM(RTRIM(ISNULL(pr.programa, ''))) <> ''
    )
    SELECT @programas = STUFF((
                            SELECT ' / ' + programa
                            FROM   programasPedido
                            ORDER BY programa
                            FOR XML PATH(''), TYPE
                        ).value('.', 'varchar(1000)'), 1, 3, '');

    RETURN NULLIF(@programas, '');
END
GO
