using cinemas.Exceptions;
using cinemas.Models;
using cinemas.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Services
{
    public class RoomService
    {
        private RoomRepository repository;
        public RoomService(RoomRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates a room
        /// </summary>
        /// <param name="room">Room to create</param>
        /// <returns>List of all rooms</returns>
        public List<Room> CreateRoom(Room room)
        {
            return this.repository.CreateRoom(room);
        }


        public List<Room> GetAllRooms()
        {
            return this.repository.GetAllRooms();

        }

        /// <summary>
        /// Returns the room with the given id
        /// </summary>
        /// <param name="id">room id</param>
        /// <returns></returns>
        public Room FindById(string id)
        {
            Room room = this.repository.FindById(id);
            if (room == null)
            {
                throw new NotFoundException($"None of the rooms has the ID {id}");
            }
            return room;
        }

        /// <summary>
        /// Modify a room
        /// </summary>
        /// <param name="id">room id </param>
        /// <param name="roomUpdated">room with new info</param>
        /// <returns>updated room info</returns>
        public Room UpdateRoom(String id, Room roomUpdated)
        {
            Room room = this.repository.UpdateRoom(id, roomUpdated);
            return room;
        }
    }
}
