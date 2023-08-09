using LibraryManagementAdo.Net;
using System.Runtime.CompilerServices;

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
            Console.WriteLine("3. Display available books");
            Console.WriteLine("4. Get Borrowed Books");
            Console.WriteLine("5. Get books by author");

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

                    Console.WriteLine("Displaying all Books.......");
                    library.DisplayallBooks();
                    break;

                case 3:

                    Console.WriteLine("Displaying Available books......");
                    library.GetAvailableBooks();
                    break;

                case 4:

                    Console.WriteLine("Displaying borrowed books.....");
                    library.GetBorrowedBooks();
                    break;

                case 5:

                    Console.Write("Enter the name of Author: ");
                    string name = Console.ReadLine();
                    library.Get_books_by_author(name);
                    break;
            }

        }
    }
}
