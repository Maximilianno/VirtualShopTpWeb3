﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.586
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.586.
// 
#pragma warning disable 1591

namespace VisualStudio.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebService1Soap", Namespace="http://tempuri.org/")]
    public partial class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ObtenerTiendasPorCategoriaOperationCompleted;
        
        private System.Threading.SendOrPostCallback ProductosPorTiendaCategoriaOperationCompleted;
        
        private System.Threading.SendOrPostCallback ProductoOperationCompleted;
        
        private System.Threading.SendOrPostCallback VentaOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService1() {
            this.Url = global::VisualStudio.Properties.Settings.Default.VisualStudio_localhost_WebService1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ObtenerTiendasPorCategoriaCompletedEventHandler ObtenerTiendasPorCategoriaCompleted;
        
        /// <remarks/>
        public event ProductosPorTiendaCategoriaCompletedEventHandler ProductosPorTiendaCategoriaCompleted;
        
        /// <remarks/>
        public event ProductoCompletedEventHandler ProductoCompleted;
        
        /// <remarks/>
        public event VentaCompletedEventHandler VentaCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerTiendasPorCategoria", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Tienda[] ObtenerTiendasPorCategoria(int idCategoria) {
            object[] results = this.Invoke("ObtenerTiendasPorCategoria", new object[] {
                        idCategoria});
            return ((Tienda[])(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerTiendasPorCategoriaAsync(int idCategoria) {
            this.ObtenerTiendasPorCategoriaAsync(idCategoria, null);
        }
        
        /// <remarks/>
        public void ObtenerTiendasPorCategoriaAsync(int idCategoria, object userState) {
            if ((this.ObtenerTiendasPorCategoriaOperationCompleted == null)) {
                this.ObtenerTiendasPorCategoriaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerTiendasPorCategoriaOperationCompleted);
            }
            this.InvokeAsync("ObtenerTiendasPorCategoria", new object[] {
                        idCategoria}, this.ObtenerTiendasPorCategoriaOperationCompleted, userState);
        }
        
        private void OnObtenerTiendasPorCategoriaOperationCompleted(object arg) {
            if ((this.ObtenerTiendasPorCategoriaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerTiendasPorCategoriaCompleted(this, new ObtenerTiendasPorCategoriaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ProductosPorTiendaCategoria", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Producto[] ProductosPorTiendaCategoria(int idTienda, int idCategoria) {
            object[] results = this.Invoke("ProductosPorTiendaCategoria", new object[] {
                        idTienda,
                        idCategoria});
            return ((Producto[])(results[0]));
        }
        
        /// <remarks/>
        public void ProductosPorTiendaCategoriaAsync(int idTienda, int idCategoria) {
            this.ProductosPorTiendaCategoriaAsync(idTienda, idCategoria, null);
        }
        
        /// <remarks/>
        public void ProductosPorTiendaCategoriaAsync(int idTienda, int idCategoria, object userState) {
            if ((this.ProductosPorTiendaCategoriaOperationCompleted == null)) {
                this.ProductosPorTiendaCategoriaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnProductosPorTiendaCategoriaOperationCompleted);
            }
            this.InvokeAsync("ProductosPorTiendaCategoria", new object[] {
                        idTienda,
                        idCategoria}, this.ProductosPorTiendaCategoriaOperationCompleted, userState);
        }
        
        private void OnProductosPorTiendaCategoriaOperationCompleted(object arg) {
            if ((this.ProductosPorTiendaCategoriaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ProductosPorTiendaCategoriaCompleted(this, new ProductosPorTiendaCategoriaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Producto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Producto[] Producto(int idProducto) {
            object[] results = this.Invoke("Producto", new object[] {
                        idProducto});
            return ((Producto[])(results[0]));
        }
        
        /// <remarks/>
        public void ProductoAsync(int idProducto) {
            this.ProductoAsync(idProducto, null);
        }
        
        /// <remarks/>
        public void ProductoAsync(int idProducto, object userState) {
            if ((this.ProductoOperationCompleted == null)) {
                this.ProductoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnProductoOperationCompleted);
            }
            this.InvokeAsync("Producto", new object[] {
                        idProducto}, this.ProductoOperationCompleted, userState);
        }
        
        private void OnProductoOperationCompleted(object arg) {
            if ((this.ProductoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ProductoCompleted(this, new ProductoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Venta", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Venta(int IdTienda, string Email, int IdProducto, float PrecioUnitario, int Cantidad) {
            object[] results = this.Invoke("Venta", new object[] {
                        IdTienda,
                        Email,
                        IdProducto,
                        PrecioUnitario,
                        Cantidad});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void VentaAsync(int IdTienda, string Email, int IdProducto, float PrecioUnitario, int Cantidad) {
            this.VentaAsync(IdTienda, Email, IdProducto, PrecioUnitario, Cantidad, null);
        }
        
        /// <remarks/>
        public void VentaAsync(int IdTienda, string Email, int IdProducto, float PrecioUnitario, int Cantidad, object userState) {
            if ((this.VentaOperationCompleted == null)) {
                this.VentaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVentaOperationCompleted);
            }
            this.InvokeAsync("Venta", new object[] {
                        IdTienda,
                        Email,
                        IdProducto,
                        PrecioUnitario,
                        Cantidad}, this.VentaOperationCompleted, userState);
        }
        
        private void OnVentaOperationCompleted(object arg) {
            if ((this.VentaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VentaCompleted(this, new VentaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Tienda {
        
        private string razonSocialField;
        
        private int idField;
        
        private string idRegistracionField;
        
        private string emailField;
        
        private string passwordField;
        
        private string imagenField;
        
        private string cUITField;
        
        private string estadoField;
        
        private System.DateTime fechaRegistracionField;
        
        /// <comentarios/>
        public string RazonSocial {
            get {
                return this.razonSocialField;
            }
            set {
                this.razonSocialField = value;
            }
        }
        
        /// <comentarios/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <comentarios/>
        public string IdRegistracion {
            get {
                return this.idRegistracionField;
            }
            set {
                this.idRegistracionField = value;
            }
        }
        
        /// <comentarios/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <comentarios/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <comentarios/>
        public string Imagen {
            get {
                return this.imagenField;
            }
            set {
                this.imagenField = value;
            }
        }
        
        /// <comentarios/>
        public string CUIT {
            get {
                return this.cUITField;
            }
            set {
                this.cUITField = value;
            }
        }
        
        /// <comentarios/>
        public string Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime FechaRegistracion {
            get {
                return this.fechaRegistracionField;
            }
            set {
                this.fechaRegistracionField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Producto {
        
        private string tiendaRazonSocialField;
        
        private int idField;
        
        private int idTiendaField;
        
        private int idCategoriaField;
        
        private string nombreField;
        
        private string descripcionField;
        
        private float precioField;
        
        private int stockField;
        
        private string imagenField;
        
        /// <comentarios/>
        public string TiendaRazonSocial {
            get {
                return this.tiendaRazonSocialField;
            }
            set {
                this.tiendaRazonSocialField = value;
            }
        }
        
        /// <comentarios/>
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <comentarios/>
        public int idTienda {
            get {
                return this.idTiendaField;
            }
            set {
                this.idTiendaField = value;
            }
        }
        
        /// <comentarios/>
        public int IdCategoria {
            get {
                return this.idCategoriaField;
            }
            set {
                this.idCategoriaField = value;
            }
        }
        
        /// <comentarios/>
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <comentarios/>
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
            }
        }
        
        /// <comentarios/>
        public float Precio {
            get {
                return this.precioField;
            }
            set {
                this.precioField = value;
            }
        }
        
        /// <comentarios/>
        public int Stock {
            get {
                return this.stockField;
            }
            set {
                this.stockField = value;
            }
        }
        
        /// <comentarios/>
        public string Imagen {
            get {
                return this.imagenField;
            }
            set {
                this.imagenField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ObtenerTiendasPorCategoriaCompletedEventHandler(object sender, ObtenerTiendasPorCategoriaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerTiendasPorCategoriaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerTiendasPorCategoriaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Tienda[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Tienda[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ProductosPorTiendaCategoriaCompletedEventHandler(object sender, ProductosPorTiendaCategoriaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProductosPorTiendaCategoriaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ProductosPorTiendaCategoriaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Producto[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Producto[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ProductoCompletedEventHandler(object sender, ProductoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProductoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ProductoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Producto[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Producto[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void VentaCompletedEventHandler(object sender, VentaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VentaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VentaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591