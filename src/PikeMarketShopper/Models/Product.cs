using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  [Table("Products")]
  public class Product
  {
    public Product()
    {

    }
    public Product(string name, double price)
    {
      Name = name;
      Price = price;
    }


    public override bool Equals(System.Object otherProduct)
    {
      if (!(otherProduct is Product))
      { return false;  }
      else
      {
        Product newProduct = (Product)otherProduct;
        return this.ProductId.Equals(newProduct.ProductId);
      }
    }
    public override int GetHashCode()
    {
      return this.ProductId.GetHashCode();
    }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Size { get; set; }
    public double Price { get; set; }
    public double SentimentValue { get; set; }
    public string Image { get; set; }
    public int ProductTypeId { get; set; }
    public virtual ProductType ProductType { get; set; }
    // the inventory table is a lookup table between Product and Shop
    public virtual ICollection<Inventory> Shops { get; set; }
  }
}
