using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualStudio.Entidad
{
    public class Venta
    {
        int Id { set; get; }
        int IdProducto { set; get; }
        string EmailComprador { set; get; }
        DateTime FechaTransaction { set; get; }
        int Cantidad { set; get; }
        int PrecioUnitario { set; get; }
        string Estado { set; get; }
    }
}