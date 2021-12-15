using CatalogApi.Entities;
using CatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IBookRepository repository, ILogger<CatalogController> logger)
        {
           _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books =  await _repository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<Book>> GeBookById(string id)
        {
            var book = await _repository.GetBookById(id);
            if (book == null)
            {
                _logger.LogError($"Book with id {id} not found");
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("{[action]/{author}}", Name = "GetBookByAuthor")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Book>>> GeBookByAuthorName(string author)
        {
            var books = await _repository.FilterByAuthor(author);
            if (books == null)
            {
                _logger.LogError($"Book with authorname: {author} not found");
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{[action]/{title}}", Name = "GetBookByAuthor")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Book>>> GeBookByTitle(string title)
        {
            var books = await _repository.GetBookByName(title);
            if (books == null)
            {
                _logger.LogError($"Book with id {title} not found");
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            await _repository.CreateBook(book);
            return CreatedAtRoute("GetBook", new { id = book.ID }, book);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> UpdateBook(Book book)
        {
            return Ok(await _repository.UpdateBook(book));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteBook")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> DeleteBook(string id)
        {
            return Ok(await _repository.DeleteBook(id));
        }
    }
}
