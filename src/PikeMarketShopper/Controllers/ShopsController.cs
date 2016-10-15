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
        return View(db.Shops.ToList());
    }
  }
}
