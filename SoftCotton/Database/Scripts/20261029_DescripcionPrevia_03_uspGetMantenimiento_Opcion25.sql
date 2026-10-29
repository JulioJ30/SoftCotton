/*
    Descripcion previa de grupos - Script 3 de 4: uspGetMantenimiento @opcion = 25
    -----------------------------------------------------------------------------
    RegistroProductoView (lista principal de grupos) ahora tambien recibe la
    columna descripcionPrevia para poder editarla.

    El resto del procedimiento se deja exactamente igual al texto actual
    (obtenido via OBJECT_DEFINITION('uspGetMantenimiento') de bdsoftcotton al 29/10/2026).
    Si en produccion el procedimiento cambio despues de esa fecha, comparar antes
    de ejecutar (sp_helptext uspGetMantenimiento).

    Requiere: 20261029_DescripcionPrevia_01_ColumnaGrupos.sql
*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER procedure [dbo].[uspGetMantenimiento]
	@opcion int,
	@filtroTxt1 varchar(100)	= null,
	@filtroTxt2 varchar(100)	= null,
	@filtroInt1 int				= null,
	@filtroInt2 int				= null,
	@filtroDecimal decimal(16,5)	= null
as
begin
	if @opcion = 1 
	begin
		-- Formulario	: RegistroUsuarioView
		-- Tipo 		: Lista principal - DataGriView
		select	u.id,
				p.numDoc,
			 (p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres) as persona,
				u.usuario,	
				u.contrasena,
				convert(varchar,u.fechaReg,103) as fechaReg,
				u.usuarioReg,
				u.estado
		from	usuarios u
			inner join personas p on u.numDoc = p.numDoc
		order by	p.nombres asc, 
					p.apellidoPaterno asc;

	end
	else if @opcion = 2 
	begin
		-- Formulario	: RegistroModuloView
		-- Tipo 		: Lista principal - DataGriView
		select	id,
				modulo,
				iconPath,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from	modulos
	end
	else if @opcion = 3
	begin
		-- Formulario	: RegistroSubModuloView
		-- Tipo 		: Lista principal - DataGriView
		select	sm.id,
				m.id as idModulo,
				m.modulo,
				sm.submodulo,
				sm.rutaForm,
				sm.iconPath,
				sm.usuarioReg,
				convert(varchar,sm.fechaReg,103) as fechaReg,
				sm.estado
		from	submodulos sm
			inner join modulos m on sm.idModulo = m.id
		order by m.modulo asc, sm.submodulo asc;

	end
	else if @opcion = 4
	begin
		-- Formulario	: RegistroModuloView / RegistroAccesoView
		-- Tipo 		: Lista principal - ComboBox
		select	tblCbx.id,
				tblCbx.modulo
		from	(select	0 as id,
						'-- Seleccione --' as modulo
				 union all
				 select	id,
				 		modulo
				 from	modulos
				 where	estado = 1) as tblCbx
		order by tblCbx.modulo asc;
	end
	else if @opcion = 5
	begin
		-- Formulario	: RegistroAccesoView
		-- Tipo 		: Lista de Usuarios - DataGriView
		select	id as idUsuario,
				(p.apellidoPaterno + ' ' + p.apellidoMaterno + ' ' + p.nombres + ' (' + usuario + ')') as colaborador
		from	usuarios u
			inner join personas p on u.numDoc = p.numDoc
		where	estado = 1
		order by	p.apellidoPaterno asc;

	end
	else if @opcion = 6
	begin
		-- Formulario	: RegistroAccesoView
		-- Tipo			: Lista de Accesos por usuario - DataGridView
		
		-- @filtroInt1	: ID Modulo

		select	m.id as idModulo,
				m.modulo,
				sm.id as idSubModulo,
				sm.submodulo,
				sm.rutaForm,
				case when isnull(ac.idUsuario,0) > 0 then 1 else 0 end as activo
		from	submodulos sm
			inner join modulos	m	on m.id = sm.idModulo
			left join accesos	ac	on ac.idSubModulo = sm.id and ac.idUsuario = @filtroInt1
		where	sm.estado = 1 
		order by m.modulo asc, sm.submodulo asc;

	end
	else if @opcion = 7
	begin
		-- Formulario	: RegistroAccesoView
		-- Tipo 		: Lista de Centros de Costo - DataGriView
		select	codceco,
				ceco,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from centroCostos;

	end
	else if @opcion = 8
	begin
		-- Formulario	: RegistroTipoCpteView
		-- Tipo 		: Lista de Tipos de Comprobante - DataGriView
		select	codTipoCpte,
				tipoComprobante,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from tipoComprobantes;
	
	end
	else if @opcion = 9
	begin
		-- Formulario	: RegistroCondPagoView
		-- Tipo 		: Lista de condiciones de pago - DataGriView
		select	idCondPago,
				condicion,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from	condicionesPago;

	end
	else if @opcion = 10
	begin
		-- Formulario	: RegistroTipoMonedaView
		-- Tipo 		: Lista de tipos de moneda - DataGriView
		select	idTipoMoneda,
				simbolo,
				monedaSingular,
				monedaPlural,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from	tipoMonedas;

	end
	else if @opcion = 11
	begin
		-- Formulario	: RegistroTipoDocView
		-- Tipo 		: Lista de tipos de documento - DataGriView
		select	codTipoDoc,
				tipoDocLarga,
				tipoDocCorta,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from	tipoDocumentos;

	end
	else if @opcion = 12
	begin
		-- Formulario	: RegistroProvClientesView
		-- Tipo 		: Lista de Proveedores / clientes - DataGriView
		select	pc.codigo,
				pc.codTipoDoc,
				td.tipoDocCorta,
				pc.razonSocial,
				pc.nombre1,
				pc.nombre2,
				pc.apellido1,
				pc.apellido2,
				pc.codTipoPC,
				pct.tipo,
				pc.telefono,
				pc.direccion,
				pc.usuarioReg,
				convert(varchar,pc.fechaReg,103) as fechaReg,
				pc.estado,
				isnull(pc.contacto,'') as contacto,
				isnull(pc.email,'') as email,

				di.iddistrito,
				di.distrito,
				pr.idprovincia,
				pr.provincia,
				de.iddepartamento,
				de.departamento
		from	provClientes as pc
			inner join tipoDocumentos	as td	on pc.codTipoDoc = td.codTipoDoc
			inner join provClientesTPC	as pct	on pc.codTipoPC	 = pct.codTipoPC
			left join distrito		di	on di.iddistrito		= pc.iddistrito
			left join provincia		pr	on pr.idprovincia		= di.idprovincia
			left join departamento	de	on de.iddepartamento	= pr.iddepartamento

		--select * from provClientes

	end
	else if @opcion = 13
	begin
		-- Formulario	: RegistroProvClientesView : RegistroPersonaView
		-- Tipo 		: Lista de tipos de documento - ComboBox
		select	tblCbx.codTipoDoc,
				tblCbx.tipoDocCorta
		from	(select	'00' as codTipoDoc,
						'-- Seleccione --' as tipoDocCorta
				union all
				select	codTipoDoc,
						tipoDocCorta
				from	tipoDocumentos) as tblCbx;

	end
	else if @opcion = 14
	begin
		-- Formulario	: RegistroProvClientesView
		-- Tipo 		: Lista de tipos de Relacion con la Empresa - ComboBox
		select	tblCbx.codTipoPC,
				tblCbx.tipo
		from	(select	'0' as codTipoPC,
						'-- Seleccione --' as tipo
				union all
				select	codTipoPC,
						tipo
				from	provClientesTPC) as tblCbx;

	end
	else if @opcion = 15
	begin
		-- Formulario	: RegistronivelView
		-- Tipo 		: Lista de niveles - DataGriView
		select	codNivel,
				nivel,
				abreviatura,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from	niveles;

	end
	else if @opcion = 16
	begin
		-- Listar tipos de nivel : RegistroProductoView - ComboBox
		select	'00' as codNivel,
				'-- Seleccione -- ' as nivel
		union all
		select	codNivel,
			 (codNivel + ' - ' + nivel) as nivel
		from	niveles
		where	estado = 1;

	end	
	else if @opcion = 17
	begin
		-- Listar tipos de Tallas : RegistroProductoView - ComboBox
		select	'000' as codTalla,
				'-- Seleccione -- ' as descripcion
		union all
		select	codTalla,
			 (codTalla + ' - ' + descripcion) as descripcion
		from	tallas;

	end
	else if @opcion = 18
	begin
		-- Listar tipos de Colores : RegistroProductoView - ComboBox
		select	'000000' as codColor,
				'-- Seleccione -- ' as descripcion
		union all
		select	codColor,
			 (codColor + ' - ' + descripcion) as descripcion
		from	colores

	end
	else if @opcion = 19
	begin
		-- Listar tipos de unidades de medida : RegistroProductoView - ComboBox
		select	'000' as codUM,
				'-- Seleccione -- ' as descripcion
		union all
		select	codUM,
			 (codUM + ' - ' + descripcion) as descripcion
		from	unidadMedidas
		where	estado = 1;

	end
	else if @opcion = 20
	begin
		-- Listar de grupos : RegistroProductoView - DataGridView
		--select	f.codnivel,
		--		f.nivel,
		--		p.codGrupo,
		--		p.codGrupoAlt,
		--		p.grupo as producto,
		--		t.codTalla,
		--		t.descripcion as talla,
		--		c.codColor,
		--		c.descripcion as color,
		--		um.codUM,
		--		um.descripcion as unidadMedida,
		--		p.estado,
		--		p.usuarioReg,
		--		p.fechaReg
		--from grupos p as
		--	inner join niveles f on p.codnivel = f.codnivel
		--	inner join tallas t on p.codTalla = t.codTalla
		--	inner join colores c on p.codColor = c.codColor
		--	inner join unidadMedidas um on p.codUM = um.codUM;

		select 1;

	end
	else if @opcion = 21
	begin
		-- Formulario	: RegistroTallaView
		-- Tipo 		: Lista de Tallas - DataGriView
		select	codTalla,
				descripcion,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado,
				ordenTalla
		from	tallas;

	end
	else if @opcion = 22
	begin
		-- Formulario	: RegistroColorView
		-- Tipo 		: Lista de Colores - DataGriView
		select	codColor,
				descripcion,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from	colores;

	end
	else if @opcion = 23
	begin
		-- Formulario	: RegistroTipoCambioView
		-- Tipo 		: Lista de Tipo de Cambio - DataGriView
		select	convert(varchar,tc.fecha, 23) as fecha,
				tc.idTipoMoneda,
				tm.monedaSingular,
				tc.compra,
				tc.venta,
				tc.usuarioReg,
				convert(varchar,tc.fechaReg,103) as fechaReg
		from	tipoCambio tc
			inner join tipoMonedas tm on tc.idTipoMoneda = tm.idTipoMoneda
		order by tc.fecha desc;

	end
	else if @opcion = 24
	begin
		-- Formulario	: RegistroTipoCambioView
		-- Tipo 		: Lista desplegable - ComboBox
		select	tbl.idTipoMoneda,
				tbl.moneda
		from	(select	0 as idTipoMoneda,
						'-- Seleccione --' as moneda
				union all 
				select	idTipoMoneda,
						(monedaSingular + ' (' + simbolo + ')') as moneda
				from	tipoMonedas) as tbl 
		order by tbl.idTipoMoneda asc;


	end
	else if @opcion = 25
	begin
		-- Formulario	: RegistroProductoView
		-- Tipo 		: Lista principal de grupos
		-- @filtroTxt1	: CodNivel
		select	g.codNivel,
				g.codGrupo,
				n.nivel,
				g.grupo,
				um.codUM,
				um.descripcion as unidadmedida,
				isnull(c.codCuenta,'') as codCuenta,
				isnull(c.cuenta,'') as cuenta,
				g.codGrupoAlt,
				isnull(g.descripcionPrevia,'') as descripcionPrevia
		from	grupos g
			inner join niveles n on n.codNivel = g.codNivel
			inner join unidadMedidas um on um.codUM = g.codUM
			left join cuentas c on g.codCuenta = c.codCuenta
		where	g.codNivel = @filtroTxt1
			and g.codGrupo = @filtroTxt2
		order by g.codGrupo asc;

	end
	else if @opcion = 26
	begin
		-- Formulario	: RegistroProductoView
		-- Tipo 		: Lista principal de grupos
		-- @filtroTxt1	: CodNivel	
		-- @filtroTxt2 : CodGrupo

		select	ps.codNivel,
				ps.codGrupo,
				ps.codTalla,
				ps.codColor,

				n.nivel,
				g.grupo,
				t.descripcion as talla,
				c.descripcion as color

		from productoServicios	ps
			inner join grupos	g	on	ps.codNivel = g.codNivel
									and ps.codGrupo = g.codGrupo
			inner join niveles	n	on	g.codNivel = n.codNivel
			inner join tallas	t	on	ps.codTalla = t.codTalla
			inner join colores	c	on	ps.codColor = c.codColor
		where	ps.codNivel = @filtroTxt1
			and ps.codGrupo = @filtroTxt2;

	end	
	else if @opcion = 27
	begin
		-- Formulario	: RegistroCuentaView
		-- Tipo 		: Lista principal de cuentas
		select	c.codCuenta,
				c.cuenta,
				c.codCuentaNivel,
				cn.cuentaNivel,
				c.codCuentaTipo,
				ct.cuentaTipo,
				c.cuentaAmarreDebe,
				c.cuentaAmarreHaber,
				convert(varchar,c.fechaReg,103) as fechaReg,
				c.usuarioReg,
				c.estado,
				c.FlgMostrarKardex
		from	cuentas c
			inner join cuentaNiveles cn on c.codCuentaNivel = cn.codCuentaNivel
			inner join cuentaTipos ct on c.codCuentaTipo = ct.codCuentaTipo
		order by c.codCuenta asc;

	end
	else if @opcion = 28
	begin
		-- Formulario	: RegistroCuentaView
		-- Tipo 		: Lista de niveles de cuenta
		select	'0' as codCuentaNivel,
				'-- Seleccione -- ' as cuentaNivel
		union all
		select	codCuentaNivel,
				cuentaNivel
		from cuentaNiveles
	end
	else if @opcion = 29
	begin
		-- Formulario	: RegistroCuentaView
		-- Tipo 		: Lista de tipos de cuenta
		select	'0' as codCuentaTipo,
				'-- Seleccione -- ' as cuentaTipo
		union all
		select	codCuentaTipo,
				cuentaTipo
		from cuentaTipos
	end
	else if @opcion = 30
	begin
		-- Formulario	: RegistroCuentaView
		-- Tipo 		: Lista de principa de las unidades de medida
		select	codUM,
				descripcion,
				usuarioReg,
				convert(varchar,fechaReg,103) as fechaReg,
				estado
		from	unidadMedidas

	end
	else if @opcion = 31
	begin
		-- Formulario	: RegistroProductoView
		-- Tipo 		: Lista principal de productos
		-- @filtroTxt1	: Codigo de Nivel
		-- @filtroTxt2	: Filtro de Grupo

		select	ps.codNivel,
				ps.codGrupo,
				ps.codTalla,
				ps.codColor,

				n.nivel,
				g.grupo,
				t.descripcion as talla,
				c.descripcion as color,

				g.codGrupoAlt 

		from productoServicios	ps
			inner join grupos	g	on	ps.codNivel = g.codNivel
									and ps.codGrupo = g.codGrupo
			inner join niveles	n	on	g.codNivel = n.codNivel
			inner join tallas	t	on	ps.codTalla = t.codTalla
			inner join colores	c	on	ps.codColor = c.codColor
		where	ps.codNivel = @filtroTxt1
		 and (ps.codGrupo + ' ' + g.grupo) like '%' + @filtroTxt2 + '%';

	end
	else if @opcion = 32
	begin
		-- Formulario	: BuscarColorProductoView
		-- Tipo 		: Busqueda de colores
		-- @filtroTxt1	: Color

		select	codColor,
			 	rtrim(ltrim(descripcion)) as descripcion
		from colores
		where (codColor + ' ' + upper(descripcion)) like '%' + @filtroTxt1 + '%'
			and estado = 1
		order by descripcion asc;

	end
	else if @opcion = 33
	begin
		-- Formulario	: BuscarColorProductoView
		-- Tipo 		: Busqueda de colores
		-- @filtroTxt1	: Color
		if @filtroInt1 = 1
			begin
				select	codServicio,rtrim(ltrim(nombreServicio)) as nombreServicio,estado,usuarioReg,convert(varchar,fechaReg,103) as fechaReg from servicio where (codServicio + ' ' + upper(nombreServicio)) like '%' + @filtroTxt1 + '%' and estado=1
				order by nombreServicio asc;
			end
		else
			begin
				select	codServicio,rtrim(ltrim(nombreServicio)) as nombreServicio,estado,usuarioReg,convert(varchar,fechaReg,103) as fechaReg from servicio where (codServicio + ' ' + upper(nombreServicio)) like '%' + @filtroTxt1 + '%'
				order by nombreServicio asc;
			end
	end
	else if @opcion = 34
	begin
		-- Formulario	: BuscarColorProductoView
		-- Tipo 		: Busqueda de colores
		-- @filtroTxt1	: Color
		if @filtroInt1 = 1
			begin
				select	
					a.codPrograma,
					rtrim(ltrim(a.nombrePrograma)) as nombrePrograma,
					a.estado,
					a.usuarioReg,
					convert(varchar,a.fechaReg,103) as fechaReg,
					a.pedido,
					a.estilo,
					a.nombre,
					a.codColor,
					b.descripcion descripcionColor
					from programa a 
					left join colores b
					on b.codColor = a.codColor
					where (a.codPrograma + ' ' + upper(a.nombrePrograma)) like '%' + @filtroTxt1 + '%' and a.estado=1
				order by a.nombrePrograma asc;
			end
		else
			begin
				select	
					a.codPrograma,
					rtrim(ltrim(a.nombrePrograma)) as nombrePrograma,
					a.estado,
					a.usuarioReg,
					convert(varchar,a.fechaReg,103) as fechaReg,
					a.pedido,
					a.estilo,
					a.nombre,
					a.codColor,
					b.descripcion descripcionColor
				from programa a 
				left join colores b
				on b.codColor = a.codColor
				where (a.codPrograma + ' ' + upper(a.nombrePrograma)) like '%' + @filtroTxt1 + '%'
				order by a.nombrePrograma asc;
			end
	end


	-- ####################
	-- ### AGREGADOSSSS ###
	-- ####################
	else if @opcion = 40
	begin
		
		-- Formulario	: GuiaRemisionExportacion
		-- Tipo 		: Mantenimiento Constancia Inscripciones
		-- @filtroTxt1	: Estado

		select 
			idConstanciaInscripcion,
			constanciaInscripcion,
			estado,
			fechaCrea,
			fechaMod,
			apellidos,
			nombres,
			usuarioReg
		from constanciaInscripciones
		where estado = ISNULL(@filtroTxt1,estado)

	end
	else if @opcion = 41
	begin
		
		-- Formulario	: GuiaRemisionExportacion
		-- Tipo 		: Mantenimiento Licencia de Conducir
		-- @filtroTxt1	: Estado

		select 
			a.idNumeroLicenciaConducir,
			a.numeroLicenciaConducir,
			a.estado,
			a.fechaCrea,
			a.fechaMod,
			--a.apellidos,
			--a.nombres,
			a.usuarioReg,
			a.numDocConductor,
			a.codTipoDocConductor,
			b.nombres,
			CONCAT(b.apellidoPaterno,' ',b.apellidoMaterno)apellidos

		from numeroLicenciaConducir a
		left join personas b
		on	b.codTipoDoc	= a.codTipoDocConductor
		and b.numDoc		= a.numDocConductor
		where a.estado = ISNULL(@filtroTxt1,estado)

	end
	else if @opcion = 42
	begin
		
		-- Formulario	: CatalogoNubeFact
		-- Tipo 		: Mantenimiento Catalogo NubeFact

		SELECT 	
				(select COUNT(*) from catalogoNubefact where 	codigoInterno like CONCAT('%',@filtroTxt1,'%') )total,
				codigoInterno,				
				isnull(idCategoria,0)idCategoria,				
				codUm,						
				case 
					when codMoneda = '1' then '1-SOLES' 	
					when codMoneda = '2' then '2-DOLARES' 
					when codMoneda = '3' then '3-EUROS' 
				end codMoneda,
				descripcionCatalogo,		
				isnull(ventaValorUnitarioSinIgv,0)ventaValorUnitarioSinIgv,	
				isnull(ventaPrecioUnitarioIgv,0)ventaPrecioUnitarioIgv,		
				isnull(compraValorUnitarioSinIgv,0)compraValorUnitarioSinIgv,	
				isnull(compraPrecioUnitarioIgv,0)compraPrecioUnitarioIgv,	
				destacado,					tipoAfectacionIgv,			codProductoSunat,
				stockActualDisponible
		FROM (
			SELECT 
				ROW_NUMBER() OVER (ORDER BY codigointerno) AS RowNumber,
				*
			FROM catalogoNubefact
			where 	codigoInterno like CONCAT('%',@filtroTxt1,'%')
		) AS t
		WHERE RowNumber BETWEEN @filtroInt1 AND @filtroInt2



	end
	else if @opcion = 43
	begin
		
		-- Formulario	: CatalogoNubeFact
		-- Tipo 		: Categorias
		SELECT 
			0 idCategoria,
			'SIN CATEGORIA' descripcionCategoria,
			'' usuarioCrea,
			'' usuarioMod,
			'' fechaCrea,
			'' fechaMod,
			1 estado
		union all
		SELECT 
			idCategoria,
			descripcionCategoria,
			usuarioCrea,
			usuarioMod,
			fechaCrea,
			fechaMod,
			estado
		from categorias

	end
	else if @opcion = 44
	begin
		-- Formulario	: RegistroProvClientes
		-- Tipo 		: DEPARTAMENTOS
		select 
			'00' iddepartamento,
			'SELECCIONE' departamento
		union all
		select 
			iddepartamento,
			departamento
		from departamento
		order by iddepartamento

	end
	else if @opcion = 45
	begin
		-- Formulario	: RegistroProvClientes
		-- Tipo 		: PROVINCIAS
		select 
			'0000' idprovincia,
			'00' iddepartamento,
			'SELECCIONE' provincia
		union all
		select 
			idprovincia,
			iddepartamento,
			provincia
		from provincia
		where iddepartamento = ISNULL(@filtroTxt1,iddepartamento)
		ORDER BY idprovincia

	end
	else if @opcion = 46
	begin
		-- Formulario	: RegistroProvClientes
		-- Tipo 		: PROVINCIAS
		select 
			'000000' iddistrito,
			'0000' idprovincia,
			'SELECCIONE' distrito
		union all
		select 
			iddistrito,
			idprovincia,
			distrito
		from distrito
		where idprovincia = ISNULL(@filtroTxt1,idprovincia)
		order by	
				iddistrito

	end

	else if @opcion = 47
	begin
		-- Formulario	: RegistroTipoCambioView
		-- Tipo 		: Lista desplegable - ComboBox
		select 
			*
		from tipoCambio where fecha = cast(@filtroTxt1 as date)
		and idTipoMoneda = @filtroInt1


	end

	-- TALLAS ESTANDAR PARA REGISTROS 
	else if @opcion = 48
	begin
		
			select 
				b.codTalla,
				trim(b.descripcion)descripcion,
				b.ordenTalla
			from tallas b
			where b.codTalla in ('004','005','006','007','008','009','010')
				group by 
					b.codTalla,
					trim(b.descripcion),
					b.ordenTalla
				order by b.ordenTalla

	
	end

	-- BUSCAR PROGRAMAS POR PEDIDO
	else if @opcion = 49
	begin
			

			if @filtroTxt1 != '' 
			begin
				
				select 
					a.codPrograma,
					a.nombrePrograma,
					a.estilo,
					a.nombre,
					a.codColor, 
					a.pedido,
					b.descripcion descripcionColor
				from programa a
				inner join colores b
				on b.codColor = a.codColor
				where trim(a.pedido) like CONCAT( '%',@filtroTxt1,'%' )
				and a.estado = '1'
					
			end
			else
			begin
				
				select 
					a.codPrograma,
					a.nombrePrograma,
					a.estilo,
					a.nombre,
					a.codColor, 
					a.pedido,
					b.descripcion descripcionColor
				from programa a
				inner join colores b
				on b.codColor = a.codColor
				where 
				 a.estado = '1'

			end 


	end
	-- BUSCAR DETALLE DE OS POR OS - PARA CONTROL DE DESPACHO
	else if @opcion = 50
	begin
		
		select 
			a.codTalla,
			trim(b.descripcion) talla,
			b.ordenTalla,
			sum(a.cantidad) cantidad
		from osDet a
		inner join tallas b
		on b.codTalla = a.codTalla
		where a.idOS = @filtroInt1
			group by 
				a.codTalla,
				trim(b.descripcion),
				b.ordenTalla
			order by b.ordenTalla

	end

	else if @opcion = 51
	begin
		
		--create table #tmptallas(
		--	ordenTalla		int,
		--	talla			varchar(100)
		--)

		--insert into #tmptallas(
		--	ordenTalla, talla
		--)
		--select 
		--	distinct d.ordenTalla,trim(d.descripcion)
		--FROm controlDespachoDet b
		--		inner join controlDespachoDetTallas c
		--		on c.idProcesoControlDespachoDet = b.idProcesoControlDespachoDet
		--		inner join tallas d
		--		on d.codTalla = c.codTalla
		--			where b.idProcesoControlDespachoCab = @filtroInt1
		--order by d.ordenTalla

		--DECLARE @cols AS NVARCHAR(MAX),
 -- @query AS NVARCHAR(MAX);

		---- OBTENEMOS COLUMNAS
		--set @cols =	STUFF((SELECT ',' + QUOTENAME(talla) 
		--		from #tmptallas

		--		FOR XML PATH(''), TYPE 
		--		).value('.', 'NVARCHAR(MAX)') 
		--	,1,1,'') 



		--	SET @query = 'SELECT
		--								nc, 
		--								ordenServicio,
		--								fechaGuia,
		--								guia,
		--								' + @cols +',
		--								0 total,
		--								fechaFactura,
		--								factura,
		--								destinatario
		--				FROM
		--				(
		--						select 
		--								b.numeroCorte nc, 
		--								b.ordenServicio,
		--								b.fechaGuia,
		--								b.guia,
		--								trim(d.descripcion)talla,
		--								0 total,
		--								b.fechaFactura,
		--								b.factura,
		--								b.destinatario,

		--								b.idProcesoControlDespachoDet,
		--								c.cantidad

		--						from controlDespachoDet b
		--						inner join controlDespachoDetTallas c
		--						on c.idProcesoControlDespachoDet = b.idProcesoControlDespachoDet
		--						inner join tallas d
		--						on d.codTalla = c.codTalla
		--						where b.idProcesoControlDespachoCab = ' + @filtroTxt1 + '
		--			 ) x
		--				PIVOT 
		--				(
		--					SUM(Cantidad)
		--					FOR talla IN (' + @cols + ')
		--				) p '

		--	print @query
		
		--	EXEC(@query);

		create table #tmptallas(
			codTalla		char(3),
			ordenTalla		int,
			talla			varchar(100)
		)

		insert into #tmptallas(
			codTalla,talla,ordenTalla
		)
		exec [dbo].[uspGetMantenimiento] 48
		--select 
		--	distinct d.ordenTalla,trim(d.descripcion)
		--FROm controlDespachoDet b
		--		inner join controlDespachoDetTallas c
		--		on c.idProcesoControlDespachoDet = b.idProcesoControlDespachoDet
		--		inner join tallas d
		--		on d.codTalla = c.codTalla
		--			where b.idProcesoControlDespachoCab = @filtroInt1
		--order by d.ordenTalla

		DECLARE @cols AS NVARCHAR(MAX),
 @query AS NVARCHAR(MAX);

		-- OBTENEMOS COLUMNAS
		set @cols =	STUFF((SELECT ',' + QUOTENAME(talla) 
				from #tmptallas

				FOR XML PATH(''), TYPE 
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'') 

			

			SET @query = 'SELECT	
										idProcesoControlDespachoDet,
										nc, 
										ordenServicio,
										fechaGuia,
										guia,
										' + @cols +',
										(
											SELECT 
												SUM(ba.CANTIDAD) 
											FROM controlDespachoDetTallas ba
											WHERE ba.idProcesoControlDespachoDet = p.idProcesoControlDespachoDet
										) total,
										fechaFactura,
										factura,
										destinatario
						FROM
						(
								select 
										b.numeroCorte nc, 
										b.ordenServicio,
										b.fechaGuia,
										b.guia,
										trim(d.descripcion)talla,
										0 total,
										b.fechaFactura,
										b.factura,
										b.destinatario,

										b.idProcesoControlDespachoDet,
										c.cantidad

								from controlDespachoDet b
								inner join controlDespachoDetTallas c
								on c.idProcesoControlDespachoDet = b.idProcesoControlDespachoDet
								inner join tallas d
								on d.codTalla = c.codTalla
								where b.idProcesoControlDespachoCab = ' + @filtroTxt1 + '
					 ) x
						PIVOT 
						(
							SUM(Cantidad)
							FOR talla IN (' + @cols + ')
						) p '

			print @query
		
			EXEC(@query);
		
		

	end
	else if @opcion = 52
	begin
		
		
			--select 
			--		a.idProcesoControl,
			--		b.proceso,
			--		a.idProcesoControlDespachoCab,
			--		a.codPrograma,
			--		c.estilo,
			--		c.nombre,
			--		c.codColor,
			--		e.descripcion descripcionColor,
			--		c.pedido,
			--		a.codCliente,
			--		d.razonSocial,
			--		a.ruc
			--from controlDespachoCab a
			--inner join procesoControl b
			--on b.idProcesoControl = a.idProcesoControl
			--inner join programa c
			--on c.codPrograma = a.codPrograma
			--inner join provClientes d
			--on d.codigo = a.codCliente
			--inner join colores e
			--on e.codColor = c.codColor
			--where a.idProcesoControl = @filtroInt1
			--and c.pedido like concat('%',@filtroTxt1,'%')

			select 
					a.idProcesoControl,
					b.proceso,
					a.idProcesoControlDespachoCab,
					e.idPrograma,
					f.programa,
					e.idEstilo,
					g.estilo,
					e.pedido,
					d.idPedidoColor,
					trim(h.descripcion) color,
					a.cliente,
					a.idProveedor,
					c.razonSocial proveedor
			from controlDespachoCab a
			inner join procesoControl b
			on b.idProcesoControl = a.idProcesoControl
			inner join provClientes c
			on c.codigo = a.idProveedor
			inner join pedidosColor d
			on d.idPedidoColor = a.idPedidoColor
			inner join pedidos e
			on e.idPedido = d.idPedido
			inner join programas f
			on f.idPrograma = e.idPrograma
			inner join estilos g
			on g.idEstilo = e.idEstilo
			inner join colores h
			on h.codColor = d.codColor
			where a.idProcesoControl = @filtroInt1
			and e.pedido like concat('%',@filtroTxt1,'%')


	end

	-- ESTILOS
	else if @opcion = 53
	begin
			
			select 
				a.idEstilo,
				a.idUsuarioCrea,
				a.codigoEstilo,
				a.estilo,
				a.fechaCrea,
				a.estado,
				b.usuario
			from estilos a
			inner join usuarios b
			on b.id = a.idUsuarioCrea
			where concat(a.codigoEstilo,a.estilo) like concat('%',@filtroTxt1,'%')


	end

	-- PROGRAMAS
	else if @opcion = 54
	begin
		
		select 
			a.idPrograma,
			a.idUsuarioCrea,
			a.programa,
			a.fechaCrea,
			a.estado,
			b.usuario
		from programas a
		inner join usuarios b
		on b.id = a.idUsuarioCrea
		where a.estado = iif(@filtroInt1 = 1,cast(1 as bit),a.estado)
		and a.programa like concat('%',@filtroTxt1,'%')
	end

	-- PEDIDOS
	else if @opcion = 55
	begin
		
		select 
			a.idPedido,
			a.idEstilo,
			a.idPrograma,
			a.idUsuarioCrea,
			a.pedido,
			a.fechaCrea,
			a.estado,
			b.estilo,
			c.programa,
			d.usuario,
			b.codigoEstilo
		from pedidos a
		inner join estilos b
		on a.idEstilo = b.idEstilo
		inner join programas c
		on a.idPrograma = c.idPrograma
		inner join usuarios d
		on a.idUsuarioCrea = d.id
		where a.estado ='1'
		ORDER BY a.pedido

		--select * from pedidos where pedido = 'p1'
		
	end

	-- PEDIDOS COLOR
	else if @opcion = 56
	begin
		
		select 
			a.idPedidoColor,
			a.idPedido,
			b.codColor,
			b.descripcion color,
			a.fechaCrea,
			a.estado
		from pedidosColor a
		inner join colores b
		on b.codColor = a.codColor
		where a.idPedido = @filtroInt1
		and a.estado = 1


	end

		-- BUSCAMOS PEDIDOS COLOR
	else if @opcion = 57
	begin
		
			--select 
			--	d.idPedidoColor,
			--	a.idPedido,
			--	a.idEstilo,
			--	a.idPrograma,
			--	d.codColor,
			--	a.pedido,
			--	trim(e.descripcion) color,
			--	b.estilo,
			--	c.programa,
			--	b.codigoEstilo
			--from pedidos a
			--inner join estilos b
			--on b.idEstilo = a.idEstilo
			--inner join programas c
			--on c.idPrograma = a.idPrograma
			--inner join pedidosColor d
			--on d.idPedido = a.idPedido
			--inner join colores e
			--on e.codColor = d.codColor
			--where a.pedido like CONCAT('%',@filtroTxt1,'%')
			
			
			create table #tmpNivelesAnteriores(
				CodNivel	varchar(100)
			)

			-- SI ESTA EN EXPORTACION
			if @filtroTxt2 = '20'
			begin
				insert into #tmpNivelesAnteriores(CodNivel) values(''/*'08'*/)
			end

			-- SI ESTA EN ACABADOS
			if @filtroTxt2 = '08'
			begin
			
				insert into #tmpNivelesAnteriores(CodNivel) values(''/*'07'*/)
			end

			-- SI ESTA EN COSTURA
			if @filtroTxt2 = '07'
			begin
				insert into #tmpNivelesAnteriores(CodNivel) values('06')
			end

			-- SI ESTA EN CORTE
			if @filtroTxt2 = '06'
			begin
				insert into #tmpNivelesAnteriores(CodNivel) values('')
			end

			if @filtroTxt2 not in ('20','08','07','06')
			begin
				insert into #tmpNivelesAnteriores(CodNivel) values('')
			end
			
			--declare @_count int = 0
			--if exists (
			--	SELECT 1
			--					FROM #tmpNivelesAnteriores
			--					WHERE CodNivel = ''
			--)begin
			--	set @_count = 1;
			--else
				

			--end

			select 
				d.idPedidoColor,
				a.idPedido,
				a.idEstilo,
				a.idPrograma,
				d.codColor,
				a.pedido,
				trim(e.descripcion) color,
				b.estilo,
				c.programa,
				b.codigoEstilo,

					-- PermitirRegistro: cuenta registros de nivel '08' para cada PedidoColor
				(
					 --1
						
					case when exists(
							SELECT 1
								FROM #tmpNivelesAnteriores
								WHERE CodNivel = ''
					) then 1
					else 
					(
						SELECT COUNT(*)
						FROM grDet   gr
						INNER JOIN osDet os
										ON os.idOS       = gr.idDet
										AND os.secuencia = gr.idSecuenciaDet
						WHERE gr.IdPedidoColor  = d.idPedidoColor
						  AND gr.tipoOrden      = 'S'
						  AND gr.tipoMovimiento = 'E'
						AND (
							--EXISTS (
							--	SELECT 1
							--	FROM #tmpNivelesAnteriores
							--	WHERE CodNivel = ''
							--)
							 os.codNivel COLLATE database_default IN (
								SELECT CodNivel COLLATE database_default
								FROM #tmpNivelesAnteriores
								WHERE CodNivel <> ''
							)
						  )
					)

					
					end 

					  
				) AS PermitirRegistro

			from pedidos a
			left join estilos b
			on b.idEstilo = a.idEstilo
			left join programas c
			on c.idPrograma = a.idPrograma
			left join pedidosColor d
			on d.idPedido = a.idPedido
			left join colores e
			on e.codColor = d.codColor
			where a.pedido like CONCAT('%',@filtroTxt1,'%')
			and a.estado = '1' and d.estado = '1'
			order by a.pedido
		
		
		DROP TABLE #tmpNivelesAnteriores

	end
	else if @opcion = 58
	begin
		select codigo, descripcion, tresumido resumida, lactivo estado from AreasAlmacen
		where codigo + ' ' + descripcion like CONCAT('%',@filtroTxt1,'%')
		order by codigo asc
	end
	else if @opcion = 59
	begin
		SELECT 
		tCodigoProducto					codigo, 
		CONCAT(N.CODNIVEL,'.',NIVEL)	tipo, 
		G.grupo							grupo,	 
		c.descripcion					color,
		dbo.fn_Obtener_Stock(1,tCodigoProducto,'') stock
		FROM MKARDEX t1
		INNER JOIN PRODUCTOSERVICIOS OC 
			ON	OC.CODNIVEL + '.' + OC.CODGRUPO + '.' + OC.CODTALLA	+'.' + OC.CODCOLOR = t1.tCodigoProducto
		INNER JOIN GRUPOS G 
						ON	OC.CODNIVEL			= G.CODNIVEL
						AND OC.CODGRUPO			= G.CODGRUPO
		INNER JOIN NIVELES N 
						ON G.CODNIVEL			= N.CODNIVEL
		inner join colores c 
						on oc.codColor = c.codColor
		WHERE tCodigoProducto + ' ' + G.grupo + ' ' + c.descripcion like CONCAT('%',@filtroTxt1,'%')
		GROUP BY tCodigoProducto, N.CODNIVEL,NIVEL, G.grupo, c.descripcion
	end
	else if @opcion = 60
	begin
		SELECT 
		tCodigoProducto,
		tCodigoArea + ' - ' + t3.Descripcion almacen,
		tTipoDocumento + ' - ' + t2.tipoComprobante tipoComprobante,
		tDocumento,
		case when nIngreso = 0 then
		'SALIDA'
		ELSE
		'INGRESO'
		END TipoMovimiento,
		nIngreso,
		nValor,
		nSalida,
		nStockActual,
		nStockUltimo,
		nPrecioPromedio,
		nPrecioCosto,
		case when tEstadoKardex = '01' then
			'PROCESADO'
		else
			'ANULADO'
		end tEstadoKardex,
		fRegistro,
		tUsuario
		FROM MKARDEX t1
		inner join tipoComprobantes t2
			on t1.tTipoDocumento = t2.codTipoCpte
		inner join AreasAlmacen t3
			on t1.tCodigoArea = t3.Codigo
		WHERE tCodigoProducto = @filtroTxt1
		order by nSecuencia asc
	end
	else if @opcion = 61
	begin
		SELECT 
		tCodigoProducto					codigo, 
		CONCAT(N.CODNIVEL,'.',NIVEL)	tipo, 
		G.grupo							grupo,	 
		c.descripcion					color,
		dbo.fn_Obtener_Stock(1,tCodigoProducto,'') stock,
		g.codUM
		FROM MKARDEX t1
		INNER JOIN PRODUCTOSERVICIOS OC 
			ON	OC.CODNIVEL + '.' + OC.CODGRUPO + '.' + OC.CODTALLA	+'.' + OC.CODCOLOR = t1.tCodigoProducto
		INNER JOIN GRUPOS G 
						ON	OC.CODNIVEL			= G.CODNIVEL
						AND OC.CODGRUPO			= G.CODGRUPO
		INNER JOIN NIVELES N 
						ON G.CODNIVEL			= N.CODNIVEL
		inner join colores c 
						on oc.codColor = c.codColor
		WHERE tCodigoProducto + ' ' + G.grupo + ' ' + c.descripcion like CONCAT('%',@filtroTxt1,'%')
		and t1.tCodigoArea = @filtroTxt2
		GROUP BY tCodigoProducto, N.CODNIVEL,NIVEL, G.grupo, c.descripcion,g.codUM

	end
	else if @opcion = 62
	begin
		select codAlmacen, t2.Descripcion from UsuarioAlmacen t1
		inner join AreasAlmacen t2
			on t1.codAlmacen = t2.Codigo
		where t1.CodUsuario = @filtroTxt1
	end
	else if @opcion = 63
	begin
			DECLARE @CANT INT

			SET @CANT = (select COUNT(*) from UsuarioAlmacen where CodUsuario = @filtroTxt1 AND CodAlmacen = '000' )
			
			IF @CANT = 0
				BEGIN
					select 
					idRequerimiento,
					fechaEmsion,	
					fechaAtencion,	
					AlmacenID,	
					almacenDespacho,	
					AlmacenReque,
					almacenrequiere,
					observacion,	
					fechaProceso,	
					CodusuarioProce,	
					DesusuarioProce,
					CodusuarioReg,	
					DesusuarioReg,	
					fechaRegistro,	
					CodusuarioAnulado,
					DesusuarioAnulado,
					fechaAnulado,
					estado,	
					DesEstado
					from vrequerimientoCabe 
					where AlmacenReque In ( select CodAlmacen from UsuarioAlmacen where CodUsuario = @filtroTxt1)
					order by idRequerimiento asc
				
				END
			ELSE
				BEGIN
					select 
					idRequerimiento,
					fechaEmsion,	
					fechaAtencion,	
					AlmacenID,	
					almacenDespacho,	
					AlmacenReque,
					almacenrequiere,
					observacion,	
					fechaProceso,	
					CodusuarioProce,	
					DesusuarioProce,
					CodusuarioReg,	
					DesusuarioReg,	
					fechaRegistro,	
					CodusuarioAnulado,
					DesusuarioAnulado,
					fechaAnulado,
					estado,	
					DesEstado
					from vrequerimientoCabe 
					where almacenId in ( select CodAlmacen from UsuarioAlmacen where CodUsuario = @filtroTxt1)
					order by idRequerimiento asc
				END
	end
	else if @opcion = 64
		begin

			select 
			t1.item,
			ProductoID						Codigo, 	
			G.grupo	+ ' ' + c.descripcion	producto,	 
			g.codUM							unidad_medida,
			cantidad,			
			stock_actual					stock, 
			cantidad_atendida				cantidad_atendida			

			from requerimientoDeta t1

			INNER JOIN PRODUCTOSERVICIOS OC 
						ON	OC.CODNIVEL + '.' + OC.CODGRUPO + '.' + OC.CODTALLA	+'.' + OC.CODCOLOR = t1.ProductoID
					INNER JOIN GRUPOS G 
									ON	OC.CODNIVEL			= G.CODNIVEL
									AND OC.CODGRUPO			= G.CODGRUPO
					INNER JOIN NIVELES N 
									ON G.CODNIVEL			= N.CODNIVEL
					inner join colores c 
									on oc.codColor = c.codColor
			where t1.idRequerimiento = @filtroTxt1
			order by t1.item asc
		end
	else if @opcion = 65
		begin
			select count(*) from UsuarioAlmacen where codAlmacen = '000' and CodUsuario = @filtroTxt1
		end
	else if @opcion = 66
		begin
			SELECT 
				tCodigoProducto					codigo, 
				CONCAT(N.CODNIVEL,'.',NIVEL)	tipo, 
				G.grupo							grupo,	 
				c.descripcion					color,
				dbo.fn_Obtener_Stock(2,tCodigoProducto, t1.tCodigoSubArea) stock
				FROM MSUBKARDEX t1
				INNER JOIN PRODUCTOSERVICIOS OC 
					ON	OC.CODNIVEL + '.' + OC.CODGRUPO + '.' + OC.CODTALLA	+'.' + OC.CODCOLOR = t1.tCodigoProducto
				INNER JOIN GRUPOS G 
								ON	OC.CODNIVEL			= G.CODNIVEL
								AND OC.CODGRUPO			= G.CODGRUPO
				INNER JOIN NIVELES N 
								ON G.CODNIVEL			= N.CODNIVEL
				inner join colores c 
								on oc.codColor = c.codColor
				WHERE 
				tCodigoProducto + ' ' + G.grupo + ' ' + c.descripcion like CONCAT('%',@filtroTxt1,'%')
				and t1.tCodigoSubArea = @filtroTxt2
				GROUP BY tCodigoProducto, N.CODNIVEL,NIVEL, G.grupo, c.descripcion, t1.tCodigoSubArea
		end
	else if @opcion = 67
		begin
			select tCodigoSubArea , t2.Descripcion
			from MSUBKARDEX t1
				inner join AreasAlmacen t2
				 on t1.tCodigoSubArea = t2.Codigo
			group by tCodigoSubArea , t2.Descripcion
			order by tCodigoSubArea

		end
	else if @opcion = 68
		begin			
				SELECT 
				tCodigoProducto,
				tCodigoSubArea + ' - ' + t4.Descripcion AlmacenDestino,
				tCodigoArea + ' - ' + t3.Descripcion almacen,
				tTipoDocumento + ' - ' + t2.tipoComprobante tipoComprobante,
				tDocumento,
				case when nIngreso = 0 then
				'SALIDA'
				ELSE
				'INGRESO'
				END TipoMovimiento,
				nIngreso,
				nValor,
				nSalida,
				nStockActual,
				nStockUltimo,
				nPrecioPromedio,
				nPrecioCosto,
				case when tEstadoKardex = '01' then
					'PROCESADO'
				else
					'ANULADO'
				end tEstadoKardex,
				fRegistro,
				tUsuario
				FROM MSUBKARDEX t1
				inner join tipoComprobantes t2
					on t1.tTipoDocumento = t2.codTipoCpte
				inner join AreasAlmacen t3
					on t1.tCodigoArea = t3.Codigo
				inner join AreasAlmacen t4
					on t1.tCodigoSubArea = t4.Codigo
				WHERE tCodigoProducto = @filtroTxt1
				order by nSecuencia asc
	 
		end
		else if @opcion = 69
		begin	
			SELECT t2.codGrupoAlt, t2.grupo , t1.cantidad, t2.codUM FROM OrdenSalidaDet t1
			inner join vListaCodigoExterno t2
			on t1.codNivel+'.'+t1.codGrupo+'.'+t1.codTalla+'.'+t1.codColor = t2.codigo
			where t1.idOrdenSalida = @filtroTxt1
		end
		else if @opcion = 70
			begin
				select Codigo, Descripcion from AreasAlmacen
			end
		else if @opcion = 71
			begin
				declare @codigo varchar(100)

				set @codigo = (select codigo from vListaCodigoExterno where codGrupoAlt = @filtroTxt1)

				select dbo.fn_Obtener_Stock(2, @codigo, '006')

			end

	else if @opcion = 72
	begin
		if @filtroInt1 = 2
			begin
				--select compra codigo, 'Compra - ' + cast(compra as varchar) descripcion from tipoCambio where fecha = cast(@filtroTxt1 as date)
				--and idTipoMoneda = @filtroInt1
				--union all
				--select venta codigo, 'Venta - ' + cast(venta as varchar) descripcion from tipoCambio where fecha = cast(@filtroTxt1 as date)
				--and idTipoMoneda = @filtroInt1

				if not exists (
					select 
						compra codigo, 'Compra - ' + cast(compra as varchar) descripcion from tipoCambio where fecha = cast(@filtroTxt1 as date)
					and idTipoMoneda = @filtroInt1 and (compra = @filtroDecimal or venta = @filtroDecimal)
				)begin
					
					select compra codigo, 'Compra - ' + cast(compra as varchar) descripcion from tipoCambio where fecha = cast(@filtroTxt1 as date)
					and idTipoMoneda = @filtroInt1
					union all
					select venta codigo, 'Venta - ' + cast(venta as varchar) descripcion from tipoCambio where fecha = cast(@filtroTxt1 as date)
					and idTipoMoneda = @filtroInt1
					union all
					-- MODIFICADO
					select @filtroDecimal codigo, 'Modificado - ' + cast(@filtroDecimal as varchar) descripcion 

				end
				else
				begin
					
					select compra codigo, 'Compra - ' + cast(compra as varchar) descripcion from tipoCambio where fecha = cast(@filtroTxt1 as date)
					and idTipoMoneda = @filtroInt1
					union all
					select venta codigo, 'Venta - ' + cast(venta as varchar) descripcion from tipoCambio where fecha = cast(@filtroTxt1 as date)
					and idTipoMoneda = @filtroInt1

				end


			end
		if @filtroInt1 = 1
			begin
				--select 1 codigo, '1.00 - Soles' descripcion 
				select cast(1 as decimal(12,7)) codigo, '1.000 - Soles' descripcion 
				 
			end
		

	end
	else if @opcion = 73 -- TIPOS DE MOVIMIENTO
	begin

		SELECT 
			IdTipoMovimiento,
			Tipo,
			CodigoTipoMovimiento,
			DescripcionTipoMovimiento
		FROM TiposMovimientos
		WHERE FlgActivo = 1

	end
	else if @opcion = 74 -- MOVIMIENTOS CABECERA
	begin
		
		
		select 
			a.IdMovimientoCabecera,
			a.IdTipoMovimiento,
			b.DescripcionTipoMovimiento,
			a.FechaMovimiento,
			a.Comentario,
			(
				select SUM(Cantidad) from MovimientosDetalle aa where aa.IdMovimientoCabecera = a.IdMovimientoCabecera
			)CantidadMovimiento,
			c.usuario Usuario
		from MovimientosCabecera a
		inner join TiposMovimientos b
		on b.IdTipoMovimiento = a.IdTipoMovimiento
		left join usuarios c
		on c.id = a.IdUsuarioRegistro
		where a.FlgActivo = 1


	end
	else if @opcion = 75
	begin
			
			select 
				a.IdMovimientoDetalle,
				a.CodNivel,
				a.CodNivel CodigoNivel,
				a.CodGrupo,
				a.CodTalla,
				a.CodColor,
				a.Cantidad,
				a.IdPedidoColor,
				a.PartidaProveedor,
				b.codColor,
				f.descripcion PedidoColor,
				d.idPrograma,
				d.programa,
				e.idEstilo,
				e.estilo Estilo,
				c.pedido,
				a.Comentario,

				(n.nivel + ' - ' + g.grupo + ' - ' + t.descripcion + ' - ' + co.descripcion) as producto
			from [dbo].[MovimientosDetalle] a
			inner join pedidosColor b
			on b.idPedidoColor = a.IdPedidoColor
			inner join pedidos c
			on c.idPedido = b.idPedido
			inner join programas d
			on d.idPrograma = c.idPrograma
			inner join estilos e
			on e.idEstilo = c.idEstilo
			inner join colores f
			on f.codColor = b.codColor

			inner join niveles	n	on	a.codNivel = n.codNivel
			inner join tallas	t	on	a.codTalla = t.codTalla
			inner join colores	co	on	a.codColor = co.codColor

			inner join grupos	g	on	a.codNivel = g.codNivel
									and a.codGrupo = g.codGrupo

			where a.IdMovimientoCabecera = @filtroInt1

	end
	else if @opcion = 76
	begin
		select 
			codTalla,
			descripcion
		from tallas 
		where estado = 1
		and descripcion = isnull(@filtroTxt1,descripcion)

	end

end

GO
