using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace cinemas.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public int duration { get; set; }
        public string imgUrl { get; set; }

        public Movie()
        {
        }

        public Movie(string id, string name, int duration, string imgUrl)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.imgUrl = imgUrl;
        }
    }
}
