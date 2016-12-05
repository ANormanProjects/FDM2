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
            book book1 = new book("Animal Farm", "George Orwell");   // greenyblue color = class   every new class you make has a constructor
            //mybook.title = "Animal Farm";     // title - public string from book.cs
            //mybook.author = "George Orwell";
            book1.isbn = "123ABC";
            book1.price = 22.50;
            book1.numberOfPages = 200;

            book book2 = new book("The Alchemist", "Paulo Cuello");
            book2.isbn = "534252";
            book2.price = 12.50;
            book2.numberOfPages = 130;

            book book3 = new book("Harry Potter", "JK Rowling");
            book3.isbn = "123451";
            book3.price = 100.50;
            book3.numberOfPages = 1000;

            book[] books = { book1, book2, book3 };    // DEFINE ARRAY

            Checkout myCheckout = new Checkout();       // LINKING CHECKOUT CLASS

            double totalPrice;   // double variable called totalPrice

            totalPrice = myCheckout.CalculateTotalPrice(books);  // total price is checkout full array of books

            //System.Console.WriteLine(mybook.title);
            //System.Console.WriteLine(mybook.author);
            //System.Console.WriteLine(mybook.isbn);
            //System.Console.WriteLine(mybook.price);
            //System.Console.WriteLine(mybook.numberOfPages);

            System.Console.ReadLine();
        }
    }
}
