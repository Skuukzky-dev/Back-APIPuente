using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class ComprobantesMgr
    {
        /// <summary>
        /// Devuelve una lista de comprobantes (Maestros)
        /// </summary>
        /// <param name="claseDeComprobanteID"></param>
        /// <param name="estado"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseComprobantes> GetList(string URLBackend, string Token, int empresaID, int sucursalID,int claseDeComprobanteID, string endpoint,string estado = "", int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseComprobantes oRespuesta = new cResponseComprobantes();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ComprobantesDAL.GetList(URLBackend, Token, empresaID, sucursalID, claseDeComprobanteID, endpoint, estado, pageNumber, pageSize);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Devuelve un objeto comprobante 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="comprobanteID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseComprobante> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, int comprobanteID, string endpoint)
        {
            try
            {
                cResponseComprobante oRespuesta = new cResponseComprobante();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ComprobantesDAL.GetItem(URLBackend, Token, empresaID, sucursalID, comprobanteID, endpoint);

                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
