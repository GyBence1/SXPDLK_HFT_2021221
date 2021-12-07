using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Client
{
    public class BrandMethods
    {
        public void BrandPrint()
        {
            Console.WriteLine("Brand methods:");
            Console.WriteLine("1 - Create");
            Console.WriteLine("2 - Read");
            Console.WriteLine("3 - Read all");
            Console.WriteLine("4 - Update");
            Console.WriteLine("5 - Delete");
            Console.WriteLine("Q - Exit");
        }
        public void BrandCreate(RestService rest)
        {
            var tmp = new Brand()
            {
                Name = "NewBrand"
            };
            rest.Post<Brand>(tmp, "brand");
            Console.WriteLine($"New Brand created: \t Id:{tmp.Id}\t Name: {tmp.Name}");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void BrandRead(RestService rest)
        {
            Console.WriteLine("Enter the id of the brand (existing)");
            int id = int.Parse(Console.ReadLine());
            var result = rest.Get<Brand>(id, "brand");
            Console.WriteLine($"Name: {result.Name} \t Id: {result.Id}");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void BrandReadAll(RestService rest)
        {
            var result = rest.Get<Brand>("brand");
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name} \t Id: {item.Id}");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void BrandUpdate(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            var result = rest.Get<Brand>(id, "brand");
            Console.WriteLine("Enter new name");
            string newname = Console.ReadLine();
            result.Name = newname;
            rest.Put<Brand>(result, "brand");
            Console.WriteLine("Brand updated successfully");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void BrandDelete(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "brand");
            Console.WriteLine("Brand deleted successfully");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public BrandMethods()
        {
            
        }
    }
}
