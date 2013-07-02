using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualStudio.Entidad
{
    public class Venta
    {
        public int Id { set; get; }
        public int IdProducto { set; get; }
        public string EmailComprador { set; get; }
        public DateTime FechaTransaction { set; get; }
        public int Cantidad { set; get; }
        public int PrecioUnitario { set; get; }
        public string Estado { set; get; }
    }
}