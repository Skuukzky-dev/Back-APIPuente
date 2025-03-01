using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class FiltroArticulos2Mgr
    {
        /// <summary>
        /// Devuelve una Lista de Filtro Articulos 2
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseFiltroArticulos2> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseFiltroArticulos2 oRespuesta = new cResponseFiltroArticulos2();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.FiltroArticulos2DAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                LoggerMgr.LoguearSucesosAPIPuente("Success FiltroArticulos2/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/FiltroArticulos2/GetList");


                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
