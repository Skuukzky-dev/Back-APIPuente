using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace API_Puente_V2
{
    public class APIHelper
    {
        public enum pPaginacion
        {
            pPageNumber = 1,
            pPageSize = 10
        } 

        /// <summary>
        /// Devuelve la URL del Host por el archivo Host
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public static string? DevolverURLBackendPorArchivoHost(HttpRequest Request)
        {
            try
            {

                string URLHOST = "";
                #region Transformo los headers en Minuscula
                var headers = Request.Headers;
                var headersEnMinuscula = new Dictionary<string, string>();

                foreach (var header in headers)
                {
                    // Agregar el header en el diccionario con la clave en minúsculas
                    headersEnMinuscula[header.Key.ToLower()] = header.Value;
                }
                #endregion

                if (headersEnMinuscula.ContainsKey("clientegesiid")) // ENCONTRO CLIENTEGESIID
                {
                    string ClienteGesiID = headersEnMinuscula["clientegesiid"];

                    if (ClienteGesiID?.Length > 0)
                    {
                        string archivoHost = Path.Combine(Directory.GetCurrentDirectory(), "host.json");

                        try
                        {
                            string fileContent = System.IO.File.ReadAllText(archivoHost);

                            if (fileContent?.Length > 0)
                            {
                                fileContent = GESI.CORE.V2.SEC.Seguridad.DesencriptarTexto(fileContent);
                                List<Host>? lstHost = JsonConvert.DeserializeObject<List<Host>>(fileContent);

                                if (lstHost == null)
                                    throw new ApplicationException("El archivo host esta vacio");
                                
                                Host oHost = lstHost.FirstOrDefault(x => x.ClienteHOSTID == ClienteGesiID);

                                if (oHost == null)
                                    throw new ApplicationException("No se encontro el host en el archivo");

                                if (!oHost.ClienteHOSTID.Contains("/"))
                                    throw new ApplicationException("El clientegesiid no tiene digito verificador");

                                string ClienteHost = oHost.ClienteHOSTID.Split("/")[0];
                                string DigitoVerificador = oHost.ClienteHOSTID.Split("/")[1];

                                int intDigito = GESI.CORE.V2.SEC.Seguridad.DigitoVerificador(ClienteHost);

                                if (!DigitoVerificador.Equals(intDigito.ToString()))
                                    throw new ApplicationException("El digito verificador no coincide con el ingresado");


                                URLHOST = oHost.URLHOST;  // OBTENGO LA URL DEL HOST

                                return URLHOST;
                            }
                            else
                                throw new ApplicationException("El archivo host esta vacio");

                        }                        
                        catch (Exception )
                        {
                            throw;
                        }
                    }
                    else
                        throw new ApplicationException("No se encontro valor en el clientegesiid");
                }
                else
                    throw new ApplicationException("No se encontro el header clientegesiid");


            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve el Token del encabezado
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string DevolverTokenEncabezado(HttpRequest Request)
        {

            

            string? Token = Request.Headers["Authorization"];

            if (Request.Path.Equals("/api/Autenticacion/Login"))
                Token = "Bearer 11";

            if (Token?.Length > 0)
            {

                #region Transformo los headers en Minuscula
                var headers = Request.Headers;
                var headersEnMinuscula = new Dictionary<string, string>();

                foreach (var header in headers)
                {
                    // Agregar el header en el diccionario con la clave en minúsculas
                    headersEnMinuscula[header.Key.ToLower()] = header.Value;
                }
                #endregion
                var HeaderGrupoESI = headersEnMinuscula.Where(x => x.Key == "grupoesi").ToList();

                if (HeaderGrupoESI.Count > 0)
                {
                    string[] parts = Token.Split(' ');
                    Token = parts[1];
                    return Token;
                }

                else
                    throw new InvalidOperationException("No se encontro el Encabezado en el request");

            }
            else
                throw new InvalidOperationException("No se encontro el Token en el request");

        }
       

        /// <summary>
        /// Captura la empresaID y la SucursalID del encabezado
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static (int,int) DevolverEmpresaIDYSucursalID(HttpRequest Request)
        {
            try
            {

                int empresaID = 0;
                int sucursalID = 0;

                #region Transformo los headers en Minuscula
                var headers = Request.Headers;
                var headersEnMinuscula = new Dictionary<string, string>();

                foreach (var header in headers)
                {
                    // Agregar el header en el diccionario con la clave en minúsculas
                    headersEnMinuscula[header.Key.ToLower()] = header.Value;
                }
                #endregion

                if (headersEnMinuscula.ContainsKey("empresaid"))
                {
                    empresaID = Convert.ToInt32(headersEnMinuscula["empresaid"]);
                }

                if(headersEnMinuscula.ContainsKey("sucursalid"))
                {
                    sucursalID = Convert.ToInt32(headersEnMinuscula["sucursalid"]);
                }

                if (empresaID == 0)
                    throw new ApplicationException("empresaid no informado");

                if (sucursalID == 0)
                    sucursalID = 1;

                return (empresaID, sucursalID);

            }
            catch(ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

       public class Host
       {
            private string? _ClienteHOSTID;
            private string? _URLHOST;

            public string? ClienteHOSTID { get => _ClienteHOSTID; set => _ClienteHOSTID = value; }
            public string? URLHOST { get => _URLHOST; set => _URLHOST = value; }
       }

        

    }
}
