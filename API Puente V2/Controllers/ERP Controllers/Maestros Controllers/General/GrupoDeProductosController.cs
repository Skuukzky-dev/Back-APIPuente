using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers.ERP_Controllers.Maestros_Controllers.General
{
    [Route("api/Maestros/[controller]")]
    [ApiController]
    public class GrupoDeProductosController : ControllerBase
    {
        // GET: api/<GrupoDeProductosController>
        [HttpGet("GetList")]
        [SwaggerResponse(200, "OK", typeof(cResponseGrupoDeArticulos))]
        public async Task<IActionResult> GetList(int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponseGrupoDeArticulos? oRespuesta = new GESI.CORE.API.BO.cResponseGrupoDeArticulos();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GrupoDeProductosGetList(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strGruposDeProductosGetList, Token,empresaID,sucursalID,pageNumber,pageSize);

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
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cErrorInternoPuente, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }

        [HttpGet("GetItem")]
        [SwaggerResponse(200, "OK", typeof(cResponseGrupoDeArticulo))]
        public async Task<IActionResult> GetItem(int grupoArticulosID = 0)
        {
            GESI.CORE.API.BO.cResponseGrupoDeArticulo? oRespuesta = new GESI.CORE.API.BO.cResponseGrupoDeArticulo();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);

                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProductosMgr.GrupoDeProductosGetItem(URLBackend, GESI.CORE.API.PUENTE.BLL.Endpoints.strGruposDeProductosGetItem, Token,empresaID,sucursalID,grupoArticulosID);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch (InvalidDataException)
            {
                stop.Stop();
                return NoContent();

            }
            catch (ArgumentNullException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cDatoObligatorioNoEspecificado, "No se especificó un almacenID");

                return BadRequest(oRespuesta);
            }
            catch (InvalidOperationException Encabezado)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, Encabezado.Message);

                GESI.CORE.API.PUENTE.BLL.LoggerMgr.LoguearSucesosAPIPuente(oRespuesta.error.message, LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strLogin);

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

    }
}
