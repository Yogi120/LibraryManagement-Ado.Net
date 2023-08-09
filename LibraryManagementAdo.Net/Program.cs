using LibraryManagementAdo.Net;

public class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine(" Library Management ");

            Console.WriteLine("1. Add Book in Library");
            Console.WriteLine("2. Retrieve/Display the total number of books");

            Console.Write("Enter your Preference: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    Console.Write("Enter Book_id: ");
                    int book_id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Book Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Book Genre: ");
                    string genre = Console.ReadLine();

                    Books book = new Books(book_id, title, author, genre, false);
                    library.Addbook(book);

                    break;

                case 2:

                    Console.WriteLine("Displaying all contact.......");
                    library.DisplayallBooks();
                    break;
            }

        }
    }
}
