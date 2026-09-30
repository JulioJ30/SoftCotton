-- =====================================================================================
-- Permisos de movimiento en Guias - Script 3 de 3: uspGetAcceso
-- =====================================================================================
-- Agrega dos opciones (las opciones 1 a 4 quedan igual):
--
--		@opcion = 5	-> RegistroAccesoView: submodulos con el acceso del usuario y sus
--					   permisos de movimiento. Reemplaza a uspGetMantenimiento opcion 6,
--					   que no devuelve los permisos. Si el usuario aun no tiene el acceso,
--					   los permisos salen en 1 (es lo que se grabaria al activarlo).
--
--		@opcion = 6	-> Permisos de movimiento del usuario para un formulario (@rutaForm).
--					   Siempre devuelve una fila; si el usuario no tiene acceso al
--					   formulario, los tres permisos salen en 0.
--
-- @rutaForm es opcional para no romper las llamadas anteriores.
--
-- Requiere el script 1 (columnas en accesos).
-- =====================================================================================

SET NOCOUNT ON;
GO

ALTER procedure [dbo].[uspGetAcceso]
	@opcion		int,
	@idUsuario	int,
	@idModulo	int,
	@rutaForm	varchar(200) = null
as
begin

	if (@opcion = 1) -- Accesos por Usuario
	begin
		select	a.idSubModulo,
				m.modulo,
				sm.submodulo,
				sm.rutaForm,
				sm.estado
		from	accesos	a
			inner join submodulos	sm	on a.idSubModulo = sm.Id
			inner join modulos		m	on sm.idModulo = m.id
			inner join usuarios		u	on u.id = a.idUsuario
		where	u.estado = 1
			and sm.estado = 1
			and u.id = @idUsuario;
	end
	else if @opcion = 2
	begin
		-- Accesos a modulos al iniciar sesión.
		select	distinct
				m.id as idModulo,
				m.modulo
		from	accesos	a
			inner join submodulos	sm	on a.idSubModulo = sm.Id
			inner join modulos		m	on sm.idModulo = m.id
			inner join usuarios		u	on u.id = a.idUsuario
		where	u.estado = 1
			and sm.estado = 1
			and u.id = @idUsuario;

	end
	else if @opcion = 3
	begin
		-- Accesos a submodulo al iniciar sesión.
		select	a.idSubModulo,
				sm.submodulo,
				sm.rutaForm
		from	accesos	a
			inner join submodulos	sm	on a.idSubModulo = sm.Id
			inner join modulos		m	on sm.idModulo = m.id
			inner join usuarios		u	on u.id = a.idUsuario
		where	u.estado = 1
			and sm.estado = 1
			and u.id = @idUsuario
			and m.id = @idModulo;
	end
	else if @opcion = 4
	begin
		-- Lista de Personas activas
		select	tbl.numDoc,
				tbl.persona
		from	(select	'0' as numDoc,
						'-- Seleccione --' as persona
				union all
				select	numDoc,
						ltrim((apellidoPaterno + ' ' + apellidoMaterno + ' ' + nombres)) as persona
				from	personas) as tbl
		order by tbl.persona asc;

	end
	else if @opcion = 5
	begin
		-- Formulario	: RegistroAccesoView
		-- Tipo			: Lista de Accesos por usuario con permisos de movimiento - DataGridView

		select	m.id as idModulo,
				m.modulo,
				sm.id as idSubModulo,
				sm.submodulo,
				sm.rutaForm,
				cast(case when ac.idUsuario is null then 0 else 1 end as bit) as activo,
				isnull(ac.permiteEntrada, 1) as permiteEntrada,
				isnull(ac.permiteSalida, 1) as permiteSalida,
				isnull(ac.permiteDevolucion, 1) as permiteDevolucion
		from	submodulos sm
			inner join modulos	m	on m.id = sm.idModulo
			left join accesos	ac	on ac.idSubModulo = sm.id and ac.idUsuario = @idUsuario
		where	sm.estado = 1
		order by m.modulo asc, sm.submodulo asc;

	end
	else if @opcion = 6
	begin
		-- Formularios	: RegistroGuiaRemisionView / RegistroGuiaRemisionExportacionView
		-- Tipo			: Permisos de movimiento del usuario en el formulario

		select	cast(isnull(max(cast(a.permiteEntrada as int)), 0) as bit) as permiteEntrada,
				cast(isnull(max(cast(a.permiteSalida as int)), 0) as bit) as permiteSalida,
				cast(isnull(max(cast(a.permiteDevolucion as int)), 0) as bit) as permiteDevolucion
		from	accesos	a
			inner join submodulos	sm	on a.idSubModulo = sm.Id
			inner join usuarios		u	on u.id = a.idUsuario
		where	u.estado = 1
			and sm.estado = 1
			and u.id = @idUsuario
			and sm.rutaForm = @rutaForm;

	end


end
GO
