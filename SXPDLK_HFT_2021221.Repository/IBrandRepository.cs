using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SXPDLK_HFT_2021221.Models;

namespace SXPDLK_HFT_2021221.Repository
{
    public interface IBrandRepository
    {
        void Create(Brand brand);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand brand);
    }
}
