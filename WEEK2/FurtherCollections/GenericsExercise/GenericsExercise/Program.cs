using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Pair<int, string> pair = new Pair<int, string>();
            Pair<string, string> pair2 = new Pair<string, string>();

            pair.id = 9;
            pair.name = "Ben";
            pair2.id = "9";
            pair2.name = "Benny";

            Console.WriteLine(pair2.name);

            Catalog<Book> book = new Catalog<Book>();

            Book book1 = new Book();
            book1.id = 1;
            book1.title = "Hello";

            book.AddCatalogable(book1);

            Console.WriteLine(book.FindCatalogable(1).title);
            Console.ReadKey();

        }
    }
}
