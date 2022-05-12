using cinemas.Exceptions;
using cinemas.Models;
using cinemas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Services
{
    public class MovieService
    {
        private MovieRepository repository;
        public MovieService (MovieRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates a movie
        /// </summary>
        /// <param name="movie">Movie to create</param>
        /// <returns>List of all movies</returns>
        public List<Movie> CreateMovie(Movie movie)
        {
            return this.repository.CreateMovie(movie);
        }

        
        public List<Movie> GetAllMovies()
        {
            return this.repository.GetAllMovies();

        }

        /// <summary>
        /// Returns the movie with the given id
        /// </summary>
        /// <param name="id">movie id</param>
        /// <returns></returns>
        public Movie FindById(string id)
        {
            Movie movie = this.repository.FindById(id);
            if (movie == null)
            {
                throw new NotFoundException($"None of the movies has the ID {id}");
            }
            return movie;
        }

    }
}
