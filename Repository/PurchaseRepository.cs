using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private MarketPlaceDbContext context;

        public PurchaseRepository(MarketPlaceDbContext context)
        {
            this.context = context;
        }
        public Purchase Add(Purchase purchase)
        {
            context.Purchase.Add(purchase);
            context.SaveChanges();
            return purchase;
        }

        public virtual void Delete(Purchase pur)
        {
            if (pur != null)
            {
                 context.Purchase.Remove(pur);
                 context.SaveChanges();
            }
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            return context.Purchase;
        }

        public Purchase GetPurchase(int Id)
        {
            return context.Purchase.Find(Id);
        }

        public Purchase Update(Purchase purchaseChanges)
        {
            var pur = context.Purchase.Attach(purchaseChanges);
            pur.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return purchaseChanges;
        }
    }
}
