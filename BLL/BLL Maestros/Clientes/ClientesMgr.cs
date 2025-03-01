using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class ClientesMgr
    {

        /// <summary>
        /// Realiza un GetList a la API
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseClientes?> GetList(string? strURLBackend,string Token,int empresaID,int sucursalID,string strEndpoint,int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                GESI.CORE.API.BO.cResponseClientes? oRespuesta = new BO.cResponseClientes();

                oRespuesta = await DAL.ClientesDAL.GetList(strURLBackend, Token, empresaID,sucursalID,strEndpoint,pageNumber,pageSize);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, "E", "/api/Maestros/Clientes/GetList");
                }

                LoggerMgr.LoguearSucesosAPIPuente("Success Clientes/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/Clientes/GetList");

                return oRespuesta;
            }
            catch(HttpRequestException htex)
            {
                LoggerMgr.LoguearSucesosAPIPuente("Error al Obtener Lista Clientes: Descripcion: "+htex.Message, LoggerMgr.TiposDeLogueo.Error, "api/Maestros/Clientes/GetList");
                
                throw;
            }
            catch(Exception)
            { throw; }

        }

        /// <summary>
        /// Devuelve un Cliente de la API
        /// </summary>
        /// <param name="strURLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="strEndpoint"></param>
        /// <param name="clienteID"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseCliente?> GetItem(string? strURLBackend, string Token,int empresaID,int sucursalID, string strEndpoint, int clienteID = 0)
        {
            try
            {
                GESI.CORE.API.BO.cResponseCliente? oRespuesta = new BO.cResponseCliente();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ClientesDAL.GetItem(strURLBackend, Token,empresaID,sucursalID, strEndpoint, clienteID);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, "E", "/api/Maestros/Clientes/GetItem");
                }

                LoggerMgr.LoguearSucesosAPIPuente("Success Clientes/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/Clientes/GetItem");

                return oRespuesta;
            }
            catch (HttpRequestException htex)
            {
                LoggerMgr.LoguearSucesosAPIPuente("Error al obtener cliente. Descripcion: "+htex.Message, LoggerMgr.TiposDeLogueo.Error, "api/Maestros/Clientes/GetItem");
                
                throw;
            }
            catch (Exception)
            { throw; }

        }


        /// <summary>
        /// Realiza una busqueda de clientes por Razon Social
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="strEndpoint"></param>
        /// <param name="expresion"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseClientes?> GetSearchResults(string? URLBackend,string Token,int empresaID,int sucursalID,string strEndpoint,string? expresion ,int pageNumber = 1 , int pageSize = 10)
        {

            try
            {
                GESI.CORE.API.BO.cResponseClientes? oRespuesta = new BO.cResponseClientes();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ClientesDAL.GetSearchResults(URLBackend, Token, empresaID,sucursalID,strEndpoint, expresion, pageNumber, pageSize);

                if (oRespuesta?.error != null)
                {
                    if (oRespuesta?.error?.message?.Length > 0)
                        LoggerMgr.LoguearSucesosAPIPuente("Error: " + oRespuesta.error.message, "E", "/api/Maestros/Clientes/GetSearchResults");
                }

                LoggerMgr.LoguearSucesosAPIPuente("Success Clientes/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/Clientes/GetSearchResults");


                return oRespuesta;
            }
            catch (HttpRequestException htex)
            {
                LoggerMgr.LoguearSucesosAPIPuente("Error al realizar busqueda de clientes. Descripcion: "+htex.Message, LoggerMgr.TiposDeLogueo.Error, "api/Maestros/Clientes/GetSearchResults");

                throw;
            }
            catch (Exception)
            { throw; }

        }

        /// <summary>
        /// Da de alta un nuevo cliente por API
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="strEndpoint"></param>
        /// <param name="oClientes"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseClientes?> Create (string? URLBackend,string Token,int empresaID,int sucursalID,string strEndpoint, List<GESI.ERP.Core.V2.BO.cCliente> oClientes)
        {
            try
            {
                GESI.CORE.API.BO.cResponseClientes? oRespuesta = new BO.cResponseClientes();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ClientesDAL.Create(URLBackend, Token, empresaID,sucursalID,strEndpoint, oClientes);

                LoggerMgr.LoguearSucesosAPIPuente("Success Clientes/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/Clientes/Create");


                return oRespuesta;

            }
            catch (HttpRequestException htex)
            {
                LoggerMgr.LoguearSucesosAPIPuente("Error al crear cliente. Descripcion: "+htex.Message, LoggerMgr.TiposDeLogueo.Error, "api/Maestros/Clientes/Create");
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza una colección de clientes
        /// </summary>
        /// <param name="URLBackend"></param>
        /// <param name="Token"></param>
        /// <param name="strEndpoint"></param>
        /// <param name="oClientes"></param>
        /// <returns></returns>
        public static async Task<GESI.CORE.API.BO.cResponseClientes?> Update(string? URLBackend, string Token,int empresaID,int sucursalID, string strEndpoint, List<GESI.ERP.Core.V2.BO.cCliente> oClientes)
        {
            try
            {
                GESI.CORE.API.BO.cResponseClientes? oRespuesta = new BO.cResponseClientes();

                oRespuesta = await GESI.CORE.API.PUENTE.DAL.ClientesDAL.Update(URLBackend, Token,empresaID,sucursalID, strEndpoint, oClientes);

                LoggerMgr.LoguearSucesosAPIPuente("Success Clientes/GetList", LoggerMgr.TiposDeLogueo.Info, "api/Maestros/Clientes/Update");


                return oRespuesta;

            }
            catch (HttpRequestException htex)
            {
                LoggerMgr.LoguearSucesosAPIPuente("Error al actualizar clientes. Descripcion: "+htex.Message, LoggerMgr.TiposDeLogueo.Error, strEndpoint);
                
                throw;
            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}
