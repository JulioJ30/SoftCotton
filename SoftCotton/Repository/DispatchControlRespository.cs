using SoftCotton.Database;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SoftCotton.Model.DispatchControl;


namespace SoftCotton.Repository
{
    public class DispatchControlRespository
    {
        // AGREGADOS
        public IEnumerable<controlDespachoDetTallas> GetDetalleTallasOs(int idOs)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 50, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt1", idOs, DbType.Int32, ParameterDirection.Input);

                return sqlConnection.Query<controlDespachoDetTallas>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        // BUSCAR CONTROL DE DESPACHO
        public IEnumerable<busquedaControlDespacho> GetControlDespachos(int idProceso,string pedido)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 52, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt1", idProceso, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", pedido, DbType.String, ParameterDirection.Input);


                return sqlConnection.Query<busquedaControlDespacho>("uspGetMantenimiento",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }

        // REGISTRAR
        public parametrosRegistros SetControlDespacho(int opcion,parametrosRegistros parametro)
        {
            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", opcion, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idProcesoControl", parametro.idProcesoControl, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idProcesoControlDespachoCab", parametro.idProcesoControlDespachoCab, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@idPedidoColor", parametro.idPedidoColor, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@cliente", parametro.cliente, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@idProveedor", parametro.idProveedor, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@usuario", parametro.usuario, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@idProcesoControlDespachoDet", parametro.idProcesoControlDespachoDet, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@numeroCorte", parametro.numeroCorte, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@fechaGuia", parametro.fechaGuia == "" ? null : parametro.fechaGuia, DbType.Date, ParameterDirection.Input);
                sp_parametros.Add("@guia", parametro.guia, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@fechaFactura", parametro.fechaFactura == "" ? null : parametro.fechaFactura, DbType.Date, ParameterDirection.Input);
                sp_parametros.Add("@factura", parametro.factura, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@ordenServicio", parametro.ordenServicio, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@destinatario", parametro.destinario, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@idProcesoControlDespachoDetTalla", parametro.idProcesoControlDespachoDetTalla, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@codTalla", parametro.codTalla, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@cantidad", parametro.cantidad, DbType.Int32, ParameterDirection.Input);


                return sqlConnection.QuerySingleOrDefault<parametrosRegistros>("uspSetControlDespacho",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }


        // GET DETALLE CONTROL DESPACHO DETALLE
        public DataTable GetControlDespachoDetalleTalla(int? idControlDespachoCabecera)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 51;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = idControlDespachoCabecera.ToString();
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idControlDespachoCabecera;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }


            }
        }

    }
}
