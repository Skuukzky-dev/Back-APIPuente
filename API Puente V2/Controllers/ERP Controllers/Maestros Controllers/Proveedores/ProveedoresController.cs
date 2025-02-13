using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers.ERP_Controllers.Maestros_Controllers.Proveedores
{
    [Route("api/Maestros/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        // GET: api/<ProveedoresController>
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
        {
            GESI.CORE.API.BO.cResponseProveedores? oRespuesta = new GESI.CORE.API.BO.cResponseProveedores();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

               oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProveedoresMgr.GetList(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strProveedoresGetList, pageNumber, pageSize);

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
            catch (InvalidOperationException)
            {
                stop.Stop();
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el Encabezado en el request");
                
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

        public async Task<IActionResult> GetItem(int proveedorID = 0)
        {
            GESI.CORE.API.BO.cResponseProveedor? oRespuesta = new GESI.CORE.API.BO.cResponseProveedor();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);
                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.ProveedoresMgr.GetItem(URLBackend, Token, empresaID, sucursalID, GESI.CORE.API.PUENTE.BLL.Endpoints.strProveedoresGetItem,proveedorID);

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
                oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEncabezadoNoEncontrado, "No se encontro el Encabezado en el request");
                
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
