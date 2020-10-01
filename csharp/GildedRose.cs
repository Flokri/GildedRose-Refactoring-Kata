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
                var behavior = ItemUpdateFactory.Create(item);
                if (behavior == null)
                {
                    string test = "";
                }
                behavior?.Update(item);
            }
        }

        public List<Item> GetItems => Items as List<Item>;
    }
}
