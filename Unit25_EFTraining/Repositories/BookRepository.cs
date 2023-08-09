using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit25_EFTraining.Entities;

namespace Unit25_EFTraining.Repositories
{
    public class BookRepository
    {
        
        private AppContext _context;
        public BookRepository(AppContext context)
        {
            _context = context;
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public bool AddBook(Book book)
        {
            try
            {
                _context.Books.Add(book);
            }
            catch 
            {
                return false;
            }
            return true;
        }
        public bool DeleteBook(Book book) 
        {
            try
            {
                _context.Books.Remove(book);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool UpdateBookById(int id, string date) 
        {
            try
            {
                var book = GetBookById(id);
                book.Created = DateTime.Parse(date);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public List<Book> GetListByAuthor(string author)
        {
            return _context.Books.
                Where(x => x.Author == author).ToList();
        }
    }
}
