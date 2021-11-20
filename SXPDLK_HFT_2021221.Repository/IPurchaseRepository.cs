using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Repository
{
    public interface IPurchaseRepository
    {
        void Create(Purchase purchase);
        void Delete(int id);
        Purchase Read(int id);
        IQueryable<Purchase> ReadAll();
        void Update(Purchase purchase);
        
    }
}
