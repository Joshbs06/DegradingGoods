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

        static Item BackstagePassesLogic(Item item) {

            if (item.SellIn <= 0) {
                item.SellIn--;
                item.QualityValue = 0;
                return item;
            }
            else if (item.SellIn <= 5) {
                item.SellIn--;
                item.QualityValue += 3;
                return item;
            }
            else if (item.SellIn <= 10) {
                item.SellIn--;
                item.QualityValue += 2;
                return item;
            }
            else {
                item.SellIn--;
                item.QualityValue++;
                return item;
            };
        }

        static int QualityDegradingLogic(Item item, int currentDegradingAmount) {

            if (item.SellIn < 0) {
                return currentDegradingAmount * 2;
            }

            return currentDegradingAmount;
        }

        static Item DegradationMethod(int degradationAmount, Item item) {

            var degradeAmount = 0;
            var degradedItem = new Item();
            degradedItem = item;
            for (var i = 0; i < degradationAmount; i++) {
                if (item.Name.ToLower() == "aged brie")
                {
                    degradeAmount = QualityDegradingLogic(degradedItem, 1);
                    degradedItem.SellIn = degradedItem.SellIn - 1;
                    degradedItem.QualityValue = degradedItem.QualityValue + degradeAmount;
                }
                else if (item.Name.ToLower() == "sulfuras")
                {
                    return degradedItem;
                }
                else if (degradedItem.Name.ToLower() == "conjured")
                {
                    degradeAmount = QualityDegradingLogic(degradedItem,-2);
                    degradedItem.SellIn = degradedItem.SellIn - 1;
                    degradedItem.QualityValue = degradedItem.QualityValue - degradeAmount;
                }
                else if (degradedItem.Name.ToLower() == "backstage passes")
                {

                }
                else
                {
                    degradeAmount = QualityDegradingLogic(degradedItem, -1);
                    degradedItem.SellIn = degradedItem.SellIn - 1;
                    degradedItem.QualityValue = degradedItem.QualityValue - degradeAmount;
                }
            };
                               
            return degradedItem;
        }
        
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 

            var item = new Item();
            var daysOfDegradation = 0;

            var itemList = new List<Item>()
            {
                new Item(){
                    Name = "Aged Brie",
                    SellIn = 1,
                    QualityValue = 1
                }
            };

            var degradedItemList = new List<Item>();
                       
            foreach (var itemListElement in itemList)
            {
                if (itemListElement.Name.ToUpper() == "INVALID ITEM")
                {
                    var invalidItem = new Item()
                    {
                        Name = "NO SUCH ITEM",
                        SellIn = 0,
                        QualityValue = 0
                    };
                    degradedItemList.Add(invalidItem);
                    Console.WriteLine(invalidItem.Name);
                }

                var itemToAdd = DegradationMethod(1, itemListElement);
                degradedItemList.Add(itemToAdd);
                Console.WriteLine(itemToAdd.Name + ' ' + itemToAdd.SellIn + ' ' + itemToAdd.QualityValue);
            }

            Console.ReadKey();


            //User Input Option
            ////Gains Item Input//
            //Console.WriteLine("Enter item Name followed by enter");
            //item.Name = Console.ReadLine();
            //Console.WriteLine("Enter item Sell In Value followed by enter");
            //item.SellIn = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter item Quality Value followed by enter");
            //item.QualityValue = Convert.ToInt32(Console.ReadLine());

            ////Gains days of degradation wanted//
            //Console.WriteLine("Please enter how many days of degrading wanted");
            //daysOfDegradation = Convert.ToInt32(Console.ReadLine());

        }
    }
}
