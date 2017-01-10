using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise.LibraryStuff
{
    public abstract class Catalogable<T>
    {
        public T id { get; set; }
    }

    public class Book : Catalogable<int>
    {

    }

    public class Borrower : Catalogable<int>
    {

    }

    public class Staff : Catalogable<int>
    {

    }

    public class Loans : Catalogable<int>
    {

    }
}
