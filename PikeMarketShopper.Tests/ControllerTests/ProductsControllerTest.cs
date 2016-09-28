using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Controllers;
using PikeMarketShopper.Models;
using Xunit;

namespace PikeMarketShopper.Tests.ControllerTests
{
  public class ProductsControllerTest
  {
    [Fact]
    public void Get_ViewResult_Index_Test()
    {
      // Arrange
      ProductsController controller = new ProductsController();
      // Act
      var result = controller.Index();
      // Assert
      Assert.IsType<ViewResult>(result);
    }
  }
}
