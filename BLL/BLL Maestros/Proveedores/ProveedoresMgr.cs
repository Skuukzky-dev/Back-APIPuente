using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class ProveedoresMgr
    {


        /// <summary>
        /// Devuelve una lista de Proveedores 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseProveedores> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseProveedores oRespuesta = new cResponseProveedores();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProveedoresDAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);

                return oRespuesta;

            }
            catch(Exception)
            {
                throw;
            }

        }



        public static async Task<cResponseProveedor> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint , int proveedorID)
        {
            try
            {
                cResponseProveedor oRespuesta = new cResponseProveedor();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ProveedoresDAL.GetItem(URLBackend, Token, empresaID, sucursalID, endpoint, proveedorID);

                return oRespuesta;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
