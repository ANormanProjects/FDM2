using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwoExercise
{
    public interface EightA
    {
        void EightAMethod();
    }

    public interface EightB : EightA
    {
        void EightBMethod();
    }

    public class EightC : EightB
    {
        public void EightBMethod()
        {
            //Add code here
        }

        public void EightAMethod()
        {
            //Add code here
        }
    }
}
