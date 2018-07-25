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
            
    }
}
