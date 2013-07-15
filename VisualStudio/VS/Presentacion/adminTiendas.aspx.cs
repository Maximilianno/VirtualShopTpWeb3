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
    public partial class adminTiendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TiendaServicio tiendaService = new TiendaServicio();
            List<Tienda> tiendas = new List<Tienda>();
            tiendas = tiendaService.Obtener();
            
            TemplateField comboField = new TemplateField();
            DropDownList comboBox = new DropDownList();
            comboBox.ID = "ComboEstado";
            comboBox.Width = 120;
            CargarCombo(ref comboBox);

            comboField.ItemTemplate = (ITemplate)comboBox;

            GrdVwTiendas.Columns.Add(comboField);

            GrdVwTiendas.DataSource = tiendas;
            GrdVwTiendas.DataBind();
        }

        protected void GrdVwTiendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow){
                DropDownList combo =(DropDownList)e.Row.FindControl("ComboEstado");
                CargarCombo(ref combo);
            }
        }

        public void CargarCombo (ref DropDownList combo){
            ListItem item1 = new ListItem();
            ListItem item2 = new ListItem();
            ListItem item3 = new ListItem();
            
            item1.Text = "Activo";
            item1.Value = "A";

            item2.Text = "Desactivado";
            item2.Value = "D";

            item3.Text = "Pendiente";
            item3.Value = "P";

            combo.Items.Add(item1);
            combo.Items.Add(item2);
            combo.Items.Add(item3);
        }

    }
}