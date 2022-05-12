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
    //localhost:port/api/cinema
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private CinemaService service;

        public CinemasController(CinemaService service)

        {
            this.service = service;
        }

        //POST : localhost:port/api/cinemas
        /// <summary>
        /// Create a cinema
        /// </summary>
        /// <param name="cinema">Cinema to create</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCinema(Cinema cinema)
        {
            return Created("", service.CreateCinema(cinema));
        }

        /// <summary>
        /// Get all cinemas
        /// </summary>
        /// <returns>List of cinemas</returns>
        [HttpGet("allCinemas")]
        public IActionResult GetAllCinemas()
        {
            return Ok(this.service.GetAllCinemas());
        }

        /// <summary>
        /// Find cinema by Id
        /// </summary>
        /// <param name="id">Cinema id</param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult FindCinemaById(string id)
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
        /// Modify a cinema
        /// </summary>
        /// <param name="id">cinema id </param>
        /// <param name="cinemaUpdated">cinema with new info</param>
        /// <returns>updated cinema info</returns>
        [HttpPut("update")]
        public IActionResult UpdateCinema(String id, Cinema cinemaUpdated)
        {
            return Ok(service.UpdateCinema(id, cinemaUpdated));
        }


        /// <summary>
        /// Delete Cinema
        /// </summary>
        /// <param name="cinemaId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{cinemaId}")]
        public IActionResult DeleteCinema(string cinemaId)
        {
            try
            {
                this.service.DeleteCinema(cinemaId);
                return Ok("The cinema was deleted");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
