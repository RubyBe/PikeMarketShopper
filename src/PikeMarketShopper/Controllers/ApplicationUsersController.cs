using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using PikeMarketShopper.Models;
using Microsoft.EntityFrameworkCore;

namespace PikeMarketShopper.Controllers
{
  public class ApplicationUsersController : Controller
  {
    PikeMarketDbContext db = new PikeMarketDbContext();
    public IActionResult Index()
    {
      return View(db.Users.ToList());
    }

    // Get and Post for Editing an existing user
    public IActionResult Edit(string id)
    {
      var thisUser = db.Users.Select(user => user.Id == id);
      return View(thisUser);
    }
    //[HttpPost]
    //public IActionResult Edit(ApplicationUser user)
    //{
    //  //db.Entry(product).State = EntityState.Modified;
    //  //db.SaveChanges();
    //  return RedirectToAction("Index");
    //}
  }
}
