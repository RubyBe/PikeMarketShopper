using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using PikeMarketShopper.Models;

namespace PikeMarketShopper.Controllers
{
  public class ProductsController : Controller
  {
    PikeMarketDbContext db = new PikeMarketDbContext();
    public IActionResult Index()
    {
      dynamic duoModel = new ExpandoObject();
      var theseProducts = db.Products.ToList();
      var theseProductTypes = db.ProductTypes.ToList();
      duoModel.Products = theseProducts;
      duoModel.ProductTypes =theseProductTypes;
      return View(duoModel);
    }
  }
}
