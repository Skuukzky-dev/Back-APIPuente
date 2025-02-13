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
