using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Client
{
    public class Menu
    {
        private string input;
        RestService rest = new RestService("http://localhost:43375");
        private PurchaseMethods pm = new PurchaseMethods();
        private GuitarMethods gm = new GuitarMethods();
        private BrandMethods bm = new BrandMethods();
        private string innerinput;

        public Menu()
        {
            
        }

        public void MenuPrint()
        {
            Console.WriteLine("Welcome to the Guitar shop!");
            Console.WriteLine("1 - Brand methods");
            Console.WriteLine("2 - Guitar methods");
            Console.WriteLine("3 - Purchase methods");
            Console.WriteLine("Q - Exit");
        }
        public void Start()
        {
            input = "";
            while (input!="Q")
            {
                MenuPrint();
                Console.WriteLine("Choose an option:");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        bm.BrandPrint();
                        Console.WriteLine("Choose an option");
                        innerinput = Console.ReadLine();
                        switch (innerinput)
                        {
                            case "1":
                                bm.BrandCreate(rest);
                                Console.Clear();
                                break;
                            case "2":
                                bm.BrandRead(rest);
                                Console.Clear();
                                break;
                            case "3":
                                bm.BrandReadAll(rest);
                                Console.Clear();
                                break;
                            case "4":
                                bm.BrandUpdate(rest);
                                Console.Clear();
                                break;
                            case "5":
                                bm.BrandDelete(rest);
                                Console.Clear();
                                break;
                            case "Q":
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        gm.GuitarPrint();
                        Console.WriteLine("Choose an option");
                        innerinput = Console.ReadLine();
                        switch (innerinput)
                        {
                            case "1":
                                gm.GuitarCreate(rest);
                                Console.Clear();
                                break;
                            case "2":
                                gm.GuitarRead(rest);
                                Console.Clear();
                                break;
                            case "3":
                                gm.GuitarReadAll(rest);
                                Console.Clear();
                                break;
                            case "4":
                                gm.GuitarUpdate(rest);
                                Console.Clear();
                                break;
                            case "5":
                                gm.GuitarDelete(rest);
                                Console.Clear();
                                break;
                            case "6":
                                gm.AveragePrice(rest);
                                Console.Clear();
                                break;
                            case "7":
                                gm.AveragePriceByBrands(rest);
                                Console.Clear();
                                break;
                            case "8":
                                gm.AveragePriceByTypes(rest);
                                Console.Clear();
                                break;
                            case "9":
                                gm.AveragePriceByRanking(rest);
                                Console.Clear();
                                break;
                            case "0":
                                gm.AverageReliabilityByBrands(rest);
                                Console.Clear();
                                break;
                            case "Q":
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                        break;
                    case "3":
                        Console.Clear();
                        pm.PurchasePrint();
                        Console.WriteLine("Choose an option");
                        innerinput = Console.ReadLine();
                        switch (innerinput)
                        {
                            case "1":
                                pm.PurchaseCreate(rest);
                                Console.Clear();
                                break;
                            case "2":
                                pm.PurchaseRead(rest);
                                Console.Clear();
                                break;
                            case "3":
                                pm.PurchaseReadAll(rest);
                                Console.Clear();
                                break;
                            case "4":
                                pm.PurchaseUpdate(rest);
                                Console.Clear();
                                break;
                            case "5":
                                pm.PurchaseDelete(rest);
                                Console.Clear();
                                break;
                            case "6":
                                pm.AVGRatingByCities(rest);
                                Console.Clear();
                                break;
                            case "Q":
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                        break;
                    case "Q":
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }

    }
}
