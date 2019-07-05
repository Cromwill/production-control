using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Location.Models;

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
            var userId = User.Identity.GetUserId();

            using (var context = new ProductContolEntities())
            {
                context.Locations.Add(new Models.Location
                {
                    Title = model.Title,
                    SecondTitle = model.SecondTitle,
                    Customer = model.Customer,
                    //CreatorId = userId
                });

                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}