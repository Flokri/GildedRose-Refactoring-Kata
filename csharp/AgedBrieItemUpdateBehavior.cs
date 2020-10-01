using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class AgedBrieItemUpdateBehavior : IItemUpdateBehavior
    {
        public void Update(Item itemToUpdate)
        {
            if (itemToUpdate.Quality < 50)
                itemToUpdate.Quality += 1;

            itemToUpdate.SellIn -= 1;

            if (itemToUpdate.SellIn >= 0)
                return;

            if (itemToUpdate.Quality < 50)
                itemToUpdate.Quality += 1;
        }
    }
}
