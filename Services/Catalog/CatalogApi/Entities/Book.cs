using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Entities
{
    public class Book
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Country { get; set; }
        public string ImageLink { get; set; }
        public string Language { get; set; }
        public string Link { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
    }
}
