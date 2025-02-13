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
    public class FormasDePagoDAL
    {
        

        /// <summary>
        /// Devuelve una lista de referencias contables 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseFormasDePago> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseFormasDePago? oRespuesta = new cResponseFormasDePago();
                string cadenaConParametros = "pageNumber=" + pageNumber+"&pageSize="+pageSize;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseFormasDePago>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Devuelve un item de Forma de Pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="formaDePagoID"></param>
        /// <returns></returns>
        public static async Task<cResponseFormaDePago> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int formaDePagoID = 0)
        {
            try
            {
                cResponseFormaDePago? oRespuesta = new cResponseFormaDePago();
                string cadenaConParametros = "formaDePagoID=" + formaDePagoID;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true; 

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseFormaDePago>(respuesta);

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
        /// Elimina una lista de Formas de Pago
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
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true; 

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
    
        /// <summary>
        /// Crea una forma de Pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="oFormaPago"></param>
        /// <returns></returns>
        public static async Task<cResponseFormaDePago> Create(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, cFormaDePago oFormaPago)
        {
            try
            {
                cResponseFormaDePago? oRespuesta = new cResponseFormaDePago();

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint))
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(oFormaPago));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        request.Content = new StringContent(JsonConvert.SerializeObject(oFormaPago));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");


                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseFormaDePago?>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static async Task<cResponseFormaDePago> Update(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, cFormaDePago oFormaPago)
        {
            try
            {
                cResponseFormaDePago? oRespuesta = new cResponseFormaDePago();

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true; 

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("PUT"), URLBackend + endpoint))
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(oFormaPago));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        request.Content = new StringContent(JsonConvert.SerializeObject(oFormaPago));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");


                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseFormaDePago?>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
