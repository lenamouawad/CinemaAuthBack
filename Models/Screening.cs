using System;
using cinemas.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cinemas.Models
{
    public class Screening
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }
        public DateTime dateTime { get; set; }

        // Movie
        [BsonRepresentation(BsonType.ObjectId)]
        public String movieId { get; set; }
        [BsonIgnore]
        public Movie movie { get; set; }

        // Cinema
        [BsonRepresentation(BsonType.ObjectId)]
        public String cinemaId { get; set; }
        [BsonIgnore]
        public Cinema cinema { get; set; }

        // Showroom
        [BsonRepresentation(BsonType.ObjectId)]
        public String roomId { get; set; }
        [BsonIgnore]
        public Room room { get; set; }


        // Constructors
        public Screening()
        {
        }

        public Screening(string id, DateTime dateTime, string movieId, Movie movie, string cinemaId, Cinema cinema, string roomId, Room room)
        {
            this.id = id;
            this.dateTime = dateTime;
            this.movieId = movieId;
            this.movie = movie;
            this.cinemaId = cinemaId;
            this.cinema = cinema;
            this.roomId = roomId;
            this.room = room;
        }

        public static implicit operator ScreeningDTO(Screening screening)
        {
            return new ScreeningDTO(screening.id, screening.movie.name, screening.movie.imgUrl, screening.movie.duration, screening.dateTime, screening.cinema.region, screening.room.number);
        }
    }
}
