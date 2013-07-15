using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.VS.Servicio;
using System.ComponentModel;

namespace VisualStudio.VS
{
    public partial class ucElegirCategoria : System.Web.UI.UserControl
    {
        public String SelectedValue
        {
            get
            {
                return category.SelectedValue;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                category.DataSource = CategoriaServicio.LlenarDDL();
                category.DataValueField = "Id";
                category.DataTextField = "Nombre";
                category.DataBind();
            }

        }
        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void Habilitar()
        {
            category.Enabled = true;
        }

        public void Desabilitar()
        {
            category.Enabled = false;
        }
    }
}