using SoftCotton.Database;
using SoftCotton.Model.Maintenance;
using SoftCotton.Model.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class CompartidoRepository
    {

        public List<GetShared1_ProvClientes> Get1_ProvClientes(string filtroBusqueda)
        {
            List<GetShared1_ProvClientes> provClientes = new List<GetShared1_ProvClientes>();
            GetShared1_ProvClientes provCliente;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetCompartido";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtroBusqueda;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            provCliente = new GetShared1_ProvClientes();
                            provCliente.codigo = reader["codigo"].ToString();
                            provCliente.razonSocial = reader["razonSocial"].ToString();
                            provCliente.direccion = reader["direccion"].ToString();
                            provClientes.Add(provCliente);
                        }
                    }
                }
            }
            return provClientes;
        }

        public List<GetShared2_BuscarProdServ> Get2_BuscarProdServ(string codNivel, string codGrupo)
        {
            List<GetShared2_BuscarProdServ> prodServs = new List<GetShared2_BuscarProdServ>();
            GetShared2_BuscarProdServ prodServ;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetCompartido";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
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
                            prodServ = new GetShared2_BuscarProdServ();

                            prodServ.codProducto = reader["codProducto"].ToString();
                            prodServ.producto = reader["producto"].ToString();

                            prodServ.codNivel = reader["codNivel"].ToString();
                            prodServ.nivel = reader["nivel"].ToString();
                            prodServ.codGrupo = reader["codGrupo"].ToString();
                            prodServ.grupo = reader["grupo"].ToString();
                            prodServ.codTalla = reader["codTalla"].ToString();
                            prodServ.talla = reader["talla"].ToString();
                            prodServ.codColor = reader["codColor"].ToString();
                            prodServ.color = reader["color"].ToString();
                            prodServ.codUM = reader["codUM"].ToString();

                            prodServs.Add(prodServ);
                        }
                    }
                }
            }
            return prodServs;
        }
        
        public List<GetShared3_BuscarCuenta> Get3_BuscarCuenta(string cuentaFiltro)
        {
            List<GetShared3_BuscarCuenta> cuentas = new List<GetShared3_BuscarCuenta>();
            GetShared3_BuscarCuenta cuenta;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetCompartido";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = cuentaFiltro;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cuenta = new GetShared3_BuscarCuenta();

                            cuenta.codCuenta = reader["codCuenta"].ToString();
                            cuenta.cuenta = reader["cuenta"].ToString();


                            cuentas.Add(cuenta);
                        }
                    }
                }
            }
            return cuentas;
        }

        public List<GetShared4_BuscarGR> Get4_BuscarGR(int idEmpresa, string serie, string numero)
        {
            List<GetShared4_BuscarGR> grs = new List<GetShared4_BuscarGR>();
            GetShared4_BuscarGR gr;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetCompartido";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = numero;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            gr = new GetShared4_BuscarGR();

                            gr.tipo = reader["tipo"].ToString();

                            gr.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            gr.serie = reader["serie"].ToString();
                            gr.numero = reader["numero"].ToString();

                            gr.fechaEmision = reader["fechaEmision"].ToString();
                            gr.destCodigoPC = reader["destCodigoPC"].ToString();
                            gr.razonSocial = reader["razonSocial"].ToString();

                            gr.secuencia = Convert.ToInt32(reader["secuencia"].ToString());
                            gr.idDet = Convert.ToInt32(reader["idDet"].ToString());
                            gr.idSecuenciaDet = Convert.ToInt32(reader["idSecuenciaDet"].ToString());

                            gr.codNivel = reader["codNivel"].ToString();
                            gr.codGrupo = reader["codGrupo"].ToString();
                            gr.codTalla = reader["codTalla"].ToString();
                            gr.codColor = reader["codColor"].ToString();

                            gr.codProducto = reader["codProducto"].ToString();
                            gr.producto = reader["producto"].ToString();

                            gr.codUM = reader["codUM"].ToString();
                            gr.tipoMovimiento = reader["tipoMovimiento"].ToString();
                            gr.cantidadIngresada = Convert.ToDecimal(reader["cantidadIngresada"]);
                            gr.pesoIngresado = Convert.ToDecimal(reader["pesoIngresado"]);

                            grs.Add(gr);
                        }
                    }
                }
            }
            return grs;
        }

    }
}
