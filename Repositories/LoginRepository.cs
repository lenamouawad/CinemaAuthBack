using cinemas.Config;
using cinemas.DTO;
using cinemas.Models;
using MongoDB.Driver;

namespace cinemas.Repositories
{
    public class LoginRepository
    {

        private readonly IMongoCollection<Login> users;
        private MovieRepository movieRepository;
        private RoomRepository roomRepository;
        private CinemaRepository cinemaRepository;
        public LoginRepository(ICinemaApiDatabaseSettings settings, MovieRepository movieRepository, RoomRepository roomRepository, CinemaRepository cinemaRepository)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            users = database.GetCollection<Login>(settings.LoginCollectionName);

            this.movieRepository = movieRepository;
            this.roomRepository = roomRepository;
            this.cinemaRepository = cinemaRepository;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">user Id</param>
        /// <returns></returns>
        public Login FindById(string id)
        {
            return this.users.Find(user => user.Id == id).FirstOrDefault();
        }

        public Login FindUserByUsername(string username)
        {
            return this.users.Find(user => user.Username == username).FirstOrDefault();
        }

        public Login FindUser(Login user)
        {
            return this.users.Find(utilisateur => utilisateur.Username == user.Username && utilisateur.Password == user.Password).FirstOrDefault();
        }

        public List<Login> CreateUser(Login login)
        {
            this.users.InsertOne(login);
            return this.users.Find(login => true).ToList();
        }

        public List<Login> GetAllUsers()
        {
            return this.users.Find(login => true).ToList();
        }

        public List<Login> DeleteUser(string id)
        {
            this.users.DeleteOne(user => user.Id == id);
            return this.users.Find(user => true).ToList();
        }

        public List<Login> DeleteAllUsers()
        {
            this.users.DeleteMany(user => true);
            return this.users.Find(user => true).ToList();
        }
    }
}
