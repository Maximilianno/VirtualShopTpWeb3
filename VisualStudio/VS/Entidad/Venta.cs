using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualStudio.Entidad
{
    public class Venta
    {
        public int Id { set; get; }
        public int IdTienda { set; get; }
        public int IdProducto { set; get; }
        public string NombreProducto { get; set; }
        public string EmailComprador { set; get; }
        public DateTime FechaTransaction { set; get; }
        public int Cantidad { set; get; }
        public float PrecioUnitario { set; get; }
        public string Estado { set; get; }
    }
}