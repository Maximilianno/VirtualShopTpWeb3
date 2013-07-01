using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisualStudio.VS.Datos;
using VisualStudio.Entidad;
using System.Data;
using System.IO;
using System.Drawing;

namespace VisualStudio.VS.Servicio
{
    public class ProductoServicio
    {
        AccesoADatos nuevo = new AccesoADatos();

        public void Insertar(Producto producto)
        {
            nuevo.InsertarNuevoProducto(producto);
        }

        //public DataTable listar()
        //{
        //    return nuevo.obtenerEmpresa();
        //}

        public void Editar(Producto producto)
        {
            nuevo.EditarProducto(producto);
        }

        public void Eliminar(int id)
        {
            nuevo.EliminarProducto(id);
        }

        public List<Producto> ObtenerProductos(int idTienda)
        {
            List<Producto> listaDeProductos = new List<Producto>();

            DataTable tabla = new DataTable();
            tabla = nuevo.ObtenerProductos(idTienda);
            int cant = tabla.Rows.Count;
            int i=0;

            while (i < cant)
            {
                Producto producto = new Producto();
                producto.ID = Convert.ToInt32(tabla.Rows[i]["Id"]);
                producto.Nombre = Convert.ToString(tabla.Rows[i]["Nombre"]);
                producto.Stock = Convert.ToInt32(tabla.Rows[i]["Stock"]);
                producto.Precio = Convert.ToInt32(tabla.Rows[i]["Precio"]);
                producto.IdCategoria = Convert.ToInt32(tabla.Rows[i]["Categoria"]);
                
                listaDeProductos.Add(producto);
                i++;
            }

            return listaDeProductos;
        }

        
    }
}