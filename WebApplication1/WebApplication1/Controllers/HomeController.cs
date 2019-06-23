using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Index()
        {
            string url = Request.IsAuthenticated ? "Manage/Index/" : "Account/Login/";
            Response.Redirect(url);
        }
    }
}