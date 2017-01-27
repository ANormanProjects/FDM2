using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the exact same thing...
            CheckValue(5);

            //... as this, excpet this function is anonymous.
            Func<int, bool> example = x => x + 5 == 10;     //Func is anonymous function always, <int, bool> (input, output).
            example.Invoke(5);

            LinqExamples();
            Console.WriteLine();

        }

        static bool CheckValue(int Value)
        {
            return Value + 5 == 10;     //Will return true or false
        }

        //Both are the same thing, but Lambdas only requires one line, simple and is an anonymous function.

        static void LinqExamples()
        {
            List<int> numbers = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9}; //Quick way to make a list with initial elements.

            IEnumerable<int> evenNumbers = numbers.Where<int>(x => x % 2 == 0);

            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
            Console.ReadLine();





            IEnumerable<int> distinct = numbers.Distinct<int>();            //IEnumerable - built in interface, used if going to return a collection/list of numbers

            int firstFour = 
                numbers.FirstOrDefault<int>(x => x == 4);      //Where<type>, Distinct<type>, FirstOrDefault<type> all require a type e.g. int

            int lastFour = 
                numbers.LastOrDefault<int>(x => x == 4);

            int singleFour = 
                numbers.SingleOrDefault<int>(x => x == 4);      //IEnumerable is not used here as you are returning one value/int

            IEnumerable<int> firstFiveElements = 
                numbers.Take<int>(5);                       //Used IEnumerable as you are going to return a list/collection of int numbers






            List<Book> books = new List<Book>()     //Use new Book because need to use Book Class to run through the constructor to generate field in collection (title, numOfPages)
            {
                new Book("title3", 300),
                new Book("title2", 300),
                new Book("title1", 300)
            };

            IEnumerable<Book> orderedBooks = books.OrderBy(b => b.title);

            
        }
    }
}
