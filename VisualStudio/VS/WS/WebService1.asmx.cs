using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VisualStudio.Entidad;
using VisualStudio.VS.Servicio;

namespace VisualStudio.VS.WS
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Tienda> ObtenerTiendasPorCategoria(int idCategoria)
        {
            TiendaServicio tiendaService = new TiendaServicio();
            List<Tienda> tiendas = new List<Tienda>();

            tiendas = tiendaService.ObtenerTiendasPorCategoria(idCategoria);
            return tiendas;
        }

        [WebMethod]
        public List<Producto> ProductosPorTiendaCategoria(int idTienda, int idCategoria)
        {
            ProductoServicio productoServicio = new ProductoServicio();
            List<Producto> productos = new List<Producto>();

            productos = productoServicio.ProductosPorTiendaCategoria(idTienda, idCategoria);
            return productos;
        }

        [WebMethod]
        public List<Producto> Producto(int idProducto)
        {
            ProductoServicio productoServicio = new ProductoServicio();
            List<Producto> productos = new List<Producto>();

            productos = productoServicio.Producto(idProducto);
            return productos;
        }
        [WebMethod]
        public string Venta(int IdTienda, string Email, int IdProducto, float PrecioUnitario, int Cantidad)
        {
            VentaServicio ventaServicio = new VentaServicio();
            if (ventaServicio.Venta(IdTienda, Email, IdProducto, PrecioUnitario, Cantidad))
                return "OK";
            return "FAIL";
        }
    }
}
