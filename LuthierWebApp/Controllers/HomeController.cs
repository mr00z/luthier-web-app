using System.Web.Mvc;

namespace LuthierWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorize()
        {
            return View();
        }
    }
}