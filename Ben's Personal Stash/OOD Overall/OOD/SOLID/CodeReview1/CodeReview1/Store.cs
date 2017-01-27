using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview1
{
    public class Store
    {
        public List<Item> items { get; set; }

        public Store(List<Item> allitems)
        {
            items = allitems;
        }

        public List<Item> getItems()
        {
            return items;
        }

        public void addItem(Item i)
        {
            items.Add(i);
        }

        public void removeItem(Item id)
        {
            items.Remove(id);
        }

    }
}
