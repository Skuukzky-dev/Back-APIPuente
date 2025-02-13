using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers
{
    [Route("api/Ventas/[controller]")]
    [ApiController]
    public class RepartosController : ControllerBase
    {
        [HttpGet("GetItem")]
        [SwaggerResponse(200, "OK", typeof(cResponseFojaDeReparto))]
        public async Task<IActionResult> GetItem(int empresaID, int fojaID)
        {
            GESI.CORE.API.BO.cResponseFojaDeReparto? oRespuesta = new GESI.CORE.API.BO.cResponseFojaDeReparto();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);
                oRespuesta = await GESI.CORE.API.PUENTE.BLL.RepartosMgr.GetItem(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strFojaDeReparto, Token, empresaID, fojaID);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)HttpStatusCode.Unauthorized, "No se encontro el Token en el request");
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)HttpStatusCode.InternalServerError,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }


        }

        [HttpGet("GetProducto")]
        [SwaggerResponse(200, "OK", typeof(cResponseGetProductoEncontradoFoja))]

        public async Task<IActionResult> GetProducto(int empresaID, int fojaID,string productoID)
        {
            GESI.CORE.API.BO.cResponseGetProductoEncontradoFoja? oRespuesta = new GESI.CORE.API.BO.cResponseGetProductoEncontradoFoja();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);
                oRespuesta = await GESI.CORE.API.PUENTE.BLL.RepartosMgr.GetProducto(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strGetProductoFojaReparto, Token, empresaID, fojaID,productoID);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)HttpStatusCode.Unauthorized, "No se encontro el Token en el request");
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)HttpStatusCode.InternalServerError,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }


        }


        [HttpPost("CompararProductos")]
        [SwaggerResponse(200, "OK", typeof(cResponseCompararProductos))]

        public async Task<IActionResult> CompararProducto(int empresaID, int fojaID, [FromBody] Dictionary<string,decimal> productos)
        {
            GESI.CORE.API.BO.cResponseCompararProductos? oRespuesta = new GESI.CORE.API.BO.cResponseCompararProductos();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);
                oRespuesta = await GESI.CORE.API.PUENTE.BLL.RepartosMgr.CompararProducto(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strCompararProductos, Token, empresaID, fojaID,productos);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException )
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)HttpStatusCode.Unauthorized, "No se encontro el Token en el request");
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)HttpStatusCode.InternalServerError,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }


        }


        [HttpPost("CerrarCargaFoja")]
        [SwaggerResponse(200, "OK", typeof(cResponseCompararProductos))]

        public async Task<IActionResult> CerrarCargaFoja(int empresaID, int fojaID, cCierreFoja? oCierreFoja = null)
        {
            GESI.CORE.API.BO.cResponseCompararProductos? oRespuesta = new GESI.CORE.API.BO.cResponseCompararProductos();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);
                oRespuesta = await GESI.CORE.API.PUENTE.BLL.RepartosMgr.CerrarCargaFoja(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strCerrarCargaFoja, Token, empresaID, fojaID, oCierreFoja);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException )
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

        [HttpGet("GetComprobantesNoAsignados")]
        [SwaggerResponse(200, "OK", typeof(cResponseMovimientoDeClientes))]

        public async Task<IActionResult> GetComprobantesNoAsignados(string fechadesde = "", string fechahasta = "",int vendedorID = 0, int repartidorID = 0,int pageNumber = 1, int pageSize = 10)
        {
            GESI.CORE.API.BO.cResponseMovimientoDeClientes? oRespuesta = new GESI.CORE.API.BO.cResponseMovimientoDeClientes();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.RepartosMgr.GetComprobantesNoAsignados(URLBackend, Endpoints.strGetComprobantesNoAsignados, Token, empresaID, sucursalID, fechadesde, fechahasta, vendedorID, repartidorID, pageNumber, pageSize);


                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
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


        [HttpPost("Create")]
        [SwaggerResponse(200, "OK", typeof(cResponseFojaDeReparto))]
        public async Task<IActionResult> Create([FromBody]GESI.ERP.Ventas.V2.BO.cFojaDeReparto oFoja)
        {
            GESI.CORE.API.BO.cResponseFojaDeReparto? oRespuesta = new GESI.CORE.API.BO.cResponseFojaDeReparto();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);
                oRespuesta = await GESI.CORE.API.PUENTE.BLL.RepartosMgr.Create(URLBackend, Endpoints.strCreateFojaDeReparto, Token, empresaID, sucursalID, oFoja);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
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
