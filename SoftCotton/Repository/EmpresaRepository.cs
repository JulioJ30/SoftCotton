using SoftCotton.Database;
using SoftCotton.Model.Enterprise;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class EmpresaRepository
    {
        public List<Get1_Empresas> Get1_Empresas()
        {
            List<Get1_Empresas> empresas = new List<Get1_Empresas>();
            Get1_Empresas empresa;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpresa";
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
                            empresa = new Get1_Empresas();
                            empresa.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            empresa.ruc = reader["ruc"].ToString();
                            empresa.rs = reader["rs"].ToString();
                            empresa.direccion = reader["direccion"].ToString();
                            empresa.Activar_Transa_Kardex = Convert.ToBoolean(reader["Activar_Transa_Kardex"].ToString());
                            empresa.Validar_stock_exportacion = Convert.ToBoolean(reader["Validar_stock_exportacion"].ToString());
                            empresas.Add(empresa);
                        }
                    }
                }
            }
            return empresas;
        }

        public Get1_Empresas Get1_EmpresasConf()
        {
            Get1_Empresas empresas = new Get1_Empresas();
            Get1_Empresas empresa;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetEmpresa";
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
                            empresa = new Get1_Empresas();
                            empresa.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            empresa.ruc = reader["ruc"].ToString();
                            empresa.rs = reader["rs"].ToString();
                            empresa.direccion = reader["direccion"].ToString();
                            empresa.Activar_Transa_Kardex = Convert.ToBoolean(reader["Activar_Transa_Kardex"].ToString());
                            empresa.Validar_stock_exportacion = Convert.ToBoolean(reader["Validar_stock_exportacion"].ToString());
                            empresas = empresa;
                        }
                    }
                }
            }
            return empresas;
        }

        public string uspSetempresa(Get1_Empresas obj)
        {
            string respuesta = "";

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetempresa";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa;
                    sqlCommand.Parameters.Add("@ruc", SqlDbType.VarChar).Value = obj.ruc;
                    sqlCommand.Parameters.Add("@rs", SqlDbType.VarChar).Value = obj.rs;
                    sqlCommand.Parameters.Add("@direccion", SqlDbType.VarChar).Value = obj.direccion;
                    sqlCommand.Parameters.Add("@Activar_Transa_Kardex", SqlDbType.Bit).Value = obj.Activar_Transa_Kardex;
                    sqlCommand.Parameters.Add("@Validar_stock_exportacion", SqlDbType.Bit).Value = obj.Validar_stock_exportacion;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            respuesta = reader["codigo"].ToString();
                        }
                    }

                }
            }

            return respuesta;
        }
    }
}
