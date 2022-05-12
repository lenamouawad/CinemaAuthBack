using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cinemas.DTO
{
    public class ReviewDTO2
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String username { get; set; }
        public String movieId { get; set; }
        public String reviewText { get; set; }

        public ReviewDTO2()
        {
        }
        public ReviewDTO2(string username, string movieId, string reviewText)
        {
            this.username = username;
            this.movieId = movieId;
            this.reviewText = reviewText;
        }
    }
}
