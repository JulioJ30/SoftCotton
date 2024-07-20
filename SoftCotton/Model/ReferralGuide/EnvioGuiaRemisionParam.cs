using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace SoftCotton.Model.ReferralGuide
{
    //public class EnvioGuiaRemisionParam
    //{

    //}

    public class Invoice
    {
        public string operacion { get; set; }
        public int tipo_de_comprobante { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public int sunat_transaction { get; set; }
        public int cliente_tipo_de_documento { get; set; }
        public string cliente_numero_de_documento { get; set; }
        public string cliente_denominacion { get; set; }
        public string cliente_direccion { get; set; }
        public string cliente_email { get; set; }
        public string cliente_email_1 { get; set; }
        public string cliente_email_2 { get; set; }
        public string motivo_de_traslado { get; set; }
        public string documento_relacionado_codigo { get; set; }
        public string motivo_de_traslado_otros_descripcion { get; set; }

        public DateTime fecha_de_emision { get; set; }
        public DateTime fecha_de_vencimiento { get; set; }
        public int moneda { get; set; }
        //public dynamic tipo_de_cambio { get; set; } //? MAKES NATURAL TYPES NULLABLE
        public string tipo_de_cambio { get; set; } //? MAKES NATURAL TYPES NULLABLE

        public double porcentaje_de_igv { get; set; }
        //public dynamic descuento_global { get; set; }
        public string descuento_global { get; set; }

        //public dynamic total_descuento { get; set; }
        public string total_descuento { get; set; }

        //public dynamic total_anticipo { get; set; }
        public string total_anticipo { get; set; }

        //public dynamic total_gravada { get; set; }
        public string total_gravada { get; set; }

        //public dynamic total_inafecta { get; set; }
        public string total_inafecta { get; set; }

        //public dynamic total_exonerada { get; set; }
        public string total_exonerada { get; set; }

        public double total_igv { get; set; }
        //public dynamic total_gratuita { get; set; }
        public string total_gratuita { get; set; }
        //public dynamic total_otros_cargos { get; set; }

        public string total_otros_cargos { get; set; }
        public double total { get; set; }
        //public dynamic percepcion_tipo { get; set; }
        public string percepcion_tipo { get; set; }

        //public dynamic percepcion_base_imponible { get; set; }
        public string percepcion_base_imponible { get; set; }

        //public dynamic total_percepcion { get; set; }
        public string total_percepcion { get; set; }

        //public dynamic total_incluido_percepcion { get; set; }
        public string total_incluido_percepcion { get; set; }

        public bool detraccion { get; set; }
        public string observaciones { get; set; }
        //public dynamic documento_que_se_modifica_tipo { get; set; }
        public string documento_que_se_modifica_tipo { get; set; }

        public string documento_que_se_modifica_serie { get; set; }
        //public dynamic documento_que_se_modifica_numero { get; set; }
        public string documento_que_se_modifica_numero { get; set; }

        //public dynamic tipo_de_nota_de_credito { get; set; }
        public string tipo_de_nota_de_credito { get; set; }

        //public dynamic tipo_de_nota_de_debito { get; set; }
        public string tipo_de_nota_de_debito { get; set; }

        public bool enviar_automaticamente_a_la_sunat { get; set; }
        public bool enviar_automaticamente_al_cliente { get; set; }
        public string codigo_unico { get; set; }
        public string condiciones_de_pago { get; set; }
        public string medio_de_pago { get; set; }
        public string placa_vehiculo { get; set; }
        public string orden_compra_servicio { get; set; }
        public string tabla_personalizada_codigo { get; set; }
        public string formato_de_pdf { get; set; }


        public string peso_bruto_total { get; set; }
        public string peso_bruto_unidad_de_medida { get; set; }
        public string numero_de_bultos { get; set; }
        public string tipo_de_transporte { get; set; }
        public DateTime fecha_de_inicio_de_traslado { get; set; }
        public string transportista_documento_tipo { get; set; }
        public string transportista_documento_numero { get; set; }
        public string transportista_denominacion { get; set; }
        public string transportista_placa_numero { get; set; }
        public string conductor_documento_tipo { get; set; }
        public string conductor_documento_numero { get; set; }
        public string conductor_nombre { get; set; }
        public string conductor_apellidos { get; set; }
        public string conductor_numero_licencia { get; set; }
        public string punto_de_partida_ubigeo { get; set; }
        public string punto_de_partida_direccion { get; set; }
        public string punto_de_partida_codigo_establecimiento_sunat { get; set; }
        public string punto_de_llegada_ubigeo { get; set; }
        public string punto_de_llegada_direccion { get; set; }
        public string punto_de_llegada_codigo_establecimiento_sunat { get; set; }
        public string tuc_vehiculo_principal { get; set; }


        public List<Items> items { get; set; }
        public List<Guias> guias { get; set; }
    }

    public class Items
    {
        public string codigo_dam { get; set; }
        public string unidad_de_medida { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double cantidad { get; set; }
        public double valor_unitario { get; set; }
        public double precio_unitario { get; set; }
        //public dynamic descuento { get; set; }
        public string descuento { get; set; }

        public double subtotal { get; set; }
        public int tipo_de_igv { get; set; }
        public double igv { get; set; }
        public double total { get; set; }
        public bool anticipo_regularizacion { get; set; }
        //public dynamic anticipo_comprobante_serie { get; set; }
        public string anticipo_comprobante_serie { get; set; }

        //public dynamic anticipo_comprobante_numero { get; set; }
        public string anticipo_comprobante_numero { get; set; }
        public string codUmDam { get; set; }

    }

    public class Guias
    {
        public int guia_tipo { get; set; }
        public string guia_serie_numero { get; set; }
    }

    public class Respuesta
    {
        public string errors { get; set; }
        public int tipo { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public string url { get; set; }
        public bool aceptada_por_sunat { get; set; }
        public string sunat_description { get; set; }
        public string sunat_note { get; set; }
        public string sunat_responsecode { get; set; }
        public string sunat_soap_error { get; set; }
        public string pdf_zip_base64 { get; set; }
        public string xml_zip_base64 { get; set; }
        public string cdr_zip_base64 { get; set; }
        public string cadena_para_codigo_qr { get; set; }
        public string codigo_hash { get; set; }
        public string codigo_de_barras { get; set; }
    }
}
