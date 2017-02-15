using E_Commerce_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Logic
{
    public class ItemLogic
    {
        Item item = new Item();
        ItemRepository itemRepo;


        public ItemLogic(ItemRepository ItemRepo)
        {
            itemRepo = ItemRepo;
        }

        public virtual List<Item> GetAllItems()
        {
            return itemRepo.GetAllItems();
        }
    }
}
