using SoftCotton.Database;
using SoftCotton.Model.Invoices;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class FacturaRepository
    {
        // ### GET ###
        public List<GetFact1_Detalle> Get1_Detalle(int idEmpresa, string serie, int numero, string ruc, string tipoComprobante, string serienota = "0", int numeronota = 0)
        {
            List<GetFact1_Detalle> dets = new List<GetFact1_Detalle>();
            GetFact1_Detalle det;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetFacturas";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = ruc;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = numero;
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = tipoComprobante;

                    sqlCommand.Parameters.Add("@filtroTxt4", SqlDbType.VarChar, 100).Value = serienota;
                    sqlCommand.Parameters.Add("@filtroInt3", SqlDbType.Int).Value = numeronota;


                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            det = new GetFact1_Detalle();

                            det.idEmpresa = Convert.ToInt32(reader["idEmpresa"].ToString());
                            det.serie = reader["serie"].ToString();
                            det.numero = Convert.ToInt32(reader["numero"].ToString());
                            det.secuencia = Convert.ToInt32(reader["secuencia"].ToString());

                            det.grIdEmpresa = Convert.ToInt32(reader["grIdEmpresa"].ToString());
                            det.grSerie = reader["grSerie"].ToString();
                            det.grNumero = reader["grNumero"].ToString();
                            det.grSecuencia = Convert.ToInt32(reader["grSecuencia"].ToString());
                            det.grTipoOrden = reader["grTipoOrden"].ToString();
                            
                            det.codigo = reader["codigo"].ToString();
                            det.descripcion = reader["descripcion"].ToString();
                            det.codUM = reader["codUM"].ToString();

                            det.cantidad = Convert.ToDecimal(reader["cantidad"]);
                            det.igv = Convert.ToDecimal(reader["igv"]);
                            det.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);

                            det.codigoPC = reader["codigoPC"].ToString();

                            // AGREGADO
                            //det.cantidadNotaCredito = Convert.ToDecimal(reader["cantidadNotaCredito"].ToString());
                            det.serieNotaCredito = reader["serieNotaCredito"].ToString();
                            det.numeroNotaCredito = reader["numeroNotaCredito"].ToString();
                            det.codTipoCpte = reader["codTipoCpte"].ToString();


                            dets.Add(det);
                        }
                    }
                }
            }
            return dets;
        }
        public List<GetFact2_TipoMoneda> Get2_TipoMoneda()
        {
            List<GetFact2_TipoMoneda> monedas = new List<GetFact2_TipoMoneda>();
            GetFact2_TipoMoneda moneda;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetFacturas";
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
                            moneda = new GetFact2_TipoMoneda();

                            moneda.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"].ToString());
                            moneda.moneda = reader["moneda"].ToString();

                            monedas.Add(moneda);
                        }
                    }
                }
            }
            return monedas;
        }
        public GetFact3_Cabecera Get3_Cabecera(int idEmpresa, string serie, int numero, string ruc,string tipoComprobante,string serienota = "0",int numeronota = 0)
        {
            GetFact3_Cabecera cabecera = new GetFact3_Cabecera();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetFacturas";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = ruc;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = numero;
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = tipoComprobante;

                    sqlCommand.Parameters.Add("@filtroTxt4", SqlDbType.VarChar, 100).Value = serienota;
                    sqlCommand.Parameters.Add("@filtroInt3", SqlDbType.Int).Value = numeronota;




                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            cabecera = new GetFact3_Cabecera();

                            cabecera.idEmpresa = Convert.ToInt32(reader["idEmpresa"].ToString());
                            cabecera.serie = reader["serie"].ToString();
                            cabecera.numero = Convert.ToInt32(reader["numero"].ToString());
                            cabecera.fechaEmision = reader["fechaEmision"].ToString();
                            cabecera.codigoPC = reader["codigoPC"].ToString();
                            cabecera.razonSocial = reader["razonSocial"].ToString();
                            cabecera.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"].ToString());

                            string tipodecambio = reader["tipoCambio"].ToString().Trim();
                            string anio = reader["anio"].ToString().Trim();
                            string mes = reader["mes"].ToString().Trim();

                            //string raaa = "";
                            cabecera.tipoCambio = Convert.ToDecimal(tipodecambio != "" ? tipodecambio : "0" );
                            cabecera.anio = Convert.ToInt32(anio != "" ? anio : "0");
                            cabecera.mes = Convert.ToInt32(mes != "" ? mes : "0");
                            //cabecera.contabilizado = reader["idTipoMoneda"].ToString();


                            // AGREGADO
                            cabecera.codTipoCpte = reader["codTipoCpte"].ToString();
                            cabecera.serieNotaCredito    = reader["serieNotaCredito"].ToString();
                            cabecera.observacionNotaCredito = reader["observacionNotaCredito"].ToString();
                            cabecera.numeroNotaCredito = reader["numeroNotaCredito"].ToString();
                            cabecera.OP = reader["Op"].ToString();



                        }
                    }
                }
            }
            return cabecera;
        }


        // ### SET ###
        public Response SetFacCab(SetFacCabParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetFacCab";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;

                    sqlCommand.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = parametros.serie;
                    sqlCommand.Parameters.Add("@numero", SqlDbType.Int).Value = parametros.numero;
                    sqlCommand.Parameters.Add("@fechaEmision", SqlDbType.VarChar, 8).Value = parametros.fechaEmision;
                    sqlCommand.Parameters.Add("@codigoPC", SqlDbType.VarChar, 15).Value = parametros.codigoPC;
                    sqlCommand.Parameters.Add("@idTipoMoneda", SqlDbType.Int).Value = parametros.idTipoMoneda;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 30).Value = parametros.usuarioReg;

                    sqlCommand.Parameters.Add("@tipoCambio", SqlDbType.Decimal).Value = parametros.tipoCambio;
                    sqlCommand.Parameters.Add("@mes", SqlDbType.Int).Value = parametros.mes;
                    sqlCommand.Parameters.Add("@anio", SqlDbType.Int).Value = parametros.anio;
                    //sqlCommand.Parameters.Add("@contabilizado", SqlDbType.VarChar, 100).Value = parametros.contabilizado;


                    sqlCommand.Parameters.Add("@codTipoCpte", SqlDbType.VarChar, 2).Value = parametros.codTipoCpte;
                    sqlCommand.Parameters.Add("@serieNotaCredito", SqlDbType.VarChar, 4).Value = parametros.serieNotaCredito;
                    sqlCommand.Parameters.Add("@numeroNotaCredito", SqlDbType.Int).Value = parametros.numeroNotaCredito;
                    sqlCommand.Parameters.Add("@observacionNotaCredito", SqlDbType.VarChar, 255).Value = parametros.observacionNotaCredito;
                    sqlCommand.Parameters.Add("@OP", SqlDbType.VarChar, 1000).Value = parametros.OP;




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
        public Response SetFacDet(SetFacDetParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetFacDet";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = parametros.serie;
                    sqlCommand.Parameters.Add("@numero", SqlDbType.Int).Value = parametros.numero;
                    sqlCommand.Parameters.Add("@secuencia", SqlDbType.Int).Value = parametros.secuencia;

                    sqlCommand.Parameters.Add("@grIdEmpresa", SqlDbType.Int).Value = parametros.grIdEmpresa;
                    sqlCommand.Parameters.Add("@grSerie", SqlDbType.VarChar, 50).Value = parametros.grSerie;
                    sqlCommand.Parameters.Add("@grNumero", SqlDbType.VarChar, 50).Value = parametros.grNumero;
                    sqlCommand.Parameters.Add("@grSecuencia", SqlDbType.Int).Value = parametros.grSecuencia;

                    sqlCommand.Parameters.Add("@codigo", SqlDbType.VarChar, 20).Value = parametros.codigo;
                    sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = parametros.descripcion;
                    sqlCommand.Parameters.Add("@codUM", SqlDbType.VarChar, 3).Value = parametros.codUM;
                    sqlCommand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = parametros.cantidad;
                    sqlCommand.Parameters.Add("@igv", SqlDbType.Decimal).Value = parametros.igv;
                    sqlCommand.Parameters.Add("@precioUnitario", SqlDbType.Decimal).Value = parametros.precioUnitario;

                    sqlCommand.Parameters.Add("@codigoPC", SqlDbType.VarChar, 15).Value = parametros.codigoPC;

                    sqlCommand.Parameters.Add("@grTipoOrden", SqlDbType.VarChar, 15).Value = parametros.grTipoOrden;

                    // AGREGADO
                    //sqlCommand.Parameters.Add("@cantidadNotaCredito", SqlDbType.Decimal).Value = parametros.cantidadNotaCredito;
                    sqlCommand.Parameters.Add("@serieNotaCredito", SqlDbType.VarChar, 4).Value = parametros.serieNotaCredito;
                    sqlCommand.Parameters.Add("@numeroNotaCredito", SqlDbType.Int).Value = string.IsNullOrEmpty(parametros.numeroNotaCredito) ? 0 : Convert.ToInt32(parametros.numeroNotaCredito);
                    sqlCommand.Parameters.Add("@codTipoCpte", SqlDbType.VarChar, 2).Value = parametros.codTipoCpte;



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
