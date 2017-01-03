namespace LambdasExcercise
{
    public delegate void ProcessBookDelegate(Book book);

    public class BookCalculator
    {
        public int totalNumberOfPages { get; set; }
        public int numberOfBooks { get; set; }

        public void AddPagesInBookToCount(Book book)
        {
            totalNumberOfPages += book.numberOfPages;
        }

        public void AddBookToCount(Book book)
        {
            numberOfBooks += 1;
        }
    }
}
