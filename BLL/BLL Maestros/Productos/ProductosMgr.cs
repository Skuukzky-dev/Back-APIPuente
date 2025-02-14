using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public  class ProductosMgr
    {

        /// <summary>
        /// Devuelve la lista de Productos 
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
        public static async Task<cResponseProductos> GetList(string? URLBackend, string Token, int empresaID,int sucursalID,string endpoint, int pageNumber = 1, int pageSize = 10, string costos = "N", string imagenes = "N", string fechamodificaciones = "", string stock = "N", string publicaecommerce = "T")
        {
            try
            {
                GESI.CORE.API.BO.cResponseProductos? oRespuesta = new cResponseProductos();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GetList(URLBackend,Token,empresaID,sucursalID,endpoint,pageNumber,pageSize,costos,imagenes,fechamodificaciones,stock,publicaecommerce);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, "E", GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetList);
                }

                return oRespuesta;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve un Producto de la API Original
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
        public static async Task<cResponseProducto> GetItem(string? URLBackend, string Token,int empresaID,int sucursalID, string endpoint ,string productoID = "", int canalDeVentaID = 0, string costos = "N", string imagenes = "N", string stock = "N")
        {
            try
            {
                GESI.CORE.API.BO.cResponseProducto? oRespuesta = new cResponseProducto();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GetItem(URLBackend, Token,empresaID,sucursalID, endpoint,productoID,canalDeVentaID,costos,imagenes,stock);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, "E", GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetItem);
                }


                if (oRespuesta?.producto != null)
                    return oRespuesta;
                else
                    throw new ArgumentNullException("No se encontraron productos");

            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Devuelve un conjunto de resultados segun una busqueda
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
        public static async Task<cResponseProductos> GetSearchResults(string? URLBackend, string Token,int empresaID,int sucursalID, string endpoint, string expresion = "", int pageNumber = 1, int pageSize = 10, string costos = "N", string categoriasafiltrar = "", string imagenes = "N", string stock = "N", string publicaecommerce = "T")
        {
            try
            {
                GESI.CORE.API.BO.cResponseProductos? oRespuesta = new cResponseProductos();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GetSearchResults(URLBackend, Token,empresaID,sucursalID, endpoint, expresion, pageNumber, pageSize, costos, categoriasafiltrar, imagenes, stock, publicaecommerce);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, "E", GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetSearchResult);
                }

                if (oRespuesta?.productos?.Count > 0)
                    return oRespuesta;
                else
                    throw new ArgumentNullException("No se encontraron productos");

            }
            catch (ArgumentNullException)
            {
                throw;
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
        public static async Task<cResponsePrecios> GetPrecios(string URLBackend,string endpoint, string Token,int empresaID, int sucursalID,string codigos = "", string fechamodificaciones = "", int pageNumber = (int)pPaginacion.pPageNumber , int pageSize = (int)pPaginacion.pPageSize)
        {
            try
            {
                GESI.CORE.API.BO.cResponsePrecios oRespuesta = new cResponsePrecios();
                
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GetPrecios(URLBackend,endpoint, Token,empresaID,sucursalID, codigos, fechamodificaciones, pageNumber, pageSize);

                return oRespuesta;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch(Exception)
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
        /// <param name="pageNuber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseExistencias> GetExistencias(string URLBackend, string endpoint, string Token,int empresaID, int sucursalID, string codigos = "",string fechahasta = "",int pageNumber = (int)pPaginacion.pPageNumber, int pageSize = (int)pPaginacion.pPageSize)
        {
            try
            {
                cResponseExistencias oRespuesta = new cResponseExistencias();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GetExistencias(URLBackend, endpoint,Token,empresaID,sucursalID ,codigos,fechahasta,pageNumber,pageSize);
                
                return oRespuesta;
            }
            catch(Exception )
            {
                throw;
            }
        }


        /// <summary>
        /// Obtener Existencias de productos que se modificaron a partir de una fecha
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="fechamodificaciones"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseExistencias> GetExistenciasConModificacionesDesdeFecha(string URLBackend, string endpoint, string Token,int empresaID, int sucursalID, string fechamodificaciones = "", int pageNumber = (int)pPaginacion.pPageNumber, int pageSize = (int)pPaginacion.pPageSize)
        {
            try
            {
                cResponseExistencias oRespuesta = new cResponseExistencias();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GetExistenciasConModificacionesDesdeFecha(URLBackend,endpoint,Token,empresaID,sucursalID,"",fechamodificaciones,pageNumber,pageSize);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Devuelve las aplicaciones de los Productos
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseAplicacionesProducto> GetAplicacionesProductos(string URLBackend, string endpoint,string Token, int empresaID, int sucursalID, int pageNumber = (int)pPaginacion.pPageNumber, int pageSize = (int)pPaginacion.pPageSize)
        {
            try
            {
                cResponseAplicacionesProducto oResponse = new cResponseAplicacionesProducto();

                oResponse = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GetListAplicaciones(URLBackend, endpoint, Token, empresaID, sucursalID, pageNumber, pageSize);

                return oResponse;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve una lista de Grupo de Productos
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseGrupoDeArticulos> GrupoDeProductosGetList(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID, int pageNumber = (int)pPaginacion.pPageNumber, int pageSize = (int)pPaginacion.pPageSize)
        {
            try
            {
                cResponseGrupoDeArticulos oResponse = new cResponseGrupoDeArticulos();

                oResponse = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GrupoDeProductosGetList(URLBackend, endpoint, Token, empresaID, sucursalID, pageNumber, pageSize);

                return oResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve un grupo de Articulos
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="grupoArtID"></param>
        /// <returns></returns>
        public static async Task<cResponseGrupoDeArticulo> GrupoDeProductosGetItem(string URLBackend, string endpoint , string Token, int empresaID, int sucursalID, int grupoArtID)
        {
            try
            {
                cResponseGrupoDeArticulo oResponse = new cResponseGrupoDeArticulo();

                oResponse = await GESI.CORE.API.PUENTE.DAL.ProductosDAL.GrupoDeProductosGetItem(URLBackend, endpoint, Token, empresaID, sucursalID,grupoArtID);

                return oResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
