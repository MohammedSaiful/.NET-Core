using LibraryManagement.DataAccessLayer.Data;
using LibraryManagement.DataAccessLayer.Modules.Books.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccessLayer.Modules.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Book?> GetByIdAsync(int id)
            => await _context.Books.FindAsync(id);

        public async Task<IEnumerable<Book>> GetAllAsync()
            => await _context.Books.ToListAsync();

        public async Task<IEnumerable<Book>> SearchAsync(string? searchTerm, Genre? genre)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(b =>
                    b.Title.Contains(searchTerm) ||
                    b.ISBN.Contains(searchTerm));
            }

            if (genre.HasValue)
                query = query.Where(b => b.Genre == genre);

            return await query.ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsIsbnUniqueAsync(string isbn, int? excludeId = null)
        {
            return !await _context.Books
                .AnyAsync(b => b.ISBN == isbn &&
                              (!excludeId.HasValue || b.Id != excludeId));
        }
    }
}
