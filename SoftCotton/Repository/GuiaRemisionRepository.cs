using SoftCotton.Database;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;


namespace SoftCotton.Repository
{
    public class GuiaRemisionRepository
    {

        // ### GET ###
        public List<GetGR1_Motivo> Get1_Motivo()
        {
            List<GetGR1_Motivo> motivos = new List<GetGR1_Motivo>();
            GetGR1_Motivo motivo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetGuiaRemision";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            motivo = new GetGR1_Motivo();
                            motivo.idMotivo = Convert.ToInt32(reader["idMotivo"]);
                            motivo.motivo = reader["motivo"].ToString();
                            motivos.Add(motivo);
                        }
                    }
                }
            }
            return motivos;
        }
        public GetGR2_CabeceraXCod Get2_CabeceraXCod(int idEmpresa, string serie, string numero, string tipoorden)
        {

            GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 2, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", serie, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt2", numero, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt3", tipoorden, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt1", idEmpresa, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt2", 0, DbType.Int32, ParameterDirection.Input);

                return sqlConnection.QuerySingleOrDefault<GetGR2_CabeceraXCod>("uspGetGuiaRemision",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
            }

            //GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();

            //using (var sqlConnection = ConnectionBD.GetConnection())
            //{
            //    using (var sqlCommand = sqlConnection.CreateCommand())
            //    {
            //        sqlCommand.CommandText = @"uspGetGuiaRemision";
            //        sqlCommand.CommandType = CommandType.StoredProcedure;

            //        sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
            //        sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
            //        sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = numero;
            //        sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = "";
            //        sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
            //        sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

            //        sqlConnection.Open();

            //        SqlDataReader reader = sqlCommand.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            if (reader.Read())
            //            {
            //                grCab = new GetGR2_CabeceraXCod();

            //                grCab.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
            //                grCab.serie = reader["serie"].ToString();
            //                grCab.numero = reader["numero"].ToString();
            //                grCab.fechaEmision = reader["fechaEmision"].ToString();
            //                grCab.puntoPartida = reader["puntoPartida"].ToString();
            //                grCab.puntoLlegada = reader["puntoLlegada"].ToString();
            //                grCab.fechaInicioTraslado = reader["fechaInicioTraslado"].ToString();

            //                grCab.destCodigoPC = reader["destCodigoPC"].ToString();
            //                grCab.destRS = reader["destRS"].ToString();
            //                grCab.transCodigoPC = reader["transCodigoPC"].ToString();
            //                grCab.transRS = reader["transRS"].ToString();

            //                grCab.transMarca = reader["transMarca"].ToString();
            //                grCab.transNumPlaca = reader["transNumPlaca"].ToString();
            //                grCab.transNumConstInscr = reader["transNumConstInscr"].ToString();
            //                grCab.transNumLicConducir = reader["transNumLicConducir"].ToString();

            //                grCab.codTipoCpte = reader["codTipoCpte"].ToString();
            //                grCab.numCptePago = reader["numCptePago"].ToString();
            //                grCab.usuarioReg = reader["usuarioReg"].ToString();
            //                grCab.fechaReg = reader["fechaReg"].ToString();

            //                grCab.voucher = Convert.ToInt32(reader["voucher"]);
            //                grCab.tipoOrden = reader["tipoOrden"].ToString();
            //            }
            //        }
            //    }
            //}
            //return grCab;
        }
        public List<GetGR3_DetalleXCod> Get3_DetalleXCod(int idEmpresa, string serie, string numero, string tipoOrden)
        {
            List<GetGR3_DetalleXCod> grDets = new List<GetGR3_DetalleXCod>();
            //GetGR3_DetalleXCod grDet;

            GetGR2_CabeceraXCod grCab = new GetGR2_CabeceraXCod();
            using (SqlConnection sqlConnection = ConnectionBD.GetConnection())
            {

                var sp_parametros = new DynamicParameters();
                sp_parametros.Add("@opcion", 3, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt1", serie, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt2", numero, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroTxt3", tipoOrden, DbType.String, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt1", idEmpresa, DbType.Int32, ParameterDirection.Input);
                sp_parametros.Add("@filtroInt2", 0, DbType.Int32, ParameterDirection.Input);

                var response = sqlConnection.Query<GetGR3_DetalleXCod>("uspGetGuiaRemision",
                                                    sp_parametros,
                                                    commandType: CommandType.StoredProcedure);
                grDets = response.ToList();
            }

            return grDets;
            //using (var sqlConnection = ConnectionBD.GetConnection())
            //{
            //    using (var sqlCommand = sqlConnection.CreateCommand())
            //    {
            //        sqlCommand.CommandText = @"uspGetGuiaRemision";
            //        sqlCommand.CommandType = CommandType.StoredProcedure;

            //        sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
            //        sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = serie;
            //        sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = numero;
            //        sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = tipoOrden;
            //        sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
            //        sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

            //        sqlConnection.Open();

            //        SqlDataReader reader = sqlCommand.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                grDet = new GetGR3_DetalleXCod();

            //                grDet.tipo = reader["tipo"].ToString();
            //                grDet.serie = reader["serie"].ToString();

            //                grDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
            //                grDet.serie = reader["serie"].ToString();
            //                grDet.numero = reader["numero"].ToString();
            //                grDet.secuencia = Convert.ToInt32(reader["secuencia"]);

            //                grDet.idEmpresaDet = Convert.ToInt32(reader["idEmpresaDet"]);
            //                grDet.idDet = Convert.ToInt32(reader["idDet"]);

            //                grDet.codigo = reader["codigo"].ToString();
            //                grDet.razonSocial = reader["razonSocial"].ToString();

            //                grDet.secuenciaDet = Convert.ToInt32(reader["secuenciaDet"]);
            //                grDet.codigoProducto = reader["codigoProducto"].ToString();
            //                grDet.producto = reader["producto"].ToString().Trim();
            //                grDet.codCuenta = reader["codCuenta"].ToString().Trim();

            //                grDet.cantidadOC = Convert.ToDecimal(reader["cantidadOC"]);
            //                //grDet.cantidadOCsaldo = Convert.ToDecimal(reader["cantidadOCsaldo"]);

            //                grDet.codUM = reader["codUM"].ToString();
            //                grDet.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);
            //                grDet.total = Convert.ToDecimal(reader["total"]);

            //                grDet.tipoMovimiento = reader["tipoMovimiento"].ToString();
            //                grDet.cantidadIngresada = Convert.ToDouble(reader["cantidadIngresada"]);
            //                grDet.pesoIngresado = Convert.ToDecimal(reader["pesoIngresado"]);
            //                grDet.cantidadSaldo = Convert.ToDecimal(reader["cantidadSaldo"]);

            //                grDet.numeroPartida = reader["numeroPartida"].ToString();

            //                grDets.Add(grDet);
            //            }
            //        }
            //    }
            //}
            //return grDets;
        }
        public List<GetGR4_TipoCptes> Get4_TipoCptes()
        {
            List<GetGR4_TipoCptes> tipoCptes = new List<GetGR4_TipoCptes>();
            GetGR4_TipoCptes tipoCpte;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetGuiaRemision";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tipoCpte = new GetGR4_TipoCptes();

                            tipoCpte.codTipoCpte = reader["codTipoCpte"].ToString();
                            tipoCpte.tipoComprobante = reader["tipoComprobante"].ToString();

                            tipoCptes.Add(tipoCpte);
                        }
                    }
                }
            }
            return tipoCptes;
        }
        public List<GetGR5_OCDetalle> Get5_OCDetalle(int idEmpresa, int idOC, string tipoOrden)
        {
            List<GetGR5_OCDetalle> grDets = new List<GetGR5_OCDetalle>();
            GetGR5_OCDetalle grDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetGuiaRemision";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = tipoOrden;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            grDet = new GetGR5_OCDetalle();

                            grDet.tipo = reader["tipo"].ToString();
                            grDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"].ToString());
                            grDet.id = Convert.ToInt32(reader["id"].ToString());
                            grDet.secuencia = Convert.ToInt32(reader["secuencia"].ToString());
                            grDet.codNivel = reader["codNivel"].ToString();
                            grDet.codGrupo = reader["codGrupo"].ToString();
                            grDet.codTalla = reader["codTalla"].ToString();
                            grDet.codColor = reader["codColor"].ToString();
                            grDet.codProductoGeneral = reader["codProductoGeneral"].ToString();
                            grDet.producto = reader["producto"].ToString();
                            grDet.codCuenta = reader["codCuenta"].ToString();
                            grDet.descripcionCta = reader["descripcionCta"].ToString();
                            grDet.cantidad = Convert.ToDecimal(reader["cantidad"].ToString());
                            grDet.codUM = reader["codUM"].ToString();
                            grDet.precioUnitario = Convert.ToDecimal(reader["precioUnitario"].ToString());
                            grDet.total = Convert.ToDecimal(reader["total"].ToString());
                            grDet.codigoPC = reader["codigoPC"].ToString();
                            grDet.razonSocial = reader["razonSocial"].ToString();
                            grDet.cantidadSaldo = Convert.ToDecimal(reader["cantidadSaldo"].ToString());
                            grDet.tienegrfact = Convert.ToInt32(reader["tienegrfact"].ToString());
                            grDet.cantidadEntrada = Convert.ToDecimal(reader["cantidadEntrada"].ToString());
                            grDet.cantidadSalida = Convert.ToDecimal(reader["cantidadSalida"].ToString());

                            grDets.Add(grDet);
                        }
                    }
                }
            }
            return grDets;
        }
        public List<GetGR6_RpteGROC> Get6_RpteGROC(string fechaInicio, string fechaFin, string codigoProducto)
        {
            List<GetGR6_RpteGROC> rptes = new List<GetGR6_RpteGROC>();
            GetGR6_RpteGROC rpte;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetGuiaRemision";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = fechaInicio;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = fechaFin;
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = codigoProducto;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            rpte = new GetGR6_RpteGROC();

                            rpte.tipo = reader["tipo"].ToString();
                            rpte.codigo = Convert.ToInt32(reader["codigo"]);
                            rpte.secuencia = Convert.ToInt32(reader["secuencia"]);
                            rpte.codProducto = reader["codProducto"].ToString();
                            rpte.codGrupoAlt = reader["codGrupoAlt"].ToString();
                            rpte.cantidad = Convert.ToDecimal(reader["cantidad"]);
                            rpte.igv = Convert.ToDecimal(reader["igv"]);
                            rpte.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);
                            rpte.codigoPC = reader["codigoPC"].ToString();
                            rpte.razonSocial = reader["razonSocial"].ToString();
                            rpte.cobservacion = reader["cobservacion"].ToString();

                            rpte.gserie = reader["gserie"].ToString();
                            rpte.gnumero = reader["gnumero"].ToString();
                            rpte.gfechaInicioTraslado = reader["gfechaInicioTraslado"].ToString();
                            rpte.gdestCodigoPC = reader["gdestCodigoPC"].ToString();
                            rpte.gdestRazonSocial = reader["gdestRazonSocial"].ToString();
                            rpte.gtransCodigoPC = reader["gtransCodigoPC"].ToString();
                            rpte.gtransRazonSocial = reader["gtransRazonSocial"].ToString();
                            rpte.gnumeroPartida = reader["gnumeroPartida"].ToString();
                            rpte.gtransMarca = reader["gtransMarca"].ToString();
                            rpte.gtransNumPlaca = reader["gtransNumPlaca"].ToString();
                            rpte.gtransNumLicConducir = reader["gtransNumLicConducir"].ToString();
                            rpte.gcodTipoCpte = reader["gcodTipoCpte"].ToString();
                            rpte.gtipoComprobante = reader["gtipoComprobante"].ToString();
                            rpte.gnumCptePago = reader["gnumCptePago"].ToString();
                            rpte.gsecuencia = Convert.ToInt32(reader["gsecuencia"]);
                            rpte.gcodCuenta = reader["codCuenta"].ToString();
                            rpte.gcantidadIngresada = Convert.ToDecimal(reader["gcantidadIngresada"]);
                            rpte.gpesoIngresado = Convert.ToDecimal(reader["gpesoIngresado"]);
                            rpte.gtipoMovimiento = Convert.ToString(reader["gtipoMovimiento"]);
                            rpte.gPeriodo = Convert.ToString(reader["gPeriodo"]);

                            rpte.fserie = reader["fserie"].ToString();
                            rpte.fnumero = reader["fnumero"].ToString();
                            rpte.ffechaEmision = reader["ffechaEmision"].ToString();
                            rpte.fcodigoPC = reader["fcodigoPC"].ToString();
                            rpte.frazonSocial = reader["frazonSocial"].ToString();
                            rpte.fsecuencia = Convert.ToInt32(reader["fsecuencia"]);
                            rpte.fcodigo = reader["fcodigo"].ToString();
                            rpte.fdescripcion = reader["fdescripcion"].ToString();
                            rpte.ftalla = reader["ftalla"].ToString();
                            rpte.fcolor = reader["fcolor"].ToString();
                            rpte.fcodUM = reader["fcodUM"].ToString();
                            rpte.fcantidad = Convert.ToDecimal(reader["fcantidad"]);
                            rpte.figv = Convert.ToDecimal(reader["figv"]);
                            rpte.fprecioUnitario = Convert.ToDecimal(reader["fprecioUnitario"]);
                            rpte.ftipoCambio = Convert.ToDecimal(reader["ftipoCambio"]);
                            rpte.ftipoMoneda = Convert.ToString(reader["ftipoMoneda"]);

                            rpte.fserieNotaCredito = reader["fserieNotaCredito"].ToString();
                            rpte.fnumeroNotaCredito = reader["fnumeroNotaCredito"].ToString();
                            rpte.fobservacionNotaCredito = reader["fobservacionNotaCredito"].ToString();

                            rptes.Add(rpte);
                        }
                    }
                }
            }
            return rptes;
        }
        public List<GetGR7_CierrePeriodo> GetGR7_CierrePeriodo()
        {
            List<GetGR7_CierrePeriodo> cecos = new List<GetGR7_CierrePeriodo>();
            GetGR7_CierrePeriodo cierrePeriodo;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetGuiaRemision";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cierrePeriodo = new GetGR7_CierrePeriodo();

                            cierrePeriodo.idCierrePeriodo = reader["idCierrePeriodo"].ToString();
                            cierrePeriodo.periodo = reader["periodo"].ToString();
                            cierrePeriodo.fechaInicio = reader["fechaInicio"].ToString();
                            cierrePeriodo.fechaFin = reader["fechaFin"].ToString();
                            cierrePeriodo.estado = reader["estado"].ToString();
                            cierrePeriodo.idEstado = reader["idEstado"].ToString();

                            cecos.Add(cierrePeriodo);
                        }
                    }
                }
            }
            return cecos;
        }


        public List<GetGR9_DetalleSalidaIngreso> GetGRDetalleSalidaIngreso(int idoc, string tipomovimiento, int secuencia, string tipoorden)
        {
            List<GetGR9_DetalleSalidaIngreso> lista = new List<GetGR9_DetalleSalidaIngreso>();
            GetGR9_DetalleSalidaIngreso obj;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetGuiaRemision";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 9;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = tipomovimiento;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = tipoorden;
                    sqlCommand.Parameters.Add("@filtroTxt3", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idoc;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = secuencia;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            obj = new GetGR9_DetalleSalidaIngreso();
                            obj.tipoOrden = reader["tipoOrden"].ToString();
                            obj.serie = reader["serie"].ToString();
                            obj.numero = reader["numero"].ToString();
                            obj.secuencia = reader["secuencia"].ToString();
                            obj.cantidadIngresada = Convert.ToDecimal(reader["cantidadIngresada"].ToString());
                            lista.Add(obj);
                        }
                    }
                }
            }
            return lista;
        }


        // ### SET ###
        public Response SetGRCabecera(SetGRCabParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetGRCabecera";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = parametros.serie;
                    sqlCommand.Parameters.Add("@numero", SqlDbType.VarChar, 10).Value = parametros.numero;
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
                    sqlCommand.Parameters.Add("@codTipoCpte", SqlDbType.VarChar, 2).Value = parametros.codTipoCpte;
                    sqlCommand.Parameters.Add("@numCptePago", SqlDbType.VarChar, 20).Value = parametros.numCptePago;
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 30).Value = parametros.usuarioReg;
                    sqlCommand.Parameters.Add("@voucher", SqlDbType.Int).Value = parametros.voucher;
                    sqlCommand.Parameters.Add("@tipoOrden", SqlDbType.VarChar, 1).Value = parametros.tipoOrden;
                    sqlCommand.Parameters.Add("@codCuenta", SqlDbType.VarChar, 10).Value = parametros.codCuenta;


                    sqlCommand.Parameters.Add("@idMotivoTraslado", SqlDbType.Int).Value = parametros.idMotivoTraslado;
                    sqlCommand.Parameters.Add("@observaciones", SqlDbType.VarChar, 500).Value = parametros.observaciones;

                    sqlCommand.Parameters.Add("@enviadosunat", SqlDbType.Bit).Value = parametros.enviadoSunat;
                    sqlCommand.Parameters.Add("@respuestasunat", SqlDbType.VarChar, 500).Value = parametros.respuestaSunat;
                    sqlCommand.Parameters.Add("@otrosmotivotraslado", SqlDbType.VarChar, 500).Value = parametros.otrosMotivoTraslado;

                    sqlCommand.Parameters.Add("@codTipoTransporte", SqlDbType.Char, 2).Value = parametros.codTipoTransporte;




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
        public Response SetGRDetalle(SetGRDetParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetGRDetalle";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@serie", SqlDbType.VarChar, 4).Value = parametros.serie;
                    sqlCommand.Parameters.Add("@numero", SqlDbType.VarChar, 10).Value = parametros.numero;
                    sqlCommand.Parameters.Add("@secuencia", SqlDbType.Int).Value = parametros.secuencia;

                    sqlCommand.Parameters.Add("@idEmpresaDet", SqlDbType.Int).Value = parametros.idEmpresaDet;
                    sqlCommand.Parameters.Add("@idDet", SqlDbType.Int).Value = parametros.idDet;
                    sqlCommand.Parameters.Add("@idSecuenciaDet", SqlDbType.Int).Value = parametros.idSecuenciaDet;

                    sqlCommand.Parameters.Add("@cantidadIngresada", SqlDbType.Decimal).Value = parametros.cantidadIngresada;
                    sqlCommand.Parameters.Add("@pesoIngresado", SqlDbType.Decimal).Value = parametros.pesoIngresado;

                    sqlCommand.Parameters.Add("@tipoMovimiento", SqlDbType.VarChar).Value = parametros.tipoMovimiento;

                    sqlCommand.Parameters.Add("@numeroPartida", SqlDbType.VarChar).Value = parametros.numeroPartida;

                    sqlCommand.Parameters.Add("@codCuenta", SqlDbType.VarChar).Value = parametros.codCuenta;

                    sqlCommand.Parameters.Add("@tipoOrden", SqlDbType.VarChar).Value = parametros.tipoOrden;
                    sqlCommand.Parameters.Add("@OP", SqlDbType.VarChar).Value = parametros.OP;


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
        public Response SetGRMotivoTraslado(SetGRMotTraslado parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetGRMotivoTraslado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idMotivo", SqlDbType.Int).Value = parametros.idMotivo;
                    sqlCommand.Parameters.Add("@motivo", SqlDbType.VarChar, 30).Value = parametros.motivo;
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
        public Response SetCierrePeriodo(SetCierrePeriodoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetCierrePeriodo";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@idCierrePeriodo", SqlDbType.Int).Value = parametros.idCierrePeriodo;
                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@periodo", SqlDbType.VarChar, 7).Value = parametros.periodo;
                    sqlCommand.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = parametros.fechaInicio;
                    sqlCommand.Parameters.Add("@fechaFin", SqlDbType.Date).Value = parametros.fechaFin;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1).Value = parametros.estado;
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
        public Response SetValidarPeriodo(string periodo)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetCierrePeriodo";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@idCierrePeriodo", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                    sqlCommand.Parameters.Add("@periodo", SqlDbType.VarChar, 7).Value = "";
                    sqlCommand.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = periodo;
                    sqlCommand.Parameters.Add("@fechaFin", SqlDbType.Date).Value = periodo;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1).Value = "";
                    sqlCommand.Parameters.Add("@usuarioReg", SqlDbType.VarChar, 50).Value = "";

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
