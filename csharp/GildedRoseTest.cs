﻿using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        public const string NORMAL = "item";
        public const string AGED_BRIE = "Aged Brie";
        public const string LEGANDARY = "Sulfuras, Hand of Ragnaros";
        public const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        public const string CONJURED = "Conjured Mana Cake";


        [TestCase(NORMAL, 2, 0, 1)] //normal item sellin decrease by 1
        [TestCase(LEGANDARY, 10, 10, 10)] //legandary item sellin never decrease
        [TestCase(AGED_BRIE, 10, 10, 9)] //aged brie item sellin decrease by 1
        [TestCase(BACKSTAGE_PASSES, 10, 10, 9)] //backstage pass item sellin decrease by 1
        [TestCase(CONJURED, 10, 10, 9)] //conjured item sellin decreases by 1
        public void Item_ChangeSellin(string name, int sellin, int quality, int expected)
        {
            var rose = gildedRoseOf(name, sellin, quality);
            rose.UpdateQuality();
            Assert.AreEqual(expected, rose.GetItems?[0].SellIn);
        }

        [TestCase(NORMAL, 2, 0, 0)] //normal item quality never below 0
        [TestCase(NORMAL, 1, 1, 0)] //normal item quality decrases by 1
        [TestCase(NORMAL, -1, 10, 8)] //normal item quality decreases by 2
        [TestCase(AGED_BRIE, 10, 10, 11)] //aged brie quality increases by 1
        [TestCase(AGED_BRIE, -1, 10, 12)] //aged brie quality increases by 2
        [TestCase(AGED_BRIE, -1, 50, 50)] //aged brie quality never increases above 50
        [TestCase(LEGANDARY, 10, 10, 10)] //legendary items quality never decreases
        [TestCase(BACKSTAGE_PASSES, 11, 10, 11)] //backstage passes items quality increases by 1
        [TestCase(BACKSTAGE_PASSES, 10, 10, 12)] //backstage passes items quality increases by 2 when sellin is 10 or lower
        [TestCase(BACKSTAGE_PASSES, 5, 10, 13)] //backstage passes items quality increases by 3 when sellin is 5 or lower
        [TestCase(BACKSTAGE_PASSES, -1, 10, 0)] //backstage passes items quality drops to 0 when concert is over
        [TestCase(CONJURED, 10, 10, 9)] //conjured item quality decreases by 1
        [TestCase(CONJURED, -1, 10, 8)] //conjured item quality decreases by 2 when sellin is below 0
        public void Item_ChangeQuality(string name, int sellin, int quality, int expected)
        {
            var rose = gildedRoseOf(name, sellin, quality);
            rose.UpdateQuality();
            Assert.AreEqual(expected, rose.GetItems?[0].Quality);
        }

        //[Test]
        //public void RefactoredOutputShouldEqualsLegacy()
        //{
        //}

        private GildedRose gildedRoseOf(string name, int sellin, int quality) => new GildedRose(new List<Item> { new Item() { Name = name, SellIn = sellin, Quality = quality } });
    }
}
