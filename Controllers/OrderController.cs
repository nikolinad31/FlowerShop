
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers
{
    public class OrderController : Controller
    {

        public IActionResult Checkout()
        {
            return View();
        }
    }
}
