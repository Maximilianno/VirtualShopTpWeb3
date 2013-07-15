using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisualStudio.VS.Datos;
using System.Data;
using VisualStudio.Entidad;
using VisualStudio.VS.classes;

namespace VisualStudio.VS.Servicio
{
    public class TiendaServicio
    {
        
        AccesoADatos nuevo = new AccesoADatos();
        
        public void Insertar(Tienda tienda)
        {
            nuevo.insertarNuevaTienda(tienda);          
        }

        public void Editar(Tienda tienda)
        {
            nuevo.editarTienda(tienda);
        }

        public void Eliminar(int ID)
        {
            nuevo.eliminarTienda(ID);
        }

        public Tienda LoginTienda(string email, string password)
        {
            string convPass = Utilitarios.CalculateMD5Hash(password);
            return nuevo.LoginTienda(email, convPass);
        }

        public bool ConfirmaTienda(string email, string uid)
        {
           return nuevo.ConfirmaTienda(email, uid);
        }

        public List<Tienda> ObtenerTiendasPorCategoria(int idCategoria) {

            return nuevo.ObtenerTiendasPorCategoria(idCategoria);
        }

        public List<Tienda> Obtener()
        {

            DataTable tabla = new DataTable();
            List<Tienda> tiendas = new List<Tienda>();
            tiendas = nuevo.ObtenerTiendas();

            return tiendas;
        }

    }
    
}