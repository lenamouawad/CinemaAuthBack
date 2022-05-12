using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cinemas.DTO
{
    public class ReviewDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String username { get; set; }
        public String reviewText { get; set; }       

        public ReviewDTO()
        {
        }
        public ReviewDTO(string username, string reviewText)
        {
            this.username = username;
            this.reviewText = reviewText;
        }
    }
}
