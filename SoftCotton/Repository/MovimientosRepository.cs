using SoftCotton.Database;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SoftCotton.Model.Movimientos;
using Newtonsoft.Json;
using System.Security.Cryptography;
using SoftCotton.Model.Transformacion;

namespace SoftCotton.Repository
{
    public class MovimientosRepository
    {
        // REGISTRO DE MOVIMENTOS
        public bool setRegistroMovimientosTela(MovimientosCabecera cab,List<MovimientosDetalle> det,int IdUsuario)
        {
            try
            {
                using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
                {

                    var sp_parametros = new DynamicParameters();
                    sp_parametros.Add("@IdMovimientoCabecera", cab.IdMovimientoCabecera, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@IdTipoMovimiento", cab.IdTipoMovimiento, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@FechaMovimiento", cab.FechaMovimiento, DbType.Date, ParameterDirection.Input);
                    sp_parametros.Add("@Comentario", cab.Comentario, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@IdUsuario", IdUsuario, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@Estacion", Environment.MachineName, DbType.String, ParameterDirection.Input);

                    string JsonDetalle = JsonConvert.SerializeObject(det, Formatting.Indented);
                    sp_parametros.Add("@JsonDetalle", JsonDetalle, DbType.String, ParameterDirection.Input);



                    sqlConnection.Execute("uspSetMovimientosTela",
                                                        sp_parametros,
                                                        commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }
        

        // REGISTRO DE TRANSFORMACION
        public bool setRegistroTransformacion(RegistroTransformacionEntity parametro)
        {
            try
            {
                using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
                {

                    var sp_parametros = new DynamicParameters();
                    sp_parametros.Add("@IdTransformacionCab", parametro.IdTransformacionCab, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@Serie", parametro.Serie, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@Numero", parametro.Numero, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@Proveedor", parametro.Proveedor, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@CodigoNivelOrigen", parametro.CodigoNivelOrigen, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@CodigoNivelDestino", parametro.CodigoNivelDestino, DbType.String, ParameterDirection.Input);

                    sp_parametros.Add("@IdUsuario", parametro.IdUsuario, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@IdSecuenciaDet", parametro.IdSecuenciaDet, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@CodNivel", parametro.CodNivel, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@CodGrupo", parametro.CodGrupo, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@CodTalla", parametro.CodTalla, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@CodColor", parametro.CodColor, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@Cantidad", parametro.Cantidad, DbType.Decimal, ParameterDirection.Input);
                    sp_parametros.Add("@Comentario", parametro.Comentario, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@Pedido", parametro.Pedido, DbType.String, ParameterDirection.Input);


                    sqlConnection.Execute("uspSetTransformacion",
                                                        sp_parametros,
                                                        commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool setRegistroTransformacionDetTalla(DetalleTransformacionDetTallaEntity parametro,int IdUsuario)
        {
            try
            {
                using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
                {

                    var sp_parametros = new DynamicParameters();
                    sp_parametros.Add("@IdTransformacionDet", parametro.IdTransformacionDet, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@CodTalla", parametro.CodTalla, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@Cantidad", parametro.Cantidad, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@Observacion", parametro.Observacion, DbType.String, ParameterDirection.Input);
                    sp_parametros.Add("@IdUsuario", IdUsuario, DbType.Int32, ParameterDirection.Input);
                    sp_parametros.Add("@Estacion", Environment.MachineName, DbType.String, ParameterDirection.Input);


                    sqlConnection.Execute("uspSetTransformacionDetTalla",
                                                        sp_parametros,
                                                        commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool setRegistroTransformacionDetTallaDelete(int IdTransformacionDetTalla)
        {
            try
            {
                using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
                {

                    var sp_parametros = new DynamicParameters();
                    sp_parametros.Add("@IdTransformacionDetTalla", IdTransformacionDetTalla, DbType.Int32, ParameterDirection.Input);


                    sqlConnection.Execute("uspSetTransformacionDetTallaDelete",
                                                        sp_parametros,
                                                        commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // LISTAMOS
        public IEnumerable<DetalleTransformacionDetTallaEntity> GetRegistroTransformacionDetTallaPorIdDet(int IdTransformacionDet)
        {

            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@IdTransformacionDet", IdTransformacionDet, DbType.Int32, ParameterDirection.Input);

                return sqlConnection.Query<DetalleTransformacionDetTallaEntity>("uspGetTransformacionDetTallaPorIdTransformacionDet",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }

        }
    }
}
