using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Client
{
    public class GuitarMethods
    {
        public GuitarMethods()
        {

        }
        public void GuitarPrint()
        {
            Console.WriteLine("Guitar methods:");
            Console.WriteLine("1 - Create");
            Console.WriteLine("2 - Read");
            Console.WriteLine("3 - ReadAll");
            Console.WriteLine("4 - Update");
            Console.WriteLine("5 - Delete");
            Console.WriteLine("6 - Average Price");
            Console.WriteLine("7 - Average Price by Brands");
            Console.WriteLine("8 - Average Price by Types");
            Console.WriteLine("9 - Average Price by Ranking");
            Console.WriteLine("0 - Average Reliability by Brands");
            Console.WriteLine("Q - Exit");
        }
        public void GuitarCreate(RestService rest)
        {
            var tmp = new Guitar()
            {
                Model = "NewGuitar"
            };
            rest.Post<Guitar>(tmp, "guitar");
            Console.WriteLine($"New guitar created: \t Id:{tmp.Id}\t Model: {tmp.Model}");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void GuitarRead(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            var result = rest.Get<Guitar>(id, "guitar");
            Console.WriteLine($"Model: {result.Model} \t Id: {result.Id}");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void GuitarReadAll(RestService rest)
        {
            var result = rest.Get<Guitar>("guitar");
            foreach (var item in result)
            {
                Console.WriteLine($"Model: {item.Model} \t Id: {item.Id}");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void GuitarUpdate(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            var result = rest.Get<Guitar>(id, "guitar");
            Console.WriteLine("Enter new model");
            string newname = Console.ReadLine();
            result.Model = newname;
            rest.Put<Guitar>(result, "guitar");
            Console.WriteLine("Guitar updated successfully");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void GuitarDelete(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "guitar");
            Console.WriteLine("Guitar deleted successfully");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void AveragePrice(RestService rest)
        {
            var res = rest.GetSingle<double>("stat/avgprice");
            Console.WriteLine($"Average price \t {res}");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void AveragePriceByBrands(RestService rest)
        {
            var res = rest.Get<KeyValuePair<string, double>>("stat/avgpricebybrands");
            foreach (var item in res)
            {
                Console.WriteLine($"Brand: {item.Key} \t Average price: {item.Value}");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void AveragePriceByTypes(RestService rest)
        {
            var res = rest.Get<KeyValuePair<string, double>>("stat/avgpricebytypes");
            foreach (var item in res)
            {
                Console.WriteLine($"Type: {item.Key} \t Average Price: {item.Value}");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void AveragePriceByRanking(RestService rest)
        {
            var res = rest.Get<KeyValuePair<string, double>>("stat/avgpricebyranking");
            foreach (var item in res)
            {
                Console.WriteLine($"Ranking: {item.Key} \t Average price: {item.Value}");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void AverageReliabilityByBrands(RestService rest)
        {
            var res = rest.Get<KeyValuePair<string, double>>("stat/avgreliabilitybybrands");
            foreach (var item in res)
            {
                Console.WriteLine($"Brand: {item.Key} \t Average reliability: {item.Value}");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
    }
}
