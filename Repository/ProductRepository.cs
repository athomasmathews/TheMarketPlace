using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private MarketPlaceDbContext context;

        public ProductRepository(MarketPlaceDbContext context)
        {
            this.context = context;
        }
        public Product Add(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();

            return product;
        }

        public Product Delete(int id)
        {
            Product prod = context.Product.Find(id);
            if (prod != null)
            {
                context.Product.Remove(prod);
                context.SaveChanges();
            }

            return prod;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Product;
        }

        public Product GetProduct(int Id)
        {
            return context.Product.Find(Id);
        }

        public Product Update(Product productChanges)
        {
            var prod = context.Product.Attach(productChanges);
            prod.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return productChanges;
        }
    }
}
