using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers.ERP_Controllers.Maestros_Controllers
{
    [Route("api/Maestros/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // GET: api/<ProductosController>
        [HttpGet("GetList")]
        [SwaggerResponse(200, "OK", typeof(cResponseProductos))]
        public async Task<IActionResult> GetList(int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize, string costos = "N", string imagenes = "N", string fechamodificaciones = "", string stock = "N", string publicaecommerce = "T")
        {
            GESI.CORE.API.BO.cResponseProductos oRespuesta = new GESI.CORE.API.BO.cResponseProductos();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GetList(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetList, pageNumber, pageSize, costos, imagenes, fechamodificaciones, stock, publicaecommerce);
                
                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch(ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch(ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el encabezado en el request");
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }

        }

        // GET api/<ProductosController>/5
        [HttpGet("GetItem")]
        [SwaggerResponse(200, "OK", typeof(cResponseProducto))]
        public async Task<IActionResult> Get(string productoID = "", int canalDeVentaID = 0, string costos = "N", string imagenes = "N", string stock = "N")
        {
            GESI.CORE.API.BO.cResponseProducto oRespuesta = new GESI.CORE.API.BO.cResponseProducto();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GetItem(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetItem, productoID, canalDeVentaID, costos, imagenes, stock);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch(ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);

            }
            catch(ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el encabezado en el request");
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

        // POST api/<ProductosController>
        [HttpGet("GetSearchResults")]
        [SwaggerResponse(200, "OK", typeof(cResponseProductos))]
        public async Task<IActionResult> GetSearchResults(string expresion = "", int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize, string costos = "N", string categoriasafiltrar = "", string imagenes = "N", string stock = "N", string publicaecommerce = "T")
        {
            GESI.CORE.API.BO.cResponseProductos? oRespuesta = new GESI.CORE.API.BO.cResponseProductos();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GetSearchResults(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetSearchResult, expresion, pageNumber, pageSize, costos, categoriasafiltrar, imagenes, stock, publicaecommerce);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el Token en el request");
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }


        [HttpGet("GetPrecios")]
        [SwaggerResponse(200, "OK", typeof(cResponsePrecios))]
        public async Task<IActionResult>GetPrecios(string codigos = "",string fechamodificaciones = "",int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponsePrecios? oRespuesta = new GESI.CORE.API.BO.cResponsePrecios();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GetPrecios(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetPrecios, Token,empresaID,sucursalID,codigos,fechamodificaciones,pageNumber, pageSize);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el Token en el request");

                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }


        [HttpGet("GetExistencias")]
        [SwaggerResponse(200, "OK", typeof(cResponseExistencias))]
        public async Task<IActionResult> GetExistencias(string codigos = "", string fechahasta = "", int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponseExistencias? oRespuesta = new GESI.CORE.API.BO.cResponseExistencias();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GetExistencias(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strExistenciasGetList, Token,empresaID,sucursalID,codigos, fechahasta, pageNumber, pageSize);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el Token en el request");

                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }



        [HttpGet("GetExistenciasConModificacionesDesdeFecha")]
        [SwaggerResponse(200, "OK", typeof(cResponseExistencias))]
        public async Task<IActionResult> GetExistenciasConModificacionesDesdeFecha(string fechamodificaciones = "", int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponseExistencias? oRespuesta = new GESI.CORE.API.BO.cResponseExistencias();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GetExistenciasConModificacionesDesdeFecha(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strProductosGetExistenciasConModificacionesDesdeFecha,Token,empresaID,sucursalID,fechamodificaciones,pageNumber,pageSize);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el Token en el request");

                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

    }
}
