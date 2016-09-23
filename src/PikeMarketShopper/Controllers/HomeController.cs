using Microsoft.AspNetCore.Mvc;


namespace PikeMarketShopper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
