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
    public IActionResult CreateProductTypesData()
    {
      ProductType productType1 = new Models.ProductType
      {
        Description = "Pike Place Market’s dozens of specialty food stores carry the spices, ingredients and products for nearly any kind of culinary endeavor or adventurous recipe.",
        Name = "Specialty Foods"
      };
      productTypeRepo.Save(productType1);
      ProductType productType2 = new Models.ProductType
      {
        Description = "The Pike Place Market’s year-round produce stands, called highstalls, sell fresh fruits, vegetables, herbs, locally foraged mushrooms and seasonal favorites from around the world and from local growers.",
        Name = "Produce"
      };
      productTypeRepo.Save(productType2);
      ProductType productType3 = new Models.ProductType
      {
        Description = "Shop at the Pike Place Market fish markets, butchers and dairy shops for fresh seafood, meat and dairy products from knowledgeable producers who know how and where the food was caught, raised or made.",
        Name = "Fresh Fish, Meat, and Dairy"
      };
      productTypeRepo.Save(productType3);
      ProductType productType4 = new Models.ProductType
      {
        Description = "The Market is filled with delicious foods—some made right here and others from around the world. Check out the wide variety of gourmet offerings and everyday staples. ",
        Name = "Artisan/Imported"
      };
      productTypeRepo.Save(productType4);
      return RedirectToAction("Index");
    }

    public IActionResult CreateProductsData()
    {
      Product product1 = new Models.Product
      {
        Description = "Seasoning",
        Image = "/img/adobada.jpg",
        Name = "Adobada",
        Price = 1.49,
        ProductTypeId = 1,
        SentimentValue = 0.1,
        Size = "1 package"
      };
      productRepo.Save(product1);
      Product product2 = new Models.Product
      {
        Description = "Leafy greens",
        Image = "/img/kale.jpg",
        Name = "Fresh Kale",
        Price = 2.59,
        ProductTypeId = 2,
        SentimentValue = 0.2,
        Size = "1 bunch"
      };
      productRepo.Save(product2);
      Product product3 = new Models.Product
      {
        Description = "Small measure cups",
        Image = "/img/measure.PNG",
        Name = "Mini Measure",
        Price = 6.95,
        ProductTypeId = 4,
        SentimentValue = 0.3,
        Size = "1 set"
      };
      productRepo.Save(product3);
      Product product4 = new Models.Product
      {
        Description = "Fresh herbs",
        Image = "/img/herbs.jpg",
        Name = "Parsley",
        Price = 1.99,
        ProductTypeId = 2,
        SentimentValue = 0.4,
        Size = "1 package"
      };
      productRepo.Save(product4);
      Product product5 = new Models.Product
      {
        Description = "Hot sauces",
        Image = "/img/salsa.jpg",
        Name = "Spicy Salsa",
        Price = 4.39,
        ProductTypeId = 1,
        SentimentValue = 0.5,
        Size = "12 ounces"
      };
      productRepo.Save(product5);
      Product product6 = new Models.Product
      {
        Description = "Smoked fish",
        Image = "/img/king.jpg",
        Name = "Smoked King Salmon Fillets",
        Price = 27.95,
        ProductTypeId = 3,
        SentimentValue = 0.6,
        Size = "8 ounces"
      };
      productRepo.Save(product6);
      Product product7 = new Models.Product
      {
        Description = "Chicken sausage",
        Image = "/img/sausage.jpg",
        Name = "Uli's Famous Chicken Sausage",
        Price = 18.95,
        ProductTypeId = 3,
        SentimentValue = 0.7,
        Size = "3 pounds"
      };
      productRepo.Save(product7);
      Product product8 = new Models.Product
      {
        Description = "Spicy cured sausage",
        Image = "/img/landjaeger.jpg",
        Name = "Bavarian Meats Hot and Spicy Landjaeger",
        Price = 8.49,
        ProductTypeId = 3,
        SentimentValue = 0.8,
        Size = "1 pound"
      };
      productRepo.Save(product8);
      Product product9 = new Models.Product
      {
        Description = "Lotion bar",
        Image = "/img/bar.jpg",
        Name = "Moon Valley Organics Melt",
        Price = 11.99,
        ProductTypeId = 4,
        SentimentValue = 0.9,
        Size = "1 package"
      };
      productRepo.Save(product9);
      Product product10 = new Models.Product
      {
        Description = "Roasted cacao beans",
        Image = "/img/indicacao.jpg",
        Name = "Cacao Beans",
        Price = 21.49,
        ProductTypeId = 1,
        SentimentValue = 1,
        Size = "8 ounces"
      };
      productRepo.Save(product10);
      return RedirectToAction("Index");
    }
  }
}
