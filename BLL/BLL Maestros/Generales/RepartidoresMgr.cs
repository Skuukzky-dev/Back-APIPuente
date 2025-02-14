using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class RepartidoresMgr
    {
        /// <summary>
        /// Devuelve una lista de repartidores
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseRepartidores> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint,int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseRepartidores oResponse = new cResponseRepartidores();

                oResponse = await GESI.CORE.API.PUENTE.DAL.RepartidoresDAL.GetList(URLBackend,Token,empresaID,sucursalID,endpoint,pageNumber,pageSize);

                return oResponse;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve un Repartidor
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="repartidorID"></param>
        /// <returns></returns>
        public static async Task<cResponseRepartidor> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int repartidorID = 0)
        {
            try
            {
                cResponseRepartidor oResponse = new cResponseRepartidor();

                oResponse = await GESI.CORE.API.PUENTE.DAL.RepartidoresDAL.GetItem(URLBackend, Token, empresaID, sucursalID, endpoint,repartidorID);

                return oResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
