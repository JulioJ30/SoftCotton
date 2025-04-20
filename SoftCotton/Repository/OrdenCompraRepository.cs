using SoftCotton.Database;
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Reports.PurchaseOrder;
using SoftCotton.Reports.PurchaseOrder.OrdenCompra;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class OrdenCompraRepository
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
                    sqlCommand.CommandText = @"uspGetOC";
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
                    sqlCommand.CommandText = @"uspGetOC";
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
                    sqlCommand.CommandText = @"uspGetOC";
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
        public List<GetOC5_TipoAprobacion> Get5_TipoAprobaciones()
        {
            List<GetOC5_TipoAprobacion> tipoAprobaciones = new List<GetOC5_TipoAprobacion>();
            GetOC5_TipoAprobacion tipoAprobacion;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            tipoAprobacion = new GetOC5_TipoAprobacion();
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
        public List<GetOC6_TipoAnulado> Get6_TipoAnulados()
        {
            List<GetOC6_TipoAnulado> tipoAnulados = new List<GetOC6_TipoAnulado>();
            GetOC6_TipoAnulado tipoAnulado;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            tipoAnulado = new GetOC6_TipoAnulado();
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
        public GetOC7_OCCabXCodigo Get7_OCCabXCodigo(int idEmpresa, int idOC)
        {
            GetOC7_OCCabXCodigo ocCab = new GetOC7_OCCabXCodigo();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;
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

                            ocCab.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocCab.idOC = Convert.ToInt32(reader["idOC"]);
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
        public List<GetOC8_OCDetXCodigo> Get8_OCDetXCodigo(int idEmpresa, int idOC)
        {
            List<GetOC8_OCDetXCodigo> ocDets = new List<GetOC8_OCDetXCodigo>();
            GetOC8_OCDetXCodigo ocDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            ocDet = new GetOC8_OCDetXCodigo();

                            ocDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocDet.idOC = Convert.ToInt32(reader["idOC"]);
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
        public List<GetOC11_Firmantes> Get11_Firmantes(int idEmpresa)
        {
            List<GetOC11_Firmantes> firmantes = new List<GetOC11_Firmantes>();
            GetOC11_Firmantes firmante;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            firmante = new GetOC11_Firmantes();

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
                    sqlCommand.CommandText = @"uspGetOC";
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
                    sqlCommand.CommandText = @"uspGetOC";
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
        public List<GetOC14_Observaciones> Get14_Observaciones()
        {
            List<GetOC14_Observaciones> observaciones = new List<GetOC14_Observaciones>();
            GetOC14_Observaciones observacion;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            observacion = new GetOC14_Observaciones();

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
        public GetOC15_FirmanteXNivel Get15_FirmanteXNivel(int idUsuario, int nivelAprobacion)
        {
            GetOC15_FirmanteXNivel firmante = new GetOC15_FirmanteXNivel();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            firmante = new GetOC15_FirmanteXNivel();

                            firmante.idUsuario = Convert.ToInt32(reader["idUsuario"]);
                            firmante.idTipoAprobacion = Convert.ToInt32(reader["idTipoAprobacion"]);
                            firmante.nivelAprobacion = Convert.ToInt32(reader["nivelAprobacion"]);
                        }
                    }
                }
            }

            return firmante;
        }
        public List<GetOC16_Firmantes> Get16_Firmantes(int idEmpresa, int oc)
        {
            List<GetOC16_Firmantes> firmantes = new List<GetOC16_Firmantes>();
            GetOC16_Firmantes firma;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            firma = new GetOC16_Firmantes();

                            firma.firmante = reader["firmante"].ToString();
                            firma.tipoAprobacion = reader["tipoAprobacion"].ToString();

                            firmantes.Add(firma);
                        }
                    }
                }
            }

            return firmantes;
        }

        public List<GetOC19_Reporte> Get19_Reporte(string fechaInicio, string fechaFin)
        {
            List<GetOC19_Reporte> ocs = new List<GetOC19_Reporte>();
            GetOC19_Reporte oc;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            oc = new GetOC19_Reporte();

                            oc.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            oc.idOC = Convert.ToInt32(reader["idOC"]);
                            oc.fechaEmision = reader["fechaEmision"].ToString();
                            oc.fechaEntrega = reader["fechaEntrega"].ToString();
                            oc.codigoPC = reader["codigoPC"].ToString();
                            oc.razonsocial = reader["razonsocial"].ToString().Trim();
                            oc.tipoMoneda = reader["tipoMoneda"].ToString();
                            oc.tipoCompra = reader["tipoCompra"].ToString();
                            oc.condicion = reader["condicion"].ToString();
                            oc.estadooc = reader["estadooc"].ToString();
                            oc.usuCreacionReg = reader["usuCreacionReg"].ToString();
                            oc.usuFechaReg = reader["usuFechaReg"].ToString();
                            oc.observacion = reader["observacion"].ToString();
                            oc.codNivel = reader["codNivel"].ToString();
                            oc.codGrupo = reader["codGrupo"].ToString();
                            oc.codTalla = reader["codTalla"].ToString();
                            oc.codColor = reader["codColor"].ToString();
                            oc.codProductoGeneral = reader["codProductoGeneral"].ToString();
                            oc.producto = reader["producto"].ToString();
                            oc.color = reader["color"].ToString();
                            oc.cantidad = Convert.ToDecimal(reader["cantidad"]);
                            oc.codUM = reader["codUM"].ToString();
                            oc.igv = Convert.ToDecimal(reader["igv"]);
                            oc.precioUnitario = Convert.ToDecimal(reader["precioUnitario"]);
                            oc.total = Convert.ToDecimal(reader["total"]);
                            oc.obs1 = reader["obs1"].ToString();
                            oc.obs2 = reader["obs2"].ToString();
                            oc.obs3 = reader["obs3"].ToString();
                            oc.obs4 = reader["obs4"].ToString();
                            oc.obs5 = reader["obs5"].ToString();
                            oc.programa = reader["programa"].ToString();


                            ocs.Add(oc);
                        }
                    }
                }
            }

            return ocs;
        }


        // ### REPORTE ###
        public OrdenCompraRpteCabModel Rpte9_OrdenCompraCabecera(int idEmpresa, int idOC)
        {
            OrdenCompraRpteCabModel ocCab = new OrdenCompraRpteCabModel();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            ocCab = new OrdenCompraRpteCabModel();

                            ocCab.empresaRUC = reader["empresaRUC"].ToString();
                            ocCab.empresaDireccion = reader["empresaDireccion"].ToString().Trim();
                            ocCab.codigoOC = reader["codigoOC"].ToString().PadLeft(5, '0');

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
                        }
                    }
                }
            }

            return ocCab;
        }
        public List<OrdenCompraRpteDetModel> Rpte10_OrdenCompraDetalle(int idEmpresa, int idOC)
        {
            List<OrdenCompraRpteDetModel> ocDets = new List<OrdenCompraRpteDetModel>();
            OrdenCompraRpteDetModel ocDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            ocDet = new OrdenCompraRpteDetModel();

                            ocDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocDet.idOC = Convert.ToInt32(reader["idOC"]);
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
        public List<OrdenCompraRpteObsModel> Rpte17_OrdenCompraObservacion()
        {
            List<OrdenCompraRpteObsModel> observaciones = new List<OrdenCompraRpteObsModel>();
            OrdenCompraRpteObsModel observacion;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            observacion = new OrdenCompraRpteObsModel();

                            observacion.idObs = Convert.ToInt32(reader["idObs"]);
                            observacion.observacion = reader["observacion"].ToString();

                            observaciones.Add(observacion);
                        }
                    }
                }
            }

            return observaciones;
        }
        public List<OrdenCompraRpteFirmasModel> Rpte17_OrdenCompraFirmantes(int idEmpresa, int idOC)
        {
            List<OrdenCompraRpteFirmasModel> firmas = new List<OrdenCompraRpteFirmasModel>();
            OrdenCompraRpteFirmasModel firma;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
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
                            firma = new OrdenCompraRpteFirmasModel();

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
        public Response SetOC(SetOCParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOC";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOC", SqlDbType.Int).Value = parametros.idOC;
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
        public Response SetOCDetalle(SetOCDetParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOCDetalle";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOC", SqlDbType.Int).Value = parametros.idOC;
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
        public Response SetOCTipoAprobacion(SetOCTipoAprobParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOCTipoAprobacion";
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
        public Response SetOCTipoAnulado(SetOCTipoAnuladoParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOCTipoAnulado";
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
        public Response SetOCFirmantes(SetOCFirmantesParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOCFirmantes";
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
        public Response SetOCObservacion(SetOCObservacionParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOCObservacion";
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
        public Response SetOCAprobacion(SetOCAprobacionParam parametros)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspSetOCAprobacion";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = parametros.opcion;
                    sqlCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = parametros.idEmpresa;
                    sqlCommand.Parameters.Add("@idOC", SqlDbType.Int).Value = parametros.idOC;
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


        // DETALLE MODIFICADO
        public List<OrdenCompraRpteDetModelV2> Rpte10_OrdenCompraDetalleV2(int idEmpresa, int idOC)
        {
            List<OrdenCompraRpteDetModelV2> ocDets = new List<OrdenCompraRpteDetModelV2>();
            OrdenCompraRpteDetModelV2 ocDet;

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetOC";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 20;
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
                            ocDet = new OrdenCompraRpteDetModelV2();

                            ocDet.idEmpresa = Convert.ToInt32(reader["idEmpresa"]);
                            ocDet.idOC = Convert.ToInt32(reader["idOC"]);   
                            ocDet.codNivel = reader["codNivel"].ToString();
                            ocDet.codColor = reader["codColor"].ToString();
                            ocDet.codProductoGeneral = reader["codProductoGeneral"].ToString();

                            ocDet.producto = reader["producto"].ToString();
                            ocDet.color = reader["color"].ToString();


                            ocDet.cantidad = Convert.ToDecimal(reader["cantidad"].ToString());

                            decimal precioUnitario = Convert.ToDecimal(reader["precioUnitario"].ToString());

                            ocDet.precioUnitario = Convert.ToDecimal(precioUnitario.ToString("F2"));

                            //ocDet.precioUnitario = Convert.ToDecimal(String.Format("{0:0.00}", reader["precioUnitario"].ToString()));




                            ocDet.codTalla = reader["codTalla"].ToString();
                            ocDet.tallaDescripcion = reader["tallaDescripcion"].ToString();



                            ocDet.Tallas = new OrdenCompraRpteDetModelTallaV2()
                            {
                                codTalla = reader["color"].ToString(),
                                tallaDescripcion = reader["tallaDescripcion"].ToString(),
                                cantidad = Convert.ToDecimal(reader["cantidad"].ToString()),

                            };



                            ocDets.Add(ocDet);
                        }
                    }
                }
            }

            return ocDets;
        }
    }
}

