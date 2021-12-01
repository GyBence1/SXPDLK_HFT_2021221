using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Client
{
    public class PurchaseMethods
    {
        public PurchaseMethods()
        {

        }
        public void PurchasePrint()
        {
            Console.WriteLine("Purchase methods");
            Console.WriteLine("1 - Create");
            Console.WriteLine("2 - Read");
            Console.WriteLine("3 - ReadAll");
            Console.WriteLine("4 - Update");
            Console.WriteLine("5 - Delete");
            Console.WriteLine("6 - Average rating by cities");
            Console.WriteLine("Q - Exit");
        }
        public void PurchaseCreate(RestService rest)
        {
            var tmp = new Purchase()
            {
                BuyerName = "NewBuyer"
            };
            rest.Post<Purchase>(tmp, "purchase");
            Console.WriteLine($"New purchase created: \t Id:{tmp.Id}\t Name: {tmp.BuyerName}");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void PurchaseRead(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            var result = rest.Get<Purchase>(id, "purchase");
            Console.WriteLine($"Name: {result.BuyerName} \t Id: {result.Id}");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void PurchaseReadAll(RestService rest)
        {
            var result = rest.Get<Purchase>("purchase");
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.BuyerName} \t Id: {item.Id}");
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void PurchaseUpdate(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            var result = rest.Get<Purchase>(id, "purchase");
            Console.WriteLine("Enter new Name");
            string newname = Console.ReadLine();
            result.BuyerName = newname;
            rest.Put<Purchase>(result, "purchase");
            Console.WriteLine("Purchase updated successfully");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void PurchaseDelete(RestService rest)
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "purchase");
            Console.WriteLine("Purchase deleted successfully");
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
        public void AVGRatingByCities(RestService rest)
        {
            var res = rest.Get<KeyValuePair<string, double>>("stat/avgratingbycities");
            foreach (var item in res)
            {
                Console.WriteLine($"City: {item.Key} \t Average rating: {item.Value}");

            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadLine();
        }
    }
}
