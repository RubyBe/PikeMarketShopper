using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Models;

namespace PikeMarketShopper.Controllers
{
  public class CartController : Controller
  {
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SendSentiment()
    {
      return View();
    }
    [HttpPost]
    public IActionResult SendSentiment(Sentiment newSentiment)
    {
      newSentiment.Send();
      return RedirectToAction("Index");
    }



    public IActionResult Create()
    {
      return View();
    }
  }
}
