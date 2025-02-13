using GESI.CORE.API.BO;
using GESI.CORE.V2.BO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.DAL
{
    public class ProductosDAL
    {

        /// <summary>
        /// Devuelve los productos desde la API Original . Utiliza GetList
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="costos"></param>
        /// <param name="imagenes"></param>
        /// <param name="fechamodificaciones"></param>
        /// <param name="stock"></param>
        /// <param name="publicaecommerce"></param>
        /// <returns></returns>
        public static async Task<cResponseProductos?> GetList(string? URLBackend, string Token, int empresaID,int sucursalID,string endpoint,  int pageNumber = 1, int pageSize = 10, string costos = "N", string imagenes = "N", string fechamodificaciones = "", string stock = "N", string publicaecommerce = "T")
        {
            try
            {
                cResponseProductos? oRespuesta = new cResponseProductos();
                string cadenaConParametros = "pageNumber=" + pageNumber + "&pageSize=" + pageSize + "&costos=" + costos + "&imagenes=" + imagenes + "&fechamodificaciones=" + fechamodificaciones + "&stock=" + stock + "&publicaecommerce=" + publicaecommerce;

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseProductos>(respuesta);

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
        /// Devuelve un producto de la API Original
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="productoID"></param>
        /// <param name="canalDeVentaID"></param>
        /// <param name="costos"></param>
        /// <param name="imagenes"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        public static async Task<cResponseProducto?> GetItem(string? URLBackend, string Token,int empresaID,int sucursalID, string endpoint, string productoID = "", int canalDeVentaID = 0, string costos = "N", string imagenes = "N", string stock = "N")
        {
            try
            {
                cResponseProducto? oRespuesta = new cResponseProducto();
                string cadenaConParametros = "";

                if(canalDeVentaID == 0)                    
                    cadenaConParametros = "productoID="+productoID +"&costos=" + costos + "&imagenes=" + imagenes +  "&stock=" + stock;
                else
                    cadenaConParametros = "productoID=" + productoID + "&costos=" + costos + "&imagenes=" + imagenes + "&stock=" + stock+"&canalDeVentaID="+canalDeVentaID;

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseProducto>(respuesta);

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
        /// Devuelve un conjunto de resultados de la API Original por Busqueda
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="expresion"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="costos"></param>
        /// <param name="categoriasafiltrar"></param>
        /// <param name="imagenes"></param>
        /// <param name="stock"></param>
        /// <param name="publicaecommerce"></param>
        /// <returns></returns>
        public static async Task<cResponseProductos?> GetSearchResults(string? URLBackend, string Token,int empresaID,int sucursalID, string endpoint, string expresion = "", int pageNumber = 1, int pageSize = 10, string costos = "N", string categoriasafiltrar = "", string imagenes = "N", string stock = "N", string publicaecommerce = "T")
        {
            try
            {
                cResponseProductos? oRespuesta = new cResponseProductos();
                string cadenaConParametros = "expresion=" + expresion+"&pageNumber=" + pageNumber + "&pageSize=" + pageSize + "&costos=" + costos + "&imagenes=" + imagenes + "&stock=" + stock + "&publicaecommerce=" + publicaecommerce;

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseProductos>(respuesta);

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
        /// Devuelve una lista de precios 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="codigos"></param>
        /// <param name="fechamodificaciones"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponsePrecios> GetPrecios(string URLBackend, string endpoint,string Token,int empresaID, int sucursalID,string codigos = "",string fechamodificaciones = "", int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponsePrecios? oRespuesta = new cResponsePrecios();
                string cadenaConParametros = "codigos="+codigos+"&fechamodificaciones="+fechamodificaciones+"&pageNumber="+pageNumber+"&pageSize="+pageSize;

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponsePrecios>(respuesta);

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
        /// Devuelve una lista de existencias
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="codigos"></param>
        /// <param name="fechahasta"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseExistencias> GetExistencias (string URLBackend, string endpoint, string Token,int empresaID, int sucursalID, string codigos = "", string fechahasta = "", int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseExistencias? oRespuesta = new cResponseExistencias();
                string cadenaConParametros = "codigos=" + codigos + "&fechahasta=" + fechahasta + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseExistencias>(respuesta);

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
        /// Obtiene el listado de productos en los que su existencia cambió a partir de una determinada fecha
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="codigos"></param>
        /// <param name="fechamodificaciones"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        public static async Task<cResponseExistencias> GetExistenciasConModificacionesDesdeFecha(string URLBackend, string endpoint, string Token,int empresaID,int sucursalID, string codigos = "", string fechamodificaciones = "", int pageNumber = 1,  int pageSize = 10)
        {
            try
            {
                cResponseExistencias? oRespuesta = new cResponseExistencias();
                string cadenaConParametros = "codigos=" + codigos + "&fechahasta=" + fechamodificaciones + "&pageNumber=" + pageNumber + "&pageSize=" + pageSize;

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseExistencias>(respuesta);

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
        /// Devuelve las aplicaciones de los productos
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseAplicacionesProducto> GetListAplicaciones(string URLBackend,string endpoint, string Token, int empresaID, int sucursalID, int pageNumber ,int pageSize)
        {
            try
            {
                cResponseAplicacionesProducto? oRespuesta = new cResponseAplicacionesProducto();
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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseAplicacionesProducto>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<cResponseGrupoDeArticulos> GrupoDeProductosGetList(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID, int pageNumber, int pageSize)
        {
            try
            {
                cResponseGrupoDeArticulos? oRespuesta = new cResponseGrupoDeArticulos();
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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseGrupoDeArticulos>(respuesta);

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
        /// Obtiene un grupo de Articulos
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="grupoArticulosID"></param>
        /// <returns></returns>
        public static async Task<cResponseGrupoDeArticulo> GrupoDeProductosGetItem(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID,int grupoArticulosID)
        {
            try
            {
                cResponseGrupoDeArticulo? oRespuesta = new cResponseGrupoDeArticulo();
                string cadenaConParametros = "grupoArticulosID=" + grupoArticulosID;

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
                        oRespuesta = JsonConvert.DeserializeObject<cResponseGrupoDeArticulo>(respuesta);

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
