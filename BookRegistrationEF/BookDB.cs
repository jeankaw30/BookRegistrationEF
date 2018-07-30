using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
    public static class BookDB
    {
        public static List<Book> GetAllBooks()
        {
            BkRegDBContext context = new BkRegDBContext();
            List<Book> allBooks = 
                                (
                                from b in context.Book
                                select b
                                ).ToList();
            return allBooks;
        }

        public static void Add(Book b)
        {
            BkRegDBContext context = new BkRegDBContext();

            // asume book vilid
            context.Book.Add(b);
            context.SaveChanges();
        }

        // Ef will track an object if you pull out of database and then do modifcations 
        public static void Update(Book b)
        {  // METHOD #1 :
            var context = new BkRegDBContext();

            // get book from database
            Book originalBook = context.Book.Find(b.ISBN);

            // update any changed properties twice in database
            originalBook.Price = b.Price;
            originalBook.Title = b.Title;
        }

        public static void UpdateAlternative(Book b)
        {
            var context = new BkRegDBContext();

            // add Book object  to current context
            context.Book.Add(b);

            //Let EF know the book already exists, just modified
            // can use a using by removing system.data.entity
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public static void Delete(Book b)
        {   // METHOD #1  
            var context = new BkRegDBContext();
            context.Book.Add(b);

            // mark the book as deleted 
            context.Entry(b).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
