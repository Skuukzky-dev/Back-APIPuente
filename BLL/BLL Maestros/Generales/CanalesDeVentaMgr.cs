using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class CanalesDeVentaMgr
    {


        /// <summary>
        /// Devuelve una Lista de Canales de Venta 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseCanalesDeVenta> GetList (string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {

                cResponseCanalesDeVenta oRespuesta = new cResponseCanalesDeVenta();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.CanalesDeVentaDAL.GetList(URLBackend,Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                return oRespuesta;


            }
            catch(Exception )
            {
                throw;
            }
        }



        /// <summary>
        /// Devuelve un canal de venta 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="canalDeVentaID"></param>
        /// <returns></returns>
        public static async Task<cResponseCanalDeVenta> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int canalDeVentaID = 0)
        {
            try
            {
                cResponseCanalDeVenta oRespuesta = new cResponseCanalDeVenta();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.CanalesDeVentaDAL.GetItem(URLBackend, Token, empresaID,sucursalID,endpoint, canalDeVentaID);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
