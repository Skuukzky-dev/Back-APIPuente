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
    public class TiposDeOperacionController : ControllerBase
    {
        // GET: api/<TiposDeOperacionController>
        [HttpGet("GetList")]
        [SwaggerResponse(200, "OK", typeof(cResponseTiposDeOperacion))]
        public async Task<IActionResult> GetList(int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {

            GESI.CORE.API.BO.cResponseTiposDeOperacion? oRespuesta = new GESI.CORE.API.BO.cResponseTiposDeOperacion();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.TiposDeOperacionMgr.GetList(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strTipoDeOperacionGetList, pageNumber, pageSize);

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
            catch (ArgumentNullException)
            {
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
                oRespuesta = new GESI.CORE.API.BO.cResponseTiposDeOperacion();
                oRespuesta.error = new GESI.CORE.API.BO.cError();
                oRespuesta.success = false;
                oRespuesta.error.code = (int)cCodigosError.cErrorInternoPuente;
                oRespuesta.error.message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Save(cTipoDeOperacion oTipoOperacion)
        {
            GESI.CORE.API.BO.cResponseTipoDeOperacion? oRespuesta = new GESI.CORE.API.BO.cResponseTipoDeOperacion();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.TiposDeOperacionMgr.Save(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strTipoDeOperacionSave, oTipoOperacion);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch(ApplicationException app)
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

        [HttpGet("GetItem")]
        [SwaggerResponse(200, "OK", typeof(cResponseTipoDeOperacion))]
        public async Task<IActionResult> GetItem(int tipoDeOperacionID = 0)
        {

            GESI.CORE.API.BO.cResponseTipoDeOperacion? oRespuesta = new GESI.CORE.API.BO.cResponseTipoDeOperacion();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.TiposDeOperacionMgr.GetItem(URLBackend, Endpoints.strTipoDeOperacionGetItem, Token, empresaID, sucursalID, tipoDeOperacionID);

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
                oRespuesta = new GESI.CORE.API.BO.cResponseTipoDeOperacion();
                oRespuesta.error = new GESI.CORE.API.BO.cError();
                oRespuesta.success = false;
                oRespuesta.error.code = (int)cCodigosError.cErrorInternoPuente;
                oRespuesta.error.message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(cTipoDeOperacion oTipoOperacion)
        {
            GESI.CORE.API.BO.cResponseTipoDeOperacion? oRespuesta = new GESI.CORE.API.BO.cResponseTipoDeOperacion();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.TiposDeOperacionMgr.Save(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strTipoDeOperacionSave, oTipoOperacion);

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
        public async Task<IActionResult> Delete(string codigos="")
        {
            GESI.CORE.API.BO.cResponseTipoDeOperacion? oRespuesta = new GESI.CORE.API.BO.cResponseTipoDeOperacion();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                string respuesta = await GESI.CORE.API.PUENTE.BLL.TiposDeOperacionMgr.Delete(URLBackend, Token, empresaID, sucursalID,Endpoints.strTipoDeOperacionDelete, codigos);



                
                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                if (respuesta?.Length > 0)
                    oRespuesta = JsonConvert.DeserializeObject<cResponseTipoDeOperacion>(respuesta);

                if (oRespuesta != null)
                    if (oRespuesta.error != null && oRespuesta.error.code > 0)
                        return BadRequest(oRespuesta);

                return Ok();

            }
            catch (ApplicationException app)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

                return BadRequest(oRespuesta);
            }
            catch (ArgumentNullException)
            {
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
                oRespuesta = new GESI.CORE.API.BO.cResponseTipoDeOperacion();
                oRespuesta.error = new GESI.CORE.API.BO.cError();
                oRespuesta.success = false;
                oRespuesta.error.code = (int)cCodigosError.cErrorInternoPuente;
                oRespuesta.error.message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

    }
}
