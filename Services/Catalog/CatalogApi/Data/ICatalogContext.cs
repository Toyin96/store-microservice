using CatalogApi.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Data
{
    public interface ICatalogContext
    {
        public IMongoCollection<Book> Books { get;  }
    }
}
