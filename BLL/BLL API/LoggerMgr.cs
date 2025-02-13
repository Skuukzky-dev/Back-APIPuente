using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.BLL
{
    public class LoggerMgr
    {
      

        /// <summary>
        /// Loguea los casos exitosos y errores de la API
        /// </summary>
        /// <param name="strDescripcionError"></param>
        public static void LoguearSucesosAPIPuente(String? strDescripcionError, String? strTipo,  String? Endpoint, int codigoErrorInterno = 200, string TiempoEjecucion = "", int cantidadDeElementos = 0)
        {
            int i = 0;
            int max_intentos = 3;
            do
            {
                try
                {

                    DateTime ahora = DateTime.Now;
                    string soloFechaStr = ahora.ToString("yyyy-MM-dd");

                    if (!Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\logs"))
                    {
                        Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\logs");
                    }

                    switch (strTipo)
                    {
                        case "I":
                            if (!Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\logs\\info"))
                            {
                                Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\logs\\info");
                            }

                            using (StreamWriter mylogs = File.AppendText(System.IO.Directory.GetCurrentDirectory() + "\\logs\\info\\logAPI-Info" + soloFechaStr + ".txt"))
                            {
                                mylogs.WriteLine(DateTime.Now.ToString() + "|" + strTipo  + "|" + Endpoint + "|" + codigoErrorInterno + "|" + strDescripcionError + " | Cantidad de Elementos: " + cantidadDeElementos);
                                mylogs.Close();
                                // Si la grabación es exitosa, establecer la variable i a 2.
                                i = max_intentos;
                            }
                            break;

                        case "E":
                            if (!Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\logs\\errors"))
                            {
                                Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\logs\\errors");
                            }
                            using (StreamWriter mylogs = File.AppendText(System.IO.Directory.GetCurrentDirectory() + "\\logs\\errors\\logAPI-Error" + soloFechaStr + ".txt"))
                            {
                                mylogs.WriteLine(DateTime.Now.ToString() + "|" + strTipo + "|" + Endpoint + "|" + codigoErrorInterno + "|" + strDescripcionError);
                                mylogs.Close();
                                // Si la grabación es exitosa, establecer la variable i a 2.
                                i = max_intentos;
                            }
                            break;
                    }


                }
                catch (Exception)
                {
                    // Si se produce un error, intenta escribirlo de nuevo.
                    i++;
                    System.Threading.Thread.Sleep(50);
                }
                // Esperar 50 ms antes de incrementar la variable.

            } while (i < max_intentos);

        }
        
        
        #region  Tipos de Logueo
        public static class TiposDeLogueo
        {
            public static string Info = "I";
            public static string Error = "E";
        }
        #endregion
    }
}
