using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BooksRepository : IBooksRepository
    {
        private int _nextId = 1;
        private List<Book> _books = new List<Book>()
        {
           new Book("Bog1", 500) { Id = 1 },
           new Book("Bog2", 500) { Id = 2 },
           new Book("Bog3", 500) { Id = 3 },
           new Book("Bog4", 500) { Id = 4 },
           new Book("Bog5", 500) { Id = 5 }
        };
        public Book Add(Book book)
        {
            book.Validate();
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? bookToRemove = this.GetById(id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }

            return bookToRemove;
        }

        public List<Book> Get()
        {
            List<Book> result = new List<Book> (_books);
            return result;
        }

        public Book? GetById(int id)
        {
            Book? result = _books.FirstOrDefault(t => t.Id == id);

            return result;
        }

        public Book Update(int id, Book book)
        {
            book.Validate();
            Book? bookToUpdate = this.GetById(id);
            if (bookToUpdate != null) 
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Price = book.Price;
            }

            return bookToUpdate;

        }
        private int NextId()
        {
            return _nextId++;
        }
    }
}
