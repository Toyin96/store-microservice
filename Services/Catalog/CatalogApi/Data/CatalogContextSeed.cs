using CatalogApi.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CatalogApi.Data
{
    internal class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Book> bookCollection)
        {
            bool existBook = bookCollection.Find(p => true).Any();
            if (!existBook)
            {
                bookCollection.InsertManyAsync(GetStaticDataBooks());   
            };
        }

        private static IEnumerable<Book> GetStaticDataBooks()
        {
            return new List<Book>()
            {

                new Book()
                {
                    ID = "61b71049107843c36de863aa",
                    Author = "Chinua Achebe",
                    Country = "Nigeria",
                    ImageLink = "images/things-fall-apart.jpg",
                    Language = "English",
                    Link = "https=//en.wikipedia.org/wiki/Things_Fall_Apart\n",
                    Pages = 209,
                    Title = "Things Fall Apart",
                    Year = 1958
                },
                new Book()
                {
                    ID = "61b71049107843c36de863ab",
                    Author = "Hans Christian Andersen",
                    Country = "Denmark",
                    ImageLink = "images/fairy-tales.jpg",
                    Language = "Danish",
                    Link = "https=//en.wikipedia.org/wiki/Fairy_Tales_Told_for_Children._First_Collection.\n",
                    Pages = 784,
                    Title = "Fairy tales",
                    Year = 1836
                },
                new Book()
                {
                    ID = "61b71049107843c36de863ac",
                    Author = "Dante Alighieri",
                    Country = "Italy",
                    ImageLink = "images/the-divine-comedy.jpg",
                    Language = "Italian",
                    Link = "https=//en.wikipedia.org/wiki/Divine_Comedy\n",
                    Pages = 928,
                    Title = "The Divine Comedy",
                    Year = 1315
                }
            };
        }
    }
}