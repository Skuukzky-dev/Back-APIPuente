using GESI.CORE.V2.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class AlmacenesMgr
    {

        /// <summary>
        /// Devuelve una lista de Almacenes
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseAlmacenes?> GetList(string? URLBackend, string Token, int empresaID,int sucursalID,string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                GESI.CORE.API.BO.cResponseAlmacenes? oRespuesta = new BO.cResponseAlmacenes();
                
                oRespuesta = await GESI.CORE.API.PUENTE.DAL.AlmacenesDAL.GetList(URLBackend, Token,empresaID,sucursalID,  endpoint, pageNumber, pageSize);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, "E", "/api/Maestros/Almacenes/GetList");
                }


                return oRespuesta;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Devuelve solamente un item del Almacen
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="endpoint"></param>
        /// <param name="almacenID"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseAlmacen?> GetItem(string? URLBackend, string Token,int empresaID,int sucursalID, string endpoint, int almacenID = 0)
        {
           
                try
                {              

                    GESI.CORE.API.BO.cResponseAlmacen? oRespuesta = new BO.cResponseAlmacen();

                    oRespuesta = await GESI.CORE.API.PUENTE.DAL.AlmacenesDAL.GetItem(URLBackend, Token,empresaID,sucursalID, endpoint, almacenID);


                    if (oRespuesta?.error != null)
                    {
                        if (oRespuesta?.error?.message?.Length > 0)
                            LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, LoggerMgr.TiposDeLogueo.Error, GESI.CORE.API.PUENTE.BLL.Endpoints.strAlmacenesGetItem);
                    }

                    if (oRespuesta?.almacen != null)
                        return oRespuesta;
                    else
                        throw new InvalidDataException("No se encontraron almacenes");

                }
                catch(InvalidDataException)
                {
                    throw;
                }
                catch (ArgumentNullException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }          
        }
    }
}
