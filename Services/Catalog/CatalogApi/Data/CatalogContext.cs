using CatalogApi.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Data
{
    public class CatalogContext : ICatalogInterface 
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionStrings"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:ConnectionStrings"));

            Books = database.GetCollection<Book>(configuration.GetValue<string>("DatabaseSettings:ConnectionStrings"));

            CatalogContextSeed.SeedData(Books);
        }
        public IMongoCollection<Book> Books { get; }
    }
}
