using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace cinemas.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string movieId { get; set; }
        public string userId { get; set; }
        public string reviewText { get; set; }

        public Review()
        {
        }
        public Review(string id, string movieId, string userId, string reviewText)
        {
            this.id = id;
            this.movieId = movieId;
            this.userId = userId;
            this.reviewText = reviewText;
        }
    }
}
