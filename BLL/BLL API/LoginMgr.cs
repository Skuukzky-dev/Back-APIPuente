using GESI.CORE.API.BO;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class LoginMgr
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        public static async Task<cResponseToken?> ObtenerTokenAPI(string? URLBackend, GESI.CORE.API.BO.cUserLogin oUserLogin, string endpoint)
        {
            try
            {
                cResponseToken? oRespuesta = await GESI.CORE.API.PUENTE.DAL.LoginDAL.ObtenerTokenAPI(URLBackend, oUserLogin, endpoint);
                                
                LoggerMgr.LoguearSucesosAPIPuente("Logueado existosamente con usuario: "+oUserLogin.Username, LoggerMgr.TiposDeLogueo.Info, GESI.CORE.API.PUENTE.BLL.Endpoints.strLogin);

                return oRespuesta;
            }
            catch (Exception ex)
            {
                LoggerMgr.LoguearSucesosAPIPuente("Error al Loguear Usuario: "+ex.Message, LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strLogin);
                throw;
            }
        }
    }
}
