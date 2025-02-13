using GESI.CORE.API.BO;
using GESI.ERP.Ventas.V2.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.DAL
{
    public class MovimientosDeClientesDAL
    {

        /// <summary>
        /// Devuelve una coleccion de comprobantes de venta con su detalle
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="comprobanteID"></param>
        /// <param name="serie"></param>
        /// <param name="puntoDeVentaID"></param>
        /// <param name="numeros"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseMovimientoDeClientes?> GetItemPedidos(string? URLBackend, string Token, string endpoint,int comprobanteID,string serie,int puntoDeVentaID,string numeros,int empresaID, int sucursalID, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes? oRespuesta = new cResponseMovimientoDeClientes();
                string cadenaConParametros = "pageNumber=" + pageNumber + "&pageSize=" + pageSize+"&comprobanteID="+comprobanteID+"&serie="+serie+"&puntoDeVentaID="+puntoDeVentaID+"&numeros="+numeros;

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


        public static async Task<cResponseMovimientoDeClientes?> GetItem(string URLBackend, string Token, int empresaID, int sucursalID,List<dClaveComprobanteDeVenta> oClaves, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes? oRespuesta = new cResponseMovimientoDeClientes();
                string cadenaConParametros = "pageNumber=" + pageNumber + "&pageSize=" + pageSize;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        request.Content = new StringContent(JsonConvert.SerializeObject(oClaves));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseMovimientoDeClientes>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }

        }

        public static async Task<cResponseMovimientoDeClientes?> GetList(string URLBackend, string Token, int empresaID, int sucursalID, dParametrosConsultaComprobantes oClaves, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes? oRespuesta = new cResponseMovimientoDeClientes();
                string cadenaConParametros = "pageNumber=" + pageNumber + "&pageSize=" + pageSize;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        request.Content = new StringContent(JsonConvert.SerializeObject(oClaves));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        var response = await httpClient.SendAsync(request);

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

        public static async Task<cResponseMovimientoDeClientes> GetComprobantesPendientes(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, string fechahasta = "", int clienteID = 0, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes? oRespuesta = new cResponseMovimientoDeClientes();
                string cadenaConParametros = "pageNumber=" + pageNumber + "&pageSize=" + pageSize+"&fechahasta="+fechahasta+"&clienteID="+clienteID;

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


        public static async Task<List<cResponseSaveMovimientosClientes>> Save (string URLBackend, string Token, int empresaID, int sucursalID, List<cMovimientoDeCliente> lstMovimientos, string endpoint)
        {
            try
            {
                List<cResponseSaveMovimientosClientes>? oRespuesta = new List<cResponseSaveMovimientosClientes>();
                
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), URLBackend + endpoint ))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        request.Content = new StringContent(JsonConvert.SerializeObject(lstMovimientos));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<List<cResponseSaveMovimientosClientes>>(respuesta);

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
