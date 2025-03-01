using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class CajasBancosMgr
    {

        /// <summary>
        /// Devuelve una lista de Cajas / Bancos
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseCajasBancos> GetList(string URLBackend, string Token,int empresaID, int sucursalID,string endpoint, int pageNumber, int pageSize)
        {
            try
            {
                cResponseCajasBancos oResponse = new cResponseCajasBancos();

                oResponse = await GESI.CORE.API.PUENTE.DAL.CajasBancosDAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                LoggerMgr.LoguearSucesosAPIPuente("Success CajasBancos/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/CajasBancos/GetList");


                return oResponse;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve una Caja / Banco
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="cajabancoID"></param>
        /// <returns></returns>
        public static async Task<cResponseCajaBanco> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int cajabancoID = 0)
        {
            try
            {
                cResponseCajaBanco oResponse = new cResponseCajaBanco();

                oResponse = await GESI.CORE.API.PUENTE.DAL.CajasBancosDAL.GetItem(URLBackend, Token, empresaID, sucursalID, endpoint, cajabancoID);

                LoggerMgr.LoguearSucesosAPIPuente("Success CajasBancos/GetItem", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/CajasBancos/GetItem");


                return oResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
