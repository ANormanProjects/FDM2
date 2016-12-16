using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    //BEST CATALOGUE - USES GENERICS
                            //Good for Dependency Inversion (relying on abstract class)
    public class Catalogue<T> where T : Item // <T> = Type    // where T : Item (Ensures it inherits from Item.cs abstract class only.
    {
        public List<T> items = new List<T>();

        public List<T> GetAllItems()
        {
            return items;
        }

        public void AddItem(T itemToAdd) //<T>, T will always link back to Catalogue<T>
        {
            items.Add(itemToAdd);
        }
    }
}
