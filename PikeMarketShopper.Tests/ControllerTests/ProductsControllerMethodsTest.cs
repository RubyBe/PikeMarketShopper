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
  }
}
