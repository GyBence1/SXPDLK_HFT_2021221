using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SXPDLK_HFT_2021221.Models;

namespace SXPDLK_HFT_2021221.Logic
{
    public interface IGuitarLogic
    {
        double AVGPrice();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
        void Create(Guitar guitar);
        void Delete(int id);
        Guitar Read(int id);
        IEnumerable<Guitar> ReadAll();
        void Update(Guitar guitar);
        IEnumerable<KeyValuePair<string, double>> AVGModelsByBrands();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByTypes();
    }
}
