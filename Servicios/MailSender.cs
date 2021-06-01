using System;


namespace Servicios
{
    public static class MailSender
    {
        public static bool EnviarMail(string mail, string mensaje, string asunto)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(mail);
                message.Subject = asunto;
                message.From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["MailAddress"].ToString(), System.Configuration.ConfigurationManager.AppSettings["NombreEmisor"].ToString());
                message.Body = mensaje;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["SMTP"].ToString());
                smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SMTPPORT"].ToString());
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Usuario"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Clave"].ToString());
                smtp.UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"].ToString());
                smtp.Credentials = SMTPUserInfo;
                smtp.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSSL"].ToString());
                smtp.Send(message);
                return true;
            }
            catch(Exception ex)
            {
                EventManager.RegistrarErrores(ex);
                return true;
            }
        }
        public static bool EnviarMail(string mail, string mensaje, string asunto, string usuario, string nombreEmisor, string mailEmisor, string passEmisor, string smtp, int puerto, bool ssl, bool CredXdefault) 
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(mail);
                message.Subject = asunto;
                message.From = new System.Net.Mail.MailAddress(mailEmisor, nombreEmisor);
                message.Body = mensaje;
                System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient(smtp);
                SMTP.Port = puerto;
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(usuario, passEmisor);
                SMTP.UseDefaultCredentials = Convert.ToBoolean(CredXdefault);
                SMTP.Credentials = SMTPUserInfo;
                SMTP.EnableSsl = Convert.ToBoolean(ssl);
                SMTP.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}

