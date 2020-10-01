using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class ItemUpdateFactory
    {
        public static IItemUpdateBehavior Create(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieItemUpdateBehavior();
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackStagePassItemUpdateBehavior();
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    return new NormalItemUpdateBehavior();
            }

            return null;
        }
    }
}
