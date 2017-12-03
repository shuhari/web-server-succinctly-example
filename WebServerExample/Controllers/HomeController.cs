using System;
using WebServerExample.Infrastructure;
using WebServerExample.Infrastructure.Results;
using WebServerExample.Middlewares;

namespace WebServerExample.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            int counter = (Session["counter"] != null) ? (int)Session["counter"] : 0;
            counter++;
            Session["counter"] = counter;
            var model = new
            {
                title = "Homepage", 
                counter = counter,
                user = User,
            };
            return View("Index", model);
        }

        public ActionResult Login()
        {
            string userName = Request.Form["username"];
            string password = Request.Form["password"];
            if (userName == "admin" && password == "1234")
            {
                Authentication.Login(HttpContext, userName);
            }
            return Redirect("/Home/Index");
        }

        public ActionResult Logout()
        {
            Authentication.Logout(HttpContext);
            return Redirect("/Home/Index");
        }
        
        public string Details(int id)
        {
            return "Details of product " + id;
        }
    }
}