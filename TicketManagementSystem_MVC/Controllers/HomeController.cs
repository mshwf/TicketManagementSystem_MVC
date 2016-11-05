using System.Web.Mvc;

namespace TicketManagementSystem_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}