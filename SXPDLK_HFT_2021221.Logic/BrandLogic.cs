using SXPDLK_HFT_2021221.Models;
using SXPDLK_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Logic
{
    public class BrandLogic:IBrandLogic
    {
        IBrandRepository brandRepo;
        public BrandLogic(IBrandRepository brandRepo)
        {
            this.brandRepo = brandRepo;
        }

        public void Create(Brand brand)
        {
            if (brand.Name==null)
            {
                throw new ArgumentNullException("You must enter a valid name!");
            }
            else
            {
                brandRepo.Create(brand);
            }
        }

        public Brand Read(int id)
        {
            return brandRepo.Read(id);
        }

        public IEnumerable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }

        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }

        public void Update(Brand brand)
        {
            brandRepo.Update(brand);
        }
    }
}
