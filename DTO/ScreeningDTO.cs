using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cinemas.DTO
{
    public class ScreeningDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }
        public String movieName { get; set; }
        public String movieImgUrl { get; set; }
        public int movieDuration { get; set; }
        public DateTime dateTime { get; set; }
        public String cinema { get; set; }
        public int roomNbr { get; set; }

        public ScreeningDTO()
        {
        }
        public ScreeningDTO(string id, string movieName, string movieImgUrl, int movieDuration, DateTime dateTime, string cinema, int roomNbr)
        {
            this.id = id;
            this.movieName = movieName;
            this.movieImgUrl = movieImgUrl;
            this.movieDuration = movieDuration;
            this.dateTime = dateTime;
            this.cinema = cinema;
            this.roomNbr = roomNbr;
        }
    }
}
