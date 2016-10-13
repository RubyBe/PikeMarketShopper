using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Models;

namespace PikeMarketShopper.Controllers
{
  [AllowAnonymous]
  public class CartController : Controller
  {
    PikeMarketDbContext db = new PikeMarketDbContext();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
      //IEnumerable<Product> productList = db.Products.ToList(); 
      //return View(productList);
      return View();
    }
  }
}
