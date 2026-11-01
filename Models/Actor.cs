using MongoDB.Bson.Serialization.Attributes;

namespace MvcMovie.Models
{
    public class Actor : Person
    {
        [BsonElement("role")]
        public string Role { get; set; }
    }
}