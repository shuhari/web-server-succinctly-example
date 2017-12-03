using WebServerExample.Infrastructure;

namespace WebServerExample.Controllers
{
    public class HomeController : Controller
    { 
        public string Index()
        {
            int counter = (Session["counter"] != null) ? (int)Session["counter"] : 0;
            counter++;
            Session["counter"] = counter;
            return "Counter = " + counter;
        }

        public string Details(int id)
        {
            return "Details of product " + id;
        }
    }
}