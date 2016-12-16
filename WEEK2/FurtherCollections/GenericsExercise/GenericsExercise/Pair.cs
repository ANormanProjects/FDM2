using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise
{
    public class Pair<T, V>
    {
        public T id { get; set; }
        public V name { get; set; }

    }
}
