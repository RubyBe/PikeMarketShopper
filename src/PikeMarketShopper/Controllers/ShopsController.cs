using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PikeMarketShopper.Models;

namespace PikeMarketShopper.Controllers
{
  public class ShopsController : Controller
  {
    PikeMarketDbContext db = new PikeMarketDbContext();
    public IActionResult Index()
    {
        return View(db.Shops.ToList());
    }
  }
}
