-- =====================================================================================
-- Cuadre de Kardex - Script 1 de 5: datos placeholder (una sola vez)
-- =====================================================================================
-- Objetivo: crear el proveedor/cliente y la cuenta contable "placeholder" (ficticios, no
-- son entidades de negocio reales) que sirven de ancla para que los ajustes manuales de
-- Kardex ("Cuadre de Kardex") aparezcan en el reporte BuscarKardexView /
-- uspGetkardexPrincipal SIN modificar ese procedimiento.
--
-- El cuadre se registra siempre sobre un producto REAL existente (el usuario ingresa el
-- codigo exacto de nivel/grupo/talla/color), asi que no se crea ningun producto ficticio
-- aqui. uspSetCuadreKardex (script 4) crea, la primera vez que se cuadra un producto dado,
-- una Orden de Compra placeholder que ancla ese producto especifico (reutilizada en
-- cuadres posteriores del mismo producto), y una Guia de Remision placeholder nueva por
-- cada cuadre, con la fecha que el usuario elija.
--
-- No se toca ninguna tabla ni procedimiento existente del calculo de Kardex. Este script
-- solo INSERTa filas nuevas.
--
-- Es idempotente: puede ejecutarse mas de una vez sin duplicar datos.
-- =====================================================================================

SET NOCOUNT ON;

-- ---------------------------------------------------------------------------
-- 1) Proveedor/cliente placeholder
-- ---------------------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM provClientes WHERE codigo = 'AJUSTE')
BEGIN
	INSERT INTO provClientes (codigo, codTipoDoc, razonSocial, codTipoPC, usuarioReg, fechaReg, estado)
	VALUES ('AJUSTE', '06', 'AJUSTES DE INVENTARIO KARDEX', '1', 'SISTEMA', GETDATE(), 1);
END

-- ---------------------------------------------------------------------------
-- 2) Cuenta contable placeholder, habilitada para Kardex
-- ---------------------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM cuentas WHERE codCuenta = 'AJUSTE')
BEGIN
	INSERT INTO cuentas (codCuenta, cuenta, codCuentaNivel, codCuentaTipo, estado, fechaReg, usuarioReg, FlgMostrarKardex)
	VALUES ('AJUSTE', 'AJUSTE DE INVENTARIO KARDEX', 'R', 'F', 1, GETDATE(), 'SISTEMA', 1);
END

PRINT 'Seed de Cuadre de Kardex completado.';
