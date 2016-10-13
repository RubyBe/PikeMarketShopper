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
      return View();
    }

    public IActionResult GetProduct(int sentiment)
    {
      Product selectedProduct = db.Products.FirstOrDefault(product => product.SentimentValue < sentiment);
      string name = selectedProduct.Name;
      double price = selectedProduct.Price;
      Product returnProduct = new Product(name, price);
      return Json(returnProduct);
    }
  }
}
