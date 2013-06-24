using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VisualStudio.VS.Datos;

namespace VisualStudio.VS.Servicio
{
    public class CategoriaServicio
    {
        AccesoADatos nuevo = new AccesoADatos();

        public static DataTable LlenarDDL()
        {
            AccesoADatos datos = new AccesoADatos();
            DataTable categorias = datos.obtenerCategorias();

            return categorias;
        }

        public int obtenerIdDeCategoria(string nombre)
        {
            return nuevo.obtenerIdDeCategoria(nombre);
        }

    }
}