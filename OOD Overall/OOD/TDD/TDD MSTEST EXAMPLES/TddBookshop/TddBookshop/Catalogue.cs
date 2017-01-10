using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddBookshop           // NO NEED TO REFACTOR, NO REPEATED CODE AND SIMPLE
{
    public class Catalogue // ENSURE ITS PUBLIC
    {
        public List<Book> books { get; set; }       // ADD THIS FOR 2ND TEST (TESTING FOR ONE OR MORE BOOKS) 

        // ^^^^ THIS IS A VARIABLE, NEEDS TO BE DECALRED
        // ERRORS WILL BE RETURNED AFTER THIS, ADD A CONSTRUCTOR!

        public Catalogue() // CONSTRUCTOR
        {
            books = new List<Book>();       // 'books' links with line 11 'books' new constructor.
            // 'new' means that it will run a constructor in that class
        }

        public List<Book> GetAllBooks() // Must not be VOID, must be able to return value to test   // This will return a value to Act test
        {
            //GetAllBooks may get error, you must provide a 'return'

            // FIRST TEST THE TEST USING NULL AND WATCH FAIL (return null;)

            // AFTER TEST USING NEW CODE ( return new List<Book>(); ) and watch pass.
            return books; //  CHANGE TO books for the 2nd test (Checking for one book) -- Remove () and just add return books;
            // () is removed as it is being pulled from line 11 which is a variable with values.

            // 3RD TEST  -- IMPORTANT, IF TEST IS SUCCESSFUL WITHOUT FAILURE FIRST,
            // CHANGE RETURN TO ( return new List<Book>(); ) TO GAIN CONFIDENCE.

        }

        public List<Book> RemoveByIsbn(string isbn)
        {
            //Insert Code
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].isbn == isbn)
                {
                    books.Remove(books[i]);
                }
            }

            return books;
        }
    }
}


