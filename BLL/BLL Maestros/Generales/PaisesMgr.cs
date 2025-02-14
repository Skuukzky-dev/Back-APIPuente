using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class PaisesMgr
    {
        /// <summary>
        /// Devuelve una lista de Paises
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponsePaises> GetList(string URLBackend, string Token,string endpoint,int empresaID,int sucursalID, int pageNumber , int pageSize )
        {
            try
            {
                cResponsePaises oRespuesta = new cResponsePaises();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.PaisesDAL.GetList(URLBackend, Token, endpoint, empresaID, sucursalID, pageNumber, pageSize);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Devuelve un pais
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="paisID"></param>
        /// <returns></returns>
        public static async Task<cResponsePais> GetItem(string URLBackend, string Token, string endpoint, int empresaID, int sucursalID, int paisID)
        {
            try
            {
                cResponsePais oRespuesta = new cResponsePais();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.PaisesDAL.GetItem(URLBackend, Token, endpoint, empresaID, sucursalID, paisID);

                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
