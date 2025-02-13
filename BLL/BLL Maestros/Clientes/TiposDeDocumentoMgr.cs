using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class TiposDeDocumentoMgr
    {
        /// <summary>
        /// Devuelve la lista de TiposDeDocumento
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="Endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseTipoDocumento> GetList(string? URLBackend,string Token,int empresaID,int sucursalID,string Endpoint,int pageNumber = 1 ,int pageSize = 10)
        {
            try
            {
                cResponseTipoDocumento? oRespuesta = new cResponseTipoDocumento();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.TiposDeDocumentoDAL.GetList(URLBackend, Token, empresaID, sucursalID, Endpoint, pageNumber, pageSize);

                if (oRespuesta?.tiposDeDocumento == null)
                    throw new ArgumentNullException();

                return oRespuesta;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch (HttpRequestException)
            {
                LoggerMgr.LoguearSucesosAPIPuente("", LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strTiposDeDocumento);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
