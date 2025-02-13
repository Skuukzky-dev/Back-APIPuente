using GESI.CORE.API.BO;
using GESI.ERP.Core.V2.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class FormasDePagoMgr
    {
        /// <summary>
        /// Devuelve una lista de formas de Pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseFormasDePago> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseFormasDePago oResponse = new cResponseFormasDePago();

                oResponse = await GESI.CORE.API.PUENTE.DAL.FormasDePagoDAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                return oResponse;
            }
            catch(InvalidDataException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Devuelve una Forma de Pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="formaDePagoID"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseFormaDePago> GetItem (string URLBackend, string Token, int empresaID, int sucursalID, string endpoint , int formaDePagoID  = 0)
        {
            try
            {
                cResponseFormaDePago oResponse = new cResponseFormaDePago();

                oResponse = await GESI.CORE.API.PUENTE.DAL.FormasDePagoDAL.GetItem(URLBackend, Token, empresaID, sucursalID, endpoint, formaDePagoID);

                return oResponse;
            }
            catch (InvalidDataException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crea una forma de Pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="oFormaDePago"></param>
        /// <returns></returns>
        public static async Task<cResponseFormaDePago> Create(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, cFormaDePago oFormaDePago)
        {
            try
            {
                cResponseFormaDePago oRespuesta = new cResponseFormaDePago();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.FormasDePagoDAL.Create(URLBackend, Token, empresaID, sucursalID, endpoint, oFormaDePago);

                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }


        public static async Task<cResponseFormaDePago> Update(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, cFormaDePago oFormaDePago)
        {
            try
            {
                cResponseFormaDePago oRespuesta = new cResponseFormaDePago();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.FormasDePagoDAL.Update(URLBackend, Token, empresaID, sucursalID, endpoint, oFormaDePago);

                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Borra una o varias formas de pago
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="codigos"></param>
        /// <returns></returns>
        public static async Task<string> Delete(string URLBackend,string Token, int empresaID, int sucursalID, string endpoint, string codigos)
        {
            try
            {
            string respuesta =     await GESI.CORE.API.PUENTE.DAL.FormasDePagoDAL.Delete(URLBackend, Token, empresaID, sucursalID, endpoint, codigos);

                return respuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
