using GESI.CORE.API.BO;
using System.Text.Json;
using System.Text;
using GESI.ERP.Core.V2.BO;

namespace API_Puente_V2.Middleware
{
    public class ValidationMiddleware
    {

        private readonly RequestDelegate _next;


        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 2. Leer el cuerpo de la solicitud

            if (!context.Request.Path.Equals("/api/Autenticacion/Login"))
            {
                await EvaluarMetodoSolicitud(context);
            }

            // 6. Pasar el control al siguiente middleware
            await _next(context);
        }


        private async Task EvaluarMetodoSolicitud(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put)
            {

                context.Request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
                await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                context.Request.Body.Position = 0;

                // 3. Deserializar el cuerpo
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                try
                {
                    bool blContinuar = EvaluarStringBody(bodyAsText, context.Request.Path);

                    if (!blContinuar)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    cResponse oRespuesta = new cResponse();
                    oRespuesta.error = new cError();
                    oRespuesta.error.code = StatusCodes.Status400BadRequest;
                    oRespuesta.error.message = "Parametro invalido";
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(oRespuesta));
                    return;
                }

            }
        }

        /// <summary>
        /// Evalua el JSON que viene en el body para ver si lo puede desserializar
        /// </summary>
        /// <param name="JSON"></param>
        /// <param name="Endpoint"></param>
        /// <returns></returns>
        private bool EvaluarStringBody(string JSON, string Endpoint)
        {
            bool blContinuar = true;

            try
            {
                switch (Endpoint)
                {
                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strFacturasGetList:
                        blContinuar = DeserializarGetList(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strFacturasGetItem:
                        blContinuar = DeserializarGetItem(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strPedidosGetList:
                        blContinuar = DeserializarGetList(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strPedidosGetItem:
                        blContinuar = DeserializarGetItem(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strRemitosGetList:
                        blContinuar = DeserializarGetList(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strRemitosGetItem:
                        blContinuar = DeserializarGetItem(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strAcopiosGetItem:
                        blContinuar = DeserializarGetItem(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strAcopiosGetList:
                        blContinuar = DeserializarGetList(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strDevolucionesRemitosGetItem:
                        blContinuar = DeserializarGetItem(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strDevolucionesRemitosGetList:
                        blContinuar = DeserializarGetList(JSON);
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strClientesCreate:
                        List<GESI.ERP.Core.V2.BO.cCliente>? lstCLienteAGrabar = JsonSerializer.Deserialize<List<GESI.ERP.Core.V2.BO.cCliente>>(JSON);

                        if (lstCLienteAGrabar?.Count > 0)
                        { }
                        else
                            blContinuar = false;
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strClientesUpdate:
                        List<GESI.ERP.Core.V2.BO.cCliente>? lstCLienteAActualizar = JsonSerializer.Deserialize<List<GESI.ERP.Core.V2.BO.cCliente>>(JSON);

                        if (lstCLienteAActualizar?.Count > 0)
                        { }
                        else
                            blContinuar = false;
                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strPedidosCreate:
                        List<cMovimientoDeCliente>? lstMovimientosAGrabar = JsonSerializer.Deserialize<List<cMovimientoDeCliente>>(JSON);

                        if (lstMovimientosAGrabar?.Count > 0)
                        { 
                            foreach(cMovimientoDeCliente oMov in lstMovimientosAGrabar)
                            {
                                if(oMov.DetalleItems?.Count > 0)
                                {
                                    oMov.DetalleDeItems = new List<GESI.ERP.Ventas.V2.BO.cItemComprobanteDeVenta>();

                                    foreach(cDetalleDeVenta oDetalle in oMov.DetalleItems)
                                    {
                                        GESI.ERP.Ventas.V2.BO.cItemComprobanteDeVenta oItem = new GESI.ERP.Ventas.V2.BO.cItemComprobanteDeVenta();
                                        oDetalle.Serie = oMov.Serie;
                                        if(oDetalle.DescuentosPorcentaje?.Length == 0)
                                            oDetalle.DescuentosPorcentaje = "";

                                        oItem.CantidadU1 = oDetalle.CantidadU1;
                                        oItem.CodigoDeItem = oDetalle.CodigoDeItem;
                                        oItem.PrecioUnitarioNeto = oDetalle.PrecioUnitarioNeto;
                                        oItem.PrecioUnitarioFinal = oDetalle.PrecioUnitarioFinal;
                                        oItem.Serie = oMov.Serie;
                                        oItem.EmpresaID = oMov.EmpresaID;
                                        oItem.ComprobanteID = oMov.ComprobanteID;
                                        oItem.DescuentosPorcentaje = oDetalle.DescuentosPorcentaje;

                                        oMov.DetalleDeItems.Add(oItem);

                                    }
                                }
                            }
                        }
                        else
                            blContinuar = false;

                        break;

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strTipoDeOperacionSave:
                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strTiposDeOperacionUpdate:
                        cTipoDeOperacion oTipoOperacion = JsonSerializer.Deserialize<cTipoDeOperacion>(JSON);
                        if (oTipoOperacion != null)
                        {
                        }
                        else
                            blContinuar = false;
                        break;

                  

                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strFormasDePagoCreate:
                    case "/" + GESI.CORE.API.PUENTE.BLL.Endpoints.strFormasDePagoUpdate:
                        cFormaDePago oFormaPago = JsonSerializer.Deserialize<cFormaDePago>(JSON);
                        if(oFormaPago != null)
                        { }
                        else
                            blContinuar = false;
                        break;
                }

                return blContinuar;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private bool DeserializarGetList(string json)
        {

            bool blContinuar = true;

            /*  try
              {
                  GESI.CORE.API.BO.cParametrosConsultaDeComprobantes? oParametros = JsonSerializer.Deserialize<GESI.CORE.API.BO.cParametrosConsultaDeComprobantes>(json);

                  if (oParametros == null)
                  {
                      blContinuar = false;
                  }

              }
              catch (Exception)
              {
                  blContinuar = false;
              }*/

            return blContinuar;
        }

        private bool DeserializarGetItem(string json)
        {

            bool blContinuar = true;

            /* try
             {

                 List<GESI.ERP.Ventas.V2.BO.dClaveComprobanteDeVenta>? oParametros = JsonSerializer.Deserialize<List<GESI.ERP.Ventas.V2.BO.dClaveComprobanteDeVenta>>(json);

                 if (oParametros == null)
                 {
                     blContinuar = false;
                 }

             }
             catch (Exception)
             {
                 blContinuar = false;
             }*/

            return blContinuar;
        }
    }
}
