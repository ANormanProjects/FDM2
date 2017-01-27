using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwoExercise
{
    public abstract class Two
    {
        public int memberVariableOne;

        public int memberVariableTwo { get; set; }

        private int _memberVariableThree;
        public int memberVariableThree
        {
            get { return _memberVariableThree; }
            set { _memberVariableThree = value; }
        }
    }
}
