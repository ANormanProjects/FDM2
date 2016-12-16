using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise
{
    public abstract class Catalogable<T>
    {
        public T id { get; set; }
    }

    public class Book : Catalogable<int>
    {
        public string title { get; set; }
    }

    public class Borrowers : Catalogable<int>
    {
    }

    public class Library : Catalogable<int>
    {
        public string name { get; set; }
    }

    public class Staff : Catalogable<int>
    {
    }

    public class Loans : Catalogable<int>
    {
    }
}
