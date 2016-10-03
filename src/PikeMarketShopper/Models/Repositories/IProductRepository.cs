using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikeMarketShopper.Models.Repositories
{
  public class IProductRepository
  {
    IQueryable<Product> Products { get;  }
    Product Save(Product product);
    Product Edit(Product product);
    void Remove(Product product);
  }
}
