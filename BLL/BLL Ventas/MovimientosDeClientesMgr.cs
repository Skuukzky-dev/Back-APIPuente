using GESI.CORE.API.BO;
using GESI.ERP.Ventas.V2.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class MovimientosDeClientesMgr
    {


        /// <summary>
        /// Devuelve una coleccion de comprobantes con su detalle
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="comprobanteID"></param>
        /// <param name="serie"></param>
        /// <param name="puntoDeVentaID"></param>
        /// <param name="numeros"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseMovimientoDeClientes?> GetItemComprobantes (string? URLBackend,string Token,string endpoint, int comprobanteID, string serie, int puntoDeVentaID, string numeros, int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                GESI.CORE.API.BO.cResponseMovimientoDeClientes? oResponse = new BO.cResponseMovimientoDeClientes();

                oResponse = await GESI.CORE.API.PUENTE.DAL.MovimientosDeClientesDAL.GetItemPedidos(URLBackend,Token,endpoint,comprobanteID,serie,puntoDeVentaID,numeros,pageNumber,pageSize);

                return oResponse;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Recibe una lista de claves y devuelve los comprobantes
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="oClaves"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseMovimientoDeClientes> GetItem (string URLBackend, string Token,int empresaID, int sucursalID, List<dClaveComprobanteDeVenta> oClaves, string endpoint, int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes oResponse = new cResponseMovimientoDeClientes();

                oResponse = await GESI.CORE.API.PUENTE.DAL.MovimientosDeClientesDAL.GetItem(URLBackend, Token, empresaID, sucursalID, oClaves, endpoint, pageNumber, pageSize);

                return oResponse;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Recibe un objeto de parametros y devuelve una lista de comprobantes de venta
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="parametros"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseMovimientoDeClientes> GetList(string URLBackend, string Token, int empresaID, int sucursalID, dParametrosConsultaComprobantes parametros, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes oResponse = new cResponseMovimientoDeClientes();

                oResponse = await GESI.CORE.API.PUENTE.DAL.MovimientosDeClientesDAL.GetList(URLBackend, Token, empresaID, sucursalID, parametros, endpoint, pageNumber, pageSize);

                return oResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Devuelve una lista de comprobantes pendientes
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="fechahasta"></param>
        /// <param name="clienteID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseMovimientoDeClientes> GetComprobantesPendientes(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, string fechahasta = "", int clienteID = 0,int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes oRespuesta = new cResponseMovimientoDeClientes();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.MovimientosDeClientesDAL.GetComprobantesPendientes(URLBackend, Token, empresaID, sucursalID, Endpoints.strGetComprobantesPendientes, fechahasta, clienteID, pageNumber, pageSize);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }


        public static async Task<List<cResponseSaveMovimientosClientes>> Save(string URLBackend,string Token, int empresaID, int sucursalID, List<cMovimientoDeCliente> lstMovimientos, string endpoint)
        {
            try
            {
                List<cResponseSaveMovimientosClientes> lstMovimientosAImportar = new List<cResponseSaveMovimientosClientes>();

                lstMovimientosAImportar = await GESI.CORE.API.PUENTE.DAL.MovimientosDeClientesDAL.Save(URLBackend,Token,empresaID,sucursalID,lstMovimientos,endpoint);

                return lstMovimientosAImportar;
            }
            catch(Exception)
            {
                throw;
            }


        }

        

    }
}
