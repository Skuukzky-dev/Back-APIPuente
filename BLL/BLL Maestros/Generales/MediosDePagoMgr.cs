using GESI.CORE.API.BO;
using GESI.CORE.V2.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class MediosDePagoMgr
    {
        /// <summary>
        /// Devuelve una lista de Medios de Pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseMediosDePagos> GetList(string URLBackend, string Token, string endpoint, int empresaID, int sucursalID, int pageNumber, int pageSize)
        {
            try
            {
                cResponseMediosDePagos oRespuesta = new cResponseMediosDePagos();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.MediosDePagoDAL.GetList(URLBackend, Token, endpoint, empresaID,sucursalID,pageNumber, pageSize); 

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve un objeto de Medio de Pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="medioDePagoID"></param>
        /// <returns></returns>
        public static async Task<cResponseMedioDePago> GetItem(string URLBackend, string Token, string endpoint, int empresaID, int sucursalID, int medioDePagoID = 0)
        {
            try
            {
                cResponseMedioDePago oRespuesta = new cResponseMedioDePago();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.MediosDePagoDAL.GetItem(URLBackend,Token,endpoint, empresaID, sucursalID, medioDePagoID);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
