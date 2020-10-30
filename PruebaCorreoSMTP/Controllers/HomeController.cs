using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PruebaCorreoSMTP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress("yarodrigueza@ppg.com"));
            email.To.Add(new MailAddress("asolorzanotapia@ppg.com"));
            email.From = new MailAddress("admonconfirmaciondepago@ppg.com");
            email.Subject = "Mensaje de prueba";

            StringBuilder strHtm = new StringBuilder();
            var uno = HttpRuntime.AppDomainAppPath;
            strHtm.Append(System.IO.File.ReadAllText(uno + "/Views/Home/Index.cshtml", Encoding.UTF8));

            System.Net.Mail.AlternateView alterView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strHtm.ToString(), Encoding.UTF8, "text/html");

            email.AlternateViews.Add(alterView);

            //email.Body = strHtm.ToString();
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "10.49.10.55";
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.Credentials = new NetworkCredential("S001846", "");

            try{
                smtp.Send(email);
                email.Dispose();
            }
            catch (Exception ex)
            {

            }


            ViewBag.Message = "Your application description page.";

            return View();
        }

        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}