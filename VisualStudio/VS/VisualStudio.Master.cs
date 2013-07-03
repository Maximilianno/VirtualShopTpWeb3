using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.Entidad;
using VisualStudio.VS.Servicio;
using System.Data;



namespace VisualStudio.VS
{
    public partial class VisualStudio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Tienda tiendaLogged = new Tienda();
            tiendaLogged = (Tienda)Session["TiendaOnline"];
            if (tiendaLogged != null)
            {
                loge.Visible = true;
                menu.Visible = true;
                HyperLink1.Visible= false;
                lblPrueba.Text = tiendaLogged.RazonSocial;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("~/VS/Presentacion/default.aspx");
        }
        protected void Log_Click(object sender, EventArgs e)
        {
            
            TiendaServicio tiendaServicio = new TiendaServicio();
            Tienda logTienda;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            logTienda = tiendaServicio.LoginTienda(email, password);

            if (logTienda != null)
            {

                Session["TiendaOnline"] = logTienda;
                Response.Redirect("default.aspx");

            }
            else
            {
                txtEmail.Text = "";
                txtPassword.Text = "";
                lblMsjError.Text = "El usuario y/o el password son incorrectos";
            }

        }
    }
}