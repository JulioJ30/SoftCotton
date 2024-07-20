using SoftCotton.Database;
using SoftCotton.Model.Employee;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class EmpleadoRepository
    {
        // ### GET ###
        public List<GetEmp1_Personas> Get1_Personas()
        {
            List<GetEmp1_Personas> personas = new List<GetEmp1_Personas>();
            GetEmp1_Personas persona;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpleado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
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
                            persona = new GetEmp1_Personas();

                            persona.numDoc = reader["numDoc"].ToString();
                            persona.codTipoDoc = reader["codTipoDoc"].ToString();
                            persona.tipoDocCorta = reader["tipoDocCorta"].ToString();
                            persona.nombres = reader["nombres"].ToString();
                            persona.apellidoPaterno = reader["apellidoPaterno"].ToString();
                            persona.apellidoMaterno = reader["apellidoMaterno"].ToString();
                            persona.celular = reader["celular"].ToString();
                            persona.usuarioReg = reader["usuarioReg"].ToString();
                            persona.fechaReg = reader["fechaReg"].ToString();

                            personas.Add(persona);
                        }
                    }
                }
            }
            return personas;
        }
        public List<GetEmp2_Colaboradores> Get2_Colaboradores()
        {
            List<GetEmp2_Colaboradores> colaboradores = new List<GetEmp2_Colaboradores>();
            GetEmp2_Colaboradores colaborador;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpleado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
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
                            colaborador = new GetEmp2_Colaboradores();

                            colaborador.idPeriodo = Convert.ToInt32(reader["idPeriodo"].ToString());
                            colaborador.numeroDocumento = reader["numeroDocumento"].ToString();
                            colaborador.persona = reader["persona"].ToString();
                            colaborador.idCargo = Convert.ToInt32(reader["idCargo"]);
                            colaborador.cargo = reader["cargo"].ToString();
                            colaborador.idArea = Convert.ToInt32(reader["idArea"]);
                            colaborador.area = reader["area"].ToString();
                            colaborador.fechaIngreso = reader["fechaIngreso"].ToString();
                            colaborador.fechaCese = reader["fechaCese"] == DBNull.Value ? "" : reader["fechaCese"].ToString();
                            colaborador.usuarioReg = reader["usuarioReg"].ToString();
                            colaborador.fechaReg = reader["fechaReg"].ToString();

                            colaborador.idEstado = Convert.ToInt32(reader["idEstado"].ToString());
                            colaborador.mensajeEstado = reader["mensajeEstado"].ToString();

                            colaboradores.Add(colaborador);
                        }
                    }
                }
            }
            return colaboradores;
        }
        public GetEmp3_BuscarPersona Get3_BuscarPersona(string numeroDocumento)
        {
            GetEmp3_BuscarPersona resultado = new GetEmp3_BuscarPersona();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpleado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = numeroDocumento;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            resultado = new GetEmp3_BuscarPersona();

                            resultado.estadoBusqueda = Convert.ToInt32(reader["estadoBusqueda"].ToString());
                            resultado.numDoc = reader["numDoc"].ToString();
                            resultado.mensaje = reader["mensajeEstado"].ToString();
                        }
                    }
                }
            }
            return resultado;
        }
        public List<GetEmp4_Cargos> Get4_Cargos()
        {
            List<GetEmp4_Cargos> cargos = new List<GetEmp4_Cargos>();
            GetEmp4_Cargos cargo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpleado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
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
                            cargo = new GetEmp4_Cargos();

                            cargo.idCargo = Convert.ToInt32(reader["idCargo"].ToString());
                            cargo.cargo = reader["cargo"].ToString();

                            cargos.Add(cargo);
                        }
                    }
                }
            }
            return cargos;
        }
        public List<GetEmp5_Areas> Get5_Areas()
        {
            List<GetEmp5_Areas> areas = new List<GetEmp5_Areas>();
            GetEmp5_Areas area;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpleado";
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
                            area = new GetEmp5_Areas();

                            area.idArea = Convert.ToInt32(reader["idArea"].ToString());
                            area.area = reader["area"].ToString();

                            areas.Add(area);
                        }
                    }
                }
            }
            return areas;
        }
        public GetEmp6_BuscarXDNI Get6_BuscarXDNI(string numeroDocumento)
        {
            GetEmp6_BuscarXDNI resultado = new GetEmp6_BuscarXDNI();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpleado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = numeroDocumento;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            resultado = new GetEmp6_BuscarXDNI();

                            resultado.idPeriodo = Convert.ToInt32(reader["idPeriodo"].ToString());
                            resultado.numeroDocumento = reader["numeroDocumento"].ToString();
                            resultado.idCargo = Convert.ToInt32(reader["idCargo"].ToString());
                            resultado.idArea = Convert.ToInt32(reader["idArea"].ToString());
                            resultado.fechaIngreso = Convert.ToDateTime(reader["fechaIngreso"].ToString());
                            resultado.fechaCese = Convert.ToDateTime(reader["fechaCese"].ToString());

                        }
                    }
                }
            }
            return resultado;
        }

        // ### SET ###
        public Response SetEmpPersona(SetPersonaParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetPersona";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@numDoc", SqlDbType.VarChar, 15).Value = parametros.numDoc;
                    sqlCommand.Parameters.Add("@numDocUpdate", SqlDbType.VarChar, 15).Value = parametros.numDocUpdate;
                    sqlCommand.Parameters.Add("@codTipoDoc", SqlDbType.VarChar, 2).Value = parametros.codTipoDoc;
                    sqlCommand.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = parametros.nombres;
                    sqlCommand.Parameters.Add("@apellidoPaterno", SqlDbType.VarChar, 50).Value = parametros.apellidoPaterno;
                    sqlCommand.Parameters.Add("@apellidoMaterno", SqlDbType.VarChar, 50).Value = parametros.apellidoMaterno;
                    sqlCommand.Parameters.Add("@celular", SqlDbType.VarChar, 30).Value = parametros.celular;
                    
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 50).Value = parametros.usuarioReg;

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
        public Response SetEmpColaborador(SetColaboradorParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetColaborador";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = parametros.idPeriodo;
                    sqlCommand.Parameters.Add("@numeroDocumento", SqlDbType.VarChar, 15).Value = parametros.numeroDocumento;
                    sqlCommand.Parameters.Add("@idCargo", SqlDbType.Int).Value = parametros.idCargo;
                    sqlCommand.Parameters.Add("@idArea", SqlDbType.Int).Value = parametros.idArea;
                    sqlCommand.Parameters.Add("@fechaIngreso", SqlDbType.VarChar, 8).Value = parametros.fechaIngreso;
                    sqlCommand.Parameters.Add("@fechaCese", SqlDbType.VarChar, 8).Value = parametros.fechaCese;

                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 30).Value = parametros.usuarioReg;

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
