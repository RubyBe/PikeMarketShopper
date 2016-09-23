using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  [Table("Addresses")]
  public class Address
  {
    // A class defining a shipping address for a customer
    [Key]
    public int AddressId { get; set; }
    public int Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public int CustomerId { get; set; } // belongs to a customer
    public virtual Customer Customer { get; set; }
  }
}
