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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void txtbxFechaDeCompra_TextChanged(object sender, EventArgs e)
        {


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //admComp.DataSource = ListasC.MiMetodo();
            //admComp.DataBind();

            if (Session["TiendaOnline"] != null)
            {
                Master.FindControl("noLog").Visible = false;
                Master.FindControl("loge").Visible = true;
                Master.FindControl("menu").Visible = true;
            }
            else
                Response.Redirect("default.aspx");

            if (!IsPostBack)
            {
                CompraServicio service = new CompraServicio();
                Tienda tienda = new Tienda();
                tienda = (Tienda)Session["TiendaOnline"];

                int idTienda = tienda.Id;
                DSTable = service.obtenerVentas(idTienda);
                gvAdmCompras.DataSource = service.obtenerVentas(idTienda);
                gvAdmCompras.DataBind();

            }

        }

        public DataTable DSTable
        {
            get
            {
                if (ViewState["DSTable"] == null)
                    return (DataTable)ViewState["DSTable"];
                return (DataTable)ViewState["DSTable"];

            }
            set
            {
                ViewState["DSTable"] = value;
            }
        }

        protected void gvAdmCompras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //gvAdmCompras.EditIndex = Convert.ToInt16(e.NewEditIndex);
            //HiddenField1.Value = e.NewEditIndex.ToString();
            //gvAdmCompras.DataSource = DSTable;
            //gvAdmCompras.DataBind();
        }

        protected void gvAdmCompras_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //TextBox t1 = new TextBox();
            //TextBox t2 = new TextBox();
            //TextBox t3 = new TextBox();
            //TextBox t4 = new TextBox();
            //TextBox t5 = new TextBox();
            
            ////Convert.ToInt16(HiddenField1.Value)

            //t1 = (TextBox)gvAdmCompras.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[0].Controls[0];
            //t2 = (TextBox)gvAdmCompras.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[1].Controls[0];
            //t3 = (TextBox)gvAdmCompras.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[2].Controls[0];
            //t4 = (TextBox)gvAdmCompras.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[3].Controls[0];
            //t5 = (TextBox)gvAdmCompras.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[4].Controls[0];
            
            //string nombre = t1.Text;
            //string cantidad = t2.Text;
            //string emailComprador = t3.Text;
            //string fecha = t4.Text;
            //string estado = t5.Text;
            

            //Producto producto = new Producto();
            //producto.ID = Convert.ToInt32(id);
            //producto.Nombre = nombre;
            //producto.Descripcion = descripcion;
            //producto.Stock = Convert.ToInt32(stock);
            //producto.Precio = (float)System.Convert.ToSingle(precio);

            //CategoriaServicio categoriaServicio = new CategoriaServicio();
            //int idCategoria = categoriaServicio.obtenerIdDeCategoria(categoria);
            //producto.IdCategoria = idCategoria;

            //ProductoServicio productoServicio = new ProductoServicio();
            //productoServicio.editar(producto);

            ////DSTable.Rows[e.RowIndex]["Id"] = id;
            //DSTable.Rows[e.RowIndex]["Nombre"] = nombre;
            //DSTable.Rows[e.RowIndex]["Descripcion"] = descripcion;
            //DSTable.Rows[e.RowIndex]["Stock"] = stock;
            //DSTable.Rows[e.RowIndex]["Precio"] = precio;
            //DSTable.Rows[e.RowIndex]["Categoria"] = categoria;



            //gvAdmCompras.EditIndex = -1;
            //gvAdmCompras.DataSource = DSTable;
            //gvAdmCompras.DataBind();
        }

        

        protected void gvAdmCompras_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        

        }
}
