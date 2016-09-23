using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  [Table("Carts")]
  public class Cart
  {
    // A class defining a shopping cart for a shopping session
    [Key]
    public int CartId { get; set; }
    public string Type { get; set; }
    public decimal Sentiment { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public virtual ICollection<Product> Products { get; set; }

  }
}
