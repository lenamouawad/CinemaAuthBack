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
    public class CinemaService
    {
        private CinemaRepository repository;
        public CinemaService(CinemaRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates a cinema
        /// </summary>
        /// <param name="cinema">Cinema to create</param>
        /// <returns>List of all cinemas</returns>
        public List<Cinema> CreateCinema(Cinema cinema)
        {
            return this.repository.CreateCinema(cinema);
        }


        public List<Cinema> GetAllCinemas()
        {
            return this.repository.GetAllCinemas();

        }

        /// <summary>
        /// Returns the cinema with the given id
        /// </summary>
        /// <param name="id">cinema id</param>
        /// <returns></returns>
        public Cinema FindById(string id)
        {
            Cinema cinema = this.repository.FindById(id);
            if (cinema == null)
            {
                throw new NotFoundException($"None of the cinemas has the ID {id}");
            }
            return cinema;
        }

        /// <summary>
        /// Modify a cinema
        /// </summary>
        /// <param name="id">cinema id </param>
        /// <param name="cinemaUpdated">cinema with new info</param>
        /// <returns>updated cinema info</returns>
        public Cinema UpdateCinema(String id, Cinema cinemaUpdated)
        {
            Cinema cinema = this.repository.UpdateCinema(id, cinemaUpdated);
            return cinema;
        }

        /// <summary>
        /// Delete cinema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Cinema> DeleteCinema(string id)
        {
            List<Cinema> cinemas = this.repository.DeleteCinema(id);
            return cinemas;
        }
    }
}
