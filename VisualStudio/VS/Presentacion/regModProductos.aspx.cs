using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.VS.Servicio;
using VisualStudio.Entidad;
using System.IO;

namespace VisualStudio.VS
{
    public partial class WebForm7 : System.Web.UI.Page
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

            if (imgProd.ImageUrl == "")
                imgProd.Visible = false;
            else
                imgProd.Visible = true;

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
            
            // producto.Imagen = fuTiendaImg.PostedFile.FileName;

            lblStatus.Text = "";
            String pathImagen = "";
            //tiendaLog = (Tienda)Session["TiendaOnline"]; //La idea es levantar la tienda de la session...

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
                        // Esto debería cambiarse porque tiene el dir de mi PC.

                        String photoFolder = Path.Combine(Server.MapPath("~/VS/photos"), tiendaLog.Email);
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
            producto.IdCategoria = Convert.ToInt32(ucElegirCategoria.SelectedValue);

            try
            {
                productoServicio.insertar(producto);
                dvMessage.InnerHtml = "<h4 class= \"alert_success\">El producto: " + txtbxNombre.Text + " ha sido insertado correctamente.</h4>";
            }
            catch (System.Data.SqlClient.SqlException)
            {

                dvMessage.InnerHtml = "<h4 class= \"alert_error\">Ha ocurrido un error al insertar el producto: " + txtbxNombre.Text + ".</h4>";

            }

            imgProd.ImageUrl = "~/VS/photos/" + tiendaLog.Email + "/" + pathImagen; // Asi se usa la imagen
            imgProd.Height = 150;
            imgProd.Width = 150;
        }
    }
}