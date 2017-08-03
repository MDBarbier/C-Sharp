using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates_test
{
    class Class1
    {
        public struct Book
        {
            public string Title;        // Title of the book.
            public string Author;       // Author of the book.
            public decimal Price;       // Price of the book.
            public bool Paperback;      // Is it paperback?

            public Book(string title, string author, decimal price, bool paperBack)
            {
                Title = title;
                Author = author;
                Price = price;
                Paperback = paperBack;
            }
        }

        // Declare a delegate type for processing a book:
        // the return type and arguments make up the delegate so if you need to use different ones you need another delegate
        public delegate void ProcessBookDelegate(Book book);

        // Maintains a book database.
        public class BookDB
        {
            // List of all books in the database:
            ArrayList list = new ArrayList();

            // Add a book to the database:
            public void AddBook(string title, string author, decimal price, bool paperBack)
            {
                list.Add(new Book(title, author, price, paperBack));
            }

            // Call a passed-in delegate on each paperback book to process it: 
            public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
            {
                foreach (Book b in list)
                {
                    if (b.Paperback)
                        // Calling the delegate:
                        processBook(b);
                }
            }
        }
    }
}
