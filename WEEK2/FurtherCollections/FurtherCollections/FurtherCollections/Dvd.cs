using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurtherCollections
{
    public class Dvd : IComparable // MAKES Dvd Comparable to every other class but breaks single responsibility
    {
        public int id { get; set; }         //PROPERTIES
        public string title { get; set; }
        public double price { get; set; }


        public Dvd(int ID, string TITLE, double PRICE) //CONSTRUCTOR
        {
            id = ID;
            title = TITLE;
            price = PRICE;
        }

        public override bool Equals(object obj)
        {
            Dvd otherdvd = obj as Dvd; //Casts the parameter back to a DVD using 'as'



            //If the cast was unsuccessful then the otherdvd
            //returns false
            if (otherdvd == null)
            {
                return false;
            }

            //If the objects are in the same space in the heap
            //Then they must be the same, good for performance
            if (this == otherdvd)
            {
                return true;
            }

            //If the titles dont match then they aren't the same
            //So return false
            if (otherdvd.title != this.title) //If not the same, return false
            {
                return false;
            }

            //If the ids dont match then they aren't the same
            //So return false
            if(otherdvd.id != this.id)
            {
                return false;
            }

            //If the method gets all the way down here then they must be the same
            //So return true
            return true;


        }


        //Not recommended - Comparable Interface (IComparable)
        public int CompareTo(object obj) //Always return 1, 0, -1
        {
            if (obj == null) return 1;
            Dvd otherdvd = obj as Dvd; //Casting parameter back to Dvd

            if (this.id < otherdvd.id)
            {
                return -1;
            }

            //else if (this.id > otherdvd.id) return 1;      Can be done like this without {} if it will return one thing

            else if (this.id > otherdvd.id)
            {
                return 1;
            }

            else
            {
                return 0;
            }
            //MOVED TO DvdIdComparer to retain the Single Responsibility of this class

        }
    }
}
