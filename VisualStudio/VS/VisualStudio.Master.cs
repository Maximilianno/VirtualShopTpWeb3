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
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            
            DataTable tabla = new DataTable();
            tabla = tiendaServicio.loginTienda(email, password);
            if (tabla.Rows.Count != 0)
            {
                Tienda userTienda = new Tienda();

                userTienda.Password = Convert.ToString(tabla.Rows[0]["Password"]);
                userTienda.Id = Convert.ToInt32(tabla.Rows[0]["Id"]);
                userTienda.Email = Convert.ToString(tabla.Rows[0]["Email"]);
                userTienda.RazonSocial = Convert.ToString(tabla.Rows[0]["RazonSocial"]);
                userTienda.CUIT = Convert.ToString(tabla.Rows[0]["CUIT"]);
                userTienda.Estado = Convert.ToString(tabla.Rows[0]["Estado"]);

                Session["TiendaOnline"] = userTienda;


                noLog.Visible = false;
                loge.Visible = true;
                menu.Visible = true;
                Tienda tienda = new Tienda();
                tienda = (Tienda)Session["TiendaOnline"];
                lblPrueba.Text = tienda.RazonSocial;

            }
            else
                Response.Redirect("default.aspx");

            //TiendaServicio servicioTienda = new TiendaServicio();
            //Tienda userLog = new Tienda();
            //userLog = servicioTienda.login(txtEmail.Text,txtPassword.Text);
            //if (userLog != null)
            //{
            //    Session["userLog"] = userLog;
            //}
            //else {
            //    lblMsjLog.Text = "Acceso Denegado";
            //}
        }
    }
}