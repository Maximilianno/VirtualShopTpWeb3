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
    public partial class WebForm5 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
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
                ProductoServicio service = new ProductoServicio();
                Tienda tienda = new Tienda();
                tienda = (Tienda)Session["TiendaOnline"];

                int idTienda = tienda.Id;
                List<Producto> listaProductoGeneral = new List<Producto>();
                listaProductoGeneral = service.ObtenerProductos(idTienda);
                Session["listaDeProductosGeneral"] = listaProductoGeneral;
                gvAdmProd.DataSource = listaProductoGeneral;
                //gvAdmProd.Columns[0].Visible = false;
                gvAdmProd.DataBind();
                
            }
        }

        //public List<Producto> DSTable
        //{
        //    get
        //    {
        //        if (ViewState["DSTable"] == null)
        //            return (List<Producto>)ViewState["DSTable"];
        //        return (List<Producto>)ViewState["DSTable"];

        //    }
        //    set
        //    {
        //        ViewState["DSTable"] = value;
        //    }
        //}

        protected void gvAdmProd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAdmProd.EditIndex = Convert.ToInt16(e.NewEditIndex);
            HiddenField1.Value = e.NewEditIndex.ToString();
            gvAdmProd.DataSource = (List<Producto>)Session["listaDeProductosGeneral"];
            gvAdmProd.DataBind();
        }

        protected void gvAdmProd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            
            //TextBox t1 = new TextBox();
            TextBox t2 = new TextBox();
            TextBox t3 = new TextBox();
            TextBox t4 = new TextBox();
            TextBox t5 = new TextBox();
            TextBox t6 = new TextBox();
            //Convert.ToInt16(HiddenField1.Value)

            //t1 = (TextBox)gvAdmProd.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[0].Controls[0];
            var colNoVisible = gvAdmProd.DataKeys[e.RowIndex].Value;
            t2 = (TextBox)gvAdmProd.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[1].Controls[0];
            t3 = (TextBox)gvAdmProd.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[2].Controls[0];
            t4 = (TextBox)gvAdmProd.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[3].Controls[0];
            t5 = (TextBox)gvAdmProd.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[4].Controls[0];
            //t6 = (TextBox)gvAdmProd.Rows[Convert.ToInt16(HiddenField1.Value)].Cells[5].Controls[0];
            DropDownList combo = (DropDownList)gvAdmProd.Rows[e.RowIndex].FindControl("ddlPrueba");
            

            int id = Convert.ToInt32(colNoVisible);
            string nombre = t2.Text;
            string descripcion = t3.Text;
            string stock = t4.Text;
            string precio = t5.Text;
            string categoria = combo.SelectedValue;

            Producto producto = new Producto();
            producto.ID = id;
            producto.Nombre = nombre;
            producto.Descripcion = descripcion;
            producto.Stock = Convert.ToInt32(stock);
            producto.Precio = (float)System.Convert.ToSingle(precio);
            producto.IdCategoria = Convert.ToInt32(categoria);
            //CategoriaServicio categoriaServicio = new CategoriaServicio();
            //int idCategoria = categoriaServicio.obtenerIdDeCategoria(categoria);

            int filaEditada = e.RowIndex;

            //Edicion Visual
            List<Producto> listaVisual = (List<Producto>)Session["listaDeProductosGeneral"];
            Producto productoAModificar = listaVisual[filaEditada];
            productoAModificar.ID = id;
            productoAModificar.Nombre = nombre;
            productoAModificar.Descripcion = descripcion;
            productoAModificar.Stock = Convert.ToInt32(stock);
            productoAModificar.Precio = (float)System.Convert.ToSingle(precio);
            productoAModificar.IdCategoria = Convert.ToInt32(categoria);

            listaVisual.Insert(filaEditada, productoAModificar);

            ProductoServicio productoServicio = new ProductoServicio();
            productoServicio.Editar(producto);

            
           
           
            //DSTable.Rows[e.RowIndex]["Id"] = id;
            //DSTable.Rows[e.RowIndex]["Nombre"] = nombre;
            //DSTable.Rows[e.RowIndex]["Descripcion"] = descripcion;
            //DSTable.Rows[e.RowIndex]["Stock"] = stock;
            //DSTable.Rows[e.RowIndex]["Precio"] = precio;
            //DSTable.Rows[e.RowIndex]["Categoria"] = categoria;



            gvAdmProd.EditIndex = -1;
            //gvAdmProd.DataSource = listaVisual;
            gvAdmProd.DataBind();

            Response.Redirect("adminProductos.aspx");
        }

        protected void gvAdmProd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAdmProd.EditIndex = -1;
            gvAdmProd.DataSource = (List<Producto>)Session["listaDeProductosGeneral"]; 
            gvAdmProd.DataBind();
        }

        protected void gvAdmProd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = gvAdmProd.Rows[e.RowIndex].Cells[0];
            var colNoVisible = gvAdmProd.DataKeys[e.RowIndex].Value;

            int id = Convert.ToInt32(colNoVisible);
            ProductoServicio productoServicio = new ProductoServicio();
            productoServicio.Eliminar(id);
            gvAdmProd.DataBind();
            Response.Redirect("adminProductos.aspx");

            
        }

        
    }
}