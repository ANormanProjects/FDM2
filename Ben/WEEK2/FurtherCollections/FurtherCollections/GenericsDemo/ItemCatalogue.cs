using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class ItemCatalogue
    {

        // BETTER APPROACH, HOLDS ALL ITEMS INSTEAD OF SPECIFICS - STILL BAD APPROACH, USE CATALOGUE<T> GENERICS


        List<Item> items = new List<Item>();

        public List<Item> GetAllItems() //GETS ALL BOOKS IN THE LIST
        {
            return items;
        }



        public void AddItem(Item itemToAdd) //ADD BOOK TO LIST              //VOID - RETURN, USE VOID IF METHOD RETURNS NO VALUE, AND DONT USE VOID IF METHOD WILL  USE 'RETURN'
        {
            items.Add(itemToAdd);
        }

    }
}
