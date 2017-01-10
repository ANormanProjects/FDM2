using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{

    //Abstract class is chosen as we are giving it properties (Interface only contains behaviour)
    //Good for Open/Closed and Dependency Inversion. Just add a new Class for any new items and put ': Item' to inherit
    
    public abstract class Item 
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Book : Item    //GENERIC CONSTRAINTS (Item). So Classes with : Item will be used in the Catalogue<T>
    {
        public string author { get; set; }

    }

    public class Dvd : Item
    {
        public DateTime releaseDate { get; set; }


    }

    public class Mag : Item
    {
        public int numberOfPages { get; set; }
    }

    public class AudioBook : Item 
    {
        public string narrator { get; set; }
    }

    public class Grocery    //GENERIC CONSTRAINTS (Item). So Classes without : Item will not be used in the Catalogue<T> //GROCERY ISNT AN ITEM
    {
        public double weight { get; set; }
    }
}
