/*
    Programas de los pedidos en la cabecera del formato de Orden de Servicio
    -------------------------------------------------------------------------
    uspGetOS @opcion = 9 (osCab, OrdenServicioRpte) y @opcion = 22 (osCabEspecial, OrdenServicioRpteV2).

    En la cabecera, la columna nombrePrograma ahora toma los programas distintos
    de los pedidos del detalle (IdPedidoColor -> pedidosColor -> pedidos -> programas)
    via dbo.ufnProgramasPedidoColor. Si ningun item del detalle tiene IdPedidoColor,
    se mantiene el programa de la cabecera (codPrograma), como hasta ahora.

    El resto del procedimiento se deja exactamente igual al texto actual
    (obtenido via OBJECT_DEFINITION('uspGetOS') de bdsoftcotton al 13/10/2026).
    Si en produccion el procedimiento cambio despues de esa fecha, comparar antes
    de ejecutar (sp_helptext uspGetOS).

    Requiere: 20261013_ProgramasPedidoColor_01_ufnProgramasPedidoColor.sql
    Ejecutar una sola vez contra la base de datos de SoftCotton (bdsoftcotton).
*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER procedure [dbo].[uspGetOS]
 @opcion int = null,
 @filtroTxt1 varchar(100) = null,
 @filtroTxt2 varchar(100) = null,
 @filtroInt1 int = null,
 @filtroInt2 int = null
as
begin
 if @opcion = 1
 begin
  -- Tipo de Moneda : RegistroOSView
  select 0 as idTipoMoneda,
    '- Seleccione -' as moneda
  union all
  select idTipoMoneda,
    simbolo + ' - ' + monedaSingular
  from tipoMonedas

 end
 else if @opcion = 2
 begin
  -- Condición de Pago : RegistroOSView
  select 0 as idCondPago,
    '- Seleccione -' as condicion
  union all
  select idCondPago,
    condicion
  from condicionesPago;

 end
 else if @opcion = 3
 begin
  -- Buscar Proveedores y Clientes.
  -- @filtroTxt1 : Filtro de busqueda : RegistroOSView
  select codigo,
    razonSocial,
    direccion
  from provClientes
  where estado = 1
   And (codigo like '%' + @filtroTxt1 + '%'
     Or razonSocial like '%' + @filtroTxt1 + '%');

 end
 else if @opcion = 5
 begin
  -- Listar Tipo de Aprobaciones : TipoAprobacionView / RegistroOSView
  select idTipoAprobacion,
    descripcion,
    estado,
    nivelAprobacion,
    usuarioReg,
    fechaReg
  from osTipoAprobacion
  order by nivelAprobacion

 end
 else if @opcion = 6
 begin
  -- Listar Tipos de Anulados : TipoAnuladoView / RegistroOSView
  select idTipoAnulado,
    descripcion,
    estado,
    usuarioReg,
    fechaReg
  from osTipoAnulado;


 end
 else if @opcion = 7
 begin

  -- Buscar OS por Codigo - Cabecera : RegistroOSView
  select idEmpresa,
    idOS,
    fechaEmision,
    fechaEntrega,
    codigoPC,
    pc.razonSocial,
    pc.direccion,
    idTipoMoneda,
    tipoCompra,
    idCondPago,
    os.idTipoAprobacion,
    a.descripcion as tipoAprobacion,
    idTipoAnulado,
    fechaAnulado,
    usuarioAnulado,
    usuCreacionReg,
    usuFechaReg,
    observacion,
    dbo.ufnOSSubTotal(idEmpresa, idOS) as subTotal,
    dbo.ufnOSIGV(idEmpresa, idOS) as igv,
    dbo.ufnOSTotal(idEmpresa, idOS) as total,
    os.usuCreacionReg,
    os.codServicio,
    se.nombreServicio,
    os.codPrograma,
    --pr.nombrePrograma
    pr.programa nombrePrograma
  from osCab os
   inner join provClientes pc on os.codigoPC = pc.codigo
   inner join osTipoAprobacion a on os.idTipoAprobacion = a.idTipoAprobacion
   left join servicio se on os.codServicio = se.codServicio
   left join programas pr on os.codPrograma = pr.idPrograma --pr.codPrograma
  where idEmpresa = @filtroInt1
   and idOS = @filtroInt2;
 end
 else if @opcion = 8
 begin
  -- Buscar OC por Codigo - Detalle : RegistroOSView
  select idEmpresa,
    idOS,
    det.secuencia,
    det.codNivel,
    det.codGrupo,
    det.codTalla,
    det.codColor,
      (n.codNivel + ' - ' + g.grupo + ' - ' + rtrim(ltrim(t.descripcion)) + ' - ' + rtrim(ltrim(c.descripcion))) as producto,
    c.descripcion as color,
    cantidad,
    g.codUM,
    igv,
    precioUnitario,
    isnull(obs1,'') as obs1,
    isnull(obs2,'') as obs2,
    isnull(obs3,'') as obs3,
    isnull(obs4,'') as obs4,
    isnull(obs5,'') as obs5,
    dbo.ufnOCTieneGRFACT(det.idEmpresa, det.idOS, det.secuencia, 'S') as tienegrfact,
    det.IdPedidoColor,
    case
     when det.IdPedidoColor is not null then
      concat(pe.pedido,' ',col.descripcion,' ',es.estilo,' ',pr.programa)
     else
     ''
    end PedidoColor
  from osDet det
   inner join productoServicios p on det.codNivel = p.codNivel
           and det.codGrupo = p.codGrupo
           and det.codTalla = p.codTalla
           and det.codColor = p.codColor
   inner join niveles n on p.codNivel = n.codNivel
   inner join grupos g on p.codNivel = g.codNivel
        and p.codGrupo = g.codGrupo
   inner join tallas t on t.codTalla = p.codTalla
   inner join colores c on p.codColor = c.codColor
   inner join unidadMedidas um on g.codUM = um.codUM
   left join pedidosColor pc on pc.idPedidoColor = det.IdPedidoColor
   left join colores col on col.codColor = pc.codColor
   left join pedidos pe on pe.idPedido = pc.idPedido
   left join estilos es on es.idEstilo = pe.idEstilo
   left join programas pr on pr.idPrograma = pe.idPrograma
  where idEmpresa = @filtroInt1
   and idOS = @filtroInt2;

 end
 else if @opcion = 9
 begin
  -- Buscar OS por Codigo - Cabecera : OrdenCompraRpteView
  select e.ruc as empresaRUC,
    e.direccion as empresaDireccion,
    os.idOS as codigoOS,
    convert(varchar, os.fechaEmision,103) as fechaEmision,
    convert(varchar, os.fechaEntrega,103) as fechaEntrega,
    pc.razonSocial as proveedorRS,
    pc.codigo as proveedorRUC,
    pc.direccion as proveedorDireccion,
    isnull(pc.contacto,'') as contacto,
    isnull(pc.telefono,'') as telefono,
    isnull(pc.email,'') email,
    m.monedaSingular as tipoMoneda,
    case when tipoCompra = 'N' then 'NACIONAL'
      when tipoCompra = 'I' then 'IMPORTADO'
      else 'INDEFINIDO'
    end as tipoCompra,
    c.condicion as formaPago,
    dbo.ufnTipoCambioXFecha (os.fechaEmision) as tipoCambio,
    dbo.ufnOSSubTotal(os.idEmpresa, os.idOS) as subTotal,
    0 as descuento,
    dbo.ufnOSSubTotal(os.idEmpresa, os.idOS) as baseImponible,
    dbo.ufnOSIGV(os.idEmpresa, os.idOS) as igv,
    dbo.ufnOSTotal(os.idEmpresa, os.idOS) as total,
    [dbo].[ufnMontoLetras] (dbo.ufnOSTotal(os.idEmpresa, os.idOS), UPPER(m.monedaPlural)) as montoLetras,
    m.simbolo,
    os.observacion,
    --p.nombrePrograma,
    isnull(dbo.ufnProgramasPedidoColor('OS', os.idEmpresa, os.idOS), p.programa) nombrePrograma,
    s.nombreServicio
  from osCab os
   inner join empresa e on os.idEmpresa = e.idEmpresa
   inner join provClientes pc on os.codigoPC = pc.codigo
   inner join osTipoAprobacion a on os.idTipoAprobacion = a.idTipoAprobacion
   inner join tipoMonedas m on os.idTipoMoneda = m.idTipoMoneda
   inner join condicionesPago c on os.idCondPago = c.idCondPago
   left join programas p on os.codPrograma = p.idPrograma
   left join servicio s on os.codServicio = s.codServicio
  where os.idEmpresa = @filtroInt1
   and os.idOS = @filtroInt2;

 end
 else if @opcion = 10
 begin
  -- Buscar OS por Codigo - Detalle : OrdenCompraRpteView
  select idEmpresa,
    idOS,
    secuencia,
    det.codNivel,
    det.codGrupo,
    det.codTalla,
    det.codColor,
    det.codNivel + '.' + det.codGrupo + '.' + det.codTalla + '.' + det.codColor as codProductoGeneral,
    (n.codNivel + ' - ' + g.grupo + ' - ' + t.descripcion) as producto,
    c.descripcion as color,
    cantidad,
    g.codUM,
    igv,
    precioUnitario,
    convert(decimal(18,2),(cantidad * precioUnitario)) as total,
    isnull(det.obs1,'') as obs1,
    isnull(det.obs2,'') as obs2,
    isnull(det.obs3,'') as obs3,
    isnull(det.obs4,'') as obs4,
    isnull(det.obs5,'') as obs5,
    det.IdPedidoColor,
    case
     when det.IdPedidoColor is not null then
      concat(pe.pedido,' ',col.descripcion)
     else
     ''
    end PedidoColor
  from osDet det
   inner join productoServicios p on det.codNivel = p.codNivel
           and det.codGrupo = p.codGrupo
           and det.codTalla = p.codTalla
           and det.codColor = p.codColor
   inner join niveles n on p.codNivel = n.codNivel
   inner join grupos g on p.codNivel = g.codNivel
        and p.codGrupo = g.codGrupo
   inner join tallas t on t.codTalla = p.codTalla
   inner join colores c on p.codColor = c.codColor
   inner join unidadMedidas um on g.codUM = um.codUM
   left join pedidosColor pc on pc.idPedidoColor = det.IdPedidoColor
   left join colores col on col.codColor = pc.codColor
   left join pedidos pe on pe.idPedido = pc.idPedido
   left join estilos es on es.idEstilo = pe.idEstilo
   left join programas pr on pr.idPrograma = pe.idPrograma

  where idEmpresa = @filtroInt1
   and idOS = @filtroInt2;

 end
 else if @opcion = 11
 begin
  -- Listar firmantes
  select osf.idUsuario,
    osf.idTipoAprobacion,
      (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as colaborador,
    ta.descripcion as tipoAprobacion,
    ta.nivelAprobacion,
    osf.rutaImgFirma,
    osf.estado,
    osf.usuReg,
    convert(varchar, osf.fechaReg, 23) as fechaReg
  from osFirmantes osf
   inner join usuarios u on osf.idUsuario = u.id
   inner join personas p on u.numDoc = p.numDoc
   inner join osTipoAprobacion ta on osf.idTipoAprobacion = ta.idTipoAprobacion
  where u.idEmpresa = @filtroInt1
  order by p.apellidoPaterno asc;
 end
 else if @opcion = 12
 begin
  -- Buscar usuarios para aprobación de Orden de Compra : BuscarUsuarioView
  select u.id,
    (c.apellidoPaterno + ' ' + c.apellidoMaterno + ' ' + c.nombres + ' (' + u.usuario + ')') as colaborador
  from usuarios u
   inner join personas c on u.numDoc = c.numDoc
  where u.estado = 1
   and u.idEmpresa = @filtroInt1
  order by c.apellidoPaterno asc, c.apellidoMaterno asc;

 end
 else if @opcion = 13
 begin
  -- Buscar tipos de Aprobaciones : FirmantesOSView - ComboBox
  select tbl.idTipoAprobacion,
    tbl.descripcion
  from (select 0 as idTipoAprobacion,
     '-- Seleccione --' as descripcion
   union all
   select idTipoAprobacion,
     descripcion
   from osTipoAprobacion
   where estado = 1) as tbl
  order by tbl.idTipoAprobacion asc;

 end
 else if @opcion = 14
 begin
  -- Lista de Observaciones : ObservacionesOCView
  select idObs,
    observacion,
    estado,
    usuReg,
    convert(varchar, fechaReg, 103) as fechaReg
  from osObservaciones;

 end
 else if @opcion = 15
 begin
  -- Listar Firmante por Nivel
  select f.idUsuario,
    f.idTipoAprobacion,
    ta.nivelAprobacion
  from osfirmantes f
   inner join osTipoAprobacion ta on f.idTipoAprobacion = ta.idTipoAprobacion
  where ta.estado = 1
   and f.idUsuario = @filtroInt1
   and ta.nivelAprobacion = @filtroInt2;

 end
 else if @opcion = 16
 begin
  -- Listar firmantes por orden de compra.
  select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
    ta.descripcion as tipoAprobacion
  from osCab os
   inner join osAprobacionFirmas af on os.idOS = af.idOS
   inner join osfirmantes   f on af.idUsuario = f.idUsuario and af.idTipoAprobacion = f.idTipoAprobacion
   inner join osTipoAprobacion  ta on af.idTipoAprobacion = ta.idTipoAprobacion
   inner join usuarios    u on af.idUsuario = u.id
   inner join personas    p on u.numDoc = p.numDoc
  where os.idEmpresa = @filtroInt1
   and os.idOS = @filtroInt2;

 end
 else if @opcion = 17
 begin
  -- Listar observaciones de orden de compra : OrdenCompraRpteView - Reporte.
  select idObs,
    observacion
  from osObservaciones
  where estado = 1
  order by idObs asc;

 end
 else if @opcion = 18
 begin
  -- Listar firmantes de orden de compra : OrdenCompraRpteView - Reporte.
  --select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
  --  f.rutaImgFirma,
  --  ta.nivelAprobacion
  --from osCab os
  -- inner join osAprobacionFirmas af on os.idOS = af.idOS
  -- inner join osfirmantes   f on af.idUsuario = f.idUsuario and af.idTipoAprobacion = f.idTipoAprobacion
  -- inner join osTipoAprobacion  ta on af.idTipoAprobacion = ta.idTipoAprobacion
  -- inner join usuarios    u on af.idUsuario = u.id
  -- inner join personas    p on u.numDoc = p.numDoc
  --where os.idEmpresa = @filtroInt1
  -- and os.idOS = @filtroInt2
  -- and ta.nivelAprobacion = 1
  --union all

  select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
    --f.rutaImgFirma,
    (
     select top 1 rutaImgFirma from osfirmantes where IdUsuario = u.id
    )rutaImgFirma,
    1 nivelAprobacion,
    u.Cargo
  from osCab os
   inner join usuarios    u on

   --os.usuCreacionReg
   case os.usuCreacionReg
     when  'JMORAN' THEN  'MMENDEZ'
     ELSE
     os.usuCreacionReg
    end

   = u.usuario
   inner join personas    p on u.numDoc = p.numDoc
  where os.idEmpresa = @filtroInt1
   and os.idOS = @filtroInt2

  --select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
  --  f.rutaImgFirma,
  --  1 nivelAprobacion,
  --  u.Cargo
  --from osfirmantes   f

  -- inner join usuarios    u on f.idUsuario = u.id
  -- inner join personas    p on u.numDoc = p.numDoc
  -- where f.idUsuario = 27

  union all

  -- NIVEL 2
  select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
    f.rutaImgFirma,
    2,
    u.Cargo
  from osfirmantes   f

   inner join usuarios    u on f.idUsuario = u.id
   inner join personas    p on u.numDoc = p.numDoc
   where f.idUsuario = 23

 end
 else if @opcion = 19
 begin
  -- Reporte de Ordenes de Servicio
  SELECT cab.idEmpresa,
    cab.idOS,
    format(cab.fechaEmision,'dd/MM/yyyy') as fechaEmision,
    format(cab.fechaEntrega,'dd/MM/yyyy') as fechaEntrega,
    pc.razonSocial,
    cab.codigoPC,

    case when cab.idTipoMoneda = 1 then 'S'
      when cab.idTipoMoneda = 2 then 'D'
      else ''
    end as tipoMoneda,

    case when cab.tipoCompra = 'N' then 'NACIONAL'
      when cab.tipoCompra = 'I' then 'IMPORTADO'
      else ''
    end as tipoCompra,

    cp.condicion,

    -- cab.idTipoAprobacion,
    case when cab.idTipoAnulado > 0 then 'Anulado' else 'Activo' end estadooc,

    --cab.usuarioAnulado,
    cab.usuCreacionReg,
    format(cab.usuFechaReg,'dd/MM/yyyy HH:mm') as usuFechaReg,
    cab.observacion,

    det.codNivel,
    det.codGrupo,
    det.codTalla,
    det.codColor,
    det.codNivel + '.' + det.codGrupo + '.' + det.codTalla + '.' + det.codColor as codProductoGeneral,
    (n.codNivel + ' - ' + g.grupo + ' - ' + t.descripcion) as producto,
    c.descripcion as color,
    cantidad,
    g.codUM,
    igv,
    precioUnitario,
    convert(decimal(18,2),(cantidad * precioUnitario)) as total,
    isnull(det.obs1,'') as obs1,
    isnull(det.obs2,'') as obs2,
    isnull(det.obs3,'') as obs3,
    isnull(det.obs4,'') as obs4,
    isnull(det.obs5,'') as obs5

    FROM dbo.osCab cab
   inner join provClientes pc on cab.codigoPC = pc.codigo
   inner join condicionesPago cp on cab.idCondPago = cp.idCondPago
   inner join dbo.osDet det on cab.idEmpresa = det.idEmpresa and cab.idOS = det.idOS
   inner join productoServicios p on det.codNivel = p.codNivel
           and det.codGrupo = p.codGrupo
           and det.codTalla = p.codTalla
           and det.codColor = p.codColor
   inner join niveles n on p.codNivel = n.codNivel
   inner join grupos g on p.codNivel = g.codNivel
        and p.codGrupo = g.codGrupo
   inner join tallas t on t.codTalla = p.codTalla
   inner join colores c on p.codColor = c.codColor
   inner join unidadMedidas um on g.codUM = um.codUM
  WHERE cast(cab.fechaEmision as date) between cast(@filtroTxt1 as date) and cast(@filtroTxt2 as date)
 end

 else if @opcion = 20
 begin

  -- Buscar OS por Codigo - Cabecera : RegistroOSView
  select idEmpresa,
    idOS,
    fechaEmision,
    fechaEntrega,
    codigoPC,
    pc.razonSocial,
    pc.direccion,
    idTipoMoneda,
    tipoCompra,
    idCondPago,
    os.idTipoAprobacion,
    a.descripcion as tipoAprobacion,
    idTipoAnulado,
    fechaAnulado,
    usuarioAnulado,
    usuCreacionReg,
    usuFechaReg,
    observacion,
    dbo.ufnOSSubTotal(idEmpresa, idOS) as subTotal,
    dbo.ufnOSIGV(idEmpresa, idOS) as igv,
    dbo.ufnOSTotal(idEmpresa, idOS) as total,
    os.usuCreacionReg,
    os.codServicio,
    se.nombreServicio,
    os.codPrograma,
    pr.programa nombrePrograma
  from osCabEspecial os
   inner join provClientes pc on os.codigoPC = pc.codigo
   inner join osTipoAprobacion a on os.idTipoAprobacion = a.idTipoAprobacion
   left join servicio se on os.codServicio = se.codServicio
   left join programas pr on os.codPrograma = pr.idPrograma
  where idEmpresa = @filtroInt1
   and idOS = @filtroInt2;
 end


 else if @opcion = 21
 begin

  create table #tmptallas(
   codTalla  char(3),
   ordenTalla  int,
   talla   varchar(100)
  )

  insert into #tmptallas(
   codTalla,talla,ordenTalla
  )
  exec [dbo].[uspGetMantenimiento] 48


  DECLARE @cols AS NVARCHAR(MAX),
        @query AS NVARCHAR(MAX);

  -- OBTENEMOS COLUMNAS
  set @cols = STUFF((SELECT ',' + QUOTENAME(talla)
    from #tmptallas

    FOR XML PATH(''), TYPE
    ).value('.', 'NVARCHAR(MAX)')
   ,1,1,'')



   SET @query = 'SELECT
          idEmpresa,
          idOS,
          secuencia,
          pedido,
          codigoEstilo,
          estilo,
          color,
          ' + @cols  +',
          precio,
          (
           select SUM(
            cantidad
           ) from osDetTallasEspecial b where b.idEmpresa = p.idEmpresa
           and b.idOS = p.idOs and b.secuencia = p.Secuencia
          ) totalTalla,
          0 total,
          idPedidoColor
      FROM
      (
        select
         a.idEmpresa,
         a.idOS,
         a.secuencia,
         c.pedido,
         d.codigoEstilo,
         d.estilo,
         e.descripcion color,
         trim(g.descripcion)talla,
         f.cantidad,
         b.idPedidoColor,
         a.precio
        from osDetEspecial a
        inner join pedidosColor b
        on b.idPedidoColor = a.idPedidoColor
        inner join pedidos c
        on c.idPedido = b.idPedido
        inner join estilos d
        on d.idEstilo = c.idEstilo
        inner join colores e
        on e.codColor = b.codColor
        inner join osDetTallasEspecial f
        on f.idEmpresa = a.idEmpresa
        and f.idOS  = a.idOS
        and f.secuencia = a.secuencia
        inner join tallas g
        on g.codTalla = f.codTalla
        where a.idEmpresa = ' + @filtroTxt1 + '
        and a.idOS = ' +  @filtroTxt2 + '
        ) x
      PIVOT
      (
       SUM(Cantidad)
       FOR talla IN (' + @cols + ')
      ) p '

   print @query

   EXEC(@query);



 end

  else if @opcion = 22
 begin
  -- Buscar OS por Codigo - Cabecera : OrdenCompraRpteView
  select e.ruc as empresaRUC,
    e.direccion as empresaDireccion,
    os.idOS as codigoOS,
    convert(varchar, os.fechaEmision,103) as fechaEmision,
    convert(varchar, os.fechaEntrega,103) as fechaEntrega,
    pc.razonSocial as proveedorRS,
    pc.codigo as proveedorRUC,
    pc.direccion as proveedorDireccion,
    isnull(pc.contacto,'') as contacto,
    isnull(pc.telefono,'') as telefono,
    isnull(pc.email,'') email,
    m.monedaSingular as tipoMoneda,
    case when tipoCompra = 'N' then 'NACIONAL'
      when tipoCompra = 'I' then 'IMPORTADO'
      else 'INDEFINIDO'
    end as tipoCompra,
    c.condicion as formaPago,
    dbo.ufnTipoCambioXFecha (os.fechaEmision) as tipoCambio,
    dbo.ufnOSSubTotalEspecial(os.idEmpresa, os.idOS) as subTotal,
    0 as descuento,
    dbo.ufnOSSubTotalEspecial(os.idEmpresa, os.idOS) as baseImponible,

    (dbo.ufnOSSubTotalEspecial(os.idEmpresa, os.idOS) * 0.18) AS igv,

    --dbo.ufnOSIGV(os.idEmpresa, os.idOS) as igv,

    --dbo.ufnOSTotal(os.idEmpresa, os.idOS) as total,

    (dbo.ufnOSSubTotalEspecial(os.idEmpresa, os.idOS) +
    (dbo.ufnOSSubTotalEspecial(os.idEmpresa, os.idOS) * 0.18)) as total,

    --dbo.ufnOSSubTotalEspecial(os.idEmpresa, os.idOS)

    [dbo].[ufnMontoLetras] (dbo.ufnOSTotal(os.idEmpresa, os.idOS), UPPER(m.monedaPlural)) as montoLetras,
    m.simbolo,
    os.observacion,
    isnull(dbo.ufnProgramasPedidoColor('OSE', os.idEmpresa, os.idOS), p.programa) nombrePrograma,
    s.nombreServicio
  from osCabEspecial os
   inner join empresa e on os.idEmpresa = e.idEmpresa
   inner join provClientes pc on os.codigoPC = pc.codigo
   inner join osTipoAprobacion a on os.idTipoAprobacion = a.idTipoAprobacion
   inner join tipoMonedas m on os.idTipoMoneda = m.idTipoMoneda
   inner join condicionesPago c on os.idCondPago = c.idCondPago
   left join programas p on os.codPrograma = p.idPrograma
   left join servicio s on os.codServicio = s.codServicio
  where os.idEmpresa = @filtroInt1
   and os.idOS = @filtroInt2;

 end
 else if @opcion = 23
 begin

   select
     det.idPedidoColor,
     det.idEmpresa,
     det.secuencia,
     det.idOS,
     p.pedido,
     es.codigoEstilo,
     es.estilo,
     trim(co.descripcion)color,
     tal.codTalla,
     trim(t.descripcion) tallaDescripcion,
     tal.cantidad,
     det.precio
   from osDetEspecial det
    inner join osDetTallasEspecial tal
    on tal.idEmpresa = det.idEmpresa
    and tal.idOS  = det.idOS
    and tal.secuencia = det.secuencia
    inner join tallas t on t.codTalla = tal.codTalla
    inner join pedidosColor pc
    on pc.idPedidoColor = det.idPedidoColor
    inner join pedidos p
    on p.idPedido = pc.idPedido
    inner join estilos es
    on es.idEstilo = p.idEstilo
    inner join colores co
    on co.codColor = pc.codColor
   where det.idEmpresa = @filtroInt1
    and det.idOS = @filtroInt2


 end
 else if @opcion = 24
 begin

   SELECT
    b.codTalla,
    b.descripcion codTallaDescripcion
   FROM osDetEspecial a
   inner join osDetTallasEspecial d
   on d.idEmpresa  = a.idEmpresa
   and d.idOS   = a.idOS
   and d.secuencia  = a.secuencia
   inner join tallas b
   on b.codTalla = d.codTalla
   WHERE  a.idEmpresa = @filtroInt1
   and a.idOS = @filtroInt2
    group by
     b.codTalla,
     b.descripcion


 end
 else if @opcion = 25
 begin
  select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
    '' as rutaImgFirma,
    1 as nivelAprobacion
  from osCabEspecial os
   inner join usuarios    u on os.usuCreacionReg = u.usuario
   inner join personas    p on u.numDoc = p.numDoc
  where os.idEmpresa = @filtroInt1
   and os.idOS = @filtroInt2;
 end

 else if @opcion = 26
 begin

  -- Buscar OS por Codigo - Cabecera : RegistroOSView
  select idEmpresa,
    idOrdenSalida,
    fechaEmision,
    fechaEntrega,
    codigoPC,
    pc.razonSocial,
    pc.direccion,
    idTipoMoneda,
    tipoCompra,
    idCondPago,
    os.idTipoAprobacion,
    a.descripcion as tipoAprobacion,
    idTipoAnulado,
    fechaAnulado,
    usuarioAnulado,
    usuCreacionReg,
    usuFechaReg,
    observacion,
    dbo.ufnOSSubTotal(idEmpresa, idOrdenSalida) as subTotal,
    dbo.ufnOSIGV(idEmpresa, idOrdenSalida) as igv,
    dbo.ufnOSTotal(idEmpresa, idOrdenSalida) as total,
    os.usuCreacionReg,
    os.codServicio,
    se.nombreServicio,
    os.codPrograma,
    --pr.nombrePrograma
    pr.programa nombrePrograma
  from OrdenSalidaCab os
   inner join provClientes pc on os.codigoPC = pc.codigo
   inner join osTipoAprobacion a on os.idTipoAprobacion = a.idTipoAprobacion
   left join servicio se on os.codServicio = se.codServicio
   left join programas pr on os.codPrograma = pr.idPrograma --pr.codPrograma
  where idEmpresa = @filtroInt1
   and idOrdenSalida = @filtroInt2;
 end
  else if @opcion = 27
 begin
  -- Buscar OC por Codigo - Detalle : RegistroOSView
  select idEmpresa,
    idOrdenSalida,
    secuencia,
    det.codNivel,
    det.codGrupo,
    det.codTalla,
    det.codColor,
      (n.codNivel + ' - ' + g.grupo + ' - ' + rtrim(ltrim(t.descripcion)) + ' - ' + rtrim(ltrim(c.descripcion))) as producto,
    c.descripcion as color,
    cantidad,
    g.codUM,
    igv,
    precioUnitario,
    isnull(obs1,'') as obs1,
    isnull(obs2,'') as obs2,
    isnull(obs3,'') as obs3,
    isnull(obs4,'') as obs4,
    isnull(obs5,'') as obs5,
    dbo.ufnOCTieneGRFACT(det.idEmpresa, det.idOrdenSalida, det.secuencia, 'S') as tienegrfact
  from OrdenSalidaDet det
   inner join productoServicios p on det.codNivel = p.codNivel
           and det.codGrupo = p.codGrupo
           and det.codTalla = p.codTalla
           and det.codColor = p.codColor
   inner join niveles n on p.codNivel = n.codNivel
   inner join grupos g on p.codNivel = g.codNivel
        and p.codGrupo = g.codGrupo
   inner join tallas t on t.codTalla = p.codTalla
   inner join colores c on p.codColor = c.codColor
   inner join unidadMedidas um on g.codUM = um.codUM
  where idEmpresa = @filtroInt1
   and idOrdenSalida = @filtroInt2;

 end
end

GO
