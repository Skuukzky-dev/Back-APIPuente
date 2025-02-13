using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers
{
    [Route("api/Maestros/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        [HttpGet("GetList")]
        [SwaggerResponse(200, "OK", typeof(cResponseEmpresas))]
        public async Task<IActionResult> GetList(int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponseEmpresas? oRespuesta = new GESI.CORE.API.BO.cResponseEmpresas();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.EmpresasMgr.GetList(URLBackend, Token, GESI.CORE.API.PUENTE.BLL.Endpoints.strEmpresasGetList, pageNumber, pageSize);                
                
                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                #region Evalua si Token esta activo o es invalido
                if (oRespuesta != null)
                    if (oRespuesta.error != null && (oRespuesta.error.code == 4012 || oRespuesta.error.code == 4025))
                        return BadRequest(oRespuesta);
                #endregion

                return Ok(oRespuesta);

            }
            catch(InvalidDataException)
            {
                stop.Stop();
                return NoContent();
            }
            catch (ApplicationException apex)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada,apex.Message);
                
                return Unauthorized(oRespuesta);
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
