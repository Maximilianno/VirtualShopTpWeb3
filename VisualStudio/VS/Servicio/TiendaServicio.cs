﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisualStudio.VS.Datos;
using System.Data;
using VisualStudio.Entidad;

namespace VisualStudio.VS.Servicio
{
    public class TiendaServicio
    {
        
        AccesoADatos nuevo = new AccesoADatos();
        
        public void insertar(Tienda tienda)
        {
            nuevo.insertarNuevaTienda(tienda);          
        }

        //public DataTable obtener(string email)
        //{
        //    return nuevo.obtenerTienda(email);
        //}

        public void editar(Tienda tienda)
        {
            nuevo.editarTienda(tienda);
        }

        public void eliminar(int ID)
        {
            nuevo.eliminarTienda(ID);
        }

        public DataTable loginTienda(string email, string password)
        {
            return nuevo.loginTienda(email, password);
        }

        public void activarTienda(string modo, string email)
        {
            nuevo.activarTiendaPorEmail(modo, email);
        }
        

    }
    
}