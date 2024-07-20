using SoftCotton.Database;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
//using SoftCotton.Model.DispatchControl;


namespace SoftCotton.Repository
{
    public class MantenimientoRepository
    {


        // ESTILOS
        public IEnumerable<GetMant53_Estilos> GetEstilos()
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 53, DbType.Int32, ParameterDirection.Input);

                return sqlConnection.Query<GetMant53_Estilos>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }

        // PROGRMAS
        public IEnumerable<GetMant54_Programas> GetProgramas()
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 54, DbType.Int32, ParameterDirection.Input);

                return sqlConnection.Query<GetMant54_Programas>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        // PEDIDOS
        public IEnumerable<GetMant55_Pedidos> GetPedidos()
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 55, DbType.Int32, ParameterDirection.Input);

                return sqlConnection.Query<GetMant55_Pedidos>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }

        // PEDIDOS COLOR
        public IEnumerable<GetMant56_PedidosColor> GetPedidosColor(int idPedido)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 56, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt1", idPedido, DbType.Int32, ParameterDirection.Input);


                return sqlConnection.Query<GetMant56_PedidosColor>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }



        // GET UBIGEOS
        public IEnumerable<GetUbigeos> GetUbigeos(int opcion = 44, string codigo = null)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", opcion, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", codigo, DbType.String, ParameterDirection.Input);

                return sqlConnection.Query<GetUbigeos>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        // MTALLAS MATRIZ
        public IEnumerable<GetMant21_Tallas> Get48_Tallas()
        {
            //List<GetMant21_Tallas> tallas = new List<GetMant21_Tallas>();
            //GetMant21_Tallas talla;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    var sp_parametros = new DynamicParameters();
                    sp_parametros.Add("@opcion", 48, DbType.Int32, ParameterDirection.Input);
                    //sp_parametros.Add("@filtroTxt1", codigo, DbType.String, ParameterDirection.Input);

                    return sqlConnection.Query<GetMant21_Tallas>("uspGetMantenimiento",
                                                        sp_parametros,
                                                        commandType: CommandType.StoredProcedure);
                }
            }
            //return tallas;
        }

        public  GetMant23_TipoCambio GetTipoCambioFecha(string fecha, int idtipomoneda)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 47, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", fecha, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt1", idtipomoneda, DbType.Int32, ParameterDirection.Input);


                return sqlConnection.QuerySingleOrDefault<GetMant23_TipoCambio>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        // ### GET ###
        public List<GetMant7_CeCos> GetMant7_CeCos()
        {
            List<GetMant7_CeCos> cecos = new List<GetMant7_CeCos>();
            GetMant7_CeCos ceco;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;
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
                            ceco = new GetMant7_CeCos();

                            ceco.codceco = reader["codceco"].ToString();
                            ceco.ceco = reader["ceco"].ToString();
                            ceco.usuarioReg = reader["usuarioReg"].ToString();
                            ceco.fechaReg = reader["fechaReg"].ToString();
                            ceco.estado = Convert.ToBoolean(reader["estado"]);

                            cecos.Add(ceco);
                        }
                    }
                }
            }
            return cecos;
        }
        public List<GetMant8_TipoCpte> GetMant8_TipoDoc()
        {
            List<GetMant8_TipoCpte> tipoComprobantes = new List<GetMant8_TipoCpte>();
            GetMant8_TipoCpte tipoComprobante;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 8;
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
                            tipoComprobante = new GetMant8_TipoCpte();

                            tipoComprobante.codTipoCpte = reader["codTipoCpte"].ToString();
                            tipoComprobante.tipoComprobante = reader["tipoComprobante"].ToString();
                            tipoComprobante.usuarioReg = reader["usuarioReg"].ToString();
                            tipoComprobante.fechaReg = reader["fechaReg"].ToString();
                            tipoComprobante.estado = Convert.ToBoolean(reader["estado"]);

                            tipoComprobantes.Add(tipoComprobante);
                        }
                    }
                }
            }
            return tipoComprobantes;
        }
        public List<GetMant9_CondPago> GetMant9_CondPago()
        {
            List<GetMant9_CondPago> condicionesPagos = new List<GetMant9_CondPago>();
            GetMant9_CondPago condicionesPago;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 9;
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
                            condicionesPago = new GetMant9_CondPago();

                            condicionesPago.idCondPago = Convert.ToInt32(reader["idCondPago"]);
                            condicionesPago.condicion = reader["condicion"].ToString();
                            condicionesPago.usuarioReg = reader["usuarioReg"].ToString();
                            condicionesPago.fechaReg = reader["fechaReg"].ToString();
                            condicionesPago.estado = Convert.ToBoolean(reader["estado"]);

                            condicionesPagos.Add(condicionesPago);
                        }
                    }
                }
            }
            return condicionesPagos;
        }
        public List<GetMant10_TipoMoneda> GetMant10_TipoMoneda()
        {
            List<GetMant10_TipoMoneda> tipoMonedas = new List<GetMant10_TipoMoneda>();
            GetMant10_TipoMoneda tipoMoneda;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 10;
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
                            tipoMoneda = new GetMant10_TipoMoneda();

                            tipoMoneda.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"]);
                            tipoMoneda.simbolo = reader["simbolo"].ToString();
                            tipoMoneda.monedaSingular = reader["monedaSingular"].ToString();
                            tipoMoneda.monedaPlural = reader["monedaPlural"].ToString();
                            tipoMoneda.usuarioReg = reader["usuarioReg"].ToString();
                            tipoMoneda.fechaReg = reader["fechaReg"].ToString();
                            tipoMoneda.estado = Convert.ToBoolean(reader["estado"]);

                            tipoMonedas.Add(tipoMoneda);
                        }
                    }
                }
            }
            return tipoMonedas;
        }
        public List<GetMant11_TipoDoc> GetMant11_TipoDoc()
        {
            List<GetMant11_TipoDoc> tipoDocumentos = new List<GetMant11_TipoDoc>();
            GetMant11_TipoDoc tipoDocumento;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 11;
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
                            tipoDocumento = new GetMant11_TipoDoc();

                            tipoDocumento.codTipoDoc = reader["codTipoDoc"].ToString();
                            tipoDocumento.tipoDocLarga = reader["tipoDocLarga"].ToString();
                            tipoDocumento.tipoDocCorta = reader["tipoDocCorta"].ToString();
                            tipoDocumento.usuarioReg = reader["usuarioReg"].ToString();
                            tipoDocumento.fechaReg = reader["fechaReg"].ToString();
                            tipoDocumento.estado = Convert.ToBoolean(reader["estado"]);

                            tipoDocumentos.Add(tipoDocumento);
                        }
                    }
                }
            }
            return tipoDocumentos;
        }
        public List<GetMant12_ProvClientes> GetMant12_ProvClientes()
        {
            List<GetMant12_ProvClientes> provClientes = new List<GetMant12_ProvClientes>();
            GetMant12_ProvClientes provCliente;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 12;
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
                            provCliente = new GetMant12_ProvClientes();

                            provCliente.codigo = reader["codigo"].ToString();
                            provCliente.codTipoDoc = reader["codTipoDoc"].ToString();
                            provCliente.tipoDocCorta = reader["tipoDocCorta"].ToString();
                            provCliente.razonSocial = reader["razonSocial"].ToString();
                            provCliente.nombre1 = reader["nombre1"].ToString();
                            provCliente.nombre2 = reader["nombre2"].ToString();
                            provCliente.apellido1 = reader["apellido1"].ToString();
                            provCliente.apellido2 = reader["apellido2"].ToString();
                            provCliente.codTipoPC = reader["codTipoPC"].ToString();
                            provCliente.tipo = reader["tipo"].ToString();
                            provCliente.telefono = reader["telefono"].ToString();
                            provCliente.direccion = reader["direccion"].ToString();
                            provCliente.usuarioReg = reader["usuarioReg"].ToString();
                            provCliente.fechaReg = reader["fechaReg"].ToString();
                            provCliente.estado = Convert.ToBoolean(reader["estado"]);
                            provCliente.contacto = reader["contacto"].ToString();
                            provCliente.email = reader["email"].ToString();

                            provCliente.iddistrito = reader["iddistrito"].ToString();
                            provCliente.distrito = reader["distrito"].ToString();
                            provCliente.idprovincia = reader["idprovincia"].ToString();
                            provCliente.provincia = reader["provincia"].ToString();
                            provCliente.iddepartamento = reader["iddepartamento"].ToString();
                            provCliente.departamento = reader["departamento"].ToString();


                            provClientes.Add(provCliente);
                        }
                    }
                }
            }
            return provClientes;
        }
        public List<GetMant13_TipoDoc> GetMant13_TipoDoc()
        {
            List<GetMant13_TipoDoc> tipoDocumentos = new List<GetMant13_TipoDoc>();
            GetMant13_TipoDoc tipoDocumento;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 13;
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
                            tipoDocumento = new GetMant13_TipoDoc();

                            tipoDocumento.codTipoDoc = reader["codTipoDoc"].ToString();
                            tipoDocumento.tipoDocCorta = reader["tipoDocCorta"].ToString();

                            tipoDocumentos.Add(tipoDocumento);
                        }
                    }
                }
            }
            return tipoDocumentos;
        }
        public List<GetMant14_RelEmpresas> GetMant14_RelEmpresas()
        {
            List<GetMant14_RelEmpresas> relacionEmpresas = new List<GetMant14_RelEmpresas>();
            GetMant14_RelEmpresas relacionEmpresa;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 14;
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
                            relacionEmpresa = new GetMant14_RelEmpresas();

                            relacionEmpresa.codTipoPC = reader["codTipoPC"].ToString();
                            relacionEmpresa.tipo = reader["tipo"].ToString();

                            relacionEmpresas.Add(relacionEmpresa);
                        }
                    }
                }
            }
            return relacionEmpresas;
        }
        public List<GetMant15_Nivel> GetMant15_Nivel()
        {
            List<GetMant15_Nivel> nivels = new List<GetMant15_Nivel>();
            GetMant15_Nivel nivel;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 15;
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
                            nivel = new GetMant15_Nivel();

                            nivel.codNivel = reader["codNivel"].ToString();
                            nivel.nivel = reader["nivel"].ToString();
                            nivel.abreviatura = reader["abreviatura"].ToString();
                            nivel.usuarioReg = reader["usuarioReg"].ToString();
                            nivel.fechaReg = reader["fechaReg"].ToString();
                            nivel.estado = Convert.ToBoolean(reader["estado"]);

                            nivels.Add(nivel);
                        }
                    }
                }
            }
            return nivels;
        }
        public List<GetMant16_NivelCBX> Get16_NivelCBX()
        {
            List<GetMant16_NivelCBX> nivels = new List<GetMant16_NivelCBX>();
            GetMant16_NivelCBX nivel;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 16;
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
                            nivel = new GetMant16_NivelCBX();

                            nivel.codNivel = reader["codNivel"].ToString();
                            nivel.nivel = reader["nivel"].ToString();

                            nivels.Add(nivel);
                        }
                    }
                }
            }
            return nivels;
        }
        public List<GetMant17_TallasCBX> Get17_TallasCBX()
        {
            List<GetMant17_TallasCBX> tallas = new List<GetMant17_TallasCBX>();
            GetMant17_TallasCBX talla;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 17;
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
                            talla = new GetMant17_TallasCBX();

                            talla.codTalla = reader["codTalla"].ToString();
                            talla.descripcion = reader["descripcion"].ToString();

                            tallas.Add(talla);
                        }
                    }
                }
            }
            return tallas;
        }
        public List<GetMant18_ColoresCBX> Get18_ColoresCBX()
        {
            List<GetMant18_ColoresCBX> colores = new List<GetMant18_ColoresCBX>();
            GetMant18_ColoresCBX color;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 18;
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
                            color = new GetMant18_ColoresCBX();

                            color.codColor = reader["codColor"].ToString();
                            color.descripcion = reader["descripcion"].ToString();

                            colores.Add(color);
                        }
                    }
                }
            }
            return colores;
        }
        public List<GetMant19_UMCBX> Get19_UMCBX()
        {
            List<GetMant19_UMCBX> unidadesMedida = new List<GetMant19_UMCBX>();
            GetMant19_UMCBX unidadMedida;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 19;
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
                            unidadMedida = new GetMant19_UMCBX();

                            unidadMedida.codUM = reader["codUM"].ToString();
                            unidadMedida.descripcion = reader["descripcion"].ToString();

                            unidadesMedida.Add(unidadMedida);
                        }
                    }
                }
            }
            return unidadesMedida;
        }
        public List<GetMant20_Productos> Get20_Productos()
        {
            List<GetMant20_Productos> productos = new List<GetMant20_Productos>();
            GetMant20_Productos producto;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 20;
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
                            producto = new GetMant20_Productos();

                            //producto.codNivel = reader["codNivel"].ToString();
                            //producto.nivel = reader["nivel"].ToString();


                            producto.codProducto = reader["codProducto"].ToString();
                            producto.codProductoAlt = reader["codProductoAlt"].ToString();
                            producto.producto = reader["producto"].ToString();
                            producto.codTalla = reader["codTalla"].ToString();
                            producto.talla = reader["talla"].ToString();
                            producto.codColor = reader["codColor"].ToString();
                            producto.color = reader["color"].ToString();
                            producto.codUM = reader["codUM"].ToString();
                            producto.unidadMedida = reader["unidadMedida"].ToString();
                            producto.estado = Convert.ToBoolean(reader["estado"]);
                            producto.usuarioReg = reader["usuarioReg"].ToString();
                            producto.fechaReg = reader["fechaReg"].ToString();

                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }
        public List<GetMant21_Tallas> Get21_Tallas()
        {
            List<GetMant21_Tallas> tallas = new List<GetMant21_Tallas>();
            GetMant21_Tallas talla;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 21;
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
                            talla = new GetMant21_Tallas();

                            talla.codTalla = reader["codTalla"].ToString();
                            talla.descripcion = reader["descripcion"].ToString();

                            talla.estado = Convert.ToBoolean(reader["estado"]);
                            talla.usuarioReg = reader["usuarioReg"].ToString();
                            talla.fechaReg = reader["fechaReg"].ToString();

                            tallas.Add(talla);
                        }
                    }
                }
            }
            return tallas;
        }
        public List<GetMant22_Color> Get22_Color()
        {
            List<GetMant22_Color> colores = new List<GetMant22_Color>();
            GetMant22_Color color;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 22;
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
                            color = new GetMant22_Color();

                            color.codColor = reader["codColor"].ToString();
                            color.descripcion = reader["descripcion"].ToString();

                            color.estado = Convert.ToBoolean(reader["estado"]);
                            color.usuarioReg = reader["usuarioReg"].ToString();
                            color.fechaReg = reader["fechaReg"].ToString();

                            colores.Add(color);
                        }
                    }
                }
            }
            return colores;
        }
        public List<GetMant23_TipoCambio> Get23_TipoCambio()
        {
            List<GetMant23_TipoCambio> tipoCambios = new List<GetMant23_TipoCambio>();
            GetMant23_TipoCambio tipoCambio;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 23;
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
                            tipoCambio = new GetMant23_TipoCambio();

                            tipoCambio.fecha = reader["fecha"].ToString();
                            tipoCambio.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"].ToString());
                            tipoCambio.monedaSingular = reader["monedaSingular"].ToString();
                            tipoCambio.compra = Convert.ToDecimal(reader["compra"]);
                            tipoCambio.venta = Convert.ToDecimal(reader["venta"]);

                            tipoCambio.usuarioReg = reader["usuarioReg"].ToString();
                            tipoCambio.fechaReg = reader["fechaReg"].ToString();

                            tipoCambios.Add(tipoCambio);
                        }
                    }
                }
            }
            return tipoCambios;
        }
        public List<GetMant24_TipoMoneda> Get24_TipoMoneda()
        {
            List<GetMant24_TipoMoneda> monedas = new List<GetMant24_TipoMoneda>();
            GetMant24_TipoMoneda moneda;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 24;
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
                            moneda = new GetMant24_TipoMoneda();

                            moneda.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"].ToString());
                            moneda.moneda = reader["moneda"].ToString();

                            monedas.Add(moneda);
                        }
                    }
                }
            }
            return monedas;
        }
        public List<GetMant25_Grupos> Get25_Grupos(string codNivel, string codGrupo)
        {
            List<GetMant25_Grupos> grupos = new List<GetMant25_Grupos>();
            GetMant25_Grupos grupo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 25;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = codNivel;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = codGrupo;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            grupo = new GetMant25_Grupos();

                            grupo.codNivel = reader["codNivel"].ToString();
                            grupo.codGrupo = reader["codGrupo"].ToString();
                            grupo.nivel = reader["nivel"].ToString();
                            grupo.grupo = reader["grupo"].ToString();
                            grupo.codUM = reader["codUM"].ToString();
                            grupo.unidadmedida = reader["unidadmedida"].ToString();
                            grupo.codCuenta = reader["codCuenta"].ToString();
                            grupo.cuenta = reader["cuenta"].ToString();
                            grupo.codGrupoAlt = reader["codGrupoAlt"].ToString();

                            grupos.Add(grupo);
                        }
                    }
                }
            }
            return grupos;
        }
        public List<GetMant26_ProdServicios> Get26_ProductosServicios(string codNivel, string codGrupo)
        {
            List<GetMant26_ProdServicios> prodServs = new List<GetMant26_ProdServicios>();
            GetMant26_ProdServicios prodServ;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 26;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = codNivel;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = codGrupo;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            prodServ = new GetMant26_ProdServicios();

                            prodServ.codNivel = reader["codNivel"].ToString();
                            prodServ.codGrupo = reader["codGrupo"].ToString();
                            prodServ.codTalla = reader["codTalla"].ToString();
                            prodServ.codColor = reader["codColor"].ToString();

                            prodServ.nivel = reader["nivel"].ToString();
                            prodServ.grupo = reader["grupo"].ToString();
                            prodServ.talla = reader["talla"].ToString();
                            prodServ.color = reader["color"].ToString();

                            prodServs.Add(prodServ);
                        }
                    }
                }
            }
            return prodServs;
        }
        public List<GetMant27_Cuentas> Get27_Cuentas()
        {
            List<GetMant27_Cuentas> cuentas = new List<GetMant27_Cuentas>();
            GetMant27_Cuentas cuenta;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 27;
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
                            cuenta = new GetMant27_Cuentas();

                            cuenta.codCuenta = reader["codCuenta"].ToString();
                            cuenta.cuenta = reader["cuenta"].ToString();
                            cuenta.codCuentaNivel = reader["codCuentaNivel"].ToString();
                            cuenta.cuentaNivel = reader["cuentaNivel"].ToString();
                            cuenta.codCuentaTipo = reader["codCuentaTipo"].ToString();
                            cuenta.cuentaTipo = reader["cuentaTipo"].ToString();
                            cuenta.cuentaAmarreDebe = reader["cuentaAmarreDebe"].ToString();
                            cuenta.cuentaAmarreHaber = reader["cuentaAmarreHaber"].ToString();

                            cuenta.fechaReg = reader["fechaReg"].ToString();
                            cuenta.usuarioReg = reader["usuarioReg"].ToString();
                            cuenta.estado = Convert.ToBoolean(reader["estado"]);
                            cuenta.FlgMostrarKardex = Convert.ToBoolean(reader["FlgMostrarKardex"]);


                            cuentas.Add(cuenta);
                        }
                    }
                }
            }
            return cuentas;
        }
        public List<GetMant28_CuentaNivelCBX> Get28_CuentaNiveles()
        {
            List<GetMant28_CuentaNivelCBX> cuentaNiveles = new List<GetMant28_CuentaNivelCBX>();
            GetMant28_CuentaNivelCBX cuentaNivel;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 28;
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
                            cuentaNivel = new GetMant28_CuentaNivelCBX();

                            cuentaNivel.codCuentaNivel = reader["codCuentaNivel"].ToString();
                            cuentaNivel.cuentaNivel = reader["cuentaNivel"].ToString();

                            cuentaNiveles.Add(cuentaNivel);
                        }
                    }
                }
            }
            return cuentaNiveles;
        }
        public List<GetMant29_CuentaTipoCBX> Get29_CuentaTipos()
        {
            List<GetMant29_CuentaTipoCBX> cuentaTipos = new List<GetMant29_CuentaTipoCBX>();
            GetMant29_CuentaTipoCBX cuentaTipo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 29;
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
                            cuentaTipo = new GetMant29_CuentaTipoCBX();

                            cuentaTipo.codCuentaTipo = reader["codCuentaTipo"].ToString();
                            cuentaTipo.cuentaTipo = reader["cuentaTipo"].ToString();

                            cuentaTipos.Add(cuentaTipo);
                        }
                    }
                }
            }
            return cuentaTipos;
        }
        public List<GetMant30_UM> Get30_UM()
        {
            List<GetMant30_UM> ums = new List<GetMant30_UM>();
            GetMant30_UM um;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 30;
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
                            um = new GetMant30_UM();

                            um.codUM = reader["codUM"].ToString();
                            um.descripcion = reader["descripcion"].ToString();
                            um.usuarioReg = reader["usuarioReg"].ToString();
                            um.fechaReg = reader["fechaReg"].ToString();
                            um.estado = Convert.ToBoolean(reader["estado"]);

                            ums.Add(um);
                        }
                    }
                }
            }
            return ums;
        }
        public List<GetMant32_BuscarColor> Get32_BuscarColor(string color)
        {
            List<GetMant32_BuscarColor> colores = new List<GetMant32_BuscarColor>();
            GetMant32_BuscarColor colorObj;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 32;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = color;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            colorObj = new GetMant32_BuscarColor();

                            colorObj.codColor = reader["codColor"].ToString();
                            colorObj.descripcion = reader["descripcion"].ToString();

                            colores.Add(colorObj);
                        }
                    }
                }
            }
            return colores;
        }
        public List<GetMant33_Servicio> Get33_Servicio(string filtroBusqueda = "", int estado = 0)
        {
            List<GetMant33_Servicio> servicios = new List<GetMant33_Servicio>();
            GetMant33_Servicio servicio;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 33;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtroBusqueda;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = estado;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            servicio = new GetMant33_Servicio();

                            servicio.codServicio = reader["codServicio"].ToString();
                            servicio.nombreServicio = reader["nombreServicio"].ToString();
                            servicio.estado = Convert.ToBoolean(reader["estado"]);
                            servicio.usuarioReg = reader["usuarioReg"].ToString();
                            servicio.fechaReg = reader["fechaReg"].ToString();

                            servicios.Add(servicio);
                        }
                    }
                }
            }
            return servicios;
        }
        public List<GetMant34_Programa> Get34_Programa(string filtroBusqueda = "", int estado = 0)
        {
            List<GetMant34_Programa> programas = new List<GetMant34_Programa>();
            GetMant34_Programa programa;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 54;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtroBusqueda;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = estado;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            programa = new GetMant34_Programa();

                            //programa.codPrograma = reader["codPrograma"].ToString();
                            //programa.nombrePrograma = reader["nombrePrograma"].ToString();

                            //programa.pedido = reader["pedido"].ToString();
                            //programa.estilo = reader["estilo"].ToString();
                            //programa.nombre = reader["nombre"].ToString();
                            //programa.codColor = reader["codColor"].ToString();
                            //programa.descripcionColor = reader["descripcionColor"].ToString();



                            //programa.estado = Convert.ToBoolean(reader["estado"]);
                            //programa.usuarioReg = reader["usuarioReg"].ToString();
                            //programa.fechaReg = reader["fechaReg"].ToString();


                            programa.idPrograma = Convert.ToInt32(reader["idPrograma"].ToString());
                            programa.programa = reader["programa"].ToString();

                            programa.codPrograma = reader["idPrograma"].ToString();
                            programa.nombrePrograma = reader["programa"].ToString();

                            //programa.pedido = reader["pedido"].ToString();
                            //programa.estilo = reader["estilo"].ToString();
                            //programa.nombre = reader["nombre"].ToString();
                            //programa.codColor = reader["codColor"].ToString();
                            //programa.descripcionColor = reader["descripcionColor"].ToString();



                            programa.estado = Convert.ToBoolean(reader["estado"]);
                            //programa.usuarioReg = reader["usuarioReg"].ToString();
                            //programa.fechaReg = reader["fechaReg"].ToString();

                            programas.Add(programa);
                        }
                    }
                }
            }
            return programas;
        }


        // BUSCAMOS PROGRAMA POR PEDIDO
        public IEnumerable<GetMant34_Programa> Get34_ProgramaPorPedido(string filtroBusqueda = "")
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 49, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", filtroBusqueda, DbType.String, ParameterDirection.Input);

                return sqlConnection.Query<GetMant34_Programa>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }



        // ### SET ###
        public Response SetCentroCosto(SetCeCoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetCentroCosto";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@codceco", SqlDbType.VarChar, 10).Value = parametros.codceco;
                    sqlCommand.Parameters.Add("@codcecoUpdate", SqlDbType.VarChar, 10).Value = parametros.codcecoUpdate;
                    sqlCommand.Parameters.Add("@ceco", SqlDbType.VarChar, 20).Value = parametros.ceco;
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
        public Response SetTipoComprobante(SetTipoComprobanteParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetTipoComprobante";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@codTipoCpte", SqlDbType.VarChar, 2).Value = parametros.codTipoCpte;
                    sqlCommand.Parameters.Add("@codTipoCpteUpdate", SqlDbType.VarChar, 2).Value = parametros.codTipoCpteUpdate;
                    sqlCommand.Parameters.Add("@tipoComprobante", SqlDbType.VarChar, 20).Value = parametros.tipoComprobante;
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
        public Response SetCondicionesPago(SetCondPagoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetCondicionesPago";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idCondPago", SqlDbType.Int).Value = parametros.idCondPago;
                    sqlCommand.Parameters.Add("@condicion", SqlDbType.VarChar, 30).Value = parametros.condicion;
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
        public Response SetTipoMoneda(SetTipoMonedaParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetTipoMoneda";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idTipoMoneda", SqlDbType.Int).Value = parametros.idTipoMoneda;
                    sqlCommand.Parameters.Add("@simbolo", SqlDbType.VarChar, 100).Value = parametros.simbolo;
                    sqlCommand.Parameters.Add("@monedaSingular", SqlDbType.VarChar, 100).Value = parametros.monedaSingular;
                    sqlCommand.Parameters.Add("@monedaPlural", SqlDbType.VarChar, 100).Value = parametros.monedaPlural;
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
        public Response SetTipoDocumento(SetTipoDocumentoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetTipoDocumento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@codTipoDoc", SqlDbType.VarChar, 2).Value = parametros.codTipoDoc;
                    sqlCommand.Parameters.Add("@codTipoDocUpdate", SqlDbType.VarChar, 2).Value = parametros.codTipoDocUpdate;
                    sqlCommand.Parameters.Add("@tipoDocLarga", SqlDbType.VarChar, 40).Value = parametros.tipoDocLarga;
                    sqlCommand.Parameters.Add("@tipoDocCorta", SqlDbType.VarChar, 20).Value = parametros.tipoDocCorta;

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
        public Response SetProvClientes(SetProvClientesParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetProvClientes";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@codigo", SqlDbType.VarChar, 15).Value = parametros.codigo;
                    sqlCommand.Parameters.Add("@codigoUpdate", SqlDbType.VarChar, 15).Value = parametros.codigo;
                    sqlCommand.Parameters.Add("@codTipoDoc", SqlDbType.VarChar, 2).Value = parametros.codTipoDoc;
                    sqlCommand.Parameters.Add("@razonSocial", SqlDbType.VarChar, 60).Value = parametros.razonSocial;
                    sqlCommand.Parameters.Add("@nombre1", SqlDbType.VarChar, 20).Value = parametros.nombre1;
                    sqlCommand.Parameters.Add("@nombre2", SqlDbType.VarChar, 20).Value = parametros.nombre2;
                    sqlCommand.Parameters.Add("@apellido1", SqlDbType.VarChar, 20).Value = parametros.apellido1;
                    sqlCommand.Parameters.Add("@apellido2", SqlDbType.VarChar, 20).Value = parametros.apellido2;
                    sqlCommand.Parameters.Add("@codTipoPC", SqlDbType.VarChar, 1).Value = parametros.codTipoPC;
                    sqlCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 11).Value = parametros.telefono;
                    sqlCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 40).Value = parametros.direccion;
                    sqlCommand.Parameters.Add("@contacto", SqlDbType.VarChar, 100).Value = parametros.contacto;
                    sqlCommand.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = parametros.email;

                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 40).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;

                    sqlCommand.Parameters.Add("@iddistrito", SqlDbType.VarChar).Value = parametros.iddistrito;


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
        public Response SetNivel(SetNivelParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetNivel";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 2).Value = parametros.codNivel;
                    sqlCommand.Parameters.Add("@codNivelUpdate", SqlDbType.VarChar, 3).Value = parametros.codNivelUpdate;
                    sqlCommand.Parameters.Add("@nivel", SqlDbType.VarChar, 200).Value = parametros.nivel;
                    sqlCommand.Parameters.Add("@abreviatura", SqlDbType.VarChar, 2).Value = parametros.abreviatura;

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
        public Response SetProducto(SetProductoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetProducto";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    //sqlCommand.Parameters.Add("@codNivel", SqlDbType.Char, 3).Value = parametros.codNivel;
                    sqlCommand.Parameters.Add("@codProducto", SqlDbType.VarChar, 5).Value = parametros.codProducto;
                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 3).Value = parametros.codTalla;
                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 6).Value = parametros.codColor;

                    sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 250).Value = parametros.descripcion;
                    sqlCommand.Parameters.Add("@codUM", SqlDbType.VarChar, 3).Value = parametros.codUM;
                    sqlCommand.Parameters.Add("@codProductoAlt", SqlDbType.VarChar, 15).Value = parametros.codProductoAlt;

                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;

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
        public Response SetTalla(SetTallaParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetTalla";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 3).Value = parametros.codTalla;
                    sqlCommand.Parameters.Add("@codTallaUpdate", SqlDbType.VarChar, 3).Value = parametros.codTallaUpdate;
                    sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = parametros.descripcion;

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
        public Response SetColor(SetColorParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetColor";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 6).Value = parametros.codColor;
                    sqlCommand.Parameters.Add("@codColorUpdate", SqlDbType.VarChar, 6).Value = parametros.codColorUpdate;
                    sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = parametros.descripcion;

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
        public Response SetTipoCambio(SetTipoCambioParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetTipoCambio";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@fecha", SqlDbType.VarChar, 8).Value = parametros.fecha;
                    sqlCommand.Parameters.Add("@idTipoMoneda", SqlDbType.Int).Value = parametros.idTipoMoneda;
                    sqlCommand.Parameters.Add("@compra", SqlDbType.Decimal).Value = parametros.compra;
                    sqlCommand.Parameters.Add("@venta", SqlDbType.Decimal).Value = parametros.venta;
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
        public Response SetGrupo(SetGrupoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetGrupo";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 2).Value = parametros.codNivel;
                    sqlCommand.Parameters.Add("@codGrupo", SqlDbType.VarChar, 5).Value = parametros.codGrupo;
                    sqlCommand.Parameters.Add("@codGrupoAlt", SqlDbType.VarChar, 200).Value = parametros.codGrupoAlt;
                    sqlCommand.Parameters.Add("@grupo", SqlDbType.VarChar, 150).Value = parametros.grupo;
                    sqlCommand.Parameters.Add("@codUM", SqlDbType.VarChar, 3).Value = parametros.codUM;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 50).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = parametros.codCuenta;

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
        public Response SetProductoServicio(SetProductoServicioParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetProductoServicio";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 2).Value = parametros.codNivel;
                    sqlCommand.Parameters.Add("@codGrupo", SqlDbType.VarChar, 5).Value = parametros.codGrupo;
                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 3).Value = parametros.codTalla;
                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 6).Value = parametros.codColor;

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
        public Response SetCuenta(SetCuentaParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetCuentas";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = parametros.codCuenta;
                    sqlCommand.Parameters.Add("@codCuentaUpdate", SqlDbType.VarChar, 10).Value = parametros.codCuentaUpdate;
                    sqlCommand.Parameters.Add("@cuenta", SqlDbType.VarChar, 150).Value = parametros.cuenta;
                    sqlCommand.Parameters.Add("@codCuentaNivel", SqlDbType.VarChar, 1).Value = parametros.codCuentaNivel;
                    sqlCommand.Parameters.Add("@codCuentaTipo", SqlDbType.VarChar, 1).Value = parametros.codCuentaTipo;
                    sqlCommand.Parameters.Add("@cuentaAmarreDebe", SqlDbType.VarChar, 10).Value = parametros.cuentaAmarreDebe;
                    sqlCommand.Parameters.Add("@cuentaAmarreHaber", SqlDbType.VarChar, 10).Value = parametros.cuentaAmarreHaber;

                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 50).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;
                    sqlCommand.Parameters.Add("@FlgMostrarKardex", SqlDbType.Bit).Value = parametros.FlgMostrarKardex;


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
        public Response SetUnidadMedida(SetUMParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetUnidadMedida";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@codUM", SqlDbType.VarChar, 10).Value = parametros.codUM;
                    sqlCommand.Parameters.Add("@codUMUpdate", SqlDbType.VarChar, 10).Value = parametros.codUMUpdate;
                    sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = parametros.descripcion;

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
        public Response SetServicio(SetServicioParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetServicio";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@codServicio", SqlDbType.VarChar, 6).Value = parametros.codServicio;
                    sqlCommand.Parameters.Add("@codServicioUpdate", SqlDbType.VarChar, 6).Value = parametros.codServicioUpdate;
                    sqlCommand.Parameters.Add("@nombreServicio", SqlDbType.VarChar, 150).Value = parametros.nombreServicio;

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
        public Response SetPrograma(SetProgramaParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    //sqlCommand.CommandText = @"uspSetPrograma";
                    sqlCommand.CommandText = @"uspSetProgramas";

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;


                    sqlCommand.Parameters.Add("@idPrograma", SqlDbType.Int).Value = parametros.idPrograma;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;
                    sqlCommand.Parameters.Add("@idusuarioCrea", SqlDbType.Int).Value = parametros.idUsuarioCrea;
                    sqlCommand.Parameters.Add("@programa", SqlDbType.VarChar, 255).Value = parametros.programa;



                    //sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 50).Value = parametros.usuarioReg;
                    //sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;

                    //sqlCommand.Parameters.Add("@codPrograma", SqlDbType.Char, 6).Value = parametros.codPrograma;
                    //sqlCommand.Parameters.Add("@codProgramaUpdate", SqlDbType.Char, 6).Value = parametros.codProgamaUpdate;
                    //sqlCommand.Parameters.Add("@nombrePrograma", SqlDbType.Char, 150).Value = parametros.nombrePrograma;

                    //sqlCommand.Parameters.Add("@pedido", SqlDbType.VarChar, 100).Value = parametros.pedido;
                    //sqlCommand.Parameters.Add("@estilo", SqlDbType.VarChar, 100).Value = parametros.estilo;
                    //sqlCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = parametros.nombre;
                    //sqlCommand.Parameters.Add("@codColor", SqlDbType.Char, 6).Value = parametros.codColor;


                    //sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 50).Value = parametros.usuarioReg;
                    //sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;

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


        // ### REPORTES ###
        public List<GetRpte1_ProvClientes> GetRpte1_ProvClientes()
        {
            List<GetRpte1_ProvClientes> provClientes = new List<GetRpte1_ProvClientes>();
            GetRpte1_ProvClientes provCliente;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimientoRpte";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt4", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt3", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            provCliente = new GetRpte1_ProvClientes();

                            provCliente.codigo = reader["codigo"].ToString();
                            provCliente.codTipoDoc = reader["codTipoDoc"].ToString();
                            provCliente.tipoDocCorta = reader["tipoDocCorta"].ToString();
                            provCliente.razonSocial = reader["razonSocial"].ToString();
                            provCliente.nombre1 = reader["nombre1"].ToString();
                            provCliente.nombre2 = reader["nombre2"].ToString();
                            provCliente.apellido1 = reader["apellido1"].ToString();
                            provCliente.apellido2 = reader["apellido2"].ToString();
                            provCliente.codTipoPC = reader["codTipoPC"].ToString();
                            provCliente.tipo = reader["tipo"].ToString();
                            provCliente.telefono = reader["telefono"].ToString();
                            provCliente.direccion = reader["direccion"].ToString();
                            provCliente.atencion = reader["atencion"].ToString();

                            provClientes.Add(provCliente);
                        }
                    }
                }
            }
            return provClientes;
        }
        public List<GetMantRpte2_Productos> Get31_Productos(string codNivel, string grupo, string talla, string color)
        {
            List<GetMantRpte2_Productos> productos = new List<GetMantRpte2_Productos>();
            GetMantRpte2_Productos producto;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimientoRpte";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 31;
                    //sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = codNivel;
                    //sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = grupo;
                    //sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    //sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = codNivel;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = grupo;
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = talla;
                    sqlCommand.Parameters.Add("@filtroTxt4", SqlDbType.VarChar, 100).Value = color;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt3", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            producto = new GetMantRpte2_Productos();

                            producto.codNivel = reader["codNivel"].ToString();
                            producto.codGrupo = reader["codGrupo"].ToString();
                            producto.codTalla = reader["codTalla"].ToString();
                            producto.codColor = reader["codColor"].ToString();

                            producto.nivel = reader["nivel"].ToString();
                            producto.grupo = reader["grupo"].ToString();
                            producto.talla = reader["talla"].ToString();
                            producto.color = reader["color"].ToString();

                            producto.codGrupoAlt = reader["codGrupoAlt"].ToString();

                            producto.stockReal = Convert.ToDecimal(reader["stockReal"]);

                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }



        public List<GetMant40_ConstanciaInscripcion> GetMant40_ConstanciaInscripcion(string estado = null)
        {
            List<GetMant40_ConstanciaInscripcion> constancias = new List<GetMant40_ConstanciaInscripcion>();
            GetMant40_ConstanciaInscripcion constancia;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 40;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = estado;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            constancia = new GetMant40_ConstanciaInscripcion();
                            constancia.idConstanciaInscripcion = Convert.ToInt32(reader["idConstanciaInscripcion"].ToString());
                            constancia.constanciaInscripcion = reader["constanciaInscripcion"].ToString();
                            constancia.estado = reader["estado"].ToString();
                            constancia.usuarioReg = reader["usuarioReg"].ToString();
                            constancia.apellidos = reader["apellidos"].ToString();
                            constancia.nombres = reader["nombres"].ToString();
                            constancias.Add(constancia);
                        }
                    }
                }
            }
            return constancias;
        }

        public List<GetMant41_NumeroLicenciaConducir> GetMant41_NumeroLicenciaConducir(string estado = null)
        {
            List<GetMant41_NumeroLicenciaConducir> lincecias = new List<GetMant41_NumeroLicenciaConducir>();
            GetMant41_NumeroLicenciaConducir licencia;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 41;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = estado;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            licencia = new GetMant41_NumeroLicenciaConducir();
                            licencia.idNumeroLicenciaConducir = Convert.ToInt32(reader["idNumeroLicenciaConducir"].ToString());
                            licencia.numeroLicenciaConducir = reader["numeroLicenciaConducir"].ToString();
                            licencia.estado = reader["estado"].ToString();
                            licencia.usuarioReg = reader["usuarioReg"].ToString();
                            licencia.apellidos = reader["apellidos"].ToString();
                            licencia.nombres = reader["nombres"].ToString();

                            licencia.numDocConductor = reader["numDocConductor"].ToString();
                            licencia.codTipoDocConductor = reader["codTipoDocConductor"].ToString();


                            lincecias.Add(licencia);
                        }
                    }
                }
            }
            return lincecias;
        }

        public List<GetMant42_CatalogoNubeFact> GetMant42_CatalogoNubeFact(int inicio,int final,string filtro)
        {
            List<GetMant42_CatalogoNubeFact> datalista = new List<GetMant42_CatalogoNubeFact>();
            GetMant42_CatalogoNubeFact data;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 42;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = inicio;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = final;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar).Value = filtro;



                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            data = new GetMant42_CatalogoNubeFact();

                            data.total = Convert.ToInt32(reader["total"].ToString());


                            data.codigoInterno = reader["codigoInterno"].ToString();
                            data.idCategoria = Convert.ToInt32(reader["idCategoria"].ToString());
                            data.codUm = reader["codUm"].ToString();
                            data.codMoneda = reader["codMoneda"].ToString();
                            data.descripcionCatalogo = reader["descripcionCatalogo"].ToString();
                            data.ventaValorUnitarioSinIgv = Convert.ToDecimal(reader["ventaValorUnitarioSinIgv"].ToString());
                            data.ventaPrecioUnitarioIgv = Convert.ToDecimal(reader["ventaPrecioUnitarioIgv"].ToString());
                            data.compraValorUnitarioSinIgv = Convert.ToDecimal(reader["compraValorUnitarioSinIgv"].ToString());
                            data.compraPrecioUnitarioIgv = Convert.ToDecimal(reader["compraPrecioUnitarioIgv"].ToString());
                            data.destacado = reader["destacado"].ToString();
                            data.tipoAfectacionIgv = reader["tipoAfectacionIgv"].ToString();
                            data.codProductoSunat = reader["codProductoSunat"].ToString();
                            data.stockActualDisponible = Convert.ToDecimal(reader["stockActualDisponible"].ToString());



                            datalista.Add(data);
                        }
                    }
                }
            }
            return datalista;
        }

        public List<GetMant43_Categorias> GetMant43_Categorias()
        {
            List<GetMant43_Categorias> datalista = new List<GetMant43_Categorias>();
            GetMant43_Categorias data;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 43;
                    //sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = estado;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            data = new GetMant43_Categorias();

                            data.idCategoria = Convert.ToInt32(reader["idCategoria"].ToString());
                            data.descripcionCategoria = reader["descripcionCategoria"].ToString();
                            //data.estado = reader["codMoneda"].ToString();
                            datalista.Add(data);
                        }
                    }
                }
            }
            return datalista;
        }


        public Response SetNumeroLicenciaConducir(SetNumeroLicenciaConducirParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetNumeroLicenciaConducir";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idNumeroLicenciaConducir", SqlDbType.Int).Value = parametros.idNumeroLicenciaConducir;
                    sqlCommand.Parameters.Add("@numeroLicenciaConducir", SqlDbType.VarChar,255).Value = parametros.numeroLicenciaConducir;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar,40).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.VarChar).Value = parametros.estado;

                    sqlCommand.Parameters.Add("@numdocconductor", SqlDbType.VarChar).Value = parametros.numDocConductor;
                    sqlCommand.Parameters.Add("@tipdocconductor", SqlDbType.VarChar).Value = parametros.codTipoDocConductor;
                    

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


        public Response SetConstanciaInscripciones(SetConstanciaInscripcionParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetConstanciaInscripciones";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idConstanciaInscripcion", SqlDbType.Int).Value = parametros.idConstanciaInscripcion;
                    sqlCommand.Parameters.Add("@constanciaInscripcion", SqlDbType.VarChar, 255).Value = parametros.constanciaInscripcion;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 40).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.VarChar).Value = parametros.estado;

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


        public Response SetCatalogoNubeFact(SetCalagoNumbeFactParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetCatalogoNubeFact";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@codigoInterno", SqlDbType.VarChar,500).Value = parametros.codigoInterno;
                    sqlCommand.Parameters.Add("@idCategoria", SqlDbType.Int).Value = parametros.idCategoria;
                    sqlCommand.Parameters.Add("@codUm", SqlDbType.VarChar, 3).Value = parametros.codUm;
                    sqlCommand.Parameters.Add("@codMoneda", SqlDbType.VarChar, 1).Value = parametros.codMoneda;
                    sqlCommand.Parameters.Add("@descripcionCatalogo", SqlDbType.VarChar,2000).Value = parametros.descripcionCatalogo;
                    sqlCommand.Parameters.Add("@ventaValorUnitarioSinIgv", SqlDbType.Decimal).Value = parametros.ventaValorUnitarioSinIgv;
                    sqlCommand.Parameters.Add("@ventaPrecioUnitarioIgv", SqlDbType.Decimal).Value = parametros.ventaPrecioUnitarioIgv;
                    sqlCommand.Parameters.Add("@compraValorUnitarioSinIgv", SqlDbType.Decimal).Value = parametros.compraValorUnitarioSinIgv;
                    sqlCommand.Parameters.Add("@compraPrecioUnitarioIgv", SqlDbType.Decimal).Value = parametros.compraPrecioUnitarioIgv;
                    sqlCommand.Parameters.Add("@destacado", SqlDbType.VarChar,2).Value = parametros.destacado;
                    sqlCommand.Parameters.Add("@tipoAfectacionIgv", SqlDbType.VarChar,10).Value = parametros.tipoAfectacionIgv;
                    sqlCommand.Parameters.Add("@codProductoSunat", SqlDbType.VarChar,255).Value = parametros.codProductoSunat;
                    sqlCommand.Parameters.Add("@stockActualDisponible", SqlDbType.Decimal).Value = parametros.stockActualDisponible;


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


        public Response setEstilosMantenimiento(SetEstilosParam param)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", param.opcion, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idusuarioCrea", param.idUsuarioCrea, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@codigoEstilo", param.codigoEstilo, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@estilo", param.estilo, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@estado", param.estado, DbType.Boolean, ParameterDirection.Input);
                sp_parametros.Add("@idestilo", param.idEstilo, DbType.Int32, ParameterDirection.Input);


                return sqlConnection.QuerySingleOrDefault<Response>("uspSetEstilos",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        public Response setPedidosMantenimiento(SetPedidosParam param)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", param.opcion, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idpedido", param.idpedido, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idestilo", param.idestilo, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idprograma", param.idprograma, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idusuariocrea", param.idusuariocrea, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@pedido", param.pedido, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@estado", param.estado, DbType.Boolean, ParameterDirection.Input);



                return sqlConnection.QuerySingleOrDefault<Response>("uspSetPedidos",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        public Response setPedidosColorMantenimiento(SetPedidosColorParam param)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", param.opcion, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idpedidocolor", param.idpedidocolor, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idpedido", param.idpedido, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@codcolor", param.codcolor, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@estado", param.estado, DbType.Boolean, ParameterDirection.Input);
                sp_parametros.Add("@idusuariocrea", param.idusuariocrea, DbType.Int32, ParameterDirection.Input);



                return sqlConnection.QuerySingleOrDefault<Response>("uspSetPedidosColor",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GetMant56_PedidosColor> getPedidosColorFiltro(string filtro)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 57, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", filtro, DbType.String, ParameterDirection.Input);


                return sqlConnection.Query<GetMant56_PedidosColor>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        public List<SetAreasAlmacen> GetListarAreasAlmacen(string filtro)
        {
            List<SetAreasAlmacen> items = new List<SetAreasAlmacen>();
            SetAreasAlmacen ite;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 58;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtro;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ite = new SetAreasAlmacen();

                            ite.codigo = reader["codigo"].ToString();
                            ite.descripcion = reader["descripcion"].ToString();
                            ite.resumida = reader["resumida"].ToString();
                            ite.estado = Convert.ToBoolean(reader["estado"]);
                            items.Add(ite);
                        }
                    }
                }
            }
            return items;
        }

        public Response SetAreasAlmacen(SetAreasAlmacen parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetAreasAlmacen";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = parametros.codigo;
                    sqlCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = parametros.descripcion;
                    sqlCommand.Parameters.Add("@tResumido", SqlDbType.VarChar).Value = parametros.resumida;
                    sqlCommand.Parameters.Add("@lActivo",SqlDbType.Bit).Value = parametros.estado;

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

        public DataTable SetDatatable(int opcion, string filtroTxt1, string filtroTxt2, int filtroInt1, int filtroInt2,decimal filtroDecimal1)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtroTxt1.ToString();
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = filtroTxt2.ToString();
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = filtroInt1;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = filtroInt2;
                    sqlCommand.Parameters.Add("@filtroDecimal", SqlDbType.Decimal).Value = filtroDecimal1;


                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }
            }
        }
        public DataTable SetDatatableReporte(int opcion, string var1, string var2, string var3, string var4, string var5, string var6)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"usp_getReportesVarios";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                    sqlCommand.Parameters.Add("@var1", SqlDbType.VarChar, 200).Value = var1.ToString();
                    sqlCommand.Parameters.Add("@var2", SqlDbType.VarChar, 200).Value = var2.ToString();
                    sqlCommand.Parameters.Add("@var3", SqlDbType.VarChar, 200).Value = var3.ToString();
                    sqlCommand.Parameters.Add("@var4", SqlDbType.VarChar, 200).Value = var4.ToString();
                    sqlCommand.Parameters.Add("@var5", SqlDbType.Date).Value = Convert.ToDateTime(var5);
                    sqlCommand.Parameters.Add("@var6", SqlDbType.Date).Value = Convert.ToDateTime(var6);
                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }
            }
        }


    }
}
