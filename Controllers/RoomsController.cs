using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cinemas.Exceptions;
using cinemas.Models;
using cinemas.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinemas.Controller
{
    //localhost:port/api/rooms
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private RoomService service;

        public RoomsController(RoomService service)
        {
            this.service = service;
        }

        //POST : localhost:port/api/rooms
        /// <summary>
        /// Create a room
        /// </summary>
        /// <param name="room">Room to create</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateRoom(Room room)
        {
            return Created("", service.CreateRoom(room));
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns>List of rooms</returns>
        [HttpGet("allRooms")]
        public IActionResult GetAllRooms()
        {
            return Ok(this.service.GetAllRooms());
        }

        /// <summary>
        /// Find room by Id
        /// </summary>
        /// <param name="id">room id</param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult FindRoomById(string id)
        {
            try
            {
                return Ok(this.service.FindById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Modify a room
        /// </summary>
        /// <param name="id">room id </param>
        /// <param name="roomUpdated">room with new info</param>
        /// <returns>updated room info</returns>
        [HttpPut("update")]
        public IActionResult UpdateRoom(String id, Room roomUpdated)
        {
            return Ok(service.UpdateRoom(id, roomUpdated));
        }
    }
}
