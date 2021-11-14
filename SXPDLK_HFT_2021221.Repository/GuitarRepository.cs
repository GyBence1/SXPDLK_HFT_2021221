using SXPDLK_HFT_2021221.Data;
using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Repository
{
    public class GuitarRepository:IGuitarRepository
    {
        GuitarDbContext db;
        public GuitarRepository(GuitarDbContext db)
        {
            this.db = db;
        }

        public void Create(Guitar guitar)
        {
            db.Guitars.Add(guitar);
            db.SaveChanges();
        }

        public Guitar Read(int id)
        {
            return db.Guitars.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Guitar> ReadAll()
        {
            return db.Guitars;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Guitar guitar)
        {
            var oldguitar = Read(guitar.Id);
            oldguitar.Price = guitar.Price;
            oldguitar.Model = guitar.Model;
            oldguitar.BrandId = guitar.BrandId;
            db.SaveChanges();
        }
    }
}
