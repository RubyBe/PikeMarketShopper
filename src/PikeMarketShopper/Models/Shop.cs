using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  [Table("Shops")]
  public class Shop
  {
    [Key]
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string GeoLocation { get; set; }
    public int Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    // the inventory table is a lookup table between Product and Shop
    public virtual ICollection<Inventory> Products { get; set; }
  }
}
