using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;


namespace Contronic.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {

        public ActionResult MailSender(string userEmail, string subject, string name, string message)
        {
            MailMessage mail = new MailMessage();

            SmtpClient Smtp = new SmtpClient()
            {
                Host = "smtp.unoeuro.com",
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential("info@contronic.dk", "6940lemst")
            };

            mail.From = new MailAddress("info@contronic.dk");
            mail.To.Add("info@contronic.dk");
            mail.Subject = "Mail fra Contronic - Kontakt";
            mail.IsBodyHtml = true;

            mail.Body = "Name:" + name +
                "<br /> Mail: " + userEmail +
                "<br /><br />Besked:" + message;

            Smtp.Send(mail);

            return RedirectToUmbracoPage(1052, "status=sent");
        }

        public ActionResult InstalSender(string firm, string phone, string name, string userEmail, string City, string message)
        {
            MailMessage mail = new MailMessage();

            SmtpClient Smtp = new SmtpClient()
            {
                Host = "smtp.unoeuro.com",
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential("info@contronic.dk", "6940lemst")
            };

            mail.From = new MailAddress(userEmail);
            mail.To.Add("info@contronic.dk");
            mail.Subject = "Mail fra Contronic - Installatør";
            mail.IsBodyHtml = true;
             
            
            mail.Body = "Firma:" + firm +
                "<br /> Navn: " + name +
                "<br /> Telefon: " + phone +
                "<br /> Email: " + userEmail +
                "<br /> Område: " + City +
                "<br /> Mail: " + message;

            Smtp.Send(mail);

            return RedirectToUmbracoPage(1052, "status=sent");
        }
    }
}