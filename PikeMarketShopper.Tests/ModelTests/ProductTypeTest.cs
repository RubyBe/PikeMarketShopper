using PikeMarketShopper.Models;
using Xunit;

namespace PikeMarketShopper.Tests
{
  public class ProductTypeTest
  {
    [Fact]
    public void GetSetProductTypeProperties()
    {
      // Arrange
      // TODO -- add Product test
      var productType = new ProductType();
      productType.ProductTypeId = 1;
      productType.Name = "testName";
      productType.Description = "testDescription";
      // Act - could string these together and have a single Assert if preferred
      var expectedId = productType.ProductTypeId;
      var expectedName = productType.Name;
      var expectedDescription = productType.Description;

      // Assert
      Assert.Equal(1, expectedId);
      Assert.Equal("testName", expectedName);
      Assert.Equal("testDescription", expectedDescription);
    }
  }
}
