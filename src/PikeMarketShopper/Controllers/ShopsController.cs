using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;

using PikeMarketShopper.Models;

namespace PikeMarketShopper.Controllers
{
  [AllowAnonymous]
  public class ShopsController : Controller
  {
    PikeMarketDbContext db = new PikeMarketDbContext();
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int shopType)
    {
      //return View(db.Shops.Where(t => t.Number == shopType).ToList());
      return View();
    }
  }
}
