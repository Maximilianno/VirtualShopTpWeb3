using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualStudio.Entidad
{
    [Serializable]
    public class Producto
    {
        public string TiendaRazonSocial { set; get; }
        public int ID { set; get; }
        public int idTienda { set; get; }
        public int IdCategoria { set; get; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        
     
        
        
   
    }


    
        

    
}
