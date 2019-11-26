using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DegradingGoods;

namespace DegradingGoods
{
    class Program
    {

        static Item DegradationMethod(int degradationAmount, Item item) {

            var degradedItem = new Item();
            degradedItem = item;
            for (var i = 0; i < degradationAmount; i++) {

            }

            if (item.Name.ToLower() == "aged brie") {
                degradedItem.SellIn = degradedItem.SellIn - 1;
                degradedItem.QualityValue = degradedItem.QualityValue + 1;
            }
            if (item.Name.ToLower() == "sulfuras")
            {
                return degradedItem;
            }
            if (degradedItem.Name.ToLower() == "conjured") {
                degradedItem.SellIn = degradedItem.SellIn - 1;
                degradedItem.QualityValue = degradedItem.QualityValue + 2;
            }
            if (degradedItem.Name.ToLower() == "backstage passes") {
                
            }
                       
            return degradedItem;
        }
        
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 

            var item = new Item();
            var daysOfDegradation = 0;

            //Gains Item Input//
            Console.WriteLine("Enter item Name followed by enter");
            item.Name = Console.ReadLine();
            Console.WriteLine("Enter item Sell In Value followed by enter");
            item.SellIn = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter item Quality Value followed by enter");
            item.QualityValue = Convert.ToInt32(Console.ReadLine());

            //Gains days of degradation wanted//
            Console.WriteLine("Please enter how many days of degrading wanted");
            daysOfDegradation = Convert.ToInt32(Console.ReadLine());

        }
    }
}
