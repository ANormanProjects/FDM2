using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise.LibraryStuff
{
    public class Catalogue<T> where T : Catalogable<int>
    {
        List<T> catalogueItems = new List<T>();

        public void Add(T thingToAdd)
        {
            catalogueItems.Add(thingToAdd);
        }

        public T Find(int id)
        {
            foreach (T item in catalogueItems)
            {
                if (item.id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
