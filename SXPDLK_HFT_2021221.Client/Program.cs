using System;
using System.Linq;
using System.Collections.Generic;
using SXPDLK_HFT_2021221.Models;
using System.Threading;

namespace SXPDLK_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);
            RestService rest = new RestService("http://localhost:43375");
            rest.Post<Brand>(new Brand() { Name = "Cort" }, "brand");
            var brands = rest.Get<Brand>("brand");
            foreach (var item in brands)
            {
                Console.WriteLine(item.Name);
            }
            double avgpr = rest.GetSingle<double>("stat/avgprice");
            Console.WriteLine("Átlagár: {0}", avgpr);
            ;
            var buyer = rest.Get<KeyValuePair<string, string>>("stat/buyernamesbymodels");
            foreach (var item in buyer)
            {
                Console.WriteLine(item);
            }
            var avgpricebycities = rest.Get<KeyValuePair<string, double>>("stat/avgpricebycities");
            foreach (var item in avgpricebycities)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }

        }
    }
}
