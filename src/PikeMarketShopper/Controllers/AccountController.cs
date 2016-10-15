using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Models;
using PikeMarketShopper.ViewModels;
using System.Threading.Tasks;

namespace PikeMarketShopper.Controllers
{
  [AllowAnonymous]
  public class AccountController : Controller
  {
    // properties for user authentication, login and logout
    private readonly PikeMarketDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    // properties for user role management
    private readonly RoleManager<ApplicationRole> _roleManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
    {
      this._userManager = userManager;
      this._signInManager = signInManager;
      this._roleManager = roleManager;
    }

    public IActionResult Index()
    {
      return View();
    }

    // Create a new user account
    public IActionResult Register()
    {
      return View();
    }
    // Add user, assign role, write to Identity tables
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      ModelState.Clear();
      ApplicationUser user = new Models.ApplicationUser();
      user.UserName = model.Email;
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        ApplicationRole role = new ApplicationRole();
        role.Name = "NormalUser";
        IdentityResult roleResults = await _roleManager.CreateAsync(role);
        _userManager.AddToRoleAsync(user, "NormalUser").Wait(); // or, Administrator
      }
      else
      {
        return View();
      }
      // automatically sign in user after registration
      Microsoft.AspNetCore.Identity.SignInResult resultNext = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View();
      }
    }

    // Authenticate returning user
    public IActionResult Login()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      ModelState.Clear();
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View();
      }
    }

    // Log out current user
    [HttpPost]
    public async Task<IActionResult> Logoff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

    // A view when login is required
    public IActionResult Forbidden()
    {
      return View();
    }
  }
}
