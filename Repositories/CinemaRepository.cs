using cinemas.Config;
using cinemas.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Repositories
{
    public class CinemaRepository
    {
        private readonly IMongoCollection<Cinema> cinemas;
        private RoomRepository roomRepository;

        public CinemaRepository(ICinemaApiDatabaseSettings settings, RoomRepository roomRepository)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            cinemas = database.GetCollection<Cinema>(settings.CinemaCollectionName);

            this.roomRepository = roomRepository;
        }

        /// <summary>
        /// Creates a cinema and adds it to the database
        /// </summary>
        /// <param name="cinema">Created cinema</param>
        /// <returns>List of all cinemas</returns>
        public List<Cinema> CreateCinema(Cinema cinema)
        {
            this.cinemas.InsertOne(cinema);
            return this.cinemas.Find(cinema => true).ToList();
        }

        /// <summary>
        /// Returns all cinemas
        /// </summary>
        /// <returns></returns>
        public List<Cinema> GetAllCinemas()
        {
            List <Cinema> cinemas = this.cinemas.Find(cinema => true).ToList();
            
            // A voir si ca pose probleme quand j'ai plusieurs cinemas (cinemaroos adds to previous cinema or no?)
            for (int i = 0; i < cinemas.Count; i++)
            {
                List<Room> cinemarooms = new List<Room>();

                for (int j =0; j < cinemas[i].roomId.Count; j++)
                {
                    cinemarooms.Add(this.roomRepository.FindById(cinemas[i].roomId[j]));
                }
                cinemas[i].rooms = cinemarooms;
            }
            return cinemas;

        }

        /// <summary>
        /// Returns the cinema with the given id
        /// </summary>
        /// <param name="id">Id of the cinema</param>
        /// <returns></returns>
        public Cinema FindById(string id)
        {
            return this.cinemas.Find(cinema => cinema.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Modify a cinema
        /// </summary>
        /// <param name="id">cinema id </param>
        /// <param name="cinemaUpdated">cinema with new info</param>
        /// <returns>updated cinema info</returns>
        public Cinema UpdateCinema(String id, Cinema cinemaUpdated)
        {
            cinemaUpdated.id = id;
            this.cinemas.FindOneAndReplace(cinema => cinema.id == id, cinemaUpdated);
            return this.cinemas.Find(cinema => cinema.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Delete Cinema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Cinema> DeleteCinema(string id)
        {
            this.cinemas.DeleteOne(cinema => cinema.id == id);
            return this.cinemas.Find(cinema => true).ToList();
        }

    }
}
