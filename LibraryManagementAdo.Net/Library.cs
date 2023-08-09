using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementAdo.Net
{
    public class Library
    {
        string connection = $"Data Source = (localdb)\\MSSQLLocalDB; Database = Books ;Integrated Security=True";

        SqlConnection sqlConnection;

        public Library()
        {
            sqlConnection = new SqlConnection(connection);
        }

        public bool Addbook(Books book)
        {
            try
            {
                sqlConnection.Open();
                string addbook = "SpAddBooks";

                SqlCommand sqlCommand = new SqlCommand(addbook, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@book_id", book.Book_id);
                sqlCommand.Parameters.AddWithValue("@Title", book.Title);
                sqlCommand.Parameters.AddWithValue("@Author", book.Author);
                sqlCommand.Parameters.AddWithValue("@Genre", book.Genre);
                sqlCommand.Parameters.AddWithValue("@Borrowed", 0);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected.");
                    Console.WriteLine("Books Added....... ");
                    return true;
                }

                else
                {
                    Console.WriteLine("Something went wrong :(");
                    sqlConnection.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool DisplayallBooks()
        {
            try
            {
                List<Books> list = new List<Books>();
                sqlConnection.Open();
                string displaybook = "SpDisplayallBooks";
                SqlCommand sqlCommand = new SqlCommand(displaybook, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Books books = new Books()
                    
                    {
                        Book_id = (int)reader["Book_id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"],
                        Borrowed = (bool)reader["Borrowed"],
                    };
                    list.Add(books);
                }
                foreach (Books book in list)
                {
                    Console.WriteLine($"Book_id : {book.Book_id}\n Title : {book.Title}\n Author : {book.Author}\n Genre : {book.Genre}\n Borrowed : {book.Borrowed}");
                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }

            finally
            {
                sqlConnection.Close();
            }

        }

        public bool GetAvailableBooks()
        {
            try 
            {
                List<Books> list = new List<Books>();
                sqlConnection.Open();
                string available = "SpDisplayAvailableBooks";
                SqlCommand sqlCommand = new SqlCommand(available, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Books book = new Books()
                    {
                        Book_id = (int)reader["Book_id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"]
                    };
                    list.Add(book);
                }
                foreach(Books book in list)
                {
                    Console.WriteLine($"Book_id : {book.Book_id}\n Title : {book.Title}\n Author : {book.Author}\n Genre : {book.Genre}");
                }
                return true;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Sometihing went wrong.....");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public bool GetBorrowedBooks()
        {
            try
            {
                List<Books> list = new List<Books>();
                sqlConnection.Open();
                string borrowed = "SpBorrowedBooks";
                SqlCommand sqlCommand = new SqlCommand(borrowed, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Books book = new Books()
                    {
                        Book_id = (int)reader["Book_id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"],
                        Borrower_Name = (string)reader["Name_of_borrower"]
                    };
                    list.Add(book);
                }
                foreach (Books book in list)
                {
                    Console.WriteLine($"Book_id : {book.Book_id}\n Title : {book.Title}\n Author : {book.Author}\n Genre : {book.Genre}\n Borrower_Name : {book.Borrower_Name}");
                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong....");
                return false;
            }

            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
