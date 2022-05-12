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
    //localhost:port/api/screenings
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningsController : ControllerBase
    {
        private ScreeningService service;

        public ScreeningsController(ScreeningService service)
        {
            this.service = service;
        }

        //POST : localhost:port/api/screenings
        /// <summary>
        /// Create a screening
        /// </summary>
        /// <param name="screening">Screening to create</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateScreening(Screening screening)
        {
            return Created("", service.CreateScreening(screening));
        }

        /// <summary>
        /// Get all screenings
        /// </summary>
        /// <returns>List of screenings</returns>
        [HttpGet("allScreenings")]
        public IActionResult GetAllScreenings()
        {
            return Ok(this.service.GetAllScreenings());
        }

        
        /// <summary>
        /// Get all screenings with only the essential information
        /// </summary>
        /// <returns>List of screenings</returns>
        [HttpGet("allScreeningsInfo")]
        public IActionResult GetAllScreeningsInfo()
        {
            return Ok(this.service.GetScreeningInfo());
        }

        
        /// <summary>
        /// Get all screenings in a cinema of a particular movie
        /// </summary>
        /// <returns>List of screenings of a movie in a cinema</returns>
        [HttpGet("screeningsMovieCinema")]
        public IActionResult GetScreeningsByMovieByCinema(String movieId, String cinemaId)
        {
            return Ok(this.service.GetScreeningsByMovieByCinema(movieId, cinemaId));
        }

        /// <summary>
        /// Get all movies in a cinema
        /// </summary>
        /// <returns>List of movies in a cinema</returns>
        [HttpGet("MoviesInCinema")]
        public IActionResult GetMoviesByCinemaId(String cinemaId)
        {
            return Ok(this.service.GetMoviesByCinemaId(cinemaId));
        }

        /// <summary>
        /// Find screening by Id
        /// </summary>
        /// <param name="id">screening id</param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult FindScreeningById(string id)
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
        /// Find screening DTO by Id
        /// </summary>
        /// <param name="id">screening id</param>
        /// <returns></returns>
        [HttpGet("id/DTO/{id}")]
        public IActionResult FindScreeningDTOById(string id)
        {
            try
            {
                return Ok(this.service.FindDTOById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Modify a screening
        /// </summary>
        /// <param name="id">screening id </param>
        /// <param name="screeningUpdated">screening with new info</param>
        /// <returns>updated screening info</returns>
        [HttpPut("update")]
        public IActionResult UpdateScreening(String id, Screening screeningUpdated)
        {
            return Ok(service.UpdateScreening(id, screeningUpdated));
        }
    }
}
