using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public int number { get; set; }
        public int nbrSeats { get; set; }

        public Room()
        {
        }

        public Room(string id, int number, int nbrSeats)
        {
            this.id = id;
            this.number = number;
            this.nbrSeats = nbrSeats;
        }
    }
}
