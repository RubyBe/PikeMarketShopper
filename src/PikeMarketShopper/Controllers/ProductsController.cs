using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PikeMarketShopper.Models;
using PikeMarketShopper.Models.Repositories;
using System.Dynamic;
using System.Linq;

namespace PikeMarketShopper.Controllers
{
  [AllowAnonymous]
  public class ProductsController : Controller
  {
    //PikeMarketDbContext db = new PikeMarketDbContext();

    private IProductRepository productRepo;
    private IProductTypeRepository productTypeRepo;

    public ProductsController(IProductRepository thisRepo = null)
    {
      if (thisRepo == null)
      {
        this.productRepo = new EFDbRepository();
        this.productTypeRepo = new EFDbRepository();
      }
      else
      {
        this.productRepo = thisRepo;
      }
    }

    // View a listing of all products - include a list of all product types for future filtering
    public IActionResult Index()
    {
      dynamic duoModelIndex = new ExpandoObject();
      var theseProducts = productRepo.Products.ToList();
      var theseProductTypes = productTypeRepo.ProductTypes.ToList();
      duoModelIndex.Products = theseProducts;
      duoModelIndex.ProductTypes =theseProductTypes;
      return View(duoModelIndex);
    }

    // View the details of a specific product - include the product type for this specific product
    public IActionResult Details(int id)
    {
      dynamic duoModelDetails = new ExpandoObject();
      var thisProduct = productRepo.Products.FirstOrDefault(product => product.ProductId == id);
      var thisProductType = productTypeRepo.ProductTypes.FirstOrDefault(producttype => producttype.ProductTypeId == thisProduct.ProductTypeId);
      duoModelDetails.Products = thisProduct;
      duoModelDetails.ProductTypes = thisProductType;
      return View(duoModelDetails);
    }

    // View lists of product by product type
    public IActionResult Categories(int id)
    {
      var theseProducts = productRepo.Products.Where(product => product.ProductTypeId == id);
      return View(theseProducts);
    }

    // Get and Post for Creating a new product
    public IActionResult Create()
    {
      ViewBag.ProductTypeId = new SelectList(productTypeRepo.ProductTypes, "ProductTypeId", "Name");
      return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
      productRepo.Save(product); 
      return RedirectToAction("Index");
    }
    // Get and Post for Editing an existing product
    public IActionResult Edit(int id)
    {
      ViewBag.ProductTypeId = new SelectList(productTypeRepo.ProductTypes, "ProductTypeId", "Name");
      var thisProduct = productRepo.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }
    [HttpPost]
    public IActionResult Edit(Product product)
    {
      productRepo.Edit(product);
      return RedirectToAction("Index");
    }

    //Post for Confirming Delete and Deleting an existing product
    public IActionResult Delete(int id)
    {
      var thisProduct = productRepo.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      var thisProduct = productRepo.Products.FirstOrDefault(product => product.ProductId == id);
      productRepo.Remove(thisProduct);
      productRepo.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
