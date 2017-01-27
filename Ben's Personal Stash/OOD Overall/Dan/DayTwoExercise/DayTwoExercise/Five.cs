using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwoExercise
{
    public interface Five
    {
        //int myPropertyOne;

        int myPropertyTwo { get; set; }
    }

    public class Fiveone : Five
    {
        public int myPropertyTwo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
