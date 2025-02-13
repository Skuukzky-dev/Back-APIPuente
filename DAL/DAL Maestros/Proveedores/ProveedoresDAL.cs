﻿using GESI.CORE.API.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESI.CORE.API.PUENTE.DAL
{
    public class ProveedoresDAL
    {
        public static async Task<cResponseProveedores> GetList(string URLBackend,string Token, int empresaID, int sucursalID, string endpoint, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                cResponseProveedores? oRespuesta = new cResponseProveedores();
                string cadenaConParametros = "pageNumber=" + pageNumber + "&pageSize=" + pageSize;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseProveedores?>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<cResponseProveedor> GetItem(string URLBackend, string Token, int empresaID, int sucursalID, string endpoint, int proveedorID)
        {
            try
            {
                cResponseProveedor? oRespuesta = new cResponseProveedor();
                string cadenaConParametros = "proveedorID=" + proveedorID;

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;  // TODO: ERROR CONEXION SSL The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), URLBackend + endpoint + "?" + cadenaConParametros))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token);
                        request.Headers.TryAddWithoutValidation("GrupoESI", "");
                        if (empresaID > 0)
                            request.Headers.TryAddWithoutValidation("empresaid", empresaID.ToString());

                        if (sucursalID > 0)
                            request.Headers.TryAddWithoutValidation("sucursalid", sucursalID.ToString());

                        var response = await httpClient.SendAsync(request);

                        string respuesta = response.Content.ReadAsStringAsync().Result.ToString();
                        oRespuesta = JsonConvert.DeserializeObject<cResponseProveedor?>(respuesta);

                        return oRespuesta;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
