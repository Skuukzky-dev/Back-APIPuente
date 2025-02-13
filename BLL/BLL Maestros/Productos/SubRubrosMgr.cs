using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class SubRubrosMgr
    {
        /// <summary>
        /// Devuelve los rubros habilitadas por Usuario
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseSubRubros?> GetList(string? URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseSubRubros? oRespuesta = new cResponseSubRubros();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.SubRubrosDAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                return oRespuesta;
            }
            catch (HttpRequestException)
            {
                LoggerMgr.LoguearSucesosAPIPuente("", LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strSubRubrosGetList);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
