using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MvcMovie.Models
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }

        [BsonElement("summary")]
        public string Summary { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("director")]
        public Director Director { get; set; }

        [BsonElement("actors")]
        public List<Actor> Actors { get; set; }
    }
}