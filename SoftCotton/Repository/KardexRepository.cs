
using Org.BouncyCastle.Math.EC.Multiplier;
using SoftCotton.Database;
using SoftCotton.Model.Kardex;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using SoftCotton.Views.Requerimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SoftCotton.Repository
{
    public class KardexRepository
    {
        // ### GET ###
        public Response GetValidarKadex(string codNivel, string codGrupo, string codTalla, string codColor)
        {
            Response response = new Response();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetValidarkardex";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 50).Value = codNivel;
                    sqlCommand.Parameters.Add("@codGrupo", SqlDbType.VarChar, 50).Value = codGrupo;
                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 50).Value = codTalla;
                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 50).Value = codColor;

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

        //uspGetMovimientoKardexValorizado
        public List<KardexValorizado> uspGetMovimientoKardexValorizado(string codNivel, string codCuenta, string codGrupo, string codTalla, string codColor, string periodo)
        {
            List<KardexValorizado> listv2 = new List<KardexValorizado>();
            List<KardexValorizado> list = new List<KardexValorizado>();
            KardexValorizado det = new KardexValorizado();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetkardexPrincipalValorizado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    codNivel = (codNivel == "00") ? "" : codNivel;

                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 50).Value = codNivel;
                    sqlCommand.Parameters.Add("@codCuenta", SqlDbType.VarChar, 50).Value = (codCuenta == "" ? "0" : codCuenta);
                    sqlCommand.Parameters.Add("@codGrupo", SqlDbType.VarChar, 50).Value = codGrupo;
                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 50).Value = codTalla;
                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 50).Value = codColor;
                    sqlCommand.Parameters.Add("@periodo", SqlDbType.VarChar, 50).Value = periodo;
                    //sqlCommand.Parameters.Add("@fechafin", SqlDbType.VarChar, 50).Value = fechafin;
                    sqlCommand.CommandTimeout = 3000;
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    int c = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            det = new KardexValorizado();

                            det.orden = Convert.ToInt32(reader["orden"].ToString());
                            det.cuo = Convert.ToString(reader["cuo"].ToString());

                            det.tipo = Convert.ToString(reader["tipo"].ToString());
                            det.cod = Convert.ToString(reader["cod"].ToString());
                            det.Nombre_Articulo = Convert.ToString(reader["Nombre_Articulo"].ToString());
                            det.color = Convert.ToString(reader["color"].ToString());
                            det.Fecha_Guia = Convert.ToDateTime(reader["Fecha_Guia"].ToString());
                            det.serie = Convert.ToString(reader["serie"].ToString());
                            det.numero = Convert.ToString(reader["numero"].ToString());
                            det.codigo_Proveedor = Convert.ToString(reader["codigo_Proveedor"].ToString());
                            det.razonSocial = Convert.ToString(reader["razonSocial"].ToString());
                            det.serie_fact = Convert.ToString(reader["serie_fact"].ToString());
                            det.Num_fact = Convert.ToString(reader["Num_fact"].ToString());
                            det.tipoCambio = Convert.ToDecimal(reader["tipoCambio"].ToString());
                            det.Tipo_Moneda = Convert.ToString(reader["Tipo_Moneda"].ToString());
                            det.codigo = Convert.ToString(reader["codigo"].ToString());
                            det.UM = Convert.ToString(reader["UM"].ToString());
                            det.PU = Convert.ToDecimal(reader["PU"].ToString());
                            det.fact_tipo = Convert.ToString(reader["fact_tipo"].ToString());
                            det.mes = Convert.ToString(reader["mes"].ToString());
                            det.tipoMovimiento = Convert.ToString(reader["tipoMovimiento"].ToString());
                            det.cantidadSolesE = Convert.ToDecimal(reader["cantidadSolesE"].ToString());
                            det.PUCalcSolesE = Convert.ToDecimal(reader["PUCalcSolesE"].ToString());
                            det.TotalSolesE = Convert.ToDecimal(reader["TotalSolesE"].ToString());
                            det.cantidadSolesS = Convert.ToDecimal(reader["cantidadSolesS"].ToString());
                            det.PUCalcSolesS = Convert.ToDecimal(reader["PUCalcSolesS"].ToString());
                            det.TotalSolesS = Convert.ToDecimal(reader["TotalSolesS"].ToString());
                            det.SaldocantidadSolesS = Convert.ToDecimal(reader["saldoCantidad"].ToString());
                            det.SaldoPUCalcSolesS = Convert.ToDecimal(reader["SaldoPuSoles"].ToString());
                            det.SaldoTotalSolesS = Convert.ToDecimal(reader["SaldoValorSoles"].ToString());

                            det.tpo_opera = Convert.ToString(reader["tpo_opera"].ToString());


                            list.Add(det);

                        }
                    }
                }
            }

            
            return list;
        }



        public List<KardexValorizadoPrincipal> uspGetMovimientoKardex(string codNivel, string codCuenta, string codGrupo, string codTalla, string codColor, string fechaIni, string fechafin)
        {
            List<KardexValorizadoPrincipal> listv2 = new List<KardexValorizadoPrincipal>();
            List<KardexValorizadoPrincipal> list = new List<KardexValorizadoPrincipal>();
            KardexValorizadoPrincipal det = new KardexValorizadoPrincipal();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetkardexPrincipal";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    codNivel = (codNivel == "00") ? "" : codNivel;

                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 50).Value = codNivel;
                    sqlCommand.Parameters.Add("@codCuenta", SqlDbType.VarChar, 50).Value = (codCuenta == "" ? "0" : codCuenta);
                    sqlCommand.Parameters.Add("@codGrupo", SqlDbType.VarChar, 50).Value = codGrupo;
                    sqlCommand.Parameters.Add("@codTalla", SqlDbType.VarChar, 50).Value = codTalla;
                    sqlCommand.Parameters.Add("@codColor", SqlDbType.VarChar, 50).Value = codColor;
                    sqlCommand.Parameters.Add("@fechaIni", SqlDbType.VarChar, 50).Value = fechaIni;
                    sqlCommand.Parameters.Add("@fechafin", SqlDbType.VarChar, 50).Value = fechafin;
                    sqlCommand.CommandTimeout = 3000;
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    int c = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            det = new KardexValorizadoPrincipal();

                            det.orden = Convert.ToInt32(reader["orden"].ToString());
                            det.tipo = Convert.ToString(reader["tipo"].ToString());
                            det.cod = Convert.ToString(reader["cod"].ToString());
                            det.Nombre_Articulo = Convert.ToString(reader["Nombre_Articulo"].ToString());
                            det.color = Convert.ToString(reader["color"].ToString());
                            det.Fecha_Guia = Convert.ToDateTime(reader["Fecha_Guia"].ToString());
                            det.serie = Convert.ToString(reader["serie"].ToString());
                            det.numero = Convert.ToString(reader["numero"].ToString());
                            det.codigo_Proveedor = Convert.ToString(reader["codigo_Proveedor"].ToString());
                            det.razonSocial = Convert.ToString(reader["razonSocial"].ToString());
                            det.serie_fact = Convert.ToString(reader["serie_fact"].ToString());
                            det.Num_fact = Convert.ToString(reader["Num_fact"].ToString());
                            det.tipoCambio = Convert.ToDecimal(reader["tipoCambio"].ToString());
                            det.Tipo_Moneda = Convert.ToString(reader["Tipo_Moneda"].ToString());
                            det.codigo = Convert.ToString(reader["codigo"].ToString());
                            det.UM = Convert.ToString(reader["UM"].ToString());
                            det.PU = Convert.ToDecimal(reader["PU"].ToString());
                            det.fact_tipo = Convert.ToString(reader["fact_tipo"].ToString());
                            det.mes = Convert.ToString(reader["mes"].ToString());
                            det.tipoMovimiento = Convert.ToString(reader["tipoMovimiento"].ToString());
                            det.cantidadSolesE = Convert.ToDecimal(reader["cantidadSolesE"].ToString());
                            det.PUCalcSolesE = Convert.ToDecimal(reader["PUCalcSolesE"].ToString());
                            det.TotalSolesE = Convert.ToDecimal(reader["TotalSolesE"].ToString());
                            det.cantidadSolesS = Convert.ToDecimal(reader["cantidadSolesS"].ToString());
                            det.PUCalcSolesS = Convert.ToDecimal(reader["PUCalcSolesS"].ToString());
                            det.TotalSolesS = Convert.ToDecimal(reader["TotalSolesS"].ToString());
                            det.SaldocantidadSolesS = Convert.ToDecimal(reader["saldoCantidad"].ToString());
                            det.SaldoPUCalcSolesS = Convert.ToDecimal(reader["SaldoPuSoles"].ToString());
                            det.SaldoTotalSolesS = Convert.ToDecimal(reader["SaldoValorSoles"].ToString());
                            det.Secuencia = Convert.ToInt32(reader["Secuencia"].ToString());



                            list.Add(det);

                        }
                    }
                }
            }

            //listv2 = list.OrderBy(x => x.item).ToList();
            return list;
        }

        public List<KardexElectronico> uspGetkardexElectronicovalorizado(string codNivel, string codCuenta,  string desde, string hasta, string codigo)
        {
            List<KardexElectronico> listv2 = new List<KardexElectronico>();
            List<KardexElectronico> list = new List<KardexElectronico>();
            KardexElectronico det = new KardexElectronico();

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetkardexElectronicovalorizado";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@codNivel", SqlDbType.VarChar, 50).Value = codNivel;
                    sqlCommand.Parameters.Add("@codCuenta", SqlDbType.VarChar, 50).Value = codCuenta;
                    sqlCommand.Parameters.Add("@desde", SqlDbType.VarChar, 50).Value = desde;
                    sqlCommand.Parameters.Add("@hasta", SqlDbType.VarChar, 50).Value = hasta;
                    sqlCommand.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = codigo;
                    sqlCommand.CommandTimeout = 3000;
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    int c = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            det = new KardexElectronico();

                            //c = c + 1;
                            //det.item = c;
                     
                            det.MATERIAL = Convert.ToString(reader["MATERIAL"].ToString());
                            det.TPO_MATERIAL = Convert.ToString(reader["TPO_MATERIAL"].ToString());
                            det.N_CUBSO = Convert.ToString(reader["N_CUBSO"].ToString());
                            det.N_LOGISTICA = Convert.ToString(reader["N_LOGISTICA"].ToString());
                            det.N_CONTAB = Convert.ToString(reader["N_CONTAB"].ToString());



                            det.PERIODO = Convert.ToString(reader["PERIODO"].ToString()); // 1
                            det.CUO = Convert.ToString(reader["CUO"].ToString()); // 2
                            det.NUMERO_CORRELATIVO = Convert.ToString(reader["NUMERO_CORRELATIVO"].ToString()); // 3
                            det.COD_ESTABLECIMIENTO = Convert.ToString(reader["COD_ESTABLECIMIENTO"].ToString()); // 4
                            det.ESTABLEC = Convert.ToString(reader["ESTABLEC"].ToString());
                            det.COD_CATALOGO = Convert.ToString(reader["COD_CATALOGO"].ToString()); // 5
                            det.TIPO_EXISTENCIA = Convert.ToString(reader["TIPO_EXISTENCIA"].ToString()); // 6
                            det.CODIGO_PROPIO_EXISTENCIA = Convert.ToString(reader["CODIGO_PROPIO_EXISTENCIA"].ToString()); // 7
                            det.CATALOGO_UNICO_BIENES = Convert.ToString(reader["CATALOGO_UNICO_BIENES"].ToString()); // 8
                            det.CODIGO_EXISTENCIA_UNSPSC = Convert.ToString(reader["CODIGO_EXISTENCIA_UNSPSC"].ToString()); // 9
                            det.FECHA = Convert.ToDateTime(reader["FECHA"].ToString()); // 10
                            det.TIPO_DOC = Convert.ToString(reader["TIPO_DOC"].ToString()); // 11
                            det.N_SERIE = Convert.ToString(reader["N_SERIE"].ToString());   // 12
                            det.N_DOCUMENTO = Convert.ToString(reader["N_DOCUMENTO"].ToString());   // 13
                            det.TPO_OPERA = Convert.ToString(reader["TPO_OPERA"].ToString());   // 14
                            det.DESC_MATERIAL = Convert.ToString(reader["DESC_MATERIAL"].ToString()); // 15
                            det.UNID_MED = Convert.ToString(reader["UNID_MED"].ToString()); // 16
                            det.CODIGO_METODO_VAL = Convert.ToString(reader["CODIGO_METODO_VAL"].ToString()); // 17
                            det.METODO_VAL = Convert.ToString(reader["METODO_VAL"].ToString());
                            det.CANT_ENTRADA = Convert.ToDouble(reader["CANT_ENTRADA"].ToString()); // 18
                            det.Costo_Unit_Entrada = Convert.ToDouble(reader["Costo_Unit_Entrada"].ToString()); // 19
                            det.Costo_Total_Entrada = Convert.ToDouble(reader["Costo_Total_Entrada"].ToString()); // 20

                            det.CANT_SALIDA = Convert.ToDouble(reader["CANT_SALIDA"].ToString()); // 21
                            det.Costo_Unit_Salida = Convert.ToDouble(reader["Costo_Unit_Salida"].ToString()); // 22
                            det.Costo_Total_Salida = Convert.ToDouble(reader["Costo_Total_Salida"].ToString()); // 23

                            det.Cantidad_Final = Convert.ToDouble(reader["Cantidad_Final"].ToString()); // 24
                            det.Costo_Unit_Final = Convert.ToDouble(reader["Costo_Unit_Final"].ToString()); // 25
                            det.Costo_Total_Final = Convert.ToDouble(reader["Costo_Total_Final"].ToString()); // 26
                            det.Est_Op = Convert.ToInt32(reader["Est_Op"].ToString()); // 27
                           
                       

                            list.Add(det);

                        }
                    }
                }
            }

            //listv2 = list.OrderBy(x => x.item).ToList();
            return list;
        }

        public DataTable GetListArticulos(string filtro)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetListArticulos";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@filtro", SqlDbType.VarChar, 200).Value = filtro.ToString();
                    
                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }
            }
        }

        public DataTable GetListarNiveles(string filtro)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"GetListarNiveles";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@filtro", SqlDbType.VarChar, 200).Value = filtro.ToString();

                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }
            }
        }

        public DataTable GetKardexCentral(string filtro)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 59;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtro.ToString();
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }
            }
        }

        public DataTable GetKardexCentralMovimientos(string filtro)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 60;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtro.ToString();
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = "";
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;
                    sqlCommand.CommandTimeout = 1000;
                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }


            }
        }

        public DataTable GetKardexCentralMovimientosFecha(int tipo, string fechaInicio, string fechaFin, string codigo, string nivel)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetkardex_Movimiento_fecha";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                    sqlCommand.Parameters.Add("@fecha_inicio", SqlDbType.Date).Value = Convert.ToDateTime(fechaInicio);
                    sqlCommand.Parameters.Add("@fecha_fin", SqlDbType.Date).Value = Convert.ToDateTime(fechaFin);
                    sqlCommand.Parameters.Add("@codigo", SqlDbType.VarChar, 100).Value = codigo;
                    sqlCommand.Parameters.Add("@nivel", SqlDbType.VarChar, 100).Value = nivel;
                    sqlCommand.CommandTimeout = 1000;
                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }


            }
        }



        public DataTable GetKardexArticulos(string filtro, string almacen)
        {

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"uspGetMantenimiento";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@opcion", SqlDbType.Int).Value = 61;
                    sqlCommand.Parameters.Add("@filtroTxt1", SqlDbType.VarChar, 100).Value = filtro.ToString();
                    sqlCommand.Parameters.Add("@filtroTxt2", SqlDbType.VarChar, 100).Value = almacen.ToString();
                    sqlCommand.Parameters.Add("@filtroInt1", SqlDbType.Int).Value = 0;
                    sqlCommand.Parameters.Add("@filtroInt2", SqlDbType.Int).Value = 0;

                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    return dt;
                }
            }
        }


        public string RegistrarReq_Cabe(double idRequerimiento, string AlmacenDespacho,string AlmacenRequiere,
            int estado, string observacion, int usuarioRegistro)
        {
            string respuesta = "";

            using (var sqlConnection = ConnectionBD.GetConnection())
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = @"GRABAR_REQUE_CABE";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;
                    sqlCommand.Parameters.Add("@AlmacenDespacho", SqlDbType.VarChar).Value = AlmacenDespacho;
                    sqlCommand.Parameters.Add("@AlmacenRequiere", SqlDbType.VarChar).Value = AlmacenRequiere;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.Int).Value = estado;
                    sqlCommand.Parameters.Add("@observacion", SqlDbType.VarChar).Value = observacion;
                    sqlCommand.Parameters.Add("@usuarioRegistro", SqlDbType.Int).Value = usuarioRegistro;

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

        public string update_RequerimientoCabe(int tipo, double idRequerimiento, int usuario)
        {
            string respuesta = "";
            try
            {
                using (var sqlConnection = ConnectionBD.GetConnection())
                {
                    using (var sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = @"uspSet_Update_RequerimientoCabe";
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                        sqlCommand.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;
                        sqlCommand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

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
            }
            catch (Exception ex)
            {
                respuesta = "";
            }
            return respuesta;
        }


        public string setCambioPrecio(string Tipo, int IdEmpresa, string Serie, int Numero, int Secuencia, float Precio)
        {
            string respuesta = "";
            try
            {
                using (var sqlConnection = ConnectionBD.GetConnection())
                {
                    using (var sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = @"uspSetEditarPrecio";
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo;
                        sqlCommand.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = IdEmpresa;
                        sqlCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie;
                        sqlCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero;
                        sqlCommand.Parameters.Add("@Secuencia", SqlDbType.Int).Value = Secuencia;
                        sqlCommand.Parameters.Add("@Precio", SqlDbType.Float).Value = Precio;

                        sqlCommand.CommandTimeout = 1000;
                        sqlConnection.Open();

                        sqlCommand.ExecuteNonQuery();

                        

                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = "";
            }
            return respuesta;
        }


        public string RegistrarReq_Deta(double idRequerimiento, string ProductoID, double cantidad, double stock_actual, double cantidad_atendida)
        {
            string respuesta = "";
            try
            {
                using (var sqlConnection = ConnectionBD.GetConnection())
                {
                    using (var sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = @"GRABAR_REQUE_DETA";
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idRequerimiento", SqlDbType.Int).Value = idRequerimiento;
                        sqlCommand.Parameters.Add("@ProductoID", SqlDbType.VarChar).Value = ProductoID;
                        sqlCommand.Parameters.Add("@cantidad", SqlDbType.Float).Value = cantidad;
                        sqlCommand.Parameters.Add("@stock_actual", SqlDbType.Float).Value = stock_actual;
                        sqlCommand.Parameters.Add("@cantidad_atendida", SqlDbType.Float).Value = cantidad_atendida;
                        sqlCommand.CommandTimeout = 1000;
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
            }
            catch (Exception ex )
            {
                respuesta = "";
            }
            return respuesta;
        }


        public string update_RequerimientoDeta(int tipo, E_Producto_Reque item, double idRequerimiento, string almacenSalida, string almaceningreso, string usuario)
        {
            string respuesta = "";
            try
            {
                using (var sqlConnection = ConnectionBD.GetConnection())
                {
                    using (var sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = @"uspSet_Update_RequerimientoDeta";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@tipo", SqlDbType.Decimal).Value = tipo;
                        sqlCommand.Parameters.Add("@idRequerimiento", SqlDbType.Decimal).Value = idRequerimiento;
                        sqlCommand.Parameters.Add("@item", SqlDbType.Int).Value = item.item;
                        sqlCommand.Parameters.Add("@ProductoID", SqlDbType.VarChar).Value = item.codigo;
                        sqlCommand.Parameters.Add("@cantidad", SqlDbType.Float).Value = item.cantidad;
                        sqlCommand.Parameters.Add("@almacenSalida", SqlDbType.VarChar).Value = almacenSalida;
                        sqlCommand.Parameters.Add("@almaceningreso", SqlDbType.VarChar).Value = almaceningreso;
                        sqlCommand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
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
            }
            catch(Exception ex)
            {
                respuesta = "";
            }
            return respuesta;
        }


    }
}
