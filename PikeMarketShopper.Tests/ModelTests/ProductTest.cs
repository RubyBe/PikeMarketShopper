using PikeMarketShopper.Models;
using Xunit;

namespace PikeMarketShopper.Tests
{
  public class ProductTest
  {
    [Fact]
    public void GetSetProductProperties()
    {
      // Arrange
      // TODO -- add shops test
      var product = new Product();
      var productType = new ProductType();
      product.ProductId = 1;
      product.Name = "testName";
      product.Description = "testDescription";
      product.Size = "testSize";
      product.Price = 0;
      product.SentimentValue = 0;
      product.Image = "testImage";
      product.ProductTypeId = 1;
      // Act -- could string these together and use a single assert if preferred
      var expectedId = product.ProductId;
      var expectedName = product.Name;
      var expectedDescription = product.Description;
      var expectedSize = product.Size;
      var expectedPrice = product.Price;
      var expectedSentimentValue = product.SentimentValue;
      var expectedImage = product.Image;
      var expectedProductTypeId = product.ProductTypeId;
      // Assert
      Assert.Equal(1, expectedId);
      Assert.Equal("testName", expectedName);
      Assert.Equal("testDescription", expectedDescription);
      Assert.Equal("testSize", expectedSize);
      Assert.Equal(0, expectedPrice);
      Assert.Equal(0, expectedSentimentValue);
      Assert.Equal("testImage", expectedImage);
      Assert.Equal(1, expectedProductTypeId);
    }
  }
}
