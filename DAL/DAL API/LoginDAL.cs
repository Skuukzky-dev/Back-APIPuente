using GESI.CORE.API.BO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GESI.CORE.API.PUENTE.DAL
{
    public class LoginDAL
    {
        /// <summary>
        /// Obtiene el token de la API EN IIS
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        public static async Task<cResponseToken?> ObtenerTokenAPI(string? URL, GESI.CORE.API.BO.cUserLogin oUserLogin, string endpoint)
        {
            cResponseToken? oRespuesta = null;
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URL + endpoint))
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(oUserLogin));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseToken>(respuesta);



                        return oRespuesta;
                    }

                }
            }
            catch (Exception )
            {
                throw ;
            }
        }
    }
}
