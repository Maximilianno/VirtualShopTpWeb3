using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.VS.Servicio;
using VisualStudio.Entidad;
using System.IO;
using log4net; 

namespace VisualStudio.VS
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger(
        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategorias.DataSource = CategoriaServicio.LlenarDDL();
                ddlCategorias.DataTextField= "Nombre";
                ddlCategorias.DataValueField="Id";
                ddlCategorias.DataBind();
            }
            
            if (Session["TiendaOnline"] != null)
            {
                Master.FindControl("noLog").Visible = false;
                Master.FindControl("loge").Visible = true;
                Master.FindControl("menu").Visible = true;
            }
            else
                Response.Redirect("default.aspx");
        }
        protected void create_Click(object sender, EventArgs e)
        {
            ProductoServicio productoServicio = new ProductoServicio();
            Producto producto = new Producto();
            Tienda tiendaLog = new Tienda();
            tiendaLog = (Tienda)Session["TiendaOnline"];
            producto.idTienda = tiendaLog.Id;
            producto.Nombre = txtbxNombre.Text;
            producto.Descripcion = txtbxDescripcion.Text;
            producto.Precio = Convert.ToSingle(txtbxPrecio.Text);
            producto.Stock = Convert.ToInt32(txtbxStock.Text);

            lblStatus.Text = "";
            String pathImagen = "";

            if (fuTiendaImg.HasFile)
            {

                if (
                   (fuTiendaImg.PostedFile.ContentType == "image/jpeg") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/pjpeg") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/x-png") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/bmp") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/jpg") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/gif")
                  )
                {
                    if (Convert.ToInt64(fuTiendaImg.PostedFile.ContentLength) < 100000000)
                    {
                        String photoFolder = Path.Combine(Server.MapPath("~/VS/photos"), Convert.ToString(tiendaLog.Id));
                        if (!Directory.Exists(photoFolder))
                        {
                            Directory.CreateDirectory(photoFolder);
                        }

                        String extension = Path.GetExtension(fuTiendaImg.FileName);
                        String uniqueFileName = Path.ChangeExtension(fuTiendaImg.FileName, DateTime.Now.Ticks.ToString());
                        fuTiendaImg.SaveAs(Path.Combine(photoFolder, uniqueFileName + extension));
                        pathImagen = uniqueFileName + extension;

                    }
                    else
                        lblStatus.Text = "El archivo debe ser menor a 10MB.";
                }
                else
                    lblStatus.Text = "El archivo debe ser una imagen.";

            }
            else
                lblStatus.Text = "No se seleccionó ningún archivo.";

            producto.Imagen = pathImagen;
            producto.IdCategoria = Convert.ToInt32(ddlCategorias.SelectedValue);

            try
            {
                productoServicio.Insertar(producto);
                dvMessage.InnerHtml = "<h4 class= \"alert_success\">El producto: " + txtbxNombre.Text + " ha sido insertado correctamente.</h4>";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                dvMessage.InnerHtml = "<h4 class= \"alert_error\">Ha ocurrido un error al insertar el producto: " + txtbxNombre.Text + ".</h4>";
                
                if (log.IsErrorEnabled)
                {
                    log.Error("Page Load failed : " + ex.Message);
                }
            }
        }
    }
}