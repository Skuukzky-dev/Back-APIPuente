﻿using GESI.CORE.API.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class FiltroArticulos3Mgr
    {
        /// <summary>
        /// Devuelve una lista de FIltro Articulos 3 
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="empresaID"></param>
        /// <param name="sucursalID"></param>
        /// <param name="endpoint"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<cResponseFiltroArticulos3> GetList(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseFiltroArticulos3 oRespuesta = new cResponseFiltroArticulos3();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.FiltroArticulos3DAL.GetList(URLBackend, Token, empresaID, sucursalID, endpoint, pageNumber, pageSize);


                LoggerMgr.LoguearSucesosAPIPuente("Success FiltroArticulos3/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/FiltroArticulos3/GetList");


                return oRespuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
