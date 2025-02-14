namespace GESI.CORE.API.PUENTE.BLL
{

    public enum cCodigosError
    {
        cErrorInternoPuente = 5001,
        cErrorEnAPIGeneral = 4001,
        cEncabezadoNoEncontrado = 3001,
        cDatoObligatorioNoEspecificado = 2001,
        cEmpresaIDNoEncontrada = 3002
            
    }
    public enum pPaginacion
    {
        pPageNumber = 1,
        pPageSize = 10
    }

    public static class Endpoints
    {
        #region CanalesDeVenta
        public const string strCanalesDeVentaGetList = "api/Maestros/CanalesDeVenta/GetList";
        public const string strCanalesDeVentaGetItem = "api/Maestros/CanalesDeVenta/GetItem";
        #endregion

        public const string strZonasGetList = "api/Maestros/Zonas/GetList";

        #region Cajas / Bancos
        public const string strCajasBancosGetList = "api/Maestros/CajasBancos/GetList";
        public const string strCajasBancosGetItem = "api/Maestros/CajasBancos/GetItem";
        #endregion

        #region Grupo De Productos
        public const string strGruposDeProductosGetList = "api/Maestros/GruposDeProductos/GetList";
        public const string strGruposDeProductosGetItem = "api/Maestros/GruposDeProductos/GetItem";
        #endregion

        #region Productos
        public const string strProductosGetList = "api/Maestros/Productos/GetList";
        public const string strProductosGetItem = "api/Maestros/Productos/GetItem";
        public const string strProductosGetSearchResult = "api/Maestros/Productos/GetSearchResults";
        public const string strProductosGetPrecios = "api/Maestros/Productos/GetPrecios";
        public const string strProductosGetExistencias = "api/Maestros/Productos/GetExistencias";
        public const string strProductosGetExistenciasConModificacionesDesdeFecha = "api/Maestros/Productos/GetExistenciasConModificacionesDesdeFecha";
        #endregion

        #region Paises
        public const string strPaisesGetList = "api/Maestros/Paises/GetList";
        public const string strPaisesGetItem = "api/Maestros/Paises/GetItem";
        #endregion

        #region Login
        public const string strLogin = "api/Autenticacion/Login";
        #endregion

        #region Empresas
        public const string strEmpresasGetList = "api/Maestros/Empresas/GetList";
        #endregion

        #region Categorias
        public const string strCategoriasGeneral = "api/Categorias/GetList";
        public const string strCategoriaGetItem = "api/Categorias/GetItem";
        public const string strFiltro1GetList = "api/Categorias/Filtro1GetList";
        public const string strFiltro2GetList = "api/Categorias/Filtro2GetList";
        public const string strFiltro3GetList = "api/Categorias/Filtro3GetList";
        #endregion

        #region Precios
        public const string strPreciosGetList = "api/Productos/GetPrecios";
        #endregion

        #region Existencias
        public const string strExistenciasGetList = "api/Maestros/Productos/GetExistencias";
        #endregion

        #region Repartos
        public const string strFojaDeReparto = "api/Ventas/Repartos/GetItem";
        public const string strGetProductoFojaReparto = "api/Ventas/Repartos/GetProducto";
        public const string strCompararProductos = "api/Ventas/Repartos/CompararProductos";
        public const string strCerrarCargaFoja = "api/Ventas/Repartos/CerrarCargaFoja";
        public const string strGetComprobantesNoAsignados = "api/Ventas/Repartos/GetComprobantesNoAsignados";
        public const string strCreateFojaDeReparto = "api/Ventas/Repartos/Create";
        #endregion

        #region Medios de Pago
        public const string strMediosDePagoGetList = "api/Maestros/MediosDePago/GetList";
        public const string strMediosDePagoGetItem = "api/Maestros/MediosDePago/GetItem";
        #endregion

        #region Almacenes
        public const string strAlmacenesGetList = "api/Maestros/Almacenes/GetList";
        public const string strAlmacenesGetItem = "api/Maestros/Almacenes/GetItem";
        #endregion

        #region Rubros
        public const string strRubrosGetList = "api/Maestros/Rubros/GetList";
        #endregion

        #region SubRubros
        public const string strSubRubrosGetList = "api/Maestros/SubRubros/GetList";
        #endregion

        #region SubSubRubros
        public const string strSubSubRubrosGetList = "api/Maestros/SubSubRubros/GetList";
        #endregion

        #region Clientes
        public const string strClientesGetList = "api/Maestros/Clientes/GetList";
        public const string strClientesGetItem = "api/Maestros/Clientes/GetItem";
        public const string strClientesCreate = "api/Maestros/Clientes/Create";
        public const string strClientesUpdate = "api/Maestros/Clientes/Update";
        public const string strClientesGetSearchResults = "api/Maestros/Clientes/GetSearchResults";
        #endregion

        #region TiposDeDocumento
        public const string strTiposDeDocumento = "api/Maestros/TiposDeDocumento/GetList";
        #endregion

        #region Pedidos
        public const string strPedidosGetItem = "api/Ventas/Comprobantes/Pedidos/GetItem";
        public const string strPedidosGetList = "api/Ventas/Comprobantes/Pedidos/GetList";
        public const string strPedidosCreate = "api/Ventas/Comprobantes/Pedidos/Create";
        #endregion


        #region Cobros
        public const string strCobrosGetList = "api/Ventas/Comprobantes/Cobros/GetList";
        public const string strCobrosCreate = "api/Ventas/Comprobantes/Cobros/Create";
        public const string strCobrosGetItem = "api/Ventas/Comprobantes/Cobros/GetItem";
        #endregion

        #region Remitos
        public const string strRemitosGetItem = "api/Ventas/Comprobantes/Remitos/GetItem";
        public const string strRemitosGetList = "api/Ventas/Comprobantes/Remitos/GetList";
        #endregion

        #region Facturas
        public const string strFacturasGetItem = "api/Ventas/Comprobantes/Facturas/GetItem";
        public const string strFacturasGetList = "api/Ventas/Comprobantes/Facturas/GetList";

        #endregion

        #region Comprobantes
        public const string strComprobanteGetItem = "api/Maestros/Comprobantes/GetItem";
        public const string strComprobanteGetList = "api/Maestros/Comprobantes/GetList";

        #endregion

        #region Tipos De Operacion
        public const string strTipoDeOperacionGetList = "api/Maestros/TiposDeOperacion/GetList";
        public const string strTipoDeOperacionGetItem = "api/Maestros/TiposDeOperacion/GetItem";
        public const string strTipoDeOperacionSave = "api/Maestros/TiposDeOperacion/Create";
        public const string strTiposDeOperacionUpdate = "api/Maestros/TiposDeOperacion/Update";
        public const string strTipoDeOperacionDelete = "api/Maestros/TiposDeOperacion/Delete";
        #endregion

        #region Vendedores
        public const string strVendedoresGetList = "api/Maestros/Vendedores/GetList";
        public const string strVendedoresGetItem = "api/Maestros/Vendedores/GetItem";
        #endregion


        #region Proveedores
        public const string strProveedoresGetList = "api/Maestros/Proveedores/GetList";
        public const string strProveedoresGetItem = "api/Maestros/Proveedores/GetItem";
        #endregion


        #region Repartidores
        public const string strRepartidoresGetList = "api/Maestros/Repartidores/GetList";
        public const string strRepartidoresGetItem = "api/Maestros/Repartidores/GetItem";
        #endregion

        #region Acopios
        public const string strAcopiosGetList = "api/Ventas/Comprobantes/Acopios/GetList";
        public const string strAcopiosGetItem = "api/Ventas/Comprobantes/Acopios/GetItem";
        #endregion


        #region Devoluciones Remito
        public const string strDevolucionesRemitosGetList = "api/Ventas/Comprobantes/DevolucionesDeRemito/GetList";
        public const string strDevolucionesRemitosGetItem = "api/Ventas/Comprobantes/DevolucionesDeRemito/GetItem";
        #endregion

        #region Formas de Pago
        public const string strFormasDePagoGetList = "api/Maestros/FormasDePago/GetList";
        public const string strFormasDePagoGetItem = "api/Maestros/FormasDePago/GetItem";
        public const string strFormasDePagoCreate = "api/Maestros/FormasDePago/Create";
        public const string strFormasDePagoDelete = "api/Maestros/FormasDePago/Delete";
        public const string strFormasDePagoUpdate = "api/Maestros/FormasDePago/Update";
        #endregion

        #region Referencias Contables
        public const string strReferenciasContablesGetList = "api/Maestros/ReferenciasContables/GetList";
        public const string strReferenciasContablesGetItem = "api/Maestros/ReferenciasContables/GetItem";
        #endregion

        public const string strGetComprobantesPendientes = "api/Ventas/Comprobantes/GetComprobantesPendientes";

        public const string strAplicacionesProductosGetList = "api/Maestros/Aplicaciones/GetList";

    }


 
}
