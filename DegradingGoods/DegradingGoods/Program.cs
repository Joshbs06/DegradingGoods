using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DegradingGoods;

namespace DegradingGoods
{
    public class Program
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
            
            for (var i = 0; i < degradationAmount; i++) {
                if (item.Name.ToLower() == "aged brie")
                {
                    degradedItem.Name = item.Name;
                    degradeAmount = QualityDegradingLogic(item, 1);
                    degradedItem.SellIn = item.SellIn - 1;
                    degradedItem.QualityValue = item.QualityValue + degradeAmount;
                }
                else if (item.Name.ToLower() == "sulfuras")
                {
                    return degradedItem = item;
                }
                else if (item.Name.ToLower() == "conjured")
                {
                    degradedItem.Name = item.Name;
                    degradeAmount = QualityDegradingLogic(item,-2);
                    degradedItem.SellIn = item.SellIn - 1;
                    degradedItem.QualityValue = item.QualityValue + degradeAmount;
                }
                else if (item.Name.ToLower() == "backstage passes")
                {
                    degradedItem = BackstagePassesLogic(item);
                }
                else
                {
                    degradedItem.Name = item.Name;
                    degradeAmount = QualityDegradingLogic(item, -1);
                    degradedItem.SellIn = item.SellIn - 1;
                    degradedItem.QualityValue = item.QualityValue + degradeAmount;
                }
            };

            if (degradedItem.QualityValue > 50)
            {
                degradedItem.QualityValue = 50;
                return degradedItem;
            }
            else if (degradedItem.QualityValue < 0)
            {
                degradedItem.QualityValue = 0;
                return degradedItem;
            }
            else {
                return degradedItem;
            }                             
        }

        public static List<Item> LogicMethod(List<Item> items, List<Item> degradedItemList) {

            foreach (var itemListElement in items)
            {
                if (itemListElement.Name.ToUpper() == "INVALID ITEM")
                {
                    var invalidItem = new Item()
                    {
                        Name = "NO SUCH ITEM"
                    };
                    degradedItemList.Add(invalidItem);
                    Console.WriteLine(invalidItem.Name);
                }
                else
                {
                    var itemToAdd = DegradationMethod(1, itemListElement);
                    degradedItemList.Add(itemToAdd);
                    Console.WriteLine(itemToAdd.Name + ' ' + itemToAdd.SellIn + ' ' + itemToAdd.QualityValue);
                }
            }
            return degradedItemList;
        }

        public static void Main(string[] args)
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
                },
                new Item(){
                    Name = "Backstage passes",
                    SellIn = -1,
                    QualityValue = 2 
                },
                new Item(){
                    Name = "Backstage passes",
                    SellIn = 9,
                    QualityValue = 2
                },
                new Item(){
                    Name = "Sulfuras",
                    SellIn = 2,
                    QualityValue = 2
                },
                new Item(){
                    Name = "Normal Item",
                    SellIn = -1,
                    QualityValue = 55
                },
                new Item(){
                    Name = "Normal Item",
                    SellIn = 2,
                    QualityValue = 2
                },
                new Item(){
                    Name = "INVALID ITEM",
                    SellIn = 2,
                    QualityValue = 2
                },
                new Item(){
                    Name = "Conjured",
                    SellIn = 2,
                    QualityValue = 2
                },
                new Item(){
                    Name = "Conjured",
                    SellIn = -1,
                    QualityValue = 5
                }
            };

            var degradedItemList = new List<Item>();

            degradedItemList = LogicMethod(itemList, degradedItemList);

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
