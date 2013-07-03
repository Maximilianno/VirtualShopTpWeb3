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
            List<Venta> listaDeVentas = new List<Venta>();

            DataTable tabla = new DataTable();
            tabla = nuevo.ObtenerVentas(idTienda);
            int cant = tabla.Rows.Count;
            int i = 0;
            Venta hola = new Venta();

            while (i < cant)
            {
                Venta venta = new Venta();
                venta.Id = Convert.ToInt32(tabla.Rows[i]["Id"]);
                venta.NombreProducto = Convert.ToString(tabla.Rows[i]["Nombre"]);
                venta.Cantidad = Convert.ToInt32(tabla.Rows[i]["Cantidad"]);
                venta.EmailComprador = Convert.ToString(tabla.Rows[i]["EmailComprador"]);
                venta.FechaTransaction = Convert.ToDateTime(tabla.Rows[i]["FechaTransaccion"]);
                venta.Estado = Convert.ToString(tabla.Rows[i]["Estado"]);

                listaDeVentas.Add(venta);
                i++;
            }

            return listaDeVentas;
        }

        public List<Venta> BuscarVentasPorFecha(DateTime fechaDeCompra, int idTienda)
        {
            List<Venta> listaDeVentas = new List<Venta>();

            DataTable tabla = new DataTable();
            tabla = nuevo.ObtenerVentasPorFecha(fechaDeCompra, idTienda);
            int cant = tabla.Rows.Count;
            int i = 0;
            Venta hola = new Venta();

            while (i < cant)
            {
                Venta venta = new Venta();
                venta.Id = Convert.ToInt32(tabla.Rows[i]["Id"]);
                venta.NombreProducto = Convert.ToString(tabla.Rows[i]["Nombre"]);
                venta.Cantidad = Convert.ToInt32(tabla.Rows[i]["Cantidad"]);
                venta.EmailComprador = Convert.ToString(tabla.Rows[i]["EmailComprador"]);
                venta.FechaTransaction = Convert.ToDateTime(tabla.Rows[i]["FechaTransaccion"]);
                venta.Estado = Convert.ToString(tabla.Rows[i]["Estado"]);

                listaDeVentas.Add(venta);
                i++;
            }
            return listaDeVentas;
        }
    }
}