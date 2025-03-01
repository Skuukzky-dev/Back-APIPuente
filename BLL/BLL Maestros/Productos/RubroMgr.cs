using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public  class RubroMgr
    {
        /// <summary>
        /// Devuelve los rubros habilitadas por Usuario
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseRubros?> GetList(string? URLBackend, string Token,int empresaID,int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseRubros? oRespuesta = new cResponseRubros();
                
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.RubrosDAL.GetList(URLBackend, Token,empresaID,sucursalID, endpoint, pageNumber, pageSize);

                LoggerMgr.LoguearSucesosAPIPuente("Success Rubros/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/Rubros/GetList");

                return oRespuesta;
            }
            catch (HttpRequestException)
            {
                LoggerMgr.LoguearSucesosAPIPuente("", LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strRubrosGetList);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
