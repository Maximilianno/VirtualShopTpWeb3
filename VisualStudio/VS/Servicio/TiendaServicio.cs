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
            string convPass = Utilitarios.CalculateMD5Hash(password);
            DataTable miTabla = nuevo.LoginTienda(email, convPass);

            if (miTabla.Rows.Count != 0)
            {
                Tienda userTienda = new Tienda();

                userTienda.Password = Convert.ToString(miTabla.Rows[0]["Password"]);
                userTienda.Id = Convert.ToInt32(miTabla.Rows[0]["Id"]);
                userTienda.Email = Convert.ToString(miTabla.Rows[0]["Email"]);
                userTienda.RazonSocial = Convert.ToString(miTabla.Rows[0]["RazonSocial"]);
                userTienda.CUIT = Convert.ToString(miTabla.Rows[0]["CUIT"]);
                userTienda.Estado = Convert.ToString(miTabla.Rows[0]["Estado"]);

                return userTienda;
            }
            else
                return null;
        }

        public bool ConfirmaTienda(string email, string uid)
        {
           return nuevo.ConfirmaTienda(email, uid);
        }
        

    }
    
}