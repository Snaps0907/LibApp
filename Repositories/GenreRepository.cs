using System.Collections.Generic;
using LibApp.Interfaces;
using LibApp.Data;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genre;
        }

        public Genre Get(int id) => _context.Genre.Find(id);

        public void Add(Genre item) => _context.Genre.Add(item);

        public void Remove(int id) => _context.Genre.Remove(Get(id));

        public void Update(Genre item) => _context.Genre.Update(item);
        public void Save() => _context.SaveChanges();
    }
}
