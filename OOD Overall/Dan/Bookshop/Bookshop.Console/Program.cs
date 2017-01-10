using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Animal Farm", "George Orwell");
            book1.isbn = "123ABC";
            book1.price = 10.00;
            book1.numberOfPages = 200;

            Book book2 = new Book("The Alcemist", "Paulo Cuello");
            book2.isbn = "456DEF";
            book2.price = 100.00;
            book2.numberOfPages = 500;

            Book book3 = new Book("Harry Potter", "JK Rowling");
            book3.isbn = "789GHI";
            book3.price = 20.00;
            book3.numberOfPages = 1000; 

            Book[] books = { book1, book2, book3 }; // ARRAY

            Checkout myCheckout = new Checkout();

            double totalPrice = myCheckout.CalculateTotalPrice(books); //USES ARRAY

            System.Console.WriteLine("The total price of the books is: " + totalPrice);

            System.Console.ReadLine();
        }
    }
}

