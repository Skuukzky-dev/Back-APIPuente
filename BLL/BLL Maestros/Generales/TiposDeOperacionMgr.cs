using GESI.CORE.API.BO;
using GESI.ERP.Core.V2.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class TiposDeOperacionMgr
    {
        /// <summary>
        /// Devuelve una Lista de Tipos de Operacion
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseTiposDeOperacion> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1 , int pageSize = 10)
        {
            try
            {
                cResponseTiposDeOperacion oRespuesta = new cResponseTiposDeOperacion();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.TiposDeOperacionDAL.GetList(URLBackend,Token, empresaID,sucursalID, endpoint, pageNumber, pageSize);

                LoggerMgr.LoguearSucesosAPIPuente("Success TiposDeOperacion/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/TiposDeOperacion/GetList");



                return oRespuesta;

            }
            catch(Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Devuelve un Tipo de Operacion 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="endpoint"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="tipoDeOperacionID"></param>
        /// <returns></returns>
        public static async Task<cResponseTipoDeOperacion> GetItem(string URLBackend, string endpoint, string Token, int empresaID, int sucursalID, int tipoDeOperacionID)
        {
            try
            {
                cResponseTipoDeOperacion oRespuesta = new cResponseTipoDeOperacion();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.TiposDeOperacionDAL.GetItem(URLBackend, endpoint, Token, empresaID, sucursalID, tipoDeOperacionID);

                LoggerMgr.LoguearSucesosAPIPuente("Success TiposDeOperacion/GetItem", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/TiposDeOperacion/GetItem");


                return oRespuesta;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Crea un tipo de Operacion
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="oTipoOperacion"></param>
        /// <returns></returns>
        public static async Task<cResponseTipoDeOperacion> Save(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, cTipoDeOperacion oTipoOperacion)
        {
            try
            {
                cResponseTipoDeOperacion oRespuestaTipoOperacion = new cResponseTipoDeOperacion();

                oRespuestaTipoOperacion = await GESI.CORE.API.PUENTE.DAL.TiposDeOperacionDAL.Create(URLBackend, Token, empresaID, sucursalID, endpoint, oTipoOperacion);

                LoggerMgr.LoguearSucesosAPIPuente("Success TiposDeOperacion/Save", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/TiposDeOperacion/Save");


                return oRespuestaTipoOperacion;
            }
            catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Borra los tipos de operacion segun sus codigos separados por coma
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="codigos"></param>
        /// <returns></returns>
        public static async Task<string> Delete(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, string codigos)
        {
            try
            {
               string respuesta = await GESI.CORE.API.PUENTE.DAL.TiposDeOperacionDAL.Delete(URLBackend,Token,empresaID,sucursalID,endpoint, codigos);

                LoggerMgr.LoguearSucesosAPIPuente("Success TiposDeOperacion/Delete", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/TiposDeOperacion/Delete");

                return respuesta;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
