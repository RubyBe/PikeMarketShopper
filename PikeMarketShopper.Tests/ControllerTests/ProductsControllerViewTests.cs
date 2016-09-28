using Microsoft.AspNetCore.Mvc;
using PikeMarketShopper.Controllers;
using PikeMarketShopper.Models;
using Xunit;

namespace PikeMarketShopper.Tests.ControllerTests
{
  public class ProductsControllerViewTests
  {
    [Fact]
    public void Get_ViewResult_Create_Test()
    {
      // Arrange
      ProductsController controller = new ProductsController();
      // Act
      var result = controller.Create();
      // Assert
      Assert.IsType<ViewResult>(result);
    }
    public void Get_ViewResult_Details_Test()
    {
      // Arrange
      ProductsController controller = new ProductsController();
      // Act
      var result = controller.Details(1);
      // Assert
      Assert.IsType<ViewResult>(result);
    }
    public void Get_ViewResult_Edit_Test()
    {
      // Arrange
      ProductsController controller = new ProductsController();
      // Act
      var result = controller.Edit(1);
      // Assert
      Assert.IsType<ViewResult>(result);
    }
    public void Get_ViewResult_Delete_Test()
    {
      // Arrange
      ProductsController controller = new ProductsController();
      // Act
      var result = controller.Delete(1);
      // Assert
      Assert.IsType<ViewResult>(result);
    }
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
