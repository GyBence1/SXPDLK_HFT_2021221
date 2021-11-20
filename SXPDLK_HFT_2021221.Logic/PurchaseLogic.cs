using SXPDLK_HFT_2021221.Models;
using SXPDLK_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Logic
{
    public class PurchaseLogic : IPurchaseLogic
    {
        IGuitarRepository guitarRepo;
        IBrandRepository brandRepo;
        IPurchaseRepository purchaseRepo;

        public PurchaseLogic(IGuitarRepository guitarRepo, IBrandRepository brandRepo, IPurchaseRepository purchaseRepo)
        {
            this.guitarRepo = guitarRepo;
            this.brandRepo = brandRepo;
            this.purchaseRepo = purchaseRepo;
        }



        public void Create(Purchase purchase)
        {
            if (purchase.BuyerName==null)
            {
                throw new ArgumentNullException("You must enter a valid name!");
            }
            else
            {
                purchaseRepo.Create(purchase);
            }
        }

        public Purchase Read(int id)
        {
            return purchaseRepo.Read(id);
        }

        public IEnumerable<Purchase> ReadAll()
        {
            return purchaseRepo.ReadAll();
        }

        public void Delete(int id)
        {
            purchaseRepo.Delete(id);
        }

        public void Update(Purchase purchase)
        {
            purchaseRepo.Update(purchase);
        }
        public IEnumerable<KeyValuePair<string, List<string>>> BuyerNamesByBrands()
        {

            var asd = from p in purchaseRepo.ReadAll()
                      join g in guitarRepo.ReadAll() on p.GuitarId equals g.Id
                      join b in brandRepo.ReadAll() on g.BrandId equals b.Id
                      group p by b.Name into grp
                      select new
                      {
                          Brand = grp.Key,
                          Buyers = grp.Select(t => t.BuyerName)

                      };
            var result = asd
                .Select(x => new KeyValuePair<string, List<string>>(
                    x.Brand,
                    x.Buyers.ToList()
                    ));


            return result;
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByCities()
        {
            var query = (from p in purchaseRepo.ReadAll()
                         join g in guitarRepo.ReadAll() on p.GuitarId equals g.Id
                         select new
                         {
                             p.BuyerCity,
                             g.Price
                         }
                       ).ToList();
            return from q in query
                   group q by q.BuyerCity into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Price));
        }
    }
}
        
