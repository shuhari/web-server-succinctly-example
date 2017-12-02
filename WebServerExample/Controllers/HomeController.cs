using WebServerExample.Infrastructure;

namespace WebServerExample.Controllers
{
    public class HomeController : Controller
    { 
        public string Index()
        {
            return "Index Page";
        }

        public string Details(int id)
        {
            return "Details of product " + id;
        }
    }
}