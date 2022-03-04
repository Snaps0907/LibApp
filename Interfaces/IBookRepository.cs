using System.Collections.Generic;
using LibApp.Models;

namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book Get(int id);
        void Add(Book item);
        void Remove(int id);
        void Update(Book item);
        void Save();
    }
}
