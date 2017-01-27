using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwoExercise
{
    public abstract class Fourteen
    {
        public int myInt { get; set; }

        public Fourteen(int theInt)
        {
            myInt = theInt;
        }
    }

    public class FourteenOne : Fourteen
    {
        public FourteenOne(int daInt) : base(daInt)
        {

        }
    }
}
