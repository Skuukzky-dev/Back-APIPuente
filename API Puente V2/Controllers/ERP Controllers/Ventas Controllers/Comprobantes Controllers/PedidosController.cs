﻿using GESI.CORE.API.BO;
using GESI.CORE.API.PUENTE.BLL;
using GESI.ERP.Ventas.V2.BO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Puente_V2.Controllers.ERP_Controllers.Ventas_Controllers.Comprobantes_Controllers
{
    [Route("api/Ventas/Comprobantes/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        // GET: api/<PedidosController>
        [HttpPost("GetItem")]
        [SwaggerResponse(200, "OK", typeof(cResponseMovimientoDeClientes))]
        public async Task<IActionResult> GetItem([FromBody]List<dClaveComprobanteDeVenta> oClaves, int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
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

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.MovimientosDeClientesMgr.GetItem(URLBackend, Token, empresaID, sucursalID, oClaves, Endpoints.strPedidosGetItem,pageNumber,pageSize);
                
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



        [HttpPost("GetList")]
        [SwaggerResponse(200, "OK", typeof(cResponseMovimientoDeClientes))]
        public async Task<IActionResult> GetList([FromBody] dParametrosConsultaComprobantes parametros, int pageNumber = (int)APIHelper.pPaginacion.pPageNumber, int pageSize = (int)APIHelper.pPaginacion.pPageSize)
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

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.MovimientosDeClientesMgr.GetList(URLBackend, Token, empresaID, sucursalID,parametros,Endpoints.strPedidosGetList, pageNumber, pageSize);

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
        [SwaggerResponse(200, "OK", typeof(cResponseSaveMovimientosClientes))]
        public async Task<IActionResult> Create([FromBody] List<cMovimientoDeCliente> oMovimiento)
        {
            List<GESI.CORE.API.BO.cResponseSaveMovimientosClientes>? oRespuesta = new List<GESI.CORE.API.BO.cResponseSaveMovimientosClientes>();

            Stopwatch stop = new Stopwatch();
            stop.Start();

            try
            {
                string? Token = APIHelper.DevolverTokenEncabezado(Request);

                string URLBackend = APIHelper.DevolverURLBackendPorArchivoHost(Request);
                
                int empresaID;
                int sucursalID;

                (empresaID, sucursalID) = APIHelper.DevolverEmpresaIDYSucursalID(Request);

                oRespuesta = await GESI.CORE.API.PUENTE.BLL.MovimientosDeClientesMgr.SaveComprobantesDeVenta(URLBackend, Token, empresaID, sucursalID, oMovimiento, Endpoints.strPedidosCreate);

                stop.Stop();
                long tiempo = stop.ElapsedMilliseconds;

                return Ok(oRespuesta);

            }
            catch (ApplicationException app)
            {
                stop.Stop();
               // oRespuesta.error = new GESI.CORE.API.BO.cError((int)cCodigosError.cEmpresaIDNoEncontrada, app.Message);

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
               /* oRespuesta = new GESI.CORE.API.BO.cResponseMovimientoDeClientes();
                oRespuesta.error = new GESI.CORE.API.BO.cError();
                oRespuesta.error.code = (int)cCodigosError.cEncabezadoNoEncontrado;
                oRespuesta.error.message = "No se encontro el Encabezado en el request";*/
                return Unauthorized(oRespuesta);
            }
            catch (Exception ex)
            {
                stop.Stop();
               /* oRespuesta = new GESI.CORE.API.BO.cResponseMovimientoDeClientes();
                oRespuesta.error = new GESI.CORE.API.BO.cError();
                oRespuesta.success = false;
                oRespuesta.error.code = (int)cCodigosError.cErrorInternoPuente;
                oRespuesta.error.message = ex.Message;*/
                return StatusCode((int)HttpStatusCode.InternalServerError, oRespuesta);
            }
        }





    }
}
