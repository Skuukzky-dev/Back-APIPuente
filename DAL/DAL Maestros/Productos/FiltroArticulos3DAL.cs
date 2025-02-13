using GESI.CORE.API.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.DAL
{
    public class FiltroArticulos3DAL
    {

        /// <summary>
        /// Devuelve una lista de Filtros Articulos 3
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseFiltroArticulos3> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseFiltroArticulos3? oRespuesta = new cResponseFiltroArticulos3();
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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseFiltroArticulos3>(respuesta);

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
