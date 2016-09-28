using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace PikeMarketShopper.Controllers
{
  [Authorize]
  public class CartController : Controller
  {
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
      return View();
    }
  }
}
