namespace LambdasExcercise
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int numberOfPages { get; set; }

        public Book(string Title, string Author, int NumberOfPages)
        {
            title = Title;
            author = Author;
            numberOfPages = NumberOfPages;
        }
    }
}
