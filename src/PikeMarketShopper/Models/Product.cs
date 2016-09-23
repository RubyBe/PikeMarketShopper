using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  [Table("Products")]
  public class Product
  {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public decimal SentimentValue { get; set; }
    public string Image { get; set; }
    public int ProductTypeId { get; set; }
    public virtual ProductType ProductType { get; set; }
    // the inventory table is a lookup table between Product and Shop
    public virtual ICollection<Inventory> Shops { get; set; }
  }
}
