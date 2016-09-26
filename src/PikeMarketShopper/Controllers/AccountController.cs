﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Models;
using PikeMarketShopper.ViewModels;
using System.Threading.Tasks;

namespace PikeMarketShopper.Controllers
{
  public class AccountController : Controller
  {
    // properties for user authentication, login and logout
    private readonly PikeMarketDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    // properties for user role management
    //private readonly RoleManager<ApplicationUser> _roleManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PikeMarketDbContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
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
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      ModelState.Clear();
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Login"); // Go immediately to login page
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
        return RedirectToAction("Index");
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
      return RedirectToAction("Index");
    }
  }
}
