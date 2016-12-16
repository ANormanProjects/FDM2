using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise
{
    public class Catalog<T> where T : Catalogable<int>
    {
        List<T> catalogableItems = new List<T>(); //LIST OF ALL ITEMS


        public void AddCatalogable(T catalogable)
        {
            catalogableItems.Add(catalogable);
        }


        public T FindCatalogable(int id)
        {
            foreach (T cataloguableItem in catalogableItems)
            {
                if (cataloguableItem.id == id)
                {
                    return cataloguableItem;
                }
            }

            return null; // Returns null if you find no items
        }





    }
}
