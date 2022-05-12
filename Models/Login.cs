using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace cinemas.Models
{
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; } = "null";
        public DateTime RefreshTokenExpiryDate { get; set; } = DateTime.Today;
    }
}
