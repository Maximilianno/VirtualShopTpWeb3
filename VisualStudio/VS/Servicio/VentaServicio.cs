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

        internal DataTable ObtenerVentas(int idTienda)
        {
            List<Venta> listaDeProductos = new List<Venta>();

            DataTable tabla = new DataTable();
            tabla = nuevo.ObtenerVentas(idTienda);
            int cant = tabla.Rows.Count;
            int i = 0;
            Venta hola = new Venta();
            
            //while (i < cant)
            //{
            //    Venta venta = new Venta();
            //    venta. = Convert.ToInt32(tabla.Rows[i]["Id"]);
            //    venta.Nombre = Convert.ToString(tabla.Rows[i]["Nombre"]);
            //    venta.Stock = Convert.ToInt32(tabla.Rows[i]["Stock"]);
            //    venta.Precio = Convert.ToInt32(tabla.Rows[i]["Precio"]);
            //    venta.IdCategoria = Convert.ToInt32(tabla.Rows[i]["Categoria"]);

            //    listaDeProductos.Add(producto);
            //    i++;
            //}

            return tabla;
        }

        public DataTable BuscarVentasPorId(DateTime fechaDeCompra)
        {
            return nuevo.ObtenerVentasPorId(fechaDeCompra);
        }
    }
}