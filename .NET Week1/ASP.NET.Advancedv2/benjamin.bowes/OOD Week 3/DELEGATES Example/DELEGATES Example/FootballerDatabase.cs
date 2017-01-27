using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELEGATES_Example
{
    public delegate void ProcessPlayerDelegate(Footballer footballer);   //Declaring a Delegate - Always requires a return type, name and parameters.


    public class FootballerDatabase
    {
        List<Footballer> transferlist = new List<Footballer>();     //LIST

        public void AddFootballer(Footballer footballerToAdd)       //Adding to LIST
        {
            transferlist.Add(footballerToAdd);
        }


        public void ProcessInjuredPlayers(ProcessPlayerDelegate processPlayer)
        {
            foreach (Footballer footballer in transferlist)
            {
                if (footballer.isInjured)
                {
                    processPlayer(footballer);  //Will pass footballer from delegate and return void (determined by the delegate declared above)
                }
            }
            

        }
    }
}
