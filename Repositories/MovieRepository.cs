using cinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using cinemas.Config;

namespace cinemas.Repositories
{
    public class MovieRepository
    {
        private readonly IMongoCollection<Movie> movies;
        public MovieRepository(ICinemaApiDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            movies = database.GetCollection<Movie>(settings.MovieCollectionName);
        }

        /// <summary>
        /// Creates a movie and adds it to the database
        /// </summary>
        /// <param name="movie">Created movie</param>
        /// <returns>List of all movies</returns>
        public List<Movie> CreateMovie(Movie movie)
        {
            this.movies.InsertOne(movie);
            return this.movies.Find(movie => true).ToList();
        }

        /// <summary>
        /// Returns all movies
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            return this.movies.Find(movie => true).ToList();
        }

        /// <summary>
        /// Returns the movie with the given id
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns></returns>
        public Movie FindById(string id)
        {
            return this.movies.Find(movie => movie.id == id).FirstOrDefault();
        }
    }
}
