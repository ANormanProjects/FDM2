using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_DAL
{
    public class ItemRepository : IItemRepository
    {
        E_CommerceDataModel context;

        public ItemRepository(E_CommerceDataModel _context)
        {
            context = _context;
        }

        public virtual List<Item> GetAllItems()
        {
            return context.items.ToList();
        }

        public virtual void addNewItem(Item newItem)
        {
            context.items.Add(newItem);
            context.SaveChanges();
        }
    }
}
