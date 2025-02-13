using GESI.CORE.API.BO;
using GESI.ERP.Core.V2.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.DAL
{
    public class TiposDeOperacionDAL
    {


        /// <summary>
        /// Devuelve una Lista de Tipos de Operacion 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseTiposDeOperacion> GetList (string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseTiposDeOperacion? oRespuesta = new cResponseTiposDeOperacion();
                string cadenaConParametros = "pageNumber=" + pageNumber + "&pageSize=" + pageSize;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseTiposDeOperacion?>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


      /// <summary>
      /// Devuelve un Tipo de Operacion
      /// </summary>
      /// <param name="URLBackend"></param>
      /// <param name="endpoint"></param>
      /// <param name="Token"></param>
      /// <param name="empresaID"></param>
      /// <param name="sucursalID"></param>
      /// <param name="tipoDeOperacionID"></param>
      /// <returns></returns>
        public static async Task<cResponseTipoDeOperacion> GetItem (string URLBackend, string endpoint, string Token, int empresaID, int sucursalID, int tipoDeOperacionID )
        {
            try
            {
                cResponseTipoDeOperacion? oRespuesta = new cResponseTipoDeOperacion();
                string cadenaConParametros = "tipoDeOperacionID=" +tipoDeOperacionID;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");

                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();

                        oRespuesta = JsonConvert.DeserializeObject<cResponseTipoDeOperacion?>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crea un tipo de Operacion
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="oTipoOperacion"></param>
        /// <returns></returns>
        public static async Task<cResponseTipoDeOperacion> Create(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint , cTipoDeOperacion oTipoOperacion)
        {
            try
            {
                cResponseTipoDeOperacion? oRespuesta = new cResponseTipoDeOperacion();
               
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint))
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(oTipoOperacion));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        request.Content = new StringContent(JsonConvert.SerializeObject(oTipoOperacion));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");


                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseTipoDeOperacion?>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina uno o varios Tipos De Operacion
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="codigos"></param>
        /// <returns></returns>
        public static async Task<string> Delete(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, string codigos = "")
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), URLBackend + endpoint + "?codigos=" + codigos))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                    request.Headers.TryAddWithoutValidation("GrupoESI", "");
                    if (empresaID > 0)
                        request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                    if (sucursalID > 0)
                        request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                    var response = await httpClient.SendAsync(request);

                    string respuesta = response.Content.ReadAsStringAsync().Result.ToString();

                    return respuesta;
                }
            }
        }
    }
}
