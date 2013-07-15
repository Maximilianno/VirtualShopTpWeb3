using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualStudio.Entidad
{
    public class Tienda
    {
        public String RazonSocial{set; get;}
        public int Id { set; get; }
        public String IdRegistracion { set; get; }
        public String Email { set; get; }
        public String Password { set; get; }
        public String Imagen{ set; get; }
        public String CUIT { set; get; }
        public String Estado { set; get; }
        public DateTime FechaRegistracion { set; get; }
    }


}