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
        public IEnumerable<KeyValuePair<string, string>> BuyerNamesByGuitarModels()
        {

            var asd = from p in purchaseRepo.ReadAll()
                      join g in guitarRepo.ReadAll() on p.GuitarId equals g.Id
                      group p by g.Model into grp
                      select new
                      {
                          Model=grp.Key,
                          Buyer=grp.Select(m=>m.BuyerName)
                      };
            var result = asd
                .Select(x => new KeyValuePair<string, string>(
                    x.Model,
                    x.Buyer.FirstOrDefault()
                    ));



            return result;
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByCities()
        {
            //var query = (from p in purchaseRepo.ReadAll()
            //             join g in guitarRepo.ReadAll() on p.GuitarId equals g.Id
            //             select new
            //             {
            //                 p.BuyerCity,
            //                 g.Price
            //             }
            //           ).ToList();
            return from x in purchaseRepo.ReadAll()
                   join g in guitarRepo.ReadAll() on x.GuitarId equals g.Id
                   group x by x.BuyerCity into grp
                   select new KeyValuePair<string, double>
                   (grp.Key, grp.Average(t=>t.Guitar.Price));
        }
    }
}
        
