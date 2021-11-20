using SXPDLK_HFT_2021221.Data;
using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        GuitarDbContext db;
        public PurchaseRepository(GuitarDbContext db)
        {
            this.db = db;
        }

        public void Create(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            db.SaveChanges();
        }

        public Purchase Read(int id)
        {
            return db.Purchases.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Purchase> ReadAll()
        {
            return db.Purchases;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Purchase purchase)
        {
            var oldpurchase = Read(purchase.Id);
            oldpurchase.Id = purchase.Id;
            oldpurchase.BuyerName = purchase.BuyerName;
            oldpurchase.GuitarId = purchase.GuitarId;
            db.SaveChanges();
        }
    }
}
