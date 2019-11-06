using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
        IEnumerable<Product> GetAllProducts();
        Product Add(Product product);
        Product Update(Product productChanges);
        Product Delete(int id);
    }
}
