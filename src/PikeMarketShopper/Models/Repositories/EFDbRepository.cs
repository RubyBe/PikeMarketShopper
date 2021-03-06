﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikeMarketShopper.Models.Repositories
{
  public class EFDbRepository : IProductRepository, IProductTypeRepository
  {
    PikeMarketDbContext db = new PikeMarketDbContext();

    public IQueryable<Product> Products
    { get { return db.Products; } }

    public IQueryable<ProductType> ProductTypes
    { get { return db.ProductTypes; } }

    public Product Save(Product product)
    {
      db.Products.Add(product);
      db.SaveChanges();
      return product;
    }
    public Product Edit(Product product)
    {
      db.Entry(product).State = EntityState.Modified;
      db.SaveChanges();
      return product;
    }

    public void Remove(Product product)
    {
      db.Products.Remove(product);
      db.SaveChanges();
    }

    public void SaveChanges()
    {
      throw new NotImplementedException();
    }

    public object Entry(Product product)
    {
      throw new NotImplementedException();
    }

    public ProductType Save(ProductType productType)
    {
      db.ProductTypes.Add(productType);
      db.SaveChanges();
      return productType;
    }
  }
}
