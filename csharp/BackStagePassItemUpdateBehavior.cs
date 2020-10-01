using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class BackStagePassItemUpdateBehavior : IItemUpdateBehavior
    {
        public void Update(Item itemToUpdate)
        {
            if (itemToUpdate.Quality < 50)
            {
                itemToUpdate.Quality += 1;

                if (itemToUpdate.SellIn < 11)
                {
                    if (itemToUpdate.Quality < 50)
                    {
                        itemToUpdate.Quality += 1;
                    }
                }

                if (itemToUpdate.SellIn < 6)
                {
                    if (itemToUpdate.Quality < 50)
                    {
                        itemToUpdate.Quality += 1;
                    }
                }
            }

            itemToUpdate.SellIn -= 1;

            if (itemToUpdate.SellIn < 0)
            {
                itemToUpdate.Quality -= itemToUpdate.Quality;
            }
        }
    }
}
