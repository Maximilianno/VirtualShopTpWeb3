﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VisualStudio.VS.Datos;

namespace VisualStudio.VS.Servicio
{
    public class CompraServicio
    {
        AccesoADatos nuevo = new AccesoADatos();

        internal DataTable obtenerVentas(int idTienda)
        {
            return nuevo.obtenerVentas(idTienda);
        }
    }
}