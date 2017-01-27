using LambdasExcercise;

namespace LambdasExercise.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            BookCalculator calc = new BookCalculator();

            Book book1 = new Book("title", "author", 150);

            ProcessBookDelegate totalNumberOfPagesDelegate = new ProcessBookDelegate(calc.AddPagesInBookToCount);
            ProcessBooks(totalNumberOfPagesDelegate, book1);

            ProcessBookDelegate totalBooksDelegate = new ProcessBookDelegate(calc.AddBookToCount);
            ProcessBooks(totalBooksDelegate, book1);
        }

        static void ProcessBooks(ProcessBookDelegate myDelegate, Book book)
        {
            myDelegate(book);
        }
    }
}
