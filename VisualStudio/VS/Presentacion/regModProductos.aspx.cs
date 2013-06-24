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
            producto.Precio = Convert.ToInt32(txtbxPrecio.Text);
            producto.Stock = Convert.ToInt32(txtbxStock.Text);
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
                        // Esto debería cambiarse porque tiene el dir de mi PC.
                        String photoFolder = Path.Combine(@"C:\Users\maxi\Desktop\Fork\VisualStudio\VS\photos", tiendaLog.Email);
                        if (!Directory.Exists(photoFolder))
                        {
                            Directory.CreateDirectory(photoFolder);
                            String extension = Path.GetExtension(fuTiendaImg.FileName);
                            String uniqueFileName = Path.ChangeExtension(fuTiendaImg.FileName, DateTime.Now.Ticks.ToString());

                            fuTiendaImg.SaveAs(Path.Combine(photoFolder, uniqueFileName + extension));
                            pathImagen = photoFolder + fuTiendaImg.FileName;

                        }
                        else
                        {
                            String extension = Path.GetExtension(fuTiendaImg.FileName);
                            String uniqueFileName = Path.ChangeExtension(fuTiendaImg.FileName, DateTime.Now.Ticks.ToString());

                            fuTiendaImg.SaveAs(Path.Combine(photoFolder, uniqueFileName + extension));
                            pathImagen = photoFolder + fuTiendaImg.FileName;
                        }
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
            productoServicio.insertar(producto);

            // Una vez que se guarda habria que vaciar los datos y mostrar un cartelito de OK!!.
            

            //Producto producto = new Producto();
            //producto.Nombre= txtbxNombre.Text;
            //producto.Descripcion= txtbxDescripcion.Text;
            //producto.Precio= Convert.ToInt32(txtbxPrecio.Text);
            //producto.Stock = Convert.ToInt32(txtbxStock.Text);

            //Int32 tamaño = System.Convert.ToInt32(fileUploadTiendaImg.FileBytes.Length);
            //string nombre = fileUploadTiendaImg.FileName.ToString(); 
            //byte[] contenido = new byte[tamaño + 1];

            //fileUploadTiendaImg.PostedFile.InputStream.Read(contenido, 0, tamaño);

            // Get the name of the file to upload. string fileName = Server.HtmlEncode(FileUpload1.FileName);

            // Get the extension of the uploaded file. string extension = System.IO.Path.GetExtension(fileName);

            //productoServicio.insertar(producto);
        }
    }
}