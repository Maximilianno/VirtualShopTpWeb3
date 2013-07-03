using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.VS.classes;
using VisualStudio.VS.Servicio;

namespace VisualStudio.VS.pages
{
    public partial class confirmaRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = Request.QueryString["email"];
            String uid = Request.QueryString["uid"];

            TiendaServicio tiendaService = new TiendaServicio();

            if (tiendaService.ConfirmaTienda(email, uid))
            {
                dvRegister.InnerHtml= "<h2 class = 'alert_success'>Su tienda se encuentra habilitada. Por favor ingrese al sistema con su Correo Electrónico y Contraseña para comenzar.</h2>";
            }
            else {
                dvRegister.InnerHtml= "<h2 class = 'alert_error'>No hemos podido habilitar su tienda correctamente. Deberá registrarse nuevamente.</h2>";

            }
        }
    }
}
