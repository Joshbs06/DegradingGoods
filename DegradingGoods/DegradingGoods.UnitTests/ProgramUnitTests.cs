using System;
using System.Collections.Generic;
using DegradingGoods;
using Xunit;

namespace DegradingGoods.UnitTests
{
    public class ProgramUnitTests
    {
        [Fact]
        public void AgedBrieTest()
        {
            //Given
            var item = new Item()
            {
                Name = "Aged Brie",
                SellIn = 1,
                QualityValue = 1
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList,degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Aged Brie", resultItem.Name);
                Assert.Equal(0, resultItem.SellIn);
                Assert.Equal(2, resultItem.QualityValue);
            }
        }

        [Fact]
        public void BackstagePassesTestNegativeSellIn()
        {
            //Given
            var item = new Item()
            {
                Name = "Backstage passes",
                SellIn = -1,
                QualityValue = 2
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Backstage passes", resultItem.Name);
                Assert.Equal(-2, resultItem.SellIn);
                Assert.Equal(0, resultItem.QualityValue);
            }
        }

        [Fact]
        public void BackstagePassesTest()
        {
            //Given
            var item = new Item()
            {
                Name = "Backstage passes",
                SellIn = 9,
                QualityValue = 2
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Backstage passes", resultItem.Name);
                Assert.Equal(8, resultItem.SellIn);
                Assert.Equal(4, resultItem.QualityValue);
            }
        }

        [Fact]
        public void SulfurasTest()
        {
            //Given
            var item = new Item()
            {
                Name = "Sulfuras",
                SellIn = 2,
                QualityValue = 2
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Sulfuras", resultItem.Name);
                Assert.Equal(2, resultItem.SellIn);
                Assert.Equal(2, resultItem.QualityValue);
            }
        }

        [Fact]
        public void NormalItemNegativeSellInTest()
        {
            //Given
            var item = new Item()
            {
                Name = "Normal Item",
                SellIn = -1,
                QualityValue = 55
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Normal Item", resultItem.Name);
                Assert.Equal(-2, resultItem.SellIn);
                Assert.Equal(50, resultItem.QualityValue);
            }
        }

        [Fact]
        public void NormalItemPostiveSellInTest()
        {
            //Given
            var item = new Item()
            {
                Name = "Normal Item",
                SellIn = 2,
                QualityValue = 2
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Normal Item", resultItem.Name);
                Assert.Equal(1, resultItem.SellIn);
                Assert.Equal(1, resultItem.QualityValue);
            }
        }

        [Fact]
        public void InvalidItemTest()
        {
            //Given
            var item = new Item()
            {
                Name = "INVALID ITEM",
                SellIn = 2,
                QualityValue = 2
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("NO SUCH ITEM", resultItem.Name);
            }
        }

        [Fact]
        public void ConjuredTest()
        {
            //Given
            var item = new Item()
            {
                Name = "Conjured",
                SellIn = 2,
                QualityValue = 2
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Conjured", resultItem.Name);
                Assert.Equal(1, resultItem.SellIn);
                Assert.Equal(0, resultItem.QualityValue);
            }
        }

        [Fact]
        public void ConjuredNegativeSellInTest()
        {
            //Given
            var item = new Item()
            {
                Name = "Conjured",
                SellIn = -1,
                QualityValue = 5
            };
            var itemList = new List<Item>() { item };
            var degradedItemList = new List<Item>();
            //When
            var result = Program.LogicMethod(itemList, degradedItemList);
            //Then
            foreach (var resultItem in result)
            {
                Assert.Equal("Conjured", resultItem.Name);
                Assert.Equal(-2, resultItem.SellIn);
                Assert.Equal(1, resultItem.QualityValue);
            }
        }
    }
}
