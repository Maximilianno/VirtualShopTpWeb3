using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace VisualStudio.VS.classes
{
    public static class Utilitarios
    {
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static Boolean SendMail(string dirEmail)
        {
            try
            {
                //Configuración del Mensaje
                String uid = CalculateMD5Hash(dirEmail+"BirdIsTheWord");
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("virtual.shop.unlam@gmail.com", "Virtual Shop", Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = "Registracion en Virtual Shop";
                //Aquí ponemos el mensaje que incluirá el correo
                mail.IsBodyHtml = true;
                mail.Body = "Bienvenido a nuestro <b>sistema de administracion de tiendas Virtual Shop!.</b></ br>Para confirmar su registracion, debe hacer clic en el link que está a continuacion: <a>http://localhost:45876/VS/pages/confirmaregistro.aspx?email="+dirEmail+"&uid="+uid+"</a>";
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add(dirEmail);

                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("virtual.shop.unlam@gmail.com", "Virtual2013");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}