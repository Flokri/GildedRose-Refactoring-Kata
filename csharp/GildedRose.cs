using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                HandleItem(item);
            }
        }

        private static void HandleItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    HandelAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    HandleBackStagePasses(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    HandleNormalItem(item);
                    break;
            }
        }

        private static void HandleNormalItem(Item item)
        {
            if (item.Quality > 0) { item.Quality -= 1; }

            item.SellIn -= 1;

            if (item.SellIn >= 0) return;
            if (item.Quality > 0) { item.Quality -= 1; }
        }

        private static void HandleBackStagePasses(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }

        private static void HandelAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn >= 0) return;
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        public List<Item> GetItems => Items as List<Item>;
    }
}
