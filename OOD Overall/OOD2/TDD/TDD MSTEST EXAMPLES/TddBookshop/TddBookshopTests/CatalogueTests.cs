using Microsoft.VisualStudio.TestTools.UnitTesting; // 3. CORRECT USING STATEMENT FOR CLASS TESTING ADDED
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddBookshop;

namespace TddBookshopTests          // 1. CONVERT INTO TEST CLASS - [TestClass] below
{
    [TestClass]             // 2. IF YOU GET ERROR - INCORRECT USING STATEMENTS AT TOP, RIGHT CLICK AND RESOLVE
    public class CatalogueTests         // ENSURE ITS PUBLIC
    {
        Catalogue myCatalogue;  // CLASS DEFINITION IS PLACED HERE OUTSIDE OF [TESTINIT] SO THAT ALL METHODS CAN SEE IT.
        Book myBook;

        [TestInitialize]        // REFACTORED/GENERALISED ALL REPEATED CODE
        public void Setup()     // THIS WILL BE RUN BEFORE EVERY TEST TO PROVIDE CLASSES/CONDUCTORS.
                                // !!! NEVER USE INHERITANCE WITH TESTS !!!
        {
            myCatalogue = new Catalogue(); // GENERATING NEW CONDUCTOR FOR ALL METHODS USING CLASS CATALOGUE.
            myBook = new Book();

        }

        [TestCleanup]   // RUNS AT THE END OF ALL THE TESTS -- POSITION DOESNT MATTER.
        public void Clean()
        {

        }
        
        [TestMethod]            // 4. Ensure this is above all test methods.           MAKE SURE ALL TEST METHOD NAMES HAS VERY DESCRIPTIVE NAMES, DESCRIBE EVERYTHING.
        
            //METHOD NAME: METHOD       EXPECTED RESULT         CONDITIONS FOR TEST
        public void Test_GetAllBooks_ReturnsAListOfZeroLength_WhenTheCatalogueHasNoBooks()       // 4. WRITE METHOD FOR TESTING, TEST METHODS WILL ALWAYS BE PUBLIC AND VOID, YOU NEVER WANT ANYTHING RETURNED FROM A TEST METHOD.
        {
            //ARRANGE                -- Set up Test --          Starting to write tests can be difficult -- No real formula
            //Catalogue myCatalogue = new Catalogue();                // 5. Start - Make the object your testing - Catalogue 

            // 7. GENERATE CLASS IN CLASS LIBRARY (Catalogue) and (Book) to remove errors. Right click references in TddBookshop Tests to link library.
                                        // ENSURE NEW CLASSES IN LIBRARY ARE PUBLIC
                                        // IF ERRORS STILL APPEAR RIGHT CLICK NAMES AFTER CLASSES ARE MADE TO LINK.
            
            //ACT           -- Run the method that we're testing --                 // 6. GetAllBooks is in Catalogues class - myCatalogues.GetAllBooks  
            List<Book> books = myCatalogue.GetAllBooks();                           // HOLDING A COLLECTION OF BOOK OBJECTS  -- Saving 'books' to memory as List<Book>

            // 8. Create a method in catalogues called get all books

            //ASSERT        -- See if result is what was expected --        GetAllBooks will return a list of books (ARRAY)
            Assert.AreEqual(0, books.Count);                    // EXPECTED RESULTS IS 0 (NO BOOKS), ACTUAL RESULTS WILL BE number of books in the list e.g. books.Count ('books' = List<Book> 'books')

        }

        [TestMethod]        // SECOND TEST TESTING RETURN OF ONE BOOK IN THE CATALOGUE
        public void Test_GetAllBooks_ReturnsAListOfOneLength_WhenTheCatalogueHasNoBooks()
        {
            //ARRANGE
            //Catalogue myCatalogue = new Catalogue();    // new - runs constructor from the catalogue class
            //Book myBook = new Book();           // NEW BOOK TO TEST 1 BOOK, THIS WILL BE SET UP IN THE Catalogue.cs

            //Put the book in the catalogue
            // COMMENTS IS USED TO DEMONSTRATE THAT THESE ARE NOW PLACED IN A GENERALISATION AT THE TOP (TestInit)

            myCatalogue.books.Add(myBook); // GOES INTO THE Catalogue class to pull out the 'books' constructor to get a new value for myBook.

            //ACT
            List<Book> books = myCatalogue.GetAllBooks(); // Same as before.

            //ASSERT
            Assert.AreEqual(1, books.Count);        // (1, books.Count); as we are testing 1 book return value.

        }

        [TestMethod]
        public void Test_GetAllBooks_ReturnsTheSameBookThatWasAdded_WhenTheCatalogueHasOneBooks()
        {
            //ARRANGE

            myBook.title = "Lord Of The Rings"; // TITLE OF BOOK SET BY USER

            myCatalogue.books.Add(myBook);

            //ACT

            List<Book> books = myCatalogue.GetAllBooks();

            //ASSERT
            //myBook.name is from above (variable)
            Assert.AreEqual(myBook.title, books[0].title); // IF ERROR, BOOKS NOT GOT DEFINITION, GO TO Book.cs

            //TIME TO REFACTOR/GENERALISE

        }

        [TestMethod] // AFTER ADDING A BOOK WE SHOULD BE ABLE TO REMOVE IT USING ITS ISBN.
        public void Test_GetAllBooks_RemovesByISBN_ReturnsAListOfZero_WhenTheCatalogueHasOneBookWithISBN12345()
        {
            //ARRANGE

            myBook.isbn = "12345";

            myCatalogue.books.Add(myBook);

            myBook.isbn = "456";

            myCatalogue.books.Add(myBook);

            //ACT

            List<Book> books = myCatalogue.RemoveByIsbn(myBook.isbn);
            myCatalogue.books.Remove(myBook);

            //ASSERT
            Assert.AreEqual(0, books.Count);
        }
    }
}
