using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  [Table("Carts")]
  public class Cart
  {

    public Cart(string type, double sentiment, int id = 0)
    {
      Type = type;
      Sentiment = sentiment;
      CartId = id;
    }

    // A class defining a shopping cart for a shopping session
    [Key]
    public int RecordId { get; set; }
    public int CartId { get; set; }
    public double Sentiment { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public virtual Product Product { get; set; }
    public DateTime DateCreated { get; set; }
  }
}
