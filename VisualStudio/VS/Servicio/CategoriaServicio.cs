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
            categorias = datos.obtenerCategorias();

            return categorias;
        }

        public int obtenerIdDeCategoria(string nombre)
        {
            return nuevo.obtenerIdDeCategoria(nombre);
        }

    }
}