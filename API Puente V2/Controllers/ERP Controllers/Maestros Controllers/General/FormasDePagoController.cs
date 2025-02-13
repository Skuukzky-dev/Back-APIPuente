using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using GESI.ERP.Core.V2.BO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers.ERP_Controllers.Maestros_Controllers.General
{
    [Route("api/Maestros/[controller]")]
    [ApiController]
    public class FormasDePagoController : ControllerBase
    {
        // GET: api/<FormasDePagoController>
        [HttpGet("GetList")]
        [SwaggerResponse(200, "OK", typeof(cResponseFormasDePago))]
        public async Task<IActionResult> GetList(int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponseFormasDePago? oRespuesta = new GESI.CORE.API.BO.cResponseFormasDePago();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.FormasDePagoMgr.GetList(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strFormasDePagoGetList, pageNumber, pageSize);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
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

        // GET api/<FormasDePagoController>/5
        [HttpGet("GetItem")]
        [SwaggerResponse(200, "OK", typeof(cResponseFormaDePago))]
        public async Task<IActionResult> GetItem(int formaDePagoID = 0)
        {
            GESI.CORE.API.BO.cResponseFormaDePago? oRespuesta = new GESI.CORE.API.BO.cResponseFormaDePago();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.FormasDePagoMgr.GetItem(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strFormasDePagoGetItem, formaDePagoID);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
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

        [HttpPost("Create")]
        public async Task<IActionResult> Create(cFormaDePago oFormaPago)
        {
            GESI.CORE.API.BO.cResponseFormaDePago? oRespuesta = new GESI.CORE.API.BO.cResponseFormaDePago();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

               oRespuesta = await GESI.CORE.API.PUENTE.BLL.FormasDePagoMgr.Create(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strFormasDePagoCreate, oFormaPago);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
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
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(cFormaDePago oFormaPago)
        {
            
                GESI.CORE.API.BO.cResponseFormaDePago? oRespuesta = new GESI.CORE.API.BO.cResponseFormaDePago();

                Stopwatch stop = new Stopwatch();
                stop.Start();

                try
                {
                    string? Token = APIHelper.DevolverTokenEncabezado(Request);
                    string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                    int empresaID;
                    int sucursalID;

                    (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                    oRespuesta = await GESI.CORE.API.PUENTE.BLL.FormasDePagoMgr.Update(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strFormasDePagoUpdate, oFormaPago);

                    stop.Stop();
                    long tiempo = stop.ElapsedMilliseconds;

                    #region Evalua si Token esta activo o es invalido
                    if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                    #endregion

                    return Ok(oRespuesta);

                }
                catch (ArgumentNullException)
                {
                    stop.Stop();
                    return NoContent();
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
                    oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);

                    return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
                }
            
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string codigos = "")
        {
            cResponseFormaDePago oRespuesta = new cResponseFormaDePago();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                string respuesta = await GESI.CORE.API.PUENTE.BLL.FormasDePagoMgr.Delete(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strFormasDePagoDelete, codigos);
               
                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                if (respuesta?.Length > 0)
                    oRespuesta = JsonConvert.DeserializeObject<cResponseFormaDePago>(respuesta);

                if (oRespuesta != null)
                    if (oRespuesta.error != null && oRespuesta.error.code > 0)
                        return BadRequest(oRespuesta);

                return Ok();

            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                return NoContent();
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
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

    }
}
