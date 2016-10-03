using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Controllers;
using PikeMarketShopper.Models;
using System.Collections.Generic;
using System.Dynamic;
using Xunit;

namespace PikeMarketShopper.Tests.ControllerTests
{
  public class ProductsControllerMethodsTest
  {
    [Fact]
    public void Get_ModelList_Index_Test()
    {
      // Arrange
      ProductsController controller = new ProductsController();
      IActionResult actionResult = controller.Index();
      ViewResult indexView = controller.Index() as ViewResult;
      // Act
      var result = indexView.ViewData.Model;
      // Assert
      Assert.IsType<ExpandoObject>(result);
    }
    [Fact]
    public void Post_MethodAddsProduct_Test()
    {
      // Arrange
      ProductsController controller = new ProductsController();
      Product testProduct = new Product();
      testProduct.Description = "test product";
      testProduct.ProductTypeId = 1;
      // Act
      controller.Create(testProduct);
      ViewResult indexView = new ProductsController().Index() as ViewResult;
      var collection = indexView.ViewData.Model as IEnumerable<Product>;
      // Assert
      Assert.Contains<Product>(testProduct, collection);
      // this test fails because the model being passed in is dynamic - will continue on and see if i can figure a solution out for this later on
    }
  }
}
