using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.console
{
    class Program
    {
        static void Main(string[] args)
        {
            book mybook = new book("Animal Farm", "George Orwell");   // greenyblue color = class   every new class you make has a constructor
            //mybook.title = "Animal Farm";     // title - public string from book.cs
            //mybook.author = "George Orwell";
            mybook.isbn = "123ABC";
            mybook.price = 10.00;
            mybook.numberOfPages = 200;

            System.Console.WriteLine(mybook.title);
            System.Console.WriteLine(mybook.author);
            System.Console.WriteLine(mybook.isbn);
            System.Console.WriteLine(mybook.price);
            System.Console.WriteLine(mybook.numberOfPages);

            System.Console.ReadLine();
        }
    }
}
