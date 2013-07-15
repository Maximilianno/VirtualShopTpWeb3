using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using VisualStudio.VS;
using VisualStudio.VS.Servicio;
using VisualStudio.Entidad;
using VisualStudio.VS.classes;
using System.IO;

namespace VisualStudio.VS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string captchacode = Session["captchacode"].ToString();
            if (captchacode == txtbxCaptcha.Text)
            {


                Tienda tienda = new Tienda();
                tienda.RazonSocial = txtbxRazonSocial.Text;
                tienda.Email = txtbxMail.Text;
                tienda.Password = txtbxContrasena.Text;
                tienda.CUIT = txtbxCUIT.Text;

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
                            String photoFolder = Path.Combine(Server.MapPath("~/VS/photos"), Convert.ToString(tienda.Email));
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

                tienda.Imagen = pathImagen;

                try
                {
                    TiendaServicio tiendaServicio = new TiendaServicio();
                    tiendaServicio.Insertar(tienda);
                    Utilitarios.SendMail(tienda.Email);
                    dvMessage.InnerHtml = "<h4 class= \"alert_success\">El producto: " + txtbxRazonSocial.Text + " ha sido insertado correctamente.</h4>";
                }
                catch (System.Data.SqlClient.SqlException)
                {

                    dvMessage.InnerHtml = "<h4 class= \"alert_error\">Ha ocurrido un error al insertar el producto: " + txtbxRazonSocial.Text + ".</h4>";

                }
   
            }
        }

    }
}