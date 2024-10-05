namespace LibraryManagement
{
    internal class Program
    {
        static Library lib = new Library();

        static void Main(string[] args)
        {
            char keyChar;
            string userName;

            lib.AddBook("1984", "George Orwell");
            lib.AddBook("Le seigneur des anneaux", "JRR Tolkien");
            lib.AddBook("Les cavernes d'acier", "Isaac Asimov");
            lib.AddBook("Bilbo le hobbit", "JRR Tolkien");

            lib.AddUser("Luc Skywalker");
            lib.AddUser("Son Goku");
            lib.AddUser("Lucky Luck");

            Console.WriteLine("Bienvenue à la bibliothèque !");

            bool userConnected = false;

            do
            {
                Console.WriteLine("Quel est votre nom ?");
                userName = Console.ReadLine() ?? "";

                if (lib.UserExists(userName))
                {
                    Console.WriteLine($"Vous êtes connecté en tant que {userName}");
                    userConnected = true;
                }
                else
                {
                    Console.WriteLine($"L'utilisateur \"{userName}\" n'existe pas ! Essayez encore.");
                }
            }
            while (!userConnected);

            Console.WriteLine("1. Afficher tous les livres");
            Console.WriteLine("2. Afficher les livres disponibles");
            Console.WriteLine("3. Rechercher un livre par son titre");
            Console.WriteLine("4. Emprunter un livre");
            Console.WriteLine("5. Rendre un livre");
            Console.WriteLine("6. Quitter");

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                keyChar = key.KeyChar;

                string str = "";

                switch (keyChar)
                {
                    case '1':
                        str += lib.AllBooksRender();
                        break;
                    case '2':
                        str += lib.AvailableBooksRender();
                        break;
                    case '3':
                        Console.Write("Veuillez entrer le titre du livre à rechercher : ");
                        string searchTitle = Console.ReadLine() ?? "";
                        str += lib.BookSearch(searchTitle);
                        break;
                    case '4':
                        Console.Write("Veuillez entrer le titre du livre à emprunter : ");
                        string bookToBorrow = Console.ReadLine() ?? "";
                        if (lib.BorrowBook(bookToBorrow))
                        {
                            str += $"Vous avez emprunté \"{bookToBorrow}\" avec succès.";
                        }
                        else
                        {
                            str += $"Le livre \"{bookToBorrow}\" est soit indisponible, soit il n'existe pas.";
                        }
                        break;
                    case '5':
                        Console.Write("Veuillez entrer le titre du livre à rendre : ");
                        string bookToReturn = Console.ReadLine() ?? "";
                        if (lib.ReturnBook(bookToReturn))
                        {
                            str += $"Vous avez rendu \"{bookToReturn}\" avec succès.";
                        }
                        else
                        {
                            str += $"Vous n'avez pas emprunté le livre \"{bookToReturn}\" ou il n'existe pas.";
                        }
                        break;
                    case '6':
                        str += "Merci et à bientôt !";
                        break;
                    default:
                        str += $"{keyChar} ne fait pas partie des options disponibles !";
                        break;
                }

                Console.WriteLine(str);
            }
            while (keyChar != '6');
        }
    }
}