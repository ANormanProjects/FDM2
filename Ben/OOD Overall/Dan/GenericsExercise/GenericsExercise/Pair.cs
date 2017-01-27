using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise
{
    public class Pair<T, S>
    {
        public T OneHalfOfThePair { get; set; }
        public S OtherHalfOfthePair { get; set; }
    }
}
