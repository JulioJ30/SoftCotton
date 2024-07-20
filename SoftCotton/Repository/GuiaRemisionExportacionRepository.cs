using SoftCotton.Database;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Reports.RemittanceGuide.ExportGuide;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SoftCotton.Repository
{
    public class GuiaRemisionExportacionRepository
    {
        public GetGR2_CabeceraXCod Get2_CabeceraXCod(int idEmpresa, string serie, string numero, string ruc)
        {
            GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 2, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", serie, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt2", numero, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt3", ruc, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt1", idEmpresa, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt2", 0, DbType.Int32, ParameterDirection.Input);

                return sqlConnection.QuerySingleOrDefault<GetGR2_CabeceraXCod>("uspGetGuiaRemisionExportacion",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<GetGR3_DetalleXCod> Get3_DetalleXCod(int idEmpresa, string serie, string numero, string ruc)
        {
            List<GetGR3_DetalleXCod> grDets = new List<GetGR3_DetalleXCod>();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "uspGetGuiaRemisionExportacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
                sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = numero;
                sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = ruc;
                sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetGR3_DetalleXCod grDet = new GetGR3_DetalleXCod();
                        grDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                        grDet.serie = reader["serie"].ToString();
                        grDet.numero = reader["numero"].ToString();
                        grDet.ruc = reader["ruc"].ToString();
                        grDet.secuencia = Convert.ToInt32(reader["secuencia"]);
                        grDet.codigoProducto = reader["codProducto"].ToString();
                        grDet.descripcion = reader["descripcion"].ToString();
                        grDet.cantidadIngresada = Convert.ToDouble(reader["cantidadIngresada"]);
                        grDet.codUM = reader["codUM"].ToString();
                        grDet.codUmDam = reader["codUmDam"].ToString();
                        grDet.descripcionUM = reader["descripcionUM"].ToString();
                        grDets.Add(grDet);
                    }
                }
            }
            return grDets;
        }

        public DataTable Get8_ReporteExportacion(string filtro1, string filtro2, string filtro3, string filtro4)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = ConnectionBD.GetConnection();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "uspGetMantenimientoRpte";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
            sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtro1;
            sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = filtro2;
            sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = filtro3;
            sqlCommand.Parameters.Add("@filtroTxt4", SqlDbType.VarChar, 100).Value = filtro4;
            sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
            sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;
            sqlCommand.Parameters.Add("@filtroInt3", SqlDbType.Int).Value = 0;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public GuiaRemisionExportacionCabModel Get7_GRExportacionCab(int idEmpresa, string serie, string numero, string ruc)
        {
            GuiaRemisionExportacionCabModel grCab = new GuiaRemisionExportacionCabModel();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "uspGetGuiaRemisionExportacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;
                sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
                sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = numero;
                sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = ruc;
                sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    grCab = new GuiaRemisionExportacionCabModel();
                    grCab.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                    grCab.serie = reader["serie"].ToString();
                    grCab.numero = reader["numero"].ToString();
                    grCab.ruc = reader["ruc"].ToString();
                    grCab.fechaEmision = reader["fechaEmision"].ToString();
                    grCab.puntoPartida = reader["puntoPartida"].ToString();
                    grCab.puntoLlegada = reader["puntoLlegada"].ToString();
                    grCab.fechaInicioTraslado = reader["fechaInicioTraslado"].ToString();
                    grCab.destCodigoPC = reader["destCodigoPC"].ToString();
                    grCab.destRS = reader["destRS"].ToString();
                    grCab.transCodigoPC = reader["transCodigoPC"].ToString();
                    grCab.transRS = reader["transRS"].ToString();
                    grCab.transMarca = reader["transMarca"].ToString();
                    grCab.transNumPlaca = reader["transNumPlaca"].ToString();
                    grCab.transNumConstInscr = reader["transNumConstInscr"].ToString();
                    grCab.transNumLicConducir = reader["transNumLicConducir"].ToString();
                    grCab.idConstanciaInscripcion = Convert.ToInt32(reader["idConstanciaInscripcion"]);
                    grCab.constanciaInscripcion = reader["constanciaInscripcion"].ToString();
                    grCab.idNumeroLicenciaConducir = Convert.ToInt32(reader["idNumeroLicenciaConducir"]);
                    grCab.numeroLicenciaConducir = reader["numeroLicenciaConducir"].ToString();
                    grCab.usuarioReg = reader["usuarioReg"].ToString();
                    grCab.idMotivoTraslado = Convert.ToInt32(reader["idMotivoTraslado"]);
                    grCab.numero_contenedor = reader["numero_contenedor"].ToString();
                    grCab.precinto_aduana = reader["precinto_aduana"].ToString();
                    grCab.precinto_linea = reader["precinto_linea"].ToString();
                    grCab.precinto = reader["precinto"].ToString();
                    grCab.total = Convert.ToDecimal(reader["total"]);
                    grCab.gross_weight = Convert.ToDecimal(reader["gross_weight"]);
                    grCab.net_weight = Convert.ToDecimal(reader["net_weight"]);
                    grCab.total_um = reader["total_um"].ToString();
                    grCab.gross_weight_um = reader["gross_weight_um"].ToString();
                    grCab.net_weight_um = reader["net_weight_um"].ToString();
                }
            }
            return grCab;
        }

        public List<GuiaRemisionExportacionDetModel> Get8_GRExportacionDet(int idEmpresa, string serie, string numero, string ruc)
        {
            List<GuiaRemisionExportacionDetModel> grDets = new List<GuiaRemisionExportacionDetModel>();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "uspGetGuiaRemisionExportacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 8;
                sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
                sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = numero;
                sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = ruc;
                sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GuiaRemisionExportacionDetModel grDet = new GuiaRemisionExportacionDetModel();
                        grDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                        grDet.serie = reader["serie"].ToString();
                        grDet.numero = reader["numero"].ToString();
                        grDet.ruc = reader["ruc"].ToString();
                        grDet.secuencia = Convert.ToInt32(reader["secuencia"]);
                        grDet.codProducto = reader["codProducto"].ToString();
                        grDet.descripcion = reader["descripcion"].ToString();
                        grDet.cantidadIngresada = Convert.ToDecimal(reader["cantidadIngresada"]);
                        grDet.codUM = reader["codUM"].ToString();
                        grDets.Add(grDet);
                    }
                }
            }
            return grDets;
        }

        public Response SetGRCabeceraExportacion(SetGRCabExportacionParam parametros)
        {
            Response response = new Response();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "uspSetGRCabeceraExportacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                sqlCommand.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = parametros.serie;
                sqlCommand.Parameters.Add("@numero", SqlDbType.VarChar, 10).Value = parametros.numero;
                sqlCommand.Parameters.Add("@ruc", SqlDbType.VarChar, 20).Value = parametros.ruc;
                sqlCommand.Parameters.Add("@fechaEmision", SqlDbType.VarChar, 8).Value = parametros.fechaEmision;
                sqlCommand.Parameters.Add("@puntoPartida", SqlDbType.VarChar, 250).Value = parametros.puntoPartida;
                sqlCommand.Parameters.Add("@puntoLlegada", SqlDbType.VarChar, 250).Value = parametros.puntoLlegada;
                sqlCommand.Parameters.Add("@fechaInicioTraslado", SqlDbType.VarChar, 8).Value = parametros.fechaInicioTraslado;
                sqlCommand.Parameters.Add("@destCodigoPC", SqlDbType.VarChar, 15).Value = parametros.destCodigoPC;
                sqlCommand.Parameters.Add("@transCodigoPC", SqlDbType.VarChar, 15).Value = parametros.transCodigoPC;
                sqlCommand.Parameters.Add("@transMarca", SqlDbType.VarChar, 100).Value = parametros.transMarca;
                sqlCommand.Parameters.Add("@transNumPlaca", SqlDbType.VarChar, 100).Value = parametros.transNumPlaca;
                sqlCommand.Parameters.Add("@transNumConstInscr", SqlDbType.VarChar, 100).Value = parametros.transNumConstInscr;
                sqlCommand.Parameters.Add("@transNumLicConducir", SqlDbType.VarChar, 100).Value = parametros.transNumLicConducir;
                sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 30).Value = parametros.usuarioReg;
                sqlCommand.Parameters.Add("@idnumerolicenciaconducir", SqlDbType.Int).Value = parametros.idNumeroLicenciaConducir;
                sqlCommand.Parameters.Add("@idconstanciainscripcion", SqlDbType.Int).Value = parametros.idConstanciaInscripcion;
                sqlCommand.Parameters.Add("@idMotivoTraslado", SqlDbType.Int).Value = parametros.idMotivoTraslado;
                sqlCommand.Parameters.Add("@numero_contenedor", SqlDbType.VarChar, 50).Value = parametros.numero_contenedor;
                sqlCommand.Parameters.Add("@precinto_aduana", SqlDbType.VarChar, 50).Value = parametros.precinto_aduana;
                sqlCommand.Parameters.Add("@precinto_linea", SqlDbType.VarChar, 50).Value = parametros.precinto_linea;
                sqlCommand.Parameters.Add("@precinto", SqlDbType.VarChar, 250).Value = parametros.precinto;
                sqlCommand.Parameters.Add("@total", SqlDbType.Decimal).Value = parametros.total;
                sqlCommand.Parameters.Add("@gross_weight", SqlDbType.Decimal).Value = parametros.gross_weight;
                sqlCommand.Parameters.Add("@net_weight", SqlDbType.Decimal).Value = parametros.net_weight;
                sqlCommand.Parameters.Add("@total_um", SqlDbType.VarChar, 3).Value = parametros.total_um;
                sqlCommand.Parameters.Add("@gross_weight_um", SqlDbType.VarChar, 3).Value = parametros.gross_weight_um;
                sqlCommand.Parameters.Add("@net_weight_um", SqlDbType.VarChar, 3).Value = parametros.net_weight_um;

                sqlCommand.Parameters.Add("@fechavencimiento", SqlDbType.VarChar, 8).Value = parametros.fechaVencimiento;
                sqlCommand.Parameters.Add("@observaciones", SqlDbType.VarChar, 500).Value = parametros.observaciones;

                sqlCommand.Parameters.Add("@enviadosunat", SqlDbType.Bit).Value = parametros.enviadoSunat;
                sqlCommand.Parameters.Add("@respuestasunat", SqlDbType.VarChar, 500).Value = parametros.respuestaSunat;
                sqlCommand.Parameters.Add("@otrosmotivotraslado", SqlDbType.VarChar, 500).Value = parametros.otrosMotivoTraslado;
                sqlCommand.Parameters.Add("@damds", SqlDbType.VarChar, 1000).Value = parametros.DamDs;




                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    response.idResponse = Convert.ToInt32(reader["idResponse"]);
                    response.messageResponse = reader["messageResponse"].ToString();
                    response.typeMessage = reader["typeMessage"].ToString();
                }
            }
            return response;
        }

        public Response SetGRDetalleExportacion(SetGRDetExportacionParam parametros)
        {
            Response response = new Response();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "uspSetGRDetalleExportacion";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                sqlCommand.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = parametros.serie;
                sqlCommand.Parameters.Add("@numero", SqlDbType.VarChar, 10).Value = parametros.numero;
                sqlCommand.Parameters.Add("@ruc", SqlDbType.VarChar, 20).Value = parametros.ruc;
                sqlCommand.Parameters.Add("@secuencia", SqlDbType.Int).Value = parametros.secuencia;
                sqlCommand.Parameters.Add("@cantidadIngresada", SqlDbType.Decimal).Value = parametros.cantidadIngresada;
                sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 500).Value = parametros.descripcion;
                sqlCommand.Parameters.Add("@codUM", SqlDbType.Char, 3).Value = parametros.codUM;
                sqlCommand.Parameters.Add("@codigoproducto", SqlDbType.VarChar, 50).Value = parametros.codProducto;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    response.idResponse = Convert.ToInt32(reader["idResponse"]);
                    response.messageResponse = reader["messageResponse"].ToString();
                    response.typeMessage = reader["typeMessage"].ToString();
                }
            }
            return response;
        }
    }
}
