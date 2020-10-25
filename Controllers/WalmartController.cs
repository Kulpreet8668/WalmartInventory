using Microsoft.AspNetCore.Mvc;

namespace WalmartInventory.Controllers
{
    public class WalmartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}