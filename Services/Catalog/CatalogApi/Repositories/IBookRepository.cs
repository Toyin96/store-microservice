using CatalogApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book> GetBookById(string id);
        Task<IEnumerable<Book>> GetBookByName(string name);

        Task<IEnumerable<Book>> FilterByAuthor(string authorName);
        Task CreateBook(Book book);
        Task<bool> DeleteBook(string id);
        Task<bool> UpdateBook(Book book);

    }
}
