﻿using LibraryManagementAdo.Net;

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
            Console.WriteLine("6. Get Books by Genre");
            Console.WriteLine("7. Get Books detail by entering ID");
            Console.WriteLine("8. Borrow book from library");
            Console.WriteLine("9. Return book");
            Console.WriteLine("10. Exit the process");

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

                case 6:

                    Console.Write("Enter the type of Genre: ");
                    string type = Console.ReadLine();
                    library.Get_books_by_Genre(type);
                    break;

                case 7:

                    Console.Write("Enter Book id: ");
                    int idNum = Convert.ToInt32(Console.ReadLine());
                    library.Get_book_details(idNum);
                    break;


                case 8:

                    Console.Write("Enter book_id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter borrower name: ");
                    string borrower = Console.ReadLine();
                    library.Borrow_Book(id, borrower);
                    break;

                case 9:

                    Console.Write("Enter the book_id: ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    library.Get_book_details(Id);
                    break;

                case 10:

                    Console.WriteLine("Exiting.....");
                    return;

                default:

                    Console.WriteLine(" !! Enter correct preference !!");
                    break;
            }

        }
    }
}
