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
            
                guitarRepo.Delete(id);
          
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
        public IEnumerable<KeyValuePair<string, double>> AVGReliabilityByBrands()
        {
            return from x in guitarRepo.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Reliability));
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByTypes()
        {
            return from x in guitarRepo.ReadAll()
                   group x by x.Type into g
                   select new KeyValuePair<string, double>
                   (g.Key.ToString(), g.Average(t => t.Price));
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByRanking()
        {
            return from x in guitarRepo.ReadAll()
                   group x by x.Ranking into g
                   select new KeyValuePair<string, double>
                   (g.Key.ToString(), g.Average(t => t.Price));
        }
    }
}
