using SoftCotton.Database;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Model.ServiceOrder;
using SoftCotton.Reports.PurchaseOrder;
using SoftCotton.Reports.PurchaseOrder.OrdenCompra;
using SoftCotton.Reports.ServiceOrder.OrdenServicio;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class OrdenServicioRepository
    {

        // ### GET ###
        public List<GetOC1_TipoMoneda> Get1_TipoMoneda()
        {
            List<GetOC1_TipoMoneda> monedas = new List<GetOC1_TipoMoneda>();
            GetOC1_TipoMoneda moneda;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
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
                            moneda = new GetOC1_TipoMoneda();
                            moneda.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"]);
                            moneda.moneda = reader["moneda"].ToString();
                            monedas.Add(moneda);
                        }
                    }
                }
            }
            return monedas;
        }
        public List<GetOC2_CondPago> Get2_CondicionPago()
        {
            List<GetOC2_CondPago> condPagos = new List<GetOC2_CondPago>();
            GetOC2_CondPago condPago;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
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
                            condPago = new GetOC2_CondPago();
                            condPago.idCondPago = Convert.ToInt32(reader["idCondPago"]);
                            condPago.condicion = reader["condicion"].ToString();
                            condPagos.Add(condPago);
                        }
                    }
                }
            }
            return condPagos;
        }
        public GetOC4_ProductoXCod Get4_ProductoXCod(string codProducto)
        {
            GetOC4_ProductoXCod producto = new GetOC4_ProductoXCod();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = codProducto;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            producto = new GetOC4_ProductoXCod();
                            producto.codFamilia = reader["codFamilia"].ToString();
                            producto.codProducto = reader["codProducto"].ToString();
                            producto.codTalla = reader["codTalla"].ToString();
                            producto.codColor = reader["codColor"].ToString();
                            producto.color = reader["color"].ToString();
                            producto.producto = reader["producto"].ToString();
                            producto.codUM = reader["codUM"].ToString();
                        }
                    }
                }
            }
            return producto;
        }
        public List<GetOS5_TipoAprobacion> Get5_TipoAprobaciones()
        {
            List<GetOS5_TipoAprobacion> tipoAprobaciones = new List<GetOS5_TipoAprobacion>();
            GetOS5_TipoAprobacion tipoAprobacion;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
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
                            tipoAprobacion = new GetOS5_TipoAprobacion();
                            tipoAprobacion.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);
                            tipoAprobacion.descripcion = reader["descripcion"].ToString();
                            tipoAprobacion.estado = Convert.ToBoolean(reader["estado"].ToString());
                            tipoAprobacion.nivelAprobacion = Convert.ToInt32(reader["nivelAprobacion"]);
                            tipoAprobacion.usuarioReg = reader["usuarioReg"].ToString();
                            tipoAprobacion.fechaReg = reader["fechaReg"].ToString();

                            tipoAprobaciones.Add(tipoAprobacion);
                        }
                    }
                }
            }
            return tipoAprobaciones;
        }
        public List<GetOS6_TipoAnulado> Get6_TipoAnulados()
        {
            List<GetOS6_TipoAnulado> tipoAnulados = new List<GetOS6_TipoAnulado>();
            GetOS6_TipoAnulado tipoAnulado;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
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
                            tipoAnulado = new GetOS6_TipoAnulado();
                            tipoAnulado.idTipoAnulado = Convert.ToInt32(reader["idTipoAnulado"]);
                            tipoAnulado.descripcion = reader["descripcion"].ToString();
                            tipoAnulado.estado = Convert.ToBoolean(reader["estado"].ToString());
                            tipoAnulado.usuarioReg = reader["usuarioReg"].ToString();
                            tipoAnulado.fechaReg = reader["fechaReg"].ToString();

                            tipoAnulados.Add(tipoAnulado);
                        }
                    }
                }
            }
            return tipoAnulados;
        }
        public GetOS7_OSCabXCodigo Get7_OCCabXCodigo(int idEmpresa, int idOS)
        {
            GetOS7_OSCabXCodigo ocCab = new GetOS7_OSCabXCodigo();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOS;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {

                            ocCab.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocCab.idOS = Convert.ToInt32(reader["idOS"]);
                            ocCab.fechaEmision = reader["fechaEmision"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-mm-dd") : Convert.ToDateTime(reader["fechaEmision"]).ToString("yyyy-MM-dd");
                            ocCab.fechaEntrega = reader["fechaEntrega"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-mm-dd") : Convert.ToDateTime(reader["fechaEntrega"]).ToString("yyyy-MM-dd");

                            ocCab.codigoPC = reader["codigoPC"].ToString();
                            ocCab.razonSocial = reader["razonSocial"].ToString();
                            ocCab.direccion = reader["direccion"].ToString();

                            ocCab.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"]);
                            ocCab.tipoCompra = reader["tipoCompra"].ToString();
                            ocCab.idCondPago = Convert.ToInt32(reader["idCondPago"]);
                            ocCab.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);
                            ocCab.tipoAprobacion = reader["tipoAprobacion"].ToString();

                            ocCab.idTipoAnulado = Convert.ToInt32(reader["idTipoAnulado"]);
                            ocCab.fechaAnulado = reader["fechaAnulado"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-MM-dd") : Convert.ToDateTime(reader["fechaAnulado"]).ToString("yyyy-MM-dd");
                            ocCab.usuarioAnulado = reader["usuarioAnulado"].ToString();

                            ocCab.usuCreacionReg = reader["usuCreacionReg"].ToString();
                            ocCab.usuFechaReg = reader["usuFechaReg"].ToString();
                            ocCab.observacion = reader["observacion"].ToString();

                            ocCab.codServicio = reader["codServicio"].ToString();
                            ocCab.nombreServicio = reader["nombreServicio"].ToString();

                            ocCab.codPrograma = reader["codPrograma"].ToString();
                            ocCab.nombrePrograma = reader["nombrePrograma"].ToString();

                            ocCab.subTotal = Convert.ToDecimal(reader["subTotal"]);
                            ocCab.igv = Convert.ToDecimal(reader["igv"]);
                            ocCab.total = Convert.ToDecimal(reader["total"]);
                        }
                    }
                }
            }

            return ocCab;
        }

        public GetOS7_OSCabXCodigo Get26_OCCabXCodigo(int idEmpresa, int idOrdenSalida)
        {
            GetOS7_OSCabXCodigo ocCab = new GetOS7_OSCabXCodigo();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 26;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOrdenSalida;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {

                            ocCab.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocCab.idOS = Convert.ToInt32(reader["idOrdenSalida"]);
                            ocCab.fechaEmision = reader["fechaEmision"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-mm-dd") : Convert.ToDateTime(reader["fechaEmision"]).ToString("yyyy-MM-dd");
                            ocCab.fechaEntrega = reader["fechaEntrega"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-mm-dd") : Convert.ToDateTime(reader["fechaEntrega"]).ToString("yyyy-MM-dd");

                            ocCab.codigoPC = reader["codigoPC"].ToString();
                            ocCab.razonSocial = reader["razonSocial"].ToString();
                            ocCab.direccion = reader["direccion"].ToString();

                            ocCab.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"]);
                            ocCab.tipoCompra = reader["tipoCompra"].ToString();
                            ocCab.idCondPago = Convert.ToInt32(reader["idCondPago"]);
                            ocCab.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);
                            ocCab.tipoAprobacion = reader["tipoAprobacion"].ToString();

                            ocCab.idTipoAnulado = Convert.ToInt32(reader["idTipoAnulado"]);
                            ocCab.fechaAnulado = reader["fechaAnulado"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-MM-dd") : Convert.ToDateTime(reader["fechaAnulado"]).ToString("yyyy-MM-dd");
                            ocCab.usuarioAnulado = reader["usuarioAnulado"].ToString();

                            ocCab.usuCreacionReg = reader["usuCreacionReg"].ToString();
                            ocCab.usuFechaReg = reader["usuFechaReg"].ToString();
                            ocCab.observacion = reader["observacion"].ToString();

                            ocCab.codServicio = reader["codServicio"].ToString();
                            ocCab.nombreServicio = reader["nombreServicio"].ToString();

                            ocCab.codPrograma = reader["codPrograma"].ToString();
                            ocCab.nombrePrograma = reader["nombrePrograma"].ToString();

                            ocCab.subTotal = Convert.ToDecimal(reader["subTotal"]);
                            ocCab.igv = Convert.ToDecimal(reader["igv"]);
                            ocCab.total = Convert.ToDecimal(reader["total"]);
                        }
                    }
                }
            }

            return ocCab;
        }

        public GetOS7_OSCabXCodigo Get7_OCCabXCodigoEspecial(int idEmpresa, int idOS)
        {
            GetOS7_OSCabXCodigo ocCab = new GetOS7_OSCabXCodigo();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 20;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOS;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {

                            ocCab.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocCab.idOS = Convert.ToInt32(reader["idOS"]);
                            ocCab.fechaEmision = reader["fechaEmision"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-mm-dd") : Convert.ToDateTime(reader["fechaEmision"]).ToString("yyyy-MM-dd");
                            ocCab.fechaEntrega = reader["fechaEntrega"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-mm-dd") : Convert.ToDateTime(reader["fechaEntrega"]).ToString("yyyy-MM-dd");

                            ocCab.codigoPC = reader["codigoPC"].ToString();
                            ocCab.razonSocial = reader["razonSocial"].ToString();
                            ocCab.direccion = reader["direccion"].ToString();

                            ocCab.idTipoMoneda = Convert.ToInt32(reader["idTipoMoneda"]);
                            ocCab.tipoCompra = reader["tipoCompra"].ToString();
                            ocCab.idCondPago = Convert.ToInt32(reader["idCondPago"]);
                            ocCab.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);
                            ocCab.tipoAprobacion = reader["tipoAprobacion"].ToString();

                            ocCab.idTipoAnulado = Convert.ToInt32(reader["idTipoAnulado"]);
                            ocCab.fechaAnulado = reader["fechaAnulado"] == DBNull.Value ? new DateTime(1970, 1, 1).ToString("yyyy-MM-dd") : Convert.ToDateTime(reader["fechaAnulado"]).ToString("yyyy-MM-dd");
                            ocCab.usuarioAnulado = reader["usuarioAnulado"].ToString();

                            ocCab.usuCreacionReg = reader["usuCreacionReg"].ToString();
                            ocCab.usuFechaReg = reader["usuFechaReg"].ToString();
                            ocCab.observacion = reader["observacion"].ToString();

                            ocCab.codServicio = reader["codServicio"].ToString();
                            ocCab.nombreServicio = reader["nombreServicio"].ToString();

                            ocCab.codPrograma = reader["codPrograma"].ToString();
                            ocCab.nombrePrograma = reader["nombrePrograma"].ToString();

                            ocCab.subTotal = Convert.ToDecimal(reader["subTotal"]);
                            ocCab.igv = Convert.ToDecimal(reader["igv"]);
                            ocCab.total = Convert.ToDecimal(reader["total"]);
                        }
                    }
                }
            }

            return ocCab;
        }
        public DataTable Get7_OCDeetXCodigoEspecial(int idEmpresa, int idOS)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 21;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.Int).Value = idOS;

                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }


            }
        }
        public List<GetOS8_OSDetXCodigo> Get8_OSDetXCodigo(int idEmpresa, int idOC)
        {
            List<GetOS8_OSDetXCodigo> ocDets = new List<GetOS8_OSDetXCodigo>();
            GetOS8_OSDetXCodigo ocDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 8;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ocDet = new GetOS8_OSDetXCodigo();

                            ocDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocDet.idOS = Convert.ToInt32(reader["idOS"]);
                            ocDet.secuencia = Convert.ToInt32(reader["secuencia"]);

                            ocDet.codNivel = reader["codNivel"].ToString();
                            ocDet.codGrupo = reader["codGrupo"].ToString();
                            ocDet.codTalla = reader["codTalla"].ToString();
                            ocDet.codColor = reader["codColor"].ToString();

                            ocDet.producto = reader["producto"].ToString();
                            ocDet.color = reader["color"].ToString();
                            ocDet.codUM = reader["codUM"].ToString();

                            ocDet.cantidad = Convert.ToDecimal(reader["cantidad"]);
                            ocDet.igv = Convert.ToDecimal(reader["igv"]);
                            ocDet.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);

                            ocDet.obs1 = reader["obs1"].ToString();
                            ocDet.obs2 = reader["obs2"].ToString();
                            ocDet.obs3 = reader["obs3"].ToString();
                            ocDet.obs4 = reader["obs4"].ToString();
                            ocDet.obs5 = reader["obs5"].ToString();

                            ocDets.Add(ocDet);
                        }
                    }
                }
            }

            return ocDets;
        }

        public List<GetOS8_OSDetXCodigo> Get27_OSDetXCodigo(int idEmpresa, int idOC)
        {
            List<GetOS8_OSDetXCodigo> ocDets = new List<GetOS8_OSDetXCodigo>();
            GetOS8_OSDetXCodigo ocDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 27;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ocDet = new GetOS8_OSDetXCodigo();

                            ocDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocDet.idOS = Convert.ToInt32(reader["idOrdenSalida"]);
                            ocDet.secuencia = Convert.ToInt32(reader["secuencia"]);

                            ocDet.codNivel = reader["codNivel"].ToString();
                            ocDet.codGrupo = reader["codGrupo"].ToString();
                            ocDet.codTalla = reader["codTalla"].ToString();
                            ocDet.codColor = reader["codColor"].ToString();

                            ocDet.producto = reader["producto"].ToString();
                            ocDet.color = reader["color"].ToString();
                            ocDet.codUM = reader["codUM"].ToString();

                            ocDet.cantidad = Convert.ToDecimal(reader["cantidad"]);
                            ocDet.igv = Convert.ToDecimal(reader["igv"]);
                            ocDet.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);

                            ocDet.obs1 = reader["obs1"].ToString();
                            ocDet.obs2 = reader["obs2"].ToString();
                            ocDet.obs3 = reader["obs3"].ToString();
                            ocDet.obs4 = reader["obs4"].ToString();
                            ocDet.obs5 = reader["obs5"].ToString();

                            ocDets.Add(ocDet);
                        }
                    }
                }
            }

            return ocDets;
        }
        public List<GetOS11_Firmantes> Get11_Firmantes(int idEmpresa)
        {
            List<GetOS11_Firmantes> firmantes = new List<GetOS11_Firmantes>();
            GetOS11_Firmantes firmante;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 11;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            firmante = new GetOS11_Firmantes();

                            firmante.idUsuario = Convert.ToInt32(reader["idUsuario"]);
                            firmante.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);

                            firmante.colaborador = reader["colaborador"].ToString();
                            firmante.tipoAprobacion = reader["tipoAprobacion"].ToString();

                            firmante.nivelAprobacion = Convert.ToInt32(reader["nivelAprobacion"]);
                            firmante.rutaImgFirma = reader["rutaImgFirma"].ToString();

                            firmante.estado = Convert.ToBoolean(reader["estado"]);
                            firmante.usuReg = reader["usuReg"].ToString();
                            firmante.fechaReg = reader["fechaReg"].ToString();
                                
                            firmantes.Add(firmante);
                        }
                    }
                }
            }

            return firmantes;
        }
        public List<GetOC12_Usuarios> Get12_Usuarios(int idEmpresa)
        {
            List<GetOC12_Usuarios> usuarios = new List<GetOC12_Usuarios>();
            GetOC12_Usuarios usuario;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 12;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usuario = new GetOC12_Usuarios();

                            usuario.id = Convert.ToInt32(reader["id"]);
                            usuario.colaborador = reader["colaborador"].ToString();
                            
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }
        public List<GetOC13_TiposAprobacion> Get13_TiposAprobaciones()
        {
            List<GetOC13_TiposAprobacion> tiposAprobaciones = new List<GetOC13_TiposAprobacion>();
            GetOC13_TiposAprobacion tipoAprobacion;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
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
                            tipoAprobacion = new GetOC13_TiposAprobacion();

                            tipoAprobacion.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);
                            tipoAprobacion.descripcion = reader["descripcion"].ToString();

                            tiposAprobaciones.Add(tipoAprobacion);
                        }
                    }
                }
            }

            return tiposAprobaciones;
        }
        public List<GetOS14_Observaciones> Get14_Observaciones()
        {
            List<GetOS14_Observaciones> observaciones = new List<GetOS14_Observaciones>();
            GetOS14_Observaciones observacion;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
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
                            observacion = new GetOS14_Observaciones();

                            observacion.idObs = Convert.ToInt32(reader["idObs"]);
                            observacion.observacion = reader["observacion"].ToString();
                            observacion.estado = Convert.ToBoolean(reader["estado"].ToString());
                            observacion.usuReg = reader["usuReg"].ToString();
                            observacion.fechaReg = reader["fechaReg"].ToString();


                            observaciones.Add(observacion);
                        }
                    }
                }
            }
            return observaciones;
        }
        public GetOS15_FirmanteXNivel Get15_FirmanteXNivel(int idUsuario, int nivelAprobacion)
        {
            GetOS15_FirmanteXNivel firmante = new GetOS15_FirmanteXNivel();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 15;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idUsuario;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = nivelAprobacion;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            firmante = new GetOS15_FirmanteXNivel();

                            firmante.idUsuario = Convert.ToInt32(reader["idUsuario"]);
                            firmante.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);
                            firmante.nivelAprobacion = Convert.ToInt32(reader["nivelAprobacion"]);
                        }
                    }
                }
            }

            return firmante;
        }
        public List<GetOS16_Firmantes> Get16_Firmantes(int idEmpresa, int oc)
        {
            List<GetOS16_Firmantes> firmantes = new List<GetOS16_Firmantes>();
            GetOS16_Firmantes firma;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 16;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = oc;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            firma = new GetOS16_Firmantes();

                            firma.firmante = reader["firmante"].ToString();
                            firma.tipoAprobacion = reader["tipoAprobacion"].ToString();
                            
                            firmantes.Add(firma);
                        }
                    }
                }
            }

            return firmantes;
        }
        public List<GetOS19_Reporte> Get19_Reporte(string fechaInicio, string fechaFin)
        {
            List<GetOS19_Reporte> oss = new List<GetOS19_Reporte>();
            GetOS19_Reporte os;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 19;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = fechaInicio;
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = fechaFin;
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            os = new GetOS19_Reporte();
                             
                            os.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            os.idOS = Convert.ToInt32(reader["idOS"]);
                            os.fechaEmision = reader["fechaEmision"].ToString();
                            os.fechaEntrega = reader["fechaEntrega"].ToString();
                            os.codigoPC = reader["codigoPC"].ToString();
                            os.razonsocial = reader["razonsocial"].ToString().Trim();
                            os.tipoMoneda = reader["tipoMoneda"].ToString();
                            os.tipoCompra = reader["tipoCompra"].ToString();
                            os.condicion = reader["condicion"].ToString();
                            os.estadooc = reader["estadooc"].ToString();
                            os.usuCreacionReg = reader["usuCreacionReg"].ToString();
                            os.usuFechaReg = reader["usuFechaReg"].ToString();
                            os.observacion = reader["observacion"].ToString();
                            os.codNivel = reader["codNivel"].ToString();
                            os.codGrupo = reader["codGrupo"].ToString();
                            os.codTalla = reader["codTalla"].ToString();
                            os.codColor = reader["codColor"].ToString();
                            os.codProductoGeneral = reader["codProductoGeneral"].ToString();
                            os.producto = reader["producto"].ToString();
                            os.color = reader["color"].ToString();
                            os.cantidad = Convert.ToDecimal(reader["cantidad"]);
                            os.codUM = reader["codUM"].ToString();
                            os.igv = Convert.ToDecimal(reader["igv"]);
                            os.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);
                            os.total = Convert.ToDecimal(reader["total"]);
                            os.obs1 = reader["obs1"].ToString();
                            os.obs2 = reader["obs2"].ToString();
                            os.obs3 = reader["obs3"].ToString();
                            os.obs4 = reader["obs4"].ToString();
                            os.obs5 = reader["obs5"].ToString();

                            oss.Add(os);
                        }
                    }
                }
            }

            return oss;
        }
        // ### REPORTE ###
        public OrdenServicioRpteCabModel Rpte9_OrdenServicioCabecera(int idEmpresa, int idOC)
        {
            OrdenServicioRpteCabModel ocCab = new OrdenServicioRpteCabModel();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 9;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            ocCab = new OrdenServicioRpteCabModel();

                            ocCab.empresaRUC = reader["empresaRUC"].ToString();
                            ocCab.empresaDireccion = reader["empresaDireccion"].ToString().Trim();
                            ocCab.codigoOS = reader["codigoOS"].ToString().PadLeft(5, '0');

                            ocCab.fechaEmision = reader["fechaEmision"].ToString();
                            ocCab.fechaEntrega = reader["fechaEntrega"].ToString();

                            ocCab.proveedorRS = reader["proveedorRS"] == DBNull.Value ? "" : reader["proveedorRS"].ToString().Trim();
                            ocCab.proveedorRUC = reader["proveedorRS"] == DBNull.Value ? "" : reader["proveedorRUC"].ToString().Trim();
                            ocCab.proveedorDireccion = reader["proveedorRS"] == DBNull.Value ? "" : reader["proveedorDireccion"].ToString().Trim();

                            ocCab.contacto = reader["contacto"] == DBNull.Value ? "" : reader["contacto"].ToString().Trim();
                            ocCab.telefono = reader["telefono"] == DBNull.Value ? "" : reader["telefono"].ToString().Trim();
                            ocCab.email = reader["email"] == DBNull.Value ? "" : reader["email"].ToString().Trim();

                            ocCab.tipoMoneda = reader["tipoMoneda"].ToString().Trim();
                            ocCab.tipoCompra = reader["tipoCompra"].ToString().Trim();
                            ocCab.formaPago = reader["formaPago"].ToString().Trim();
                            ocCab.tipoCambio = Convert.ToDecimal(reader["tipoCambio"]).ToString("N3");

                            ocCab.subTotal = Convert.ToDecimal(reader["subTotal"]).ToString("N2");
                            ocCab.descuento = Convert.ToDecimal(reader["descuento"]).ToString("N2");
                            ocCab.baseImponible = Convert.ToDecimal(reader["baseImponible"]).ToString("N2");
                            ocCab.igv = Convert.ToDecimal(reader["igv"]).ToString("N2");
                            ocCab.total = Convert.ToDecimal(reader["total"]).ToString("N2");

                            ocCab.montoLetras = reader["montoLetras"].ToString().Trim();
                            ocCab.simbolo = reader["simbolo"].ToString().Trim();
                            ocCab.observacion = reader["observacion"].ToString().Trim();
                            ocCab.programa = reader["nombrePrograma"].ToString().Trim();
                            ocCab.servicio = reader["nombreServicio"].ToString().Trim();
                        }
                    }
                }
            }

            return ocCab;
        }
        // ### REPORTE V2 ### 
        public OrdenServicioRpteCabModel Rpte9_OrdenServicioCabeceraV2(int idEmpresa, int idOC)
        {
            OrdenServicioRpteCabModel ocCab = new OrdenServicioRpteCabModel();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 22;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            ocCab = new OrdenServicioRpteCabModel();

                            ocCab.empresaRUC = reader["empresaRUC"].ToString();
                            ocCab.empresaDireccion = reader["empresaDireccion"].ToString().Trim();
                            ocCab.codigoOS = reader["codigoOS"].ToString().PadLeft(5, '0');

                            ocCab.fechaEmision = reader["fechaEmision"].ToString();
                            ocCab.fechaEntrega = reader["fechaEntrega"].ToString();

                            ocCab.proveedorRS = reader["proveedorRS"] == DBNull.Value ? "" : reader["proveedorRS"].ToString().Trim();
                            ocCab.proveedorRUC = reader["proveedorRS"] == DBNull.Value ? "" : reader["proveedorRUC"].ToString().Trim();
                            ocCab.proveedorDireccion = reader["proveedorRS"] == DBNull.Value ? "" : reader["proveedorDireccion"].ToString().Trim();

                            ocCab.contacto = reader["contacto"] == DBNull.Value ? "" : reader["contacto"].ToString().Trim();
                            ocCab.telefono = reader["telefono"] == DBNull.Value ? "" : reader["telefono"].ToString().Trim();
                            ocCab.email = reader["email"] == DBNull.Value ? "" : reader["email"].ToString().Trim();

                            ocCab.tipoMoneda = reader["tipoMoneda"].ToString().Trim();
                            ocCab.tipoCompra = reader["tipoCompra"].ToString().Trim();
                            ocCab.formaPago = reader["formaPago"].ToString().Trim();
                            ocCab.tipoCambio = Convert.ToDecimal(reader["tipoCambio"]).ToString("N3");

                            ocCab.subTotal = Convert.ToDecimal(reader["subTotal"]).ToString("N2");
                            ocCab.descuento = Convert.ToDecimal(reader["descuento"]).ToString("N2");
                            ocCab.baseImponible = Convert.ToDecimal(reader["baseImponible"]).ToString("N2");
                            ocCab.igv = Convert.ToDecimal(reader["igv"]).ToString("N2");
                            ocCab.total = Convert.ToDecimal(reader["total"]).ToString("N2");

                            ocCab.montoLetras = reader["montoLetras"].ToString().Trim();
                            ocCab.simbolo = reader["simbolo"].ToString().Trim();
                            ocCab.observacion = reader["observacion"].ToString().Trim();
                            ocCab.programa = reader["nombrePrograma"].ToString().Trim();
                            ocCab.servicio = reader["nombreServicio"].ToString().Trim();
                        }
                    }
                }
            }

            return ocCab;
        }
        public List<OrdenServicioRpteDetModel> Rpte10_OrdenServicioDetalle(int idEmpresa, int idOC)
        {
            List<OrdenServicioRpteDetModel> ocDets = new List<OrdenServicioRpteDetModel>();
            OrdenServicioRpteDetModel ocDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 10;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ocDet = new OrdenServicioRpteDetModel();
                            
                            ocDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"].ToString());

                            ocDet.idOS = Convert.ToInt32(reader["idOS"]);
                            ocDet.secuencia = Convert.ToInt32(reader["secuencia"]);

                            ocDet.codNivel = reader["codNivel"].ToString();
                            ocDet.codGrupo = reader["codGrupo"].ToString();
                            ocDet.codTalla = reader["codTalla"].ToString();
                            ocDet.codColor = reader["codColor"].ToString();
                            ocDet.codProductoGeneral = reader["codProductoGeneral"].ToString();

                            ocDet.producto = reader["producto"].ToString();
                            ocDet.color = reader["color"].ToString();

                            ocDet.codUM = reader["codUM"].ToString();

                            ocDet.cantidad = Convert.ToDecimal(reader["cantidad"]);
                            ocDet.igv = Convert.ToDecimal(reader["igv"]);
                            ocDet.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);
                            ocDet.total = Convert.ToDecimal(reader["total"]);

                            ocDet.obs1 = reader["obs1"].ToString();
                            ocDet.obs2 = reader["obs2"].ToString();
                            ocDet.obs3 = reader["obs3"].ToString();
                            ocDet.obs4 = reader["obs4"].ToString();
                            ocDet.obs5 = reader["obs5"].ToString();

                            ocDets.Add(ocDet);
                        }
                    }
                }
            }

            return ocDets;
        }
        public List<OrdenServicioRpteDetModelV2> Rpte10_OrdenServicioDetalleV2(int idEmpresa, int idOC)
        {
            List<OrdenServicioRpteDetModelV2> ocDets = new List<OrdenServicioRpteDetModelV2>();
            OrdenServicioRpteDetModelV2 ocDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 23;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ocDet = new OrdenServicioRpteDetModelV2();

                            ocDet.idPedidoColor = Convert.ToInt32(reader["idPedidoColor"].ToString());

                            ocDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"].ToString());

                            ocDet.idOS = Convert.ToInt32(reader["idOS"]);
                            ocDet.secuencia = Convert.ToInt32(reader["secuencia"]);

                            ocDet.pedido = reader["pedido"].ToString();
                            ocDet.codigoEstilo = reader["codigoEstilo"].ToString();
                            ocDet.estilo = reader["estilo"].ToString();
                            ocDet.color = reader["color"].ToString();
                            ocDet.codTalla = reader["codTalla"].ToString();
                            ocDet.tallaDescripcion = reader["tallaDescripcion"].ToString();

                            //ocDet.total = Convert.ToDecimal(reader["total"]);

                            ocDet.cantidad = Convert.ToDecimal(reader["cantidad"]);
 
                            ocDet.precio = Convert.ToDecimal(reader["precio"]);


                            ocDets.Add(ocDet);
                        }
                    }
                }
            }

            return ocDets;
        }

        public List<OrdenServicioRpteObsModel> Rpte17_OrdenServicioObservacion()
        {
            List<OrdenServicioRpteObsModel> observaciones = new List<OrdenServicioRpteObsModel>();
            OrdenServicioRpteObsModel observacion;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
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
                            observacion = new OrdenServicioRpteObsModel();

                            observacion.idObs = Convert.ToInt32(reader["idObs"]);
                            observacion.observacion = reader["observacion"].ToString();

                            observaciones.Add(observacion);
                        }
                    }
                }
            }

            return observaciones;
        }
        public List<OrdenServicioRpteFirmasModel> Rpte17_OrdenServicioFirmantes(int idEmpresa, int idOC)
        {
            List<OrdenServicioRpteFirmasModel> firmas = new List<OrdenServicioRpteFirmasModel>();
            OrdenServicioRpteFirmasModel firma;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 18;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            firma = new OrdenServicioRpteFirmasModel();

                            firma.firmante = reader["firmante"].ToString();
                            firma.rutaImgFirma = reader["rutaImgFirma"].ToString();
                            firma.nivelAprobacion = Convert.ToInt32(reader["nivelAprobacion"]); 

                            firmas.Add(firma);
                        }
                    }
                }
            }

            return firmas;
        }
        public List<OrdenServicioRpteFirmasModel> Rpte25_OrdenServicioFirmantes(int idEmpresa, int idOC)
        {
            List<OrdenServicioRpteFirmasModel> firmas = new List<OrdenServicioRpteFirmasModel>();
            OrdenServicioRpteFirmasModel firma;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 25;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = idEmpresa;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = idOC;

                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            firma = new OrdenServicioRpteFirmasModel();

                            firma.firmante = reader["firmante"].ToString();
                            firma.rutaImgFirma = reader["rutaImgFirma"].ToString();
                            firma.nivelAprobacion = Convert.ToInt32(reader["nivelAprobacion"]);

                            firmas.Add(firma);
                        }
                    }
                }
            }

            return firmas;
        }
        // ### SET ###
        public Response SetOS(SetOSParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOS";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOS", SqlDbType.Int).Value = parametros.idOS;
                    sqlCommand.Parameters.Add("@fechaEmision", SqlDbType.VarChar, 8).Value = parametros.fechaEmision;
                    sqlCommand.Parameters.Add("@fechaEntrega", SqlDbType.VarChar, 8).Value = parametros.fechaEntrega;
                    sqlCommand.Parameters.Add("@codigoPC", SqlDbType.VarChar, 15).Value = parametros.codigoPC;
                    sqlCommand.Parameters.Add("@idTipoMoneda", SqlDbType.Int).Value = parametros.idTipoMoneda;
                    sqlCommand.Parameters.Add("@tipoCompra", SqlDbType.VarChar, 1).Value = parametros.tipoCompra;
                    sqlCommand.Parameters.Add("@idCondPago", SqlDbType.Int).Value = parametros.idCondPago;
                    sqlCommand.Parameters.Add("@idTipoAprobacion", SqlDbType.Int).Value = parametros.idTipoAprobacion;
                    sqlCommand.Parameters.Add("@idTipoAnulado", SqlDbType.Int).Value = parametros.idTipoAnulado;
                    sqlCommand.Parameters.Add("@fechaAnulado", SqlDbType.VarChar, 8).Value = parametros.fechaAnulado;
                    sqlCommand.Parameters.Add("@usuarioAnulado", SqlDbType.VarChar, 8).Value = parametros.usuarioAnulado;
                    sqlCommand.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar, 50).Value = parametros.usuarioRegistro;
                    sqlCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 350).Value = parametros.observacion;
                    sqlCommand.Parameters.Add("@codPrograma", SqlDbType.VarChar, 10).Value = parametros.CodPrograma;
                    sqlCommand.Parameters.Add("@codServicio", SqlDbType.VarChar, 10).Value = parametros.CodServicio;

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


        public Response SetOrdenSalida(SetOSParam parametros, string almacen)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOrdenSalida";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOrdenSalida", SqlDbType.Int).Value = parametros.idOS;
                    sqlCommand.Parameters.Add("@fechaEmision", SqlDbType.VarChar, 8).Value = parametros.fechaEmision;
                    sqlCommand.Parameters.Add("@fechaEntrega", SqlDbType.VarChar, 8).Value = parametros.fechaEntrega;
                    sqlCommand.Parameters.Add("@codigoPC", SqlDbType.VarChar, 15).Value = parametros.codigoPC;
                    sqlCommand.Parameters.Add("@idTipoMoneda", SqlDbType.Int).Value = parametros.idTipoMoneda;
                    sqlCommand.Parameters.Add("@tipoSalida", SqlDbType.VarChar, 1).Value = parametros.tipoCompra;
                    sqlCommand.Parameters.Add("@idCondPago", SqlDbType.Int).Value = parametros.idCondPago;
                    sqlCommand.Parameters.Add("@idTipoAprobacion", SqlDbType.Int).Value = parametros.idTipoAprobacion;
                    sqlCommand.Parameters.Add("@idTipoAnulado", SqlDbType.Int).Value = parametros.idTipoAnulado;
                    sqlCommand.Parameters.Add("@fechaAnulado", SqlDbType.VarChar, 8).Value = parametros.fechaAnulado;
                    sqlCommand.Parameters.Add("@usuarioAnulado", SqlDbType.VarChar, 8).Value = parametros.usuarioAnulado;
                    sqlCommand.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar, 50).Value = parametros.usuarioRegistro;
                    sqlCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 350).Value = parametros.observacion;
                    sqlCommand.Parameters.Add("@codPrograma", SqlDbType.VarChar, 10).Value = parametros.CodPrograma;
                    sqlCommand.Parameters.Add("@codServicio", SqlDbType.VarChar, 10).Value = parametros.CodServicio;
                    sqlCommand.Parameters.Add("@almacen", SqlDbType.VarChar, 10).Value = almacen;

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



        // SET OS ESPECIAL
        public Response SetOSEspecial(SetOSParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOSEspecial";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOS", SqlDbType.Int).Value = parametros.idOS;
                    sqlCommand.Parameters.Add("@fechaEmision", SqlDbType.VarChar, 8).Value = parametros.fechaEmision;
                    sqlCommand.Parameters.Add("@fechaEntrega", SqlDbType.VarChar, 8).Value = parametros.fechaEntrega;
                    sqlCommand.Parameters.Add("@codigoPC", SqlDbType.VarChar, 15).Value = parametros.codigoPC;
                    sqlCommand.Parameters.Add("@idTipoMoneda", SqlDbType.Int).Value = parametros.idTipoMoneda;
                    sqlCommand.Parameters.Add("@tipoCompra", SqlDbType.VarChar, 1).Value = parametros.tipoCompra;
                    sqlCommand.Parameters.Add("@idCondPago", SqlDbType.Int).Value = parametros.idCondPago;
                    sqlCommand.Parameters.Add("@idTipoAprobacion", SqlDbType.Int).Value = parametros.idTipoAprobacion;
                    sqlCommand.Parameters.Add("@idTipoAnulado", SqlDbType.Int).Value = parametros.idTipoAnulado;
                    sqlCommand.Parameters.Add("@fechaAnulado", SqlDbType.VarChar, 8).Value = parametros.fechaAnulado;
                    sqlCommand.Parameters.Add("@usuarioAnulado", SqlDbType.VarChar, 8).Value = parametros.usuarioAnulado;
                    sqlCommand.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar, 50).Value = parametros.usuarioRegistro;
                    sqlCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 350).Value = parametros.observacion;
                    sqlCommand.Parameters.Add("@codPrograma", SqlDbType.VarChar, 10).Value = parametros.CodPrograma;
                    sqlCommand.Parameters.Add("@codServicio", SqlDbType.VarChar, 10).Value = parametros.CodServicio;

                    sqlCommand.Parameters.Add("@secuencia", SqlDbType.Int).Value = parametros.secuencia;
                    sqlCommand.Parameters.Add("@idpedidocolor", SqlDbType.Int).Value = parametros.idPedidoColor;
                    sqlCommand.Parameters.Add("@precio", SqlDbType.Decimal).Value = parametros.precio;
                    sqlCommand.Parameters.Add("@codtalla", SqlDbType.VarChar, 10).Value = parametros.codTalla;
                    sqlCommand.Parameters.Add("@cantidad", SqlDbType.Int).Value = parametros.cantidad;


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
        public Response SetOSDetalle(SetOSDetParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOSDetalle";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOS", SqlDbType.Int).Value = parametros.idOS;
                    sqlCommand.Parameters.Add("@secuencia", SqlDbType.Int).Value = parametros.secuencia;

                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 2).Value = parametros.codNivel;
                    sqlCommand.Parameters.Add("@codGrupo", SqlDbType.VarChar, 5).Value = parametros.codGrupo;
                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 3).Value = parametros.codTalla;
                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 6).Value = parametros.codColor;

                    sqlCommand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = parametros.cantidad;
                    sqlCommand.Parameters.Add("@igv", SqlDbType.Decimal).Value = parametros.igv;
                    sqlCommand.Parameters.Add("@precioUnitario", SqlDbType.Decimal).Value = parametros.precioUnitario;

                    sqlCommand.Parameters.Add("@obs1", SqlDbType.VarChar).Value = parametros.obs1;
                    sqlCommand.Parameters.Add("@obs2", SqlDbType.VarChar).Value = parametros.obs2;
                    sqlCommand.Parameters.Add("@obs3", SqlDbType.VarChar).Value = parametros.obs3;
                    sqlCommand.Parameters.Add("@obs4", SqlDbType.VarChar).Value = parametros.obs4;
                    sqlCommand.Parameters.Add("@obs5", SqlDbType.VarChar).Value = parametros.obs5;

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

        public Response SetOrdenSalidaDetalle(SetOSDetParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOrdenSalidaDetalle";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOrdenSalida", SqlDbType.Int).Value = parametros.idOS;
                    sqlCommand.Parameters.Add("@secuencia", SqlDbType.Int).Value = parametros.secuencia;

                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 2).Value = parametros.codNivel;
                    sqlCommand.Parameters.Add("@codGrupo", SqlDbType.VarChar, 5).Value = parametros.codGrupo;
                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 3).Value = parametros.codTalla;
                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 6).Value = parametros.codColor;

                    sqlCommand.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = parametros.cantidad;
                    sqlCommand.Parameters.Add("@igv", SqlDbType.Decimal).Value = parametros.igv;
                    sqlCommand.Parameters.Add("@precioUnitario", SqlDbType.Decimal).Value = parametros.precioUnitario;

                    sqlCommand.Parameters.Add("@obs1", SqlDbType.VarChar).Value = parametros.obs1;
                    sqlCommand.Parameters.Add("@obs2", SqlDbType.VarChar).Value = parametros.obs2;
                    sqlCommand.Parameters.Add("@obs3", SqlDbType.VarChar).Value = parametros.obs3;
                    sqlCommand.Parameters.Add("@obs4", SqlDbType.VarChar).Value = parametros.obs4;
                    sqlCommand.Parameters.Add("@obs5", SqlDbType.VarChar).Value = parametros.obs5;

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

        public Response SetOSTipoAprobacion(SetOSTipoAprobParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOSTipoAprobacion";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idTipoAprobacion", SqlDbType.Int).Value = parametros.idTipoAprobacion;
                    sqlCommand.Parameters.Add("@idTipoAprobacionUpdate", SqlDbType.Int).Value = parametros.idTipoAprobacionUpdate;
                    sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = parametros.descripcion;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;
                    sqlCommand.Parameters.Add("@nivelAprobacion", SqlDbType.Int).Value = parametros.nivelAprobacion;
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
        public Response SetOSTipoAnulado(SetOSTipoAnuladoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOSTipoAnulado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idTipoAnulado", SqlDbType.Int).Value = parametros.idTipoAnulado;
                    sqlCommand.Parameters.Add("@idTipoAnuladoUpdate", SqlDbType.Int).Value = parametros.idTipoAnuladoUpdate;
                    sqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = parametros.descripcion;
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
        public Response SetOSFirmantes(SetOSFirmantesParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOSFirmantes";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = parametros.idUsuario;
                    sqlCommand.Parameters.Add("@idTipoAprobacion", SqlDbType.Int).Value = parametros.idTipoAprobacion;
                    sqlCommand.Parameters.Add("@idUsuarioUpdate", SqlDbType.Int).Value = parametros.idUsuarioUpdate;
                    sqlCommand.Parameters.Add("@idTipoAprobacionUpdate", SqlDbType.Int).Value = parametros.idTipoAprobacionUpdate;


                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;
                    sqlCommand.Parameters.Add("@usuReg", SqlDbType.VarChar, 50).Value = parametros.usuReg;
                    sqlCommand.Parameters.Add("@rutaImgFirma", SqlDbType.VarChar, 300).Value = parametros.rutaImgFirma;

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
        public Response SetOSObservacion(SetOSObservacionParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOSObservacion";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;

                    sqlCommand.Parameters.Add("@idObs", SqlDbType.Int).Value = parametros.idObs;
                    sqlCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 90).Value = parametros.observacion;

                    sqlCommand.Parameters.Add("@estado", SqlDbType.Bit).Value = parametros.estado;
                    sqlCommand.Parameters.Add("@usuReg", SqlDbType.VarChar, 50).Value = parametros.usuReg;

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
        public Response SetOSAprobacion(SetOSAprobacionParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOSAprobacion";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOS", SqlDbType.Int).Value = parametros.idOS;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = parametros.idUsuario;
                    sqlCommand.Parameters.Add("@idTipoAprobacion", SqlDbType.Int).Value = parametros.idTipoAprobacion;
                    sqlCommand.Parameters.Add("@nivelAprobacion", SqlDbType.Int).Value = parametros.nivelAprobacion;
                    
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

        public Response SetOrdenSalidaAprobacion(SetOSAprobacionParam parametros, string tipoOrden)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOrdenSalidaAprobacion";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOrdenSalida", SqlDbType.Int).Value = parametros.idOS;
                    sqlCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = parametros.idUsuario;
                    sqlCommand.Parameters.Add("@idTipoAprobacion", SqlDbType.Int).Value = parametros.idTipoAprobacion;
                    sqlCommand.Parameters.Add("@nivelAprobacion", SqlDbType.Int).Value = parametros.nivelAprobacion;
                    sqlCommand.Parameters.Add("@tipoOrden", SqlDbType.VarChar).Value = tipoOrden;

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

