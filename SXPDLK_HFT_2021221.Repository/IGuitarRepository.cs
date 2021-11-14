using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SXPDLK_HFT_2021221.Models;

namespace SXPDLK_HFT_2021221.Repository
{
    public interface IGuitarRepository
    {
        void Create(Guitar guitar);
        void Delete(int id);
        Guitar Read(int id);
        IQueryable<Guitar> ReadAll();
        void Update(Guitar guitar);
    }
}
