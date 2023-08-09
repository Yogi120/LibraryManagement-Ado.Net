using System.Data.SqlClient;

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
                        Genre = (string)reader["Genre"],
                    };
                    list.Add(book);
                }
                foreach (Books book in list)
                {
                    Console.WriteLine($"Book_id : {book.Book_id}\n Title : {book.Title}\n Author : {book.Author}\n Genre : {book.Genre}");
                }
                return true;
            }

            catch (Exception ex)
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
                        Borrower_Name = (string)reader["Name_of_borrower"],
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

        public bool Get_books_by_author(string author)
        {
            try
            {
                string query = "SpGetBooksbyAuthor";
                List<Books> list = new List<Books>();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Author", author);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Books book = new Books()
                    {
                        Book_id = (int)reader["Book_id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"],
                        Borrowed = (bool)reader["Borrowed"],
                    };
                    list.Add(book);
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
                Console.WriteLine("Something went wrong......");
                return false;
            }

            finally
            {
                sqlConnection.Close();
            }
        }

        public bool Get_books_by_Genre(string genre)
        {
            try
            {
                List<Books> list = new List<Books>();
                sqlConnection.Open();
                string query = "SpGetBooksbyGenre";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Genre", genre);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Books book = new Books()
                    {
                        Book_id = (int)reader["Book_id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"],
                        Borrowed = (bool)reader["Borrowed"],
                    };
                    list.Add(book);
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

        public bool Get_book_details(int book_id)
        {
            try
            {
                List<Books> list = new List<Books>();
                sqlConnection.Open();
                string details = "SpGetBooksbyID";
                SqlCommand sqlCommand = new SqlCommand(details, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Book_id", book_id);
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
                    Console.WriteLine($"Book_id : {book.Book_id}\n Title : {book.Title}\n Author :{book.Author}\n Genre : {book.Genre}\n Borrowed : {book.Borrowed}");
                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong.....");
                return false;
            }

            finally
            {
                sqlConnection.Close();
            }
        }

        public bool Borrow_Book(int id, string borrower)
        {
            try
            {
                sqlConnection.Open();
                string borrow = "SpBorrowBooks";
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand(borrow, sqlConnection, sqlTransaction);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Book_id", id);
                sqlCommand.Parameters.AddWithValue("@Borrower_name", borrower);

                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("Book issued !!");
                }
                catch (Exception)
                {
                    sqlTransaction.Rollback();
                    Console.WriteLine("Something went wrong :(");
                    Console.WriteLine("Rolling back");
                }
                return true;
            }

            catch (Exception)
            {
                Console.WriteLine("Something went wrong :(");
                sqlConnection.Close();
                return false;
            }

            finally
            {
                sqlConnection.Close();
            }

        }

    }
}
