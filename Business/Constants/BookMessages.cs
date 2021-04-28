using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class BookMessages
    {
        public static string BookAdded = "Book Added";
        public static string BookUpdated = "Book Updated";
        public static string BookNameInvalid = "Book name invalid";
        public static string BooksListed = "Books Listed";
        public static string BooksHasArrivedWithByCategory = "Books has arrived with by Category";
        public static string BookHasArrived = "Book has arrived";
        public static string BooksHasArrivedWithByUnitPrice = "Books has arrived with by Unit Price";

        public static string BookNameAlreadyExists { get; internal set; }
        public static string BooksHasArrivedWithByAuthor { get; internal set; }
    }
}
