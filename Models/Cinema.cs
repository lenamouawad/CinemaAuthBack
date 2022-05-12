using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cinemas.Models
{
    public class Cinema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string region { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> roomId { get; set; }

        [BsonIgnore]
        public List<Room> rooms { get; set; }

        public Cinema()
        {
        }

        public Cinema(string id, string region, List<string> roomId, List<Room> rooms)
        {
            this.id = id;
            this.region = region;
            this.roomId = roomId;
            this.rooms = rooms;
        }

    }
}
