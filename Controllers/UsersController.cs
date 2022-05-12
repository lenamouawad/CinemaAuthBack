using cinemas.Exceptions;
using cinemas.Models;
using cinemas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cinemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService service;

        public UsersController(UsersService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateUser(Login login)
        {
            return Created("", service.CreateUser(login));
        }

        [HttpGet("username/{username}")]

        public IActionResult FindUserByUsername(string username)
        {
            try
            {
                return Ok(this.service.FindUserByUsername(username));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login.Username == null || login.Password == null)
            {
                return BadRequest("Invalid request");
            }
            else
            {
                AuthenticatedResponse response = this.service.Login(login);
                if (response.Token != null)
                {
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }           
        }

        [HttpGet("VerifyUser")]

        public IActionResult FindUser(Login user)
        {
            try
            {
                return Ok(this.service.FindUser(user));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Created("", this.service.GetAllUsers());

        }

        [HttpDelete]
        public IActionResult DeleteAllUsers()
        {
            return Created("", this.service.DeleteAllUsers());
        }
    }
}
