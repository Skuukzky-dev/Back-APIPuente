using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class EmpresasMgr
    {

        /// <summary>
        /// Devuelve las Empresas habilitadas por Usuario
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseEmpresas?> GetList(string? URLBackend,string Token,string endpoint,int pageNumber = 1,int pageSize = 10)
        {
            try
            {
                cResponseEmpresas? oRespuesta = new cResponseEmpresas();
                
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.EmpresasDAL.GetList(URLBackend, Token, endpoint, pageNumber, pageSize);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strEmpresasGetList);
                }

                LoggerMgr.LoguearSucesosAPIPuente("Success Empresas/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/Empresas/GetList");


                if (oRespuesta?.empresas == null)
                    throw new InvalidDataException();

                return oRespuesta;
            }
            catch(InvalidDataException)
            {
                throw;
            }
            catch (HttpRequestException)
            {
                LoggerMgr.LoguearSucesosAPIPuente("", LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strEmpresasGetList);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
