using System.Collections.Generic;
using LibApp.Interfaces;
using LibApp.Data;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(item => item.Genre);
        }

        public Book Get(int id)
        {
            var book = _context.Books.Find(id);
            book.Genre = _context.Genre.Find(book.GenreId);
            return book;
        }

        public void Add(Book item) => _context.Books.Add(item);

        public void Remove(int id) => _context.Books.Remove(Get(id));

        public void Update(Book item) => _context.Books.Update(item);
        public void Save() => _context.SaveChanges();
    }
}
