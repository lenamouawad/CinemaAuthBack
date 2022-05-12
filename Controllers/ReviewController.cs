using cinemas.DTO;
using cinemas.Exceptions;
using cinemas.Models;
using cinemas.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Controllers
{
    //localhost:port/api/movies
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private ReviewService service;

        public ReviewController(ReviewService service)
        {
            this.service = service;
        }

        [HttpGet("MovieReviews")]
        public IActionResult GetAllReviewsByMovieId(string id)
        {
            try
            {
                return Ok(this.service.GetAllReviewsByMovieId(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            return Created("", service.CreateReview(review));
        }

        [HttpPost("create")]
        public IActionResult CreateReview(ReviewDTO2 review)
        {
            return Created("", service.CreateReview(review));
        }

        [HttpDelete]
        public IActionResult DeleteAllReviews()
        {
            return Created("", this.service.DeleteAllReviews());
        }
    }
}
