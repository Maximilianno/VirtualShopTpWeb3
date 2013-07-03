using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VisualStudio.VS.Datos;
using VisualStudio.Entidad;

namespace VisualStudio.VS.Servicio
{
    public class CategoriaServicio
    {
        AccesoADatos nuevo = new AccesoADatos();

        public static List<Categoria> LlenarDDL()
        {
            AccesoADatos datos = new AccesoADatos();
            List<Categoria> categorias = new List<Categoria>();
            DataTable MiTabla = datos.obtenerCategorias();
            int i = 0;
            int cant = MiTabla.Rows.Count;

            while (i < cant)
            {
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(MiTabla.Rows[i]["Id"]);
                categoria.Nombre = Convert.ToString(MiTabla.Rows[i]["Nombre"]);

                categorias.Add(categoria);
                i++;
            }
            
            return categorias;
        }

        public int obtenerIdDeCategoria(string nombre)
        {
            return nuevo.obtenerIdDeCategoria(nombre);
        }

    }
}