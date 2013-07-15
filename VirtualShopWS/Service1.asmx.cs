using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace VirtualShopWS
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<VisualStudio.Entidad.Tienda> ObtenerTiendasPorCategoria(int idCategoria)
        {
            VisualStudio.VS.Servicio.TiendaServicio tiendaService = new VisualStudio.VS.Servicio.TiendaServicio();
            List<VisualStudio.Entidad.Tienda> tiendas = new List<VisualStudio.Entidad.Tienda>();
            
            tiendas = tiendaService.ObtenerTiendasPorCategoria(idCategoria);
            return tiendas;
        }

        [WebMethod]
        public List<VisualStudio.Entidad.Producto> ProductosPorTiendaCategoria(int idTienda, int idCategoria) {
            VisualStudio.VS.Servicio.ProductoServicio productoServicio = new VisualStudio.VS.Servicio.ProductoServicio();
            List<VisualStudio.Entidad.Producto> productos = new List<VisualStudio.Entidad.Producto>();

            productos = productoServicio.ProductosPorTiendaCategoria(idTienda,idCategoria);
            return productos;
        }

        [WebMethod]
        public List<VisualStudio.Entidad.Producto> Producto(int idProducto)
        {
            VisualStudio.VS.Servicio.ProductoServicio productoServicio = new VisualStudio.VS.Servicio.ProductoServicio();
            List<VisualStudio.Entidad.Producto> productos = new List<VisualStudio.Entidad.Producto>();

            productos = productoServicio.Producto(idProducto);
            return productos;
        }
        [WebMethod]
        public string Venta(int IdTienda, string Email, int IdProducto, float PrecioUnitario, int Cantidad)
        {
            VisualStudio.VS.Servicio.VentaServicio ventaServicio = new VisualStudio.VS.Servicio.VentaServicio();
            if (ventaServicio.Venta(IdTienda, Email, IdProducto, PrecioUnitario, Cantidad))
                return "OK";
            return "FAIL";
        }
    }
}