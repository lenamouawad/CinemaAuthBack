using cinemas.Config;
using cinemas.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Repositories
{
    public class RoomRepository
    {
        private readonly IMongoCollection<Room> rooms;
        public RoomRepository(ICinemaApiDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            rooms = database.GetCollection<Room>(settings.RoomCollectionName);
        }

        /// <summary>
        /// Creates a room and adds it to the database
        /// </summary>
        /// <param name="room">Created room</param>
        /// <returns>List of all rooms</returns>
        public List<Room> CreateRoom(Room room)
        {
            this.rooms.InsertOne(room);
            return this.rooms.Find(room => true).ToList();
        }

        /// <summary>
        /// Returns all rooms
        /// </summary>
        /// <returns></returns>
        public List<Room> GetAllRooms()
        {
            return this.rooms.Find(room => true).ToList();
        }

        /// <summary>
        /// Returns the room with the given id
        /// </summary>
        /// <param name="id">Id of the room</param>
        /// <returns></returns>
        public Room FindById(string id)
        {
            return this.rooms.Find(room => room.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Modify a room
        /// </summary>
        /// <param name="id">room id </param>
        /// <param name="roomUpdated">room with new info</param>
        /// <returns>updated room info</returns>
        public Room UpdateRoom(String id, Room roomUpdated)
        {
            roomUpdated.id = id;
            this.rooms.FindOneAndReplace(room => room.id == id, roomUpdated);
            return this.rooms.Find(room => room.id == id).FirstOrDefault();
        }
    }
}
