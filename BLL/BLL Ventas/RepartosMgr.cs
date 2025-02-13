
using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class RepartosMgr
    {
        public static async Task<GESI.CORE.API.BO.cResponseFojaDeReparto?> GetItem(string? URLBackend,string endpoint,string Token,int empresaID,int fojaID)
        {
            try
            {
                cResponseFojaDeReparto? oRespuesta = new cResponseFojaDeReparto();
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.RepartosDAL.GetItem(URLBackend,endpoint,Token,empresaID,fojaID);
                
                return oRespuesta;
            }
            catch(Exception) {
                throw;
            }

        }


        public static async Task<GESI.CORE.API.BO.cResponseGetProductoEncontradoFoja?> GetProducto(string? URLBackend, string endpoint, string Token, int empresaID, int fojaID,string productoID)
        {
            try
            {
                cResponseGetProductoEncontradoFoja? oRespuesta = new cResponseGetProductoEncontradoFoja();
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.RepartosDAL.GetProducto(URLBackend, endpoint, Token, empresaID, fojaID,productoID);

                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }

        }



        public static async Task<cResponseCompararProductos?> CompararProducto(string? URLBackend, string endpoint, string Token, int empresaID, int fojaID, Dictionary<string,decimal> productos)
        {
            try
            {
                cResponseCompararProductos? oRespuesta = new cResponseCompararProductos();
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.RepartosDAL.CompararProducto(URLBackend, endpoint, Token, empresaID, fojaID, productos);

                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static async Task<cResponseCompararProductos?> CerrarCargaFoja(string? URLBackend, string endpoint, string Token, int empresaID, int fojaID,cCierreFoja? oCierreFoja)
        {
            try
            {
                cResponseCompararProductos? oRespuesta = new cResponseCompararProductos();
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.RepartosDAL.CerrarCargaFoja(URLBackend, endpoint, Token, empresaID, fojaID, oCierreFoja);

                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Devuelve una lista de comprobantes no asignados en fojas de repartos. 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="fechadesde"></param>
        /// <param name="fechahasta"></param>
        /// <param name="vendedorID"></param>
        /// <param name="repartidorID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseMovimientoDeClientes> GetComprobantesNoAsignados(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID ,string fechadesde = "", string fechahasta = "", int vendedorID = 0, int repartidorID = 0, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseMovimientoDeClientes oRespuesta = new cResponseMovimientoDeClientes();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.RepartosDAL.GetComprobantesNoAsignados(URLBackend,endpoint,Token, empresaID, sucursalID, fechadesde, fechahasta, vendedorID, repartidorID, pageNumber, pageSize);

                return oRespuesta;
            }
            catch(Exception )
            {
                throw;
            }
        }
    
    
        /// <summary>
        /// Crea una foja de reparto
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="oFoja"></param>
        /// <returns></returns>
        public static async Task<cResponseFojaDeReparto> Create(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID, GESI.ERP.Ventas.V2.BO.cFojaDeReparto oFoja)
        {
            try
            {
                cResponseFojaDeReparto oRespuesta = new cResponseFojaDeReparto();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.RepartosDAL.CreateFojaReparto(URLBackend,endpoint,Token,empresaID, sucursalID,oFoja);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }


        
    }
}
