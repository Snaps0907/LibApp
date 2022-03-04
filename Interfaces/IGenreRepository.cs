using System.Collections.Generic;
using LibApp.Models;

namespace LibApp.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
        Genre Get(int id);
        void Add(Genre item);
        void Remove(int id);
        void Update(Genre item);
        void Save();

    }
}
