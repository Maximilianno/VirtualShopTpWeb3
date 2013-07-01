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

        //public DataTable obtener(string email)
        //{
        //    return nuevo.obtenerTienda(email);
        //}

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
            string convPass = /*Utilitarios.CalculateMD5Hash*/password;
            return nuevo.loginTienda(email, convPass);
        }

        public void ActivarTienda(string modo, string email)
        {
            nuevo.activarTiendaPorEmail(modo, email);
        }
        

    }
    
}