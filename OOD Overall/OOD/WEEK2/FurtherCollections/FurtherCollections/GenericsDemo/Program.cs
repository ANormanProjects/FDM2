using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //WAS ORIGINAL BUT DOESNT WORK, REQUIRES A GENERIC
            
            //ItemCatalogue catalogue = new ItemCatalogue(); //DEPENDING UPON AN ABSTRACT CLASS, ITEM IS ABSTRACT SO WE HAVE TO INHERIT FROM IT. DEPENDENCY INVERSION.

            //catalogue.AddItem(new Book() { id = 1, title = "Tarzan", author = "Ben Bowes" });
            //catalogue.AddItem(new Dvd() { id = 2, title = "Tarzan", releaseDate = new DateTime() });

            //foreach (Item item in catalogue)
            //{


            //    Console.WriteLine(item.title);
            //    Console.WriteLine(item.author); //using item.author will only print 'item' properties and not the special classes such as 'book' which has an additional property and inherit item
            //    Console.WriteLine(item.releaseDate);
            //}

            //USING GENERICS = BEST WAY
            Catalogue<Book> catalogueOfBooks = new Catalogue<Book>();
            catalogueOfBooks.AddItem(new Book());

            Catalogue<Dvd> catalogueOfDvd = new Catalogue<Dvd>();
            catalogueOfDvd.AddItem(new Dvd());

            foreach (Book book in catalogueOfBooks.items)
            {
                Console.WriteLine(book.title);
            }

            Console.ReadKey();
        }
    }
}
