using CatalogApi.Data;
using CatalogApi.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ICatalogContext _context;

        public BookRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateBook(Book book)
        {
            await _context.Books.InsertOneAsync(book);
        }

        public async Task<bool> DeleteBook(string id)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.ID, id);
            var deleteResult =  await _context.Books.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Book>> FilterByAuthor(string authorName)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Author, authorName);
            return await _context.Books.Find(filter).ToListAsync();
        }

        public async Task<Book> GetBookById(string id)
        {
            return await _context.Books.Find(p => p.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByName(string name)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Title, name);
            return await _context.Books.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var updateResult = await _context.Books.ReplaceOneAsync(filter: k => k.ID == book.ID, replacement: book);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
