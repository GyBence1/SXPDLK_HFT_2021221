using System;
using System.Collections.Generic;
using SXPDLK_HFT_2021221.Models;

namespace SXPDLK_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand brand);
        void Delete(int id);
        Brand Read(int id);
        IEnumerable<Brand> ReadAll();
        void Update(Brand brand);
    }
}
