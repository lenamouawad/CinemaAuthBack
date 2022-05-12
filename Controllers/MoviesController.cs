using cinemas.Exceptions;
using cinemas.Models;
using cinemas.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Controller
{
    //localhost:port/api/movies
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        
        private MovieService service;

        public MoviesController(MovieService service)
        {
            this.service = service;
        }

        //POST : localhost:port/api/movies
        /// <summary>
        /// Create a movie
        /// </summary>
        /// <param name="movie">Movie to create</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            return Created("", service.CreateMovie(movie));
        }

        [HttpGet("allMovies")]
        public IActionResult GetAllMovies()
        {
            return Ok(this.service.GetAllMovies());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetMovieById(string id)
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
    }
}
