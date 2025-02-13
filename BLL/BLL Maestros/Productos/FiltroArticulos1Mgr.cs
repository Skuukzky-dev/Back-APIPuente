using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class FiltroArticulos1Mgr
    {

        /// <summary>
        /// Devuelve una lista de Filtro Articulos 1
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseFiltroArticulos1> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseFiltroArticulos1 oRespuesta = new cResponseFiltroArticulos1();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.FiltroArticulos1DAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
