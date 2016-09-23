using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  [Table("Inventories")]
  public class Inventory
  {
    [Key]
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public int ShopId { get; set; }
    public virtual Shop Shop { get; set; }
  }
}
