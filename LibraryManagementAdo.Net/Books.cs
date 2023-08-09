using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementAdo.Net
{
    public class Books
    {
        public int Book_id;
        public string Title;
        public string Author;
        public string Genre;
        public bool Borrowed;
        public string Borrower_Name;

        public Books()
        {
        }

        public Books(int book_id, string title, string author, string genre, bool borrowed)
        {
            Book_id = book_id;
            Title = title;
            Author = author;
            Genre = genre;
            Borrowed = borrowed;
        }

    }
}
