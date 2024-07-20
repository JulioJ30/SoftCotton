using SoftCotton.Database;
using SoftCotton.DTO.Security;
using SoftCotton.Model.Security;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SoftCotton.Repository
{
    public class SeguridadRepository
    {

        // ### GET ###
        public GetLogin Login(LoginDTO login)
        {
            GetLogin usuarioLogin = new GetLogin();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspLogin";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = login.idEmpresa;
                    sqlCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 30).Value = login.usuario;
                    sqlCommand.Parameters.Add("@contrasena", SqlDbType.VarChar, 30).Value = login.contrasena;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            usuarioLogin.id = Convert.ToInt32(reader["id"]);
                            usuarioLogin.usuario = reader["usuario"].ToString();
                            usuarioLogin.nombres = reader["nombres"].ToString();
                            usuarioLogin.apellidos = reader["apellidos"].ToString();
                        }
                    }

                }
            }

            return usuarioLogin;
        }

        public List<GetAcceso2_Mod> GetAcceso2_Mod(int idUsuario)
        {
            List<GetAcceso2_Mod> modulos = new List<GetAcceso2_Mod>();
            GetAcceso2_Mod modulo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetAcceso";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int, 11).Value = 2;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int, 11).Value = idUsuario;
                    sqlCommand.Parameters.Add("@idModulo", SqlDbType.Int, 11).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            modulo = new GetAcceso2_Mod();

                            modulo.idModulo = Convert.ToInt32(reader["idModulo"]);
                            modulo.modulo = reader["modulo"].ToString();

                            modulos.Add(modulo);
                        }
                    }

                }
            }

            return modulos;
        }
        public List<GetAcceso3_SubMod> GetAcceso3_SubMod(int idUsuario, int idModulo)
        {
            List<GetAcceso3_SubMod> submodulos = new List<GetAcceso3_SubMod>();
            GetAcceso3_SubMod submodulo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetAcceso";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int, 11).Value = 3;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int, 11).Value = idUsuario;
                    sqlCommand.Parameters.Add("@idModulo", SqlDbType.Int, 11).Value = idModulo;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            submodulo = new GetAcceso3_SubMod();

                            submodulo.idSubModulo = Convert.ToInt32(reader["idSubModulo"]);
                            submodulo.submodulo = reader["submodulo"].ToString();
                            submodulo.rutaForm = reader["rutaForm"].ToString();

                            submodulos.Add(submodulo);
                        }
                    }
                }
            }

            return submodulos;
        }
        public List<GetAcceso4_Personas> Get4_Personas()
        {
            List<GetAcceso4_Personas> personas = new List<GetAcceso4_Personas>();
            GetAcceso4_Personas persona;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetAcceso";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int, 11).Value = 4;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int, 11).Value = 0;
                    sqlCommand.Parameters.Add("@idModulo", SqlDbType.Int, 11).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            persona = new GetAcceso4_Personas();

                            persona.numDoc = reader["numDoc"].ToString();
                            persona.persona = reader["persona"].ToString();

                            personas.Add(persona);
                        }
                    }
                }
            }

            return personas;
        }
        public List<GetMant1_Usuarios> GetMant1_Usuarios()
        {
            List<GetMant1_Usuarios> usuarios = new List<GetMant1_Usuarios>();
            GetMant1_Usuarios usuario;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int, 11).Value = 1;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int, 11).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int, 11).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usuario = new GetMant1_Usuarios();

                            usuario.id = Convert.ToInt32(reader["id"]);
                            usuario.usuario = reader["usuario"].ToString();
                            usuario.contrasena = reader["contrasena"].ToString();
                            usuario.numDoc = reader["numDoc"].ToString();
                            usuario.persona = reader["persona"].ToString();
                            usuario.fechaReg = reader["fechaReg"].ToString();
                            usuario.usuarioReg = reader["usuarioReg"].ToString();
                            usuario.estado = Convert.ToBoolean(reader["estado"]);

                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }
        public List<GetMant2_Modulos> GetMant2_Modulos()
        {
            List<GetMant2_Modulos> modulos = new List<GetMant2_Modulos>();
            GetMant2_Modulos modulo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int, 11).Value = 2;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int, 11).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int, 11).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            modulo = new GetMant2_Modulos();

                            modulo.id = Convert.ToInt32(reader["id"]);
                            modulo.modulo = reader["modulo"].ToString();
                            modulo.iconPath = reader["iconPath"].ToString();
                            modulo.usuarioReg = reader["usuarioReg"].ToString();
                            modulo.fechaReg = reader["fechaReg"].ToString();
                            modulo.estado = Convert.ToBoolean(reader["estado"]);

                            modulos.Add(modulo);
                        }
                    }
                }
            }
            return modulos;
        }
        public List<GetMant3_SubModulos> GetMant3_SubModulos()
        {
            List<GetMant3_SubModulos> submodulos = new List<GetMant3_SubModulos>();
            GetMant3_SubModulos submodulo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int, 11).Value = 3;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int, 11).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int, 11).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            submodulo = new GetMant3_SubModulos();

                            submodulo.id = Convert.ToInt32(reader["id"]);
                            submodulo.idModulo = Convert.ToInt32(reader["idModulo"]);
                            submodulo.modulo = reader["modulo"].ToString();
                            submodulo.submodulo = reader["submodulo"].ToString();
                            submodulo.rutaForm = reader["rutaForm"].ToString();
                            submodulo.iconPath = reader["iconPath"].ToString();
                            submodulo.usuarioReg = reader["usuarioReg"].ToString();
                            submodulo.fechaReg = reader["fechaReg"].ToString();
                            submodulo.estado = Convert.ToBoolean(reader["estado"]);

                            submodulos.Add(submodulo);
                        }
                    }
                }
            }
            return submodulos;
        }
        public List<GetMant4_CbxModulos> GetMant4_CbxModulos()
        {
            List<GetMant4_CbxModulos> modulos = new List<GetMant4_CbxModulos>();
            GetMant4_CbxModulos modulo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int, 11).Value = 4;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int, 11).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int, 11).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            modulo = new GetMant4_CbxModulos();

                            modulo.id = Convert.ToInt32(reader["id"]);
                            modulo.modulo = reader["modulo"].ToString();

                            modulos.Add(modulo);
                        }
                    }
                }
            }
            return modulos;
        }
        public List<GetMant5_Usuarios> GetMant5_Usuarios()
        {
            List<GetMant5_Usuarios> modulos = new List<GetMant5_Usuarios>();
            GetMant5_Usuarios modulo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            modulo = new GetMant5_Usuarios();

                            modulo.idUsuario = Convert.ToInt32(reader["idUsuario"]);
                            modulo.colaborador = reader["colaborador"].ToString();

                            modulos.Add(modulo);
                        }
                    }
                }
            }
            return modulos;
        }
        public List<GetMant6_Accesos> GetMant6_Accesos(int idUsuario)
        {
            List<GetMant6_Accesos> accesos = new List<GetMant6_Accesos>();
            GetMant6_Accesos acceso;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idUsuario;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            acceso = new GetMant6_Accesos();

                            acceso.idModulo = Convert.ToInt32(reader["idModulo"]);
                            acceso.modulo = reader["modulo"].ToString();
                            acceso.idSubModulo = Convert.ToInt32(reader["idSubModulo"]);
                            acceso.submodulo = reader["submodulo"].ToString();
                            acceso.rutaForm = reader["rutaForm"].ToString();
                            acceso.activo = Convert.ToBoolean(reader["activo"]);

                            accesos.Add(acceso);
                        }
                    }
                }
            }
            return accesos;
        }


        // ### SET ###
        public Response SetUsuario(SetUsuarioParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = parametros.idUsuario;
                    sqlCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 30).Value = parametros.usuario;
                    sqlCommand.Parameters.Add("@contrasena", SqlDbType.VarChar, 200).Value = parametros.contrasena;
                    sqlCommand.Parameters.Add("@numDoc", SqlDbType.Char, 15).Value = parametros.numDoc;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 50).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            response.idResponse = Convert.ToInt32(reader["idResponse"]);
                            response.messageResponse = reader["messageResponse"].ToString();
                            response.typeMessage = reader["typeMessage"].ToString();
                        }
                    }

                }
            }

            return response;
        }
        public Response SetModulo(SetModuloParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetModulo";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idModulo", SqlDbType.Int).Value = parametros.idModulo;
                    sqlCommand.Parameters.Add("@modulo", SqlDbType.VarChar, 200).Value = parametros.modulo;
                    sqlCommand.Parameters.Add("@iconPath", SqlDbType.VarChar, 500).Value = parametros.iconPath;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 40).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            response.idResponse = Convert.ToInt32(reader["idResponse"]);
                            response.messageResponse = reader["messageResponse"].ToString();
                            response.typeMessage = reader["typeMessage"].ToString();
                        }
                    }

                }
            }

            return response;
        }
        public Response SetSubModulo(SetSubModuloParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetSubModulo";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idSubModulo", SqlDbType.Int).Value = parametros.idSubModulo;
                    sqlCommand.Parameters.Add("@idModulo", SqlDbType.Int).Value = parametros.idModulo;
                    sqlCommand.Parameters.Add("@subModulo", SqlDbType.VarChar, 200).Value = parametros.subModulo;
                    sqlCommand.Parameters.Add("@rutaForm", SqlDbType.VarChar, 200).Value = parametros.rutaForm;
                    sqlCommand.Parameters.Add("@iconPath", SqlDbType.VarChar, 500).Value = parametros.iconPath;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 40).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            response.idResponse = Convert.ToInt32(reader["idResponse"]);
                            response.messageResponse = reader["messageResponse"].ToString();
                            response.typeMessage = reader["typeMessage"].ToString();
                        }
                    }

                }
            }

            return response;
        }
        public Response SetAcceso(SetAccesoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetAcceso";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int, 11).Value = parametros.idUsuario;
                    sqlCommand.Parameters.Add("@idSubModulo", SqlDbType.Int, 11).Value = parametros.idSubModulo;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 30).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@activo", SqlDbType.Bit).Value = parametros.activo;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            response.idResponse = Convert.ToInt32(reader["idResponse"]);
                            response.messageResponse = reader["messageResponse"].ToString();
                            response.typeMessage = reader["typeMessage"].ToString();
                        }
                    }

                }
            }

            return response;
        }


    }
}
