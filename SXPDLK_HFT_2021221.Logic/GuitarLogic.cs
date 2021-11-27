using SXPDLK_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SXPDLK_HFT_2021221.Models;

namespace SXPDLK_HFT_2021221.Logic
{
    public class GuitarLogic:IGuitarLogic
    {
        IGuitarRepository guitarRepo;
        IBrandRepository brandRepo;
        public GuitarLogic(IGuitarRepository guitarRepo,IBrandRepository brandRepo)
        {
            this.guitarRepo = guitarRepo;
            this.brandRepo = brandRepo;
        }

        public void Create(Guitar guitar)
        {
            if (guitar.Price < 0)
            {
                throw new ArgumentException("Negative price is not allowed");
            }
            guitarRepo.Create(guitar);
        }

        public Guitar Read(int id)
        {
            return guitarRepo.Read(id);
        }

        public IEnumerable<Guitar> ReadAll()
        {
            return guitarRepo.ReadAll();
        }

        public void Delete(int id)
        {
            Guitar[] guitars = guitarRepo.ReadAll().ToArray();
            if (id>guitars.Length)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            else
            {
                guitarRepo.Delete(id);
            }
        }

        public void Update(Guitar guitar)
        {
            if (guitar.Model==null)
            {
                throw new ArgumentNullException("Invalid argument!");
            }
            else
            {
                guitarRepo.Update(guitar);
            }
        }

        //non-Crud methods
        //Average price
        public double AVGPrice()
        {
            return guitarRepo.ReadAll()
                .Average(t => t.Price);
        }

        //Average price by brands
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return from x in guitarRepo.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Price));
        }
        public IEnumerable<KeyValuePair<string, double>> AVGModelsByBrands()
        {
            //var query = from g in guitarRepo.ReadAll()
            //            join b in brandRepo.ReadAll() on g.BrandId equals b.Id
            //            group g by b.Name into grp
            //            select new
            //            {
            //                Brand = grp.Key,
            //                Models = grp.Select(m => m.Model)
            //            };
            //var result = query
            //    .Select(x => new KeyValuePair<string, List<string>>(
            //        x.Brand,
            //        x.Models.ToList()
            //        ));
            //return result;
            return from g in guitarRepo.ReadAll()
                   group g by g.Brand.Name into grp
                   select new KeyValuePair<string, double>
                   (grp.Key, grp.Average(t => t.Model.Count()));
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByTypes()
        {
            return from x in guitarRepo.ReadAll()
                   group x by x.Type into g
                   select new KeyValuePair<string, double>
                   (g.Key.ToString(), g.Average(t => t.Price));
        }
    }
}
