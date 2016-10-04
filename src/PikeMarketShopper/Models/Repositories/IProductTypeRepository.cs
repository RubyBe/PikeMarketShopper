using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikeMarketShopper.Models.Repositories
{
  public interface IProductTypeRepository
  {
    IQueryable<ProductType> ProductTypes { get;  }
  }
}
