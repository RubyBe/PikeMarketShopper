using Microsoft.AspNetCore.Authorization;
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

    public IActionResult Index()
    {
      return View();
    }
  }
}
