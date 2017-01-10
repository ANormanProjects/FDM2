using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwoExercise
{
    public class Thirteen
    {
        public virtual string name
        {
            get { return "Thirteen"; }
            set { name = value; }
        }
    }

    public class ThirteenOne : Thirteen
    {
        public override string name
        {
            get { return "Thirteen One"; }
            set { name = value;}
        }
    }
}
