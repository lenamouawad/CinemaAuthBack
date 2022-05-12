using cinemas.DTO;
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
    public class ScreeningService
    {
        private ScreeningRepository repository;
        public ScreeningService(ScreeningRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates a screening
        /// </summary>
        /// <param name="screening">Screening to create</param>
        /// <returns>List of all screenings</returns>
        public List<Screening> CreateScreening(Screening screening)
        {
            return this.repository.CreateScreening(screening);
        }


        public List<Screening> GetAllScreenings()
        {
            return this.repository.GetAllScreenings();

        }

        /// <summary>
        /// Returns the screening with the given id
        /// </summary>
        /// <param name="id">screening id</param>
        /// <returns></returns>
        public Screening FindById(string id)
        {
            Screening screening = this.repository.FindById(id);
            if (screening == null)
            {
                throw new NotFoundException($"None of the screenings has the ID {id}");
            }
            return screening;
        }

        
        /// <summary>
        /// Returns the screening with the given id
        /// </summary>
        /// <param name="id">screening id</param>
        /// <returns></returns>
        public ScreeningDTO FindDTOById(string id)
        {
            Screening screening = this.repository.FindById(id);
            if (screening == null)
            {
                throw new NotFoundException($"None of the screenings has the ID {id}");
            }
            return this.repository.FindDTOById(id);
        }

        /// <summary>
        /// Modify a screening
        /// </summary>
        /// <param name="id">screening id </param>
        /// <param name="screeningUpdated">screening with new info</param>
        /// <returns>updated screening info</returns>
        public Screening UpdateScreening(String id, Screening screeningUpdated)
        {
            Screening screening = this.repository.UpdateScreening(id, screeningUpdated);
            return screening;
        }

        /// <summary>
        /// Returns only the useful information of all screenings
        /// </summary>
        /// <returns></returns>
        public List<ScreeningDTO> GetScreeningInfo()
        {           
            return this.repository.GetScreeningInfo();
        }

        /// <summary>
        /// Returns screenings of a movie in a particular cinenma
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="cinemaId"></param>
        /// <returns></returns>
        public List<ScreeningDTO> GetScreeningsByMovieByCinema(String movieId, String cinemaId)
        {         
            return this.repository.GetScreeningsByMovieByCinema(movieId, cinemaId);
        }

        /// <summary>
        /// Returns all screenings in a particular cinenma
        /// </summary>
        /// <param name="cinemaId"></param>
        /// <returns></returns>
        public List<Movie> GetMoviesByCinemaId(String cinemaId)
        {
            return this.repository.GetMoviesByCinemaId(cinemaId);
        }


    }
}
