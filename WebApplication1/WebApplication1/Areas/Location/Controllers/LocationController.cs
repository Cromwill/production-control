using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        // GET: 
        [HttpGet]
        public ActionResult CreateLocation()
        {
            return View();
        }

        // POST: /Location/CreateLocation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateLocation(CreateLocationViewModel model)
        {

            using (var context = new ProductContolEntities())
            {
                context.Locations.Add(new Location
                {
                    Title = model.Title,
                    SecondTitle = model.SecondTitle,
                    Customer = model.Customer
                });

                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CreateUser()
        {
           return View();
        }

        // POST: /Location/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateLocationViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}