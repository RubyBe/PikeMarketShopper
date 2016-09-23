using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
using System.Linq;
using PikeMarketShopper.Models;
using Microsoft.EntityFrameworkCore;

namespace PikeMarketShopper.Controllers
{
  public class ProductsController : Controller
  {
    PikeMarketDbContext db = new PikeMarketDbContext();

    // View a listing of all products - indlude a list of all product types for future filtering
    public IActionResult Index()
    {
      dynamic duoModelIndex = new ExpandoObject();
      var theseProducts = db.Products.ToList();
      var theseProductTypes = db.ProductTypes.ToList();
      duoModelIndex.Products = theseProducts;
      duoModelIndex.ProductTypes =theseProductTypes;
      return View(duoModelIndex);
    }

    // View the details of a specific product - include the product type for this specific product
    public IActionResult Details(int id)
    {
      dynamic duoModelDetails = new ExpandoObject();
      var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
      var thisProductType = db.ProductTypes.FirstOrDefault(producttype => producttype.ProductTypeId == thisProduct.ProductTypeId);
      duoModelDetails.Products = thisProduct;
      duoModelDetails.ProductTypes = thisProductType;
      return View(duoModelDetails);
    }

    // Get and Post for Creating a new product
    public IActionResult Create()
    {
      ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Name");
      return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
      db.Products.Add(product);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
    // Get and Post for Editing an existing product
    public IActionResult Edit(int id)
    {
      ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Name");
      var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }
    [HttpPost]
    public IActionResult Edit(Product product)
    {
      db.Entry(product).State = EntityState.Modified;
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    //Post for Confirming Delete and Deleting an existing product
    public IActionResult Delete(int id)
    {
      var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
      db.Remove(thisProduct);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
