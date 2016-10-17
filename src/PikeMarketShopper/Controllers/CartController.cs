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

    public IActionResult GetProduct(double sentiment)
    {
      //// Determine the number of products to be returned - the lower the sentiment, the greater the number of products. A sentiment of 0.236, e.g., will return an int product tracker of 7, after trimming the string tracker result of 0.764
      //double tracker = 1 - sentiment;
      //string strTracker = tracker.ToString();
      //string subStrTracker = "";
      //string trimTracker = "";
      //// Start the end trimming based on the first non-zero digit of the tracker (always position 2 or greater) and then get the first meaningful digit which is at the end of the string.
      //if(tracker < 0.1)
      //{
      //  subStrTracker = strTracker.Remove(2);
      //  trimTracker = subStrTracker.Substring(subStrTracker.Length - 1);
      //}
      //else
      //{
      //  subStrTracker = strTracker.Remove(3);
      //  trimTracker = subStrTracker.Substring(subStrTracker.Length - 1);
      //}
      //// Convert the string digit to a char and then return its numerical value
      //char charTracker = trimTracker[0];
      //int productTracker = (int)Char.GetNumericValue(charTracker);
      //// Use the numerical value to pull that number of products from the database
      
      // Alternatively, pull the first product which has a sentiment value greater than the sentiment passed in.
      Product selectedProduct = db.Products.FirstOrDefault(product => product.SentimentValue > sentiment);
      string name = selectedProduct.Name;
      double price = selectedProduct.Price;
      string image = selectedProduct.Image;
      Product returnProduct = new Product(name, price, image);
      return Json(returnProduct);
    }
  }
}
