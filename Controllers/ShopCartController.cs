using Microsoft.AspNetCore.Mvc;

namespace VillenStore._NET_Version.Controllers
{
    public class ShopCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
