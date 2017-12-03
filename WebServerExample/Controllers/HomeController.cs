using WebServerExample.Infrastructure;
using WebServerExample.Infrastructure.Results;

namespace WebServerExample.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            int counter = (Session["counter"] != null) ? (int)Session["counter"] : 0;
            counter++;
            Session["counter"] = counter;
            var model = new { title = "Homepage", counter = counter};
            return View("Index", model);
        }

        public string Details(int id)
        {
            return "Details of product " + id;
        }
    }
}