using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers.ERP_Controllers.Maestros_Controllers
{
    [Route("api/Maestros/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet("GetList")]
        [SwaggerResponse(200, "OK", typeof(cResponseClientes))]
        public async Task<IActionResult> GetList(int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize )
        {
            GESI.CORE.API.BO.cResponseClientes? oRespuesta = new GESI.CORE.API.BO.cResponseClientes();

            int ax = (int)pPaginacion.pPageNumber;

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ClientesMgr.GetList(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strClientesGetList, pageNumber, pageSize);

               

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;


                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && oRespuesta.error.code == 4012)
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch(ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException Encabezado )
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, Encabezado.Message);
        
                GESI.CORE.API.PUENTE.BLL.LoggerMgr.LoguearSucesosAPIPuente(oRespuesta.error.message, LoggerMgr.TiposDeLogueo.Info, GESI.CORE.API.PUENTE.BLL.Endpoints.strLogin);

                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);
                GESI.CORE.API.PUENTE.BLL.LoggerMgr.LoguearSucesosAPIPuente(oRespuesta.error.message, LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strLogin);

                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }


        [HttpGet("GetItem")]
        [SwaggerResponse(200, "OK", typeof(cResponseCliente))]
        public async Task<IActionResult> GetItem(int clienteID = 0)
        {
            GESI.CORE.API.BO.cResponseCliente? oRespuesta = new GESI.CORE.API.BO.cResponseCliente();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ClientesMgr.GetItem(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strClientesGetItem, clienteID);
                
                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && oRespuesta.error.code == 4012)
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException Encabezado)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, Encabezado.Message); 
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente,ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }


        [HttpGet("GetSearchResults")]
        [SwaggerResponse(200, "OK", typeof(cResponseClientes))]
        public async Task<IActionResult> GetSearchResults(string? expresion = "", int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponseClientes? oRespuesta = new GESI.CORE.API.BO.cResponseClientes();

            Stopwatch stop = new Stopwatch();
            stop.Start();
            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ClientesMgr.GetSearchResults(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strClientesGetList, expresion, pageNumber, pageSize);
                
                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && oRespuesta.error.code == 4012)
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);
            }
            catch(ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);


                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException Encabezado)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, Encabezado.Message);
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

        // POST api/<ClientesController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] List<GESI.ERP.Core.V2.BO.cCliente> oClientes)
        {
            GESI.CORE.API.BO.cResponseClientes? oRespuesta = new GESI.CORE.API.BO.cResponseClientes();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ClientesMgr.Create(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strClientesCreate, oClientes);
               
                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch(ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new cError((int)cCodigosError.cEmpresaIDNoEncontrada,app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException Encabezado)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, Encabezado.Message);
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] List<GESI.ERP.Core.V2.BO.cCliente> oClientes)
        {
            GESI.CORE.API.BO.cResponseClientes? oRespuesta = new GESI.CORE.API.BO.cResponseClientes();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ClientesMgr.Update(URLBackend, Token,empresaID,sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strClientesUpdate, oClientes);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException Encabezado)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, Encabezado.Message);
                
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente,ex.Message);
                
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }


    }
}
