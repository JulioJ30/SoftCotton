using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    public class EnviarGuiaRemisionBL
    {
        /// # RUTA para enviar documentos
        private const string ruta = "https://api.nubefact.com/api/v1/2bdef90d-1c63-4204-98be-fa076939dbbb";

        /// # TOKEN para enviar documentos
        private const string token = "622486953b0e42088aa6343904931cf0fee1dc975a74441bbb41ec0d4e2dbea7";




        public static string SendJson(string json)
        {
            try
            {
                using (var client = new WebClient())
                {
                    /// ESPECIFICAMOS EL TIPO DE DOCUMENTO EN EL ENCABEZADO
                    client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;
                    /// OBTENEMOS LA RESPUESTA
                    string respuesta = client.UploadString(ruta, "POST", json);
                    /// Y LA 'RETORNAMOS'
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                /// EN CASO EXISTA ALGUN ERROR, LO TOMAMOS
                var respuesta = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                /// Y LO 'RETORNAMOS'
                return respuesta;
            }
        }

    }
}
