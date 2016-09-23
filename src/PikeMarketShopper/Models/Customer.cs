using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikeMarketShopper.Models
{
  //[Table("Customers")]
  public class Customer
  {
    // A class defining a shopping site user
    [Key]
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
    public string UserName { get; set; }
    public int CartId { get; set; } // will get cleared out each shopping trip
    public virtual ICollection<Address> Addresses { get; set; } // has multiple shipping addresses
  }
}
