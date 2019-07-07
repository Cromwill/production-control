using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Areas.Location.Models;

namespace WebApplication1.Areas.Location.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Location/Customer
        public ActionResult Index()
        {
            return View();
        }

        // Get
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCustomer(CreateCustomerViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var customer = new Models.Customer
            {
                Name = model.Name,
                Address = model.Address,
            };

            using (var context = new ProductContolEntities())
            {
                context.Customers.Add(customer);

                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}