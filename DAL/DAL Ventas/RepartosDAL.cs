using GESI.CORE.API.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.DAL
{
    public class RepartosDAL
    {
        /// <summary>
        /// Obtiene los datos de una foja de reparto
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="fojaID"></param>
        /// <returns></returns>
        public static async Task<cResponseFojaDeReparto?> GetItem(string? URLBackend,string endpoint, string Token,int empresaID,int fojaID)
        {
            try
            {
                cResponseFojaDeReparto? oRespuesta = new cResponseFojaDeReparto();
                string cadenaConParametros = "empresaID=" + empresaID + "&fojaID=" + fojaID;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseFojaDeReparto>(respuesta);

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
        /// Verifica si un producto esta dentro de una foja de reparto
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="fojaID"></param>
        /// <param name="productoID"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseGetProductoEncontradoFoja?> GetProducto(string? URLBackend, string endpoint, string Token, int empresaID, int fojaID,string productoID)
        {
            try
            {
                cResponseGetProductoEncontradoFoja? oRespuesta = new cResponseGetProductoEncontradoFoja();
                string cadenaConParametros = "empresaID=" + empresaID + "&fojaID=" + fojaID+"&productoID="+productoID;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseGetProductoEncontradoFoja>(respuesta);

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
        /// Compara los productos y cantidades enviadas  con las que estan grabadas en la foja
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="fojaID"></param>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static async Task<cResponseCompararProductos?> CompararProducto(string? URLBackend, string endpoint, string Token, int empresaID, int fojaID, Dictionary<string,decimal> productos)
        {
            try
            {
                cResponseCompararProductos? oRespuesta = new cResponseCompararProductos();
                string cadenaConParametros = "empresaID=" + empresaID + "&fojaID=" + fojaID;
                string jsonProductos = JsonConvert.SerializeObject(productos);

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        request.Content = new StringContent(jsonProductos, Encoding.UTF8, "application/json");

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseCompararProductos>(respuesta);

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
        /// Cambia el estado de la foja de reparto
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="fojaID"></param>
        /// <param name="oCierreFoja"></param>
        /// <returns></returns>
        public static async Task<cResponseCompararProductos?> CerrarCargaFoja(string? URLBackend, string endpoint, string Token, int empresaID, int fojaID, cCierreFoja? oCierreFoja)
        {
            try
            {
                cResponseCompararProductos? oRespuesta = new cResponseCompararProductos();
                string cadenaConParametros = "empresaID=" + empresaID + "&fojaID=" + fojaID;
                string jsonProductos = JsonConvert.SerializeObject(oCierreFoja);

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        request.Content = new StringContent(jsonProductos, Encoding.UTF8, "application/json");

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseCompararProductos>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static async Task<cResponseMovimientoDeClientes> GetComprobantesNoAsignados(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID, string fechadesde =  "", string fechahasta = "", int vendedorID = 0, int repartidorID = 0, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes? oRespuesta = new cResponseMovimientoDeClientes();
                string cadenaConParametros = "fechadesde=" + fechahasta + "&fechahasta=" + fechahasta  + "&vendedorID=" + vendedorID+"&repartidorID="+repartidorID;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");

                        var response = await httpClient.SendAsync(request);
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseMovimientoDeClientes>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static async Task<cResponseFojaDeReparto> CreateFojaReparto(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID, GESI.ERP.Ventas.V2.BO.cFojaDeReparto oFoja)
        {
            try
            {
                cResponseFojaDeReparto? oRespuesta = new cResponseFojaDeReparto();
                
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint ))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");

                        var response = await httpClient.SendAsync(request);
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());
                        request.Content = new StringContent(JsonConvert.SerializeObject(oFoja));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseFojaDeReparto>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
