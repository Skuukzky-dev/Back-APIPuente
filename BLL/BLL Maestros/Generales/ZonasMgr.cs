using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class ZonasMgr
    {
        public static async Task<cResponseZonas> GetList(string URLBackend, string Token, string endpoint, int empresaID, int sucursalID, int pageNumber, int pageSize)
        {
            try
            {
                cResponseZonas oRespuesta = new cResponseZonas();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ZonasDAL.GetList(URLBackend,Token,endpoint,empresaID,sucursalID,pageNumber, pageSize);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
