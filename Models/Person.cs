using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MvcMovie.Models
{
    public class Person
    {
        [BsonId]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("birth_date")]
        public string BirthDate { get; set; }
    }
}