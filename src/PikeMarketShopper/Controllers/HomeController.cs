using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Models;


namespace PikeMarketShopper.Controllers
{
  public class HomeController : Controller
  {
    // internal properties for Identity management
    private readonly PikeMarketDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    // constructor for Identity manager
    public  HomeController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PikeMarketDbContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public IActionResult Index()
    {
        return View();
    }
  }
}
