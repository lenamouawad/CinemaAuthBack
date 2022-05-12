using cinemas.Config;
using cinemas.DTO;
using cinemas.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cinemas.Repositories
{
    public class ScreeningRepository
    {
        private readonly IMongoCollection<Screening> screenings;
        private MovieRepository movieRepository;
        private RoomRepository roomRepository;
        private CinemaRepository cinemaRepository;
        public ScreeningRepository(ICinemaApiDatabaseSettings settings, MovieRepository movieRepository, RoomRepository roomRepository, CinemaRepository cinemaRepository)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            screenings = database.GetCollection<Screening>(settings.ScreeningCollectionName);

            this.movieRepository = movieRepository;
            this.roomRepository = roomRepository;
            this.cinemaRepository = cinemaRepository;
        }

        /// <summary>
        /// Creates a screening and adds it to the database
        /// </summary>
        /// <param name="screening">Created screening</param>
        /// <returns>List of all screenings</returns>
        public List<Screening> CreateScreening(Screening screening)
        {
            this.screenings.InsertOne(screening);
            screening.movie = this.movieRepository.FindById(screening.movieId);
            screening.room = this.roomRepository.FindById(screening.roomId);
            screening.cinema = this.cinemaRepository.FindById(screening.cinemaId);
            return this.screenings.Find(screening => true).ToList();
        }

        /// <summary>
        /// Returns all screenings
        /// </summary>
        /// <returns></returns>
        public List<Screening> GetAllScreenings()
        {          
            List<Screening> screenings = this.screenings.Find(screening => true).ToList();

            for (int i = 0; i < screenings.Count; i++)
            {
               /* Movie movie = new Movie();
                Room room = new Room();
                Cinema cinema = new Cinema();*/

                screenings[i].movie = this.movieRepository.FindById(screenings[i].movieId);
                screenings[i].room = this.roomRepository.FindById(screenings[i].roomId);
                screenings[i].cinema = this.cinemaRepository.FindById(screenings[i].cinemaId);
            }

            return screenings;
        }

        /// <summary>
        /// Returns the screening with the given id
        /// </summary>
        /// <param name="id">Id of the screening</param>
        /// <returns></returns>
        public Screening FindById(string id)
        {
            return this.screenings.Find(screening => screening.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Modify a screening
        /// </summary>
        /// <param name="id">screening id </param>
        /// <param name="screeningUpdated">screening with new info</param>
        /// <returns>updated screening info</returns>
        public Screening UpdateScreening(String id, Screening screeningUpdated)
        {
            screeningUpdated.id = id;
            this.screenings.FindOneAndReplace(screening => screening.id == id, screeningUpdated);
            return this.screenings.Find(screening => screening.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns only the useful information of all screenings
        /// </summary>
        /// <returns></returns>
        public List<ScreeningDTO> GetScreeningInfo()
        {
            List<Screening> screenings = GetAllScreenings();
            List<ScreeningDTO> screeningsInfo = new List<ScreeningDTO>();

            for (int i = 0; i < screenings.Count; i++)
            {
                ScreeningDTO screeningInfo = screenings[i];
                screeningsInfo.Add(screeningInfo);
            }

            return screeningsInfo;
        }

        /// <summary>
        /// Returns screenings of a movie in a particular cinenma
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="cinemaId"></param>
        /// <returns></returns>
        public List<ScreeningDTO> GetScreeningsByMovieByCinema(String movieId, String cinemaId)
        {
            List<Screening> screenings = this.screenings.Find(screening => true && screening.movieId == movieId && screening.cinemaId == cinemaId).ToList();
            List<ScreeningDTO> screeningsInfo = new List<ScreeningDTO>();

            for (int i = 0; i < screenings.Count; i++)
            {
                screenings[i].movie = this.movieRepository.FindById(screenings[i].movieId);
                screenings[i].room = this.roomRepository.FindById(screenings[i].roomId);
                screenings[i].cinema = this.cinemaRepository.FindById(screenings[i].cinemaId);

                ScreeningDTO screeningInfo = screenings[i];
                screeningsInfo.Add(screeningInfo);
            }
            
            return screeningsInfo;
        }

        /// <summary>
        /// Returns movies in a particular cinenma
        /// </summary>
        /// <param name="cinemaId"></param>
        /// <returns></returns>
        public List<Movie> GetMoviesByCinemaId(String cinemaId)
        {
            List<Screening> screenings = this.screenings.Find(screening => true && screening.cinemaId == cinemaId).ToList();
            List<String> moviesId = screenings.Select(screening => screening.movieId).Distinct().ToList();
            List<Movie> movies = new List<Movie>();

            for (int i = 0; i < moviesId.Count; i++)
            {
                movies.Add(movieRepository.FindById(moviesId[i]));
            }

            return movies;
        }

        /// <summary>
        /// Find screening DTO from the screening Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ScreeningDTO FindDTOById(string id)
        {
           // ScreeningDTO screeningdto = new ScreeningDTO();
            Screening screening =  this.screenings.Find(screening => true && screening.id == id).FirstOrDefault();
            screening.movie = this.movieRepository.FindById(screening.movieId);
            screening.room = this.roomRepository.FindById(screening.roomId);
            screening.cinema = this.cinemaRepository.FindById(screening.cinemaId);
            ScreeningDTO screeningdto = screening;
            return screeningdto;
        }
    }
}
