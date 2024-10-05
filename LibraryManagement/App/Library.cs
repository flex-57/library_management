using System.Text.RegularExpressions;

namespace LibraryManagement
{
    public class Library
    {
        public List<Book> booksList = new List<Book>();
        public List<User> usersList = new List<User>();
        public User connectedUser;

        public void AddBook(string title, string author)
        {
            booksList.Add(new Book(title, author));
        }

        public void AddUser(string name)
        {
            usersList.Add(new User(name));
        }

        public bool UserExists(string userName)
        {
            foreach (User user in usersList)
            {
                if (user.name == userName)
                {
                    connectedUser = user;
                    return true;
                }
            }
            return false;
        }

        public string AllBooksRender()
        {
            string list = $"Liste des livres : {Environment.NewLine}";
            int i = 1;
            foreach (var book in booksList)
            {
                list += $"{i}. {book.BookRender()} {Environment.NewLine}";
                i++;
            }
            return list;
        }

        public string AvailableBooksRender()
        {
            string list = $"Liste des livres disponibles : {Environment.NewLine}";
            int i = 1;
            foreach (var book in booksList)
            {
                if (book.isAvailable)
                {
                    list += $"{i}. {book.BookRender()} {Environment.NewLine}";
                    i++;
                }
            }
            return list;
        }

        public string BookSearch(string title)
        {
            string ret = $"Résultat de la recherche : {Environment.NewLine}";
            bool found = false;

            foreach (var book in booksList)
            {
                Regex regex = new Regex(Regex.Escape(title), RegexOptions.IgnoreCase);
                if (regex.IsMatch(book.title))
                {
                    ret += book.BookRender() + Environment.NewLine;
                    found = true;
                }
            }

            if (!found)
            {
                ret = $"Aucun livre ne porte le titre contenant \"{title}\" !";
            }

            return ret;
        }

        public bool BorrowBook(string title)
        {
            foreach (var book in booksList)
            {
                if (book.title.Equals(title, StringComparison.OrdinalIgnoreCase) && book.isAvailable)
                {
                    connectedUser.BorrowBook(book);
                    return true;
                }
            }
            return false;
        }

        public bool ReturnBook(string title)
        {
            foreach (var book in connectedUser.borrowedBooks)
            {
                if (book.title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    connectedUser.GiveBackBook(book);
                    return true;
                }
            }
            return false;
        }
    }
}
