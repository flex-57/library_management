namespace LibraryManagement
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public bool isAvailable = true;

        public Book(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public string BookRender()
        {
            string availability = isAvailable ? "Disponible" : "Indisponible";
            return $"\"{title}\" de {author} ({availability})";
        }
    }
}