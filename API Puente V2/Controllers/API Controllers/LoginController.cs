using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers
{
    [Route("api/Autenticacion/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
      
        // POST api/<LoginController>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(cResponseToken))]
        public async Task<IActionResult?> Post([FromBody] GESI.CORE.API.BO.cUserLogin UserLogin)
        {
            cResponseToken? oRespuestaConToken = new cResponseToken();
           
              
                Stopwatch stop = new Stopwatch();
                stop.Start();
                try
                {
          
                        string? Token = APIHelper.DevolverTokenEncabezado(Request);
                        string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);

                        oRespuestaConToken = await GESI.CORE.API.PUENTE.BLL.LoginMgr.ObtenerTokenAPI(URLBackend, UserLogin,GESI.CORE.API.PUENTE.BLL.Endpoints.strLogin);

                        stop.Stop();
                        long lg = stop.ElapsedMilliseconds;
                
                if(oRespuestaConToken?.token != null)
                    return Ok(oRespuestaConToken);                  
                else
                    return BadRequest(oRespuestaConToken);

                }
                catch (Exception ex)
                {

                    stop.Stop();
                    oRespuestaConToken = new cResponseToken(); 
                    oRespuestaConToken.error = new GESI.CORE.API.BO.cError();
                    oRespuestaConToken.error.code = (int)cCodigosError.cErrorEnAPIGeneral;
                    oRespuestaConToken.error.message = ex.Message;

                    GESI.CORE.API.PUENTE.BLL.LoggerMgr.LoguearSucesosAPIPuente(ex.Message, LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strLogin);

                    return StatusCode((int)HttpStatusCode.InternalServerError, oRespuestaConToken);

                }
            
          
              
        }
        
    }
}
