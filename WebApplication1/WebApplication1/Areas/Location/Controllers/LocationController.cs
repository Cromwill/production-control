using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using WebApplication1.Areas.Location.Models;
using WebApplication1.Areas.Location.Models.Repos;
using System.Collections.Generic;

namespace WebApplication1.Areas.Location.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult> CreateLocation()
        {
            var model = new CreateLocationViewModel();
            var customerRepository = new CustomerRepo();
            var customers = new List<string>();
            foreach (var v in await customerRepository.GetAllAsync())
            {
                customers.Add(v.Name);
            }

            SelectList selectListCustomers = new SelectList(customers);
            ViewBag.Customers = selectListCustomers;

            return View();
        }

        // POST: /Location/CreateLocation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateLocation(CreateLocationViewModel model)
        {
            var locationRepository = new LocationRepo();
            var orderRepository = new OrderRepo();
            var customerRepository = new CustomerRepo();

            var userId = User.Identity.GetUserId();
            var location = new Models.Location
            {
                Title = model.Title,
                SecondTitle = model.SecondTitle,
                Customer = model.Customer,
            };

            var order = new Order
            {
                LocationId = location.LocationId,
                UserId = userId
            };

            location.UsersId.Add(userId);
            var testCustIds = await customerRepository.GetAllAsync();

            await locationRepository.AddAsync(location);

            await orderRepository.AddAsync(order);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}