using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPurchaseRepository
    {
        Purchase GetPurchase(int Id);
        IEnumerable<Purchase> GetAllPurchases();
        Purchase Add(Purchase purchase);
        Purchase Update(Purchase purchaseChanges);
        void Delete(Purchase pur);
    }
}
