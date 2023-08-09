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

        
    }
}
