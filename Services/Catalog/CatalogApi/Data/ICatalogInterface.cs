using CatalogApi.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Data
{
    interface ICatalogInterface
    {
        public IMongoCollection<Book> Books { get;  }
    }
}
