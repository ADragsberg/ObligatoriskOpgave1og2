using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BooksRepository : IBooksRepository
    {
        private List<Book> _books = new List<Book>();
        public Book Add(Book book)
        {
            book.Validate();
            _books.Add(book);
            return book;
        }

        public Book Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> Get()
        {
            List<Book> result = new List<Book> (_books);
            return result;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Book Update(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
