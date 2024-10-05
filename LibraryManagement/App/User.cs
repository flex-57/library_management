namespace LibraryManagement
{
    public class User
    {
        public string name { get; set; }
        public List<Book> borrowedBooks { get; set; }

        public User(string name)
        {
            this.name = name;
            borrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            book.isAvailable = false;
            borrowedBooks.Add(book);
        }

        public void GiveBackBook(Book book)
        {
            book.isAvailable = true;
            borrowedBooks.Remove(book);
        }

        public bool HasBorrowed(Book book)
        {
            return borrowedBooks.Contains(book);
        }
    }
}