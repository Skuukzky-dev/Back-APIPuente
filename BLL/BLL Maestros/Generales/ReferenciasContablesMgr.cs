using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class ReferenciasContablesMgr
    {
        /// <summary>
        /// Devuelve una lista de referencias contables
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseReferenciasContables> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseReferenciasContables oRespuesta = new cResponseReferenciasContables();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ReferenciasContablesDAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                LoggerMgr.LoguearSucesosAPIPuente("Success ReferenciasContables/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/ReferenciasContables/GetList");

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Devuelve una referencia contable
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="referenciaContableID"></param>
        /// <returns></returns>
        public static async Task<cResponseReferenciaContable>GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint , int referenciaContableID )
        {
            try
            {
                cResponseReferenciaContable oRespuesta = new cResponseReferenciaContable();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ReferenciasContablesDAL.GetItem(URLBackend, Token, empresaID, sucursalID, endpoint, referenciaContableID);

                LoggerMgr.LoguearSucesosAPIPuente("Success ReferenciasContables/GetItem", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/ReferenciasContables/GetItem");


                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
