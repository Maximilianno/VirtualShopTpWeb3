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
            return nuevo.ObtenerProductos(idTienda);
        }

        public List<Producto> ProductosPorTiendaCategoria(int idTienda,int idCategoria){
            
           return nuevo.ProductosPorTiendaCategoria(idTienda,idCategoria);

        }
        public List<Producto> Producto(int idProducto)
        {

            return nuevo.Producto(idProducto);

        }
    }
}