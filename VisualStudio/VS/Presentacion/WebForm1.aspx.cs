using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.VS.Servicio;
using VisualStudio.Entidad;

namespace VisualStudio.VS.Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoServicio service = new ProductoServicio();
            Tienda tienda = new Tienda();
            //tienda = (Tienda)Session["TiendaOnline"];

            //int idTienda = tienda.Id;
            //DSTable = service.ObtenerProductos(idTienda);
            gvPrueba.DataSource = service.ObtenerProductos(2);
            //gvAdmProd.Columns[0].Visible = false;
            gvPrueba.DataBind();
            //ucElegirCategoria la = (ucElegirCategoria)gvPrueba.FindControl("ddlCategoria");
            //la.Desabilitar();
            
            
        }

        protected void gvPrueba_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvPrueba.SelectedRow ;
            DropDownList drop = (DropDownList)gvPrueba.FooterRow.FindControl("dllPrueba");
            string valor = drop.SelectedValue;
            Label1.Text = valor;
        }

        protected void gvPrueba_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvPrueba.SelectedRow;
            //DropDownList drop = (DropDownList)row.FindControl("ddlPrueba");
            //string valor = drop.SelectedValue;
            //Label1.Text = valor;
        }
    }
}