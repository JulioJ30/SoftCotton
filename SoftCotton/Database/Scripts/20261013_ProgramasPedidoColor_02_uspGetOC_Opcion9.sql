/*
    Programas de los pedidos en la cabecera del formato de Orden de Compra
    -------------------------------------------------------------------------
    uspGetOC @opcion = 9 (Rpte9_OrdenCompraCabecera): OrdenCompraRpte / OrdenCompraRpteV2.

    En la cabecera, la columna nombrePrograma ahora toma los programas distintos
    de los pedidos del detalle (IdPedidoColor -> pedidosColor -> pedidos -> programas)
    via dbo.ufnProgramasPedidoColor. Si ningun item del detalle tiene IdPedidoColor,
    se mantiene el programa de la cabecera (codPrograma), como hasta ahora.

    El resto del procedimiento se deja exactamente igual al texto actual
    (obtenido via OBJECT_DEFINITION('uspGetOC') de bdsoftcotton al 13/10/2026).
    Si en produccion el procedimiento cambio despues de esa fecha, comparar antes
    de ejecutar (sp_helptext uspGetOC).

    Requiere: 20261013_ProgramasPedidoColor_01_ufnProgramasPedidoColor.sql
    Ejecutar una sola vez contra la base de datos de SoftCotton (bdsoftcotton).
*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER procedure [dbo].[uspGetOC]
	@opcion int,
	@filtroTxt1 varchar(100),
	@filtroTxt2 varchar(100),
	@filtroInt1 int,
	@filtroInt2 int
as
begin
	if @opcion = 1
	begin
		-- Tipo de Moneda : RegistroOCView
		select	0 as idTipoMoneda,
				'- Seleccione -' as moneda
		union all
		select	idTipoMoneda,
				simbolo + ' - ' + monedaSingular
		from	tipoMonedas

	end
	else if @opcion = 2
	begin
		-- Condición de Pago : RegistroOCView
		select	0 as idCondPago,
				'- Seleccione -' as condicion
		union all
		select	idCondPago,
				condicion
		from	condicionesPago;

	end
	else if @opcion = 3
	begin
		-- Buscar Proveedores y Clientes.
		-- @filtroTxt1 : Filtro de busqueda : RegistroOCView
		select	codigo,
				razonSocial,
				direccion
		from	provClientes
		where	estado = 1
			And (codigo like '%' + @filtroTxt1 + '%'
			  Or razonSocial like '%' + @filtroTxt1 + '%');

	end
	else if @opcion = 5
	begin
		-- Listar Tipo de Aprobaciones : TipoAprobacionView / RegistroOCView
		select	idTipoAprobacion,
				descripcion,
				estado,
				nivelAprobacion,
				usuarioReg,
				fechaReg
		from	ocTipoAprobacion
		order by nivelAprobacion

	end
	else if @opcion = 6
	begin
		-- Listar Tipos de Anulados : TipoAnuladoView / RegistroOCView
		select	idTipoAnulado,
				descripcion,
				estado,
				usuarioReg,
				fechaReg
		from	ocTipoAnulado;

	end
	else if @opcion = 7
	begin
		-- Buscar OC por Codigo - Cabecera : RegistroOCView
		select	idEmpresa,
				idOC,
				fechaEmision,
				fechaEntrega,
				codigoPC,
				pc.razonSocial,
				pc.direccion,
				idTipoMoneda,
				tipoCompra,
				idCondPago,
				oc.idTipoAprobacion,
				a.descripcion as tipoAprobacion,
				idTipoAnulado,
				fechaAnulado,
				usuarioAnulado,
				usuCreacionReg,
				usuFechaReg,
				observacion,
				dbo.ufnOCSubTotal(idEmpresa, idOC) as subTotal,
				dbo.ufnOCIGV(idEmpresa, idOC) as igv,
				dbo.ufnOCTotal(idEmpresa, idOC) as total,
				oc.usuCreacionReg,
				oc.codServicio,
				se.nombreServicio,
				oc.codPrograma,
				pr.programa nombrePrograma
				--pr.nombrePrograma
		from	ocCab oc
			--inner join provClientes pc  on RIGHT(REPLICATE('0', 20) + LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(oc.codigoPC, CHAR(160), ''), CHAR(9), ''), CHAR(13), ''))), 11)
   --  = trim(pc.codigo)
   inner join provClientes pc  on
		trim(oc.codigoPC) = trim(pc.codigo)
			left join ocTipoAprobacion a on oc.idTipoAprobacion = a.idTipoAprobacion
			left join servicio se on oc.codServicio = se.codServicio
			left join programas pr on oc.codPrograma = pr.idPrograma
		where	idEmpresa = @filtroInt1
			and idOC = @filtroInt2;


	end
	else if @opcion = 8
	begin
		-- Buscar OC por Codigo - Detalle : RegistroOCView
		select	idEmpresa,
				idOC,
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
				dbo.ufnOCTieneGRFACT(det.idEmpresa, det.idOC, det.secuencia, 'C') as tienegrfact
		from	ocDet det
			inner join productoServicios p	on	det.codNivel = p.codNivel
											and	det.codGrupo = p.codGrupo
											and det.codTalla = p.codTalla
											and det.codColor = p.codColor
			inner join niveles n on p.codNivel = n.codNivel
			inner join grupos g on	p.codNivel = g.codNivel
								and p.codGrupo = g.codGrupo
			inner join tallas t on	t.codTalla = p.codTalla
			inner join colores	c	on	p.codColor = c.codColor
			inner join unidadMedidas um on g.codUM = um.codUM
		where	idEmpresa = @filtroInt1
			and idOC = @filtroInt2;

	end
	else if @opcion = 9
	begin
		-- Buscar OC por Codigo - Cabecera : OrdenCompraRpteView
		select	e.ruc as empresaRUC,
				e.direccion as empresaDireccion,
				oc.idOC as codigoOC,
				convert(varchar,oc.fechaEmision,103) as fechaEmision,
				convert(varchar,oc.fechaEntrega,103) as fechaEntrega,
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
				dbo.ufnTipoCambioXFecha (oc.fechaEmision) as tipoCambio,
				dbo.ufnOCSubTotal(oc.idEmpresa, oc.idOC) as subTotal,
				0 as descuento,
				dbo.ufnOCSubTotal(oc.idEmpresa, oc.idOC) as baseImponible,
				dbo.ufnOCIGV(oc.idEmpresa, oc.idOC) as igv,
				dbo.ufnOCTotal(oc.idEmpresa, oc.idOC) as total,
				dbo.ufnMontoLetras (dbo.ufnOCTotal(oc.idEmpresa, oc.idOC), UPPER(m.monedaPlural)) as montoLetras,
				m.simbolo,
				oc.observacion,
				isnull(dbo.ufnProgramasPedidoColor('OC', oc.idEmpresa, oc.idOC), p.programa) nombrePrograma
		from	ocCab oc
			inner join empresa e on oc.idEmpresa = e.idEmpresa
			inner join provClientes pc on oc.codigoPC = pc.codigo
			inner join ocTipoAprobacion a on oc.idTipoAprobacion = a.idTipoAprobacion
			inner join tipoMonedas m on oc.idTipoMoneda = m.idTipoMoneda
			inner join condicionesPago c on oc.idCondPago = c.idCondPago
			left join programas p on oc.codPrograma = p.idPrograma
		where	oc.idEmpresa = @filtroInt1
			and oc.idOC = @filtroInt2;
	end
	else if @opcion = 10
	begin
		-- Buscar OC por Codigo - Detalle : OrdenCompraRpteView
		select	idEmpresa,
				idOC,
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
		from	ocDet det
			inner join productoServicios p	on	det.codNivel = p.codNivel
											and	det.codGrupo = p.codGrupo
											and det.codTalla = p.codTalla
											and det.codColor = p.codColor
			inner join niveles n on p.codNivel = n.codNivel
			inner join grupos g on	p.codNivel = g.codNivel
								and p.codGrupo = g.codGrupo
			inner join tallas t on	t.codTalla = p.codTalla
			inner join colores	c	on	p.codColor = c.codColor
			inner join unidadMedidas um on g.codUM = um.codUM
			left join pedidosColor pc on pc.idPedidoColor = det.IdPedidoColor
			left join colores col on col.codColor = pc.codColor
			left join pedidos pe on pe.idPedido = pc.idPedido
			left join estilos es on es.idEstilo = pe.idEstilo
			left join programas pr on pr.idPrograma = pe.idPrograma

		where	idEmpresa = @filtroInt1
			and idOC = @filtroInt2;


	end
	else if @opcion = 11
	begin
		-- Listar firmantes
		select	ocf.idUsuario,
				ocf.idTipoAprobacion,
			   (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as colaborador,
				ta.descripcion as tipoAprobacion,
				ta.nivelAprobacion,
				ocf.rutaImgFirma,
				ocf.estado,
				ocf.usuReg,
				convert(varchar, ocf.fechaReg, 23) as fechaReg
		from	ocFirmantes ocf
			inner join usuarios u on ocf.idUsuario = u.id
			inner join personas p on u.numDoc = p.numDoc
			inner join ocTipoAprobacion ta on ocf.idTipoAprobacion = ta.idTipoAprobacion
		where	u.idEmpresa = @filtroInt1
		order by	p.apellidoPaterno asc;
	end
	else if @opcion = 12
	begin
		-- Buscar usuarios para aprobación de Orden de Compra : BuscarUsuarioView
		select	u.id,
				(c.apellidoPaterno + ' ' + c.apellidoMaterno + ' ' + c.nombres + ' (' + u.usuario + ')') as colaborador
		from	usuarios u
			inner join personas c on u.numDoc = c.numDoc
		where	u.estado = 1
			and u.idEmpresa = @filtroInt1
		order by c.apellidoPaterno asc, c.apellidoMaterno asc;

	end
	else if @opcion = 13
	begin
		-- Buscar tipos de Aprobaciones : FirmantesOCView - ComboBox
		select	tbl.idTipoAprobacion,
				tbl.descripcion
		from (select	0 as idTipoAprobacion,
					'-- Seleccione --' as descripcion
			union all
			select	idTipoAprobacion,
					descripcion
			from	ocTipoAprobacion
			where	estado = 1) as tbl
		order by tbl.idTipoAprobacion asc;

	end
	else if @opcion = 14
	begin
		-- Lista de Observaciones : ObservacionesOCView
		select	idObs,
				observacion,
				estado,
				usuReg,
				convert(varchar,fechaReg,103) as fechaReg
		from	ocObservaciones;

	end
	else if @opcion = 15
	begin
		-- Listar Firmante por Nivel
		select	f.idUsuario,
				f.idTipoAprobacion,
				ta.nivelAprobacion
		from	ocFirmantes f
			inner join ocTipoAprobacion ta on f.idTipoAprobacion = ta.idTipoAprobacion
		where	ta.estado = 1
			and f.idUsuario = @filtroInt1
			and ta.nivelAprobacion = @filtroInt2;

	end
	else if @opcion = 16
	begin
		-- Listar firmantes por orden de compra.
		select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
				ta.descripcion as tipoAprobacion
		from	ocCab oc
			inner join ocAprobacionFirmas	af	on oc.idOC = af.idOC
			inner join ocFirmantes			f	on af.idUsuario = f.idUsuario and af.idTipoAprobacion = f.idTipoAprobacion
			inner join ocTipoAprobacion		ta	on af.idTipoAprobacion = ta.idTipoAprobacion
			inner join usuarios				u	on af.idUsuario = u.id
			inner join personas				p	on u.numDoc = p.numDoc
		where	oc.idEmpresa = @filtroInt1
			and	oc.idOC = @filtroInt2;

	end
	else if @opcion = 17
	begin
		-- Listar observaciones de orden de compra : OrdenCompraRpteView - Reporte.
		select	idObs,
				observacion
		from	ocObservaciones
		where	estado = 1
		order by idObs asc;

	end
	else if @opcion = 18
	begin
		-- Listar firmantes de orden de compra : OrdenCompraRpteView - Reporte.
		--select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
		--		f.rutaImgFirma,
		--		ta.nivelAprobacion
		--from	ocCab oc
		--	inner join ocAprobacionFirmas	af	on oc.idOC = af.idOC
		--	inner join ocFirmantes			f	on af.idUsuario = f.idUsuario and af.idTipoAprobacion = f.idTipoAprobacion
		--	inner join ocTipoAprobacion		ta	on af.idTipoAprobacion = ta.idTipoAprobacion
		--	inner join usuarios				u	on af.idUsuario = u.id
		--	inner join personas				p	on u.numDoc = p.numDoc
		--where	oc.idEmpresa = @filtroInt1
		--	and	oc.idOC = @filtroInt2

		--	and ta.nivelAprobacion = 1
		select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
				(
					select top 1 rutaImgFirma from ocFirmantes where IdUsuario = u.id
				)rutaImgFirma,
				1 nivelAprobacion,
				u.Cargo
		from	ocCab os
			inner join usuarios				u	on
				 case os.usuCreacionReg
					when  'JMORAN' THEN  'MMENDEZ'
					ELSE
					os.usuCreacionReg
				end
			=
			u.usuario
			inner join personas				p	on u.numDoc = p.numDoc
		where	os.idEmpresa = @filtroInt1
			and	os.idOC = @filtroInt2

		--select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
		--		f.rutaImgFirma,
		--		1 nivelAprobacion,
		--		u.Cargo
		--from	ocfirmantes			f

		--	inner join usuarios				u	on f.idUsuario = u.id
		--	inner join personas				p	on u.numDoc = p.numDoc
		--	where f.idUsuario in (30)

		union all

		-- NIVEL 2
		select (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as firmante,
				f.rutaImgFirma,
				2,
				u.Cargo
		from	ocfirmantes			f

			inner join usuarios				u	on f.idUsuario = u.id
			inner join personas				p	on u.numDoc = p.numDoc
			where f.idUsuario = 23



	end
	else if @opcion = 19
	begin
		-- Reporte de Ordenes de Compra
		SELECT	cab.idEmpresa,
				cab.idOC,
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
				isnull(det.obs5,'') as obs5,
				pro.programa

		  FROM dbo.ocCab cab
			inner join provClientes pc on cab.codigoPC = pc.codigo
			inner join condicionesPago cp on cab.idCondPago = cp.idCondPago
			inner join dbo.ocDet det on cab.idEmpresa = det.idEmpresa and cab.idOC = det.idOC
			inner join productoServicios p	on	det.codNivel = p.codNivel
											and	det.codGrupo = p.codGrupo
											and det.codTalla = p.codTalla
											and det.codColor = p.codColor
			inner join niveles n on p.codNivel = n.codNivel
			inner join grupos g on	p.codNivel = g.codNivel
								and p.codGrupo = g.codGrupo
			inner join tallas t on	t.codTalla = p.codTalla
			inner join colores	c	on	p.codColor = c.codColor
			inner join unidadMedidas um on g.codUM = um.codUM
			left join programas pro on pro.idPrograma = cab.codPrograma

		WHERE	cast(cab.fechaEmision as date) between cast(@filtroTxt1 as date) and cast(@filtroTxt2 as date)



	end

	else if @opcion = 20
	begin


		--select
		--		det.idEmpresa,
		--		det.idOC,
		--		det.codNivel,
		--		det.codColor,
		--		det.codNivel + '.' + det.codGrupo + '.' + det.codColor as codProductoGeneral,
		--		(n.codNivel + ' - ' + g.grupo) as producto,
		--		c.descripcion as color
		--from	ocDet det
		--	inner join productoServicios p	on	det.codNivel = p.codNivel
		--									and	det.codGrupo = p.codGrupo
		--									and det.codTalla = p.codTalla
		--									and det.codColor = p.codColor
		--	inner join niveles n on p.codNivel = n.codNivel
		--	inner join grupos g on	p.codNivel = g.codNivel
		--						and p.codGrupo = g.codGrupo
		--	inner join tallas t on	t.codTalla = p.codTalla
		--	inner join colores	c	on	p.codColor = c.codColor
		--	inner join unidadMedidas um on g.codUM = um.codUM

		--where	idEmpresa = @filtroInt1
		--	and idOC = @filtroInt2
		--	group by
		--		det.idEmpresa,
		--		det.idOC,
		--		det.codNivel,
		--		det.codColor,
		--		det.codNivel + '.' + det.codGrupo + '.' + det.codColor,
		--		(n.codNivel + ' - ' + g.grupo),
		--		c.descripcion

		select
				det.idEmpresa,
				det.idOC,
				det.codNivel,
				det.codColor,
				det.codNivel + '.' + det.codGrupo + '.' + det.codColor as codProductoGeneral,
				(n.codNivel + ' - ' + g.grupo) as producto,
				TRIM(c.descripcion) as color,
				det.codTalla,
				trim(t.descripcion) tallaDescripcion,
				det.cantidad,
				det.precioUnitario
		from	ocDet det
			inner join productoServicios p	on	det.codNivel = p.codNivel
											and	det.codGrupo = p.codGrupo
											and det.codTalla = p.codTalla
											and det.codColor = p.codColor
			inner join niveles n on p.codNivel = n.codNivel
			inner join grupos g on	p.codNivel = g.codNivel
								and p.codGrupo = g.codGrupo
			inner join tallas t on	t.codTalla = p.codTalla
			inner join colores	c	on	p.codColor = c.codColor
			inner join unidadMedidas um on g.codUM = um.codUM

		--where	idEmpresa = 1
		--	and idOC = 623

		where	idEmpresa = @filtroInt1
			and idOC = @filtroInt2


	end
	else if @opcion = 21
	begin


			SELECT
				b.codTalla,
				b.descripcion codTallaDescripcion
			FROM ocDet a
			inner join tallas b
			on b.codTalla = a.codTalla
			WHERE  a.idEmpresa = @filtroInt1
			and a.idOC = @filtroInt2
				group by
					b.codTalla,
					b.descripcion



	end

end


GO
