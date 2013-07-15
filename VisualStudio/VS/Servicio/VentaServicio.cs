using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VisualStudio.VS.Datos;
using VisualStudio.Entidad;

namespace VisualStudio.VS.Servicio
{
    public class VentaServicio
    {
        AccesoADatos nuevo = new AccesoADatos();

        internal List<Venta> ObtenerVentas(int idTienda)
        {
            return nuevo.ObtenerVentas(idTienda);
        }

        public List<Venta> BuscarVentasPorFecha(DateTime fechaDeCompra, int idTienda)
        {
            return nuevo.ObtenerVentasPorFecha(fechaDeCompra, idTienda);
        }

        public bool Venta(int IdTienda, string Email, int IdProducto, float PrecioUnitario, int Cantidad)
        {
            Venta venta = new Venta();
            venta.IdTienda = IdTienda;
            venta.EmailComprador = Email;
            venta.IdProducto = IdProducto;
            venta.PrecioUnitario = PrecioUnitario;
            venta.Cantidad = Cantidad;
            
            return nuevo.Venta(venta);
        }
    }
}