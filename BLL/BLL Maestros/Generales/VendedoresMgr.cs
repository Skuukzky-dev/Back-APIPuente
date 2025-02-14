using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class VendedoresMgr
    {

        /// <summary>
        /// Devuelve una Lista de Vendedores 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseVendedores> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseVendedores oRespuesta = new cResponseVendedores();
                
                oRespuesta = await GESI.CORE.API.PUENTE.BLL.VendedoresMgr.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                return oRespuesta;

                   
            }
            catch (Exception) 
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve un Item Vendedor
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="vendedorID"></param>
        /// <returns></returns>
        public static async Task<cResponseVendedor> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int vendedorID )
        {
            try
            {
                cResponseVendedor oRespuesta = new cResponseVendedor();



                return oRespuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
