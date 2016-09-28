//this is currently a duplicate of everything in the Account controller which is the directory that's actually being used - couldn't get identity to work unless controller and views are under 'account'


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Models;
using PikeMarketShopper.ViewModels;
using System.Threading.Tasks;

namespace PikeMarketShopper.Controllers
{
  public class HomeController : Controller
  {
    private readonly PikeMarketDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PikeMarketDbContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

  }
}
