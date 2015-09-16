using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using RentACar.Models;
using System.Net;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "If you have any question, feel free to ask. <br> We will answer as soon as possible.";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contact(Contact model)
        {
            model.Message = Request.Form["message"];

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                MailMessage mail = new MailMessage();
                
                // Message details
                mail.From = new MailAddress(model.Email);
                mail.Subject = model.Subject;
                mail.IsBodyHtml = false;
                mail.To.Add("RECEIVER EMAIL");

                string sender = "Sender: " + model.Name + "(" + model.Email + ")" + "\n";
                string subject = "Subject: " + model.Subject + "\n\n";
                string body = "Message: " + model.Message + "\n\n";
                string sendFrom = "Sent from: IN Car Rent";

                mail.Body = sender + subject + body + sendFrom;

                // Email configuration
                // "Allow less secure apps" must be enable (Google Account)
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587 );
                client.Credentials = new NetworkCredential("GMAIL USERNAME", "GMAIL PASSWORD");
                client.EnableSsl = true;

                // Sending email
                client.Send(mail);
                mail.Dispose();

                ViewBag.Message = "<br> Your message has been sent successfuly.";
                return View();
            }
            catch
            {
                ViewBag.Message = "<br> Your message has not been sent. Please try again. <br>";
                return View();
            }
        }
    }
}