using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Logic
{
    public interface IPurchaseLogic
    {
        void Create(Purchase brand);
        void Delete(int id);
        Purchase Read(int id);
        IEnumerable<Purchase> ReadAll();
        void Update(Purchase brand);
        IEnumerable<KeyValuePair<string, List<string>>> BuyerNamesByBrands();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByCities();
    }
}
