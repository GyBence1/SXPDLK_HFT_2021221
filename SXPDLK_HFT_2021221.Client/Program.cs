using System;
using System.Linq;
using System.Collections.Generic;
using SXPDLK_HFT_2021221.Models;
using System.Threading;
using ConsoleTools;

namespace SXPDLK_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);
            Menu menu = new Menu();
            menu.Start();
        }
    }
}
