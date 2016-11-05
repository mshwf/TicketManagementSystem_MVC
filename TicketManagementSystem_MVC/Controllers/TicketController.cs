using System.Net.Mail;
using System.Web.Mvc;
using TicketManagementSystem_MVC.DAL;
using TicketManagementSystem_MVC.Models;

namespace TicketManagementSystem_MVC.Controllers
{
    public class TicketController : Controller
    {
        private TicketSysContext db = new TicketSysContext();
        const string ticketSentKey = "ticketSent";
        // GET: Ticket
        public ActionResult Index()
        {
            var ticketSent = false;
            if (TempData.ContainsKey(ticketSentKey))
                ticketSent = bool.Parse(TempData[ticketSentKey].ToString());
            if (ticketSent == true)
                ViewBag.IfcText = "done";
            else
                ViewBag.IfcText = "hello";
            return View();
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerName,Email,LaptopModelNumber,Subject,Description")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                string absPath = Server.MapPath(@"~\App_Data\EmailHtml.txt");
                var body = System.IO.File.ReadAllText(absPath);
                var message = new MailMessage();
                message.To.Add(new MailAddress("tmsys2016@gmail.com"));
                message.Subject = string.Format($"New from support center - [{ticket.Subject}]");
                message.Body = string.Format(body, ticket.OwnerName, ticket.Email, ticket.LaptopModelNumber, ticket.Subject, ticket.Description, ticket.TicketNumber, ticket.TicketDate);
                message.IsBodyHtml = true;
                try
                {
                    using (var smtp = new SmtpClient())
                    {
                        smtp.Send(message);
                        TempData[ticketSentKey] = true;
                        return RedirectToAction("Index");
                    }

                }
                catch (SmtpFailedRecipientException)
                {
                    ViewBag.ErrorInfo = "SMTP server cannot proceed your request now, try again later.";
                    return View("Error");
                }
            }

            return View(ticket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
