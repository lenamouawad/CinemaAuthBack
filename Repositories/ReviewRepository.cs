using cinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using cinemas.Config;
using cinemas.DTO;

namespace cinemas.Repositories
{
    public class ReviewRepository
    {
        private readonly IMongoCollection<Review> reviews;
        private MovieRepository movieRepository;
        private LoginRepository loginRepository;

        public ReviewRepository(ICinemaApiDatabaseSettings settings, MovieRepository movieRepository, LoginRepository loginRepository)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            reviews = database.GetCollection<Review>(settings.ReviewCollectionName);

            this.movieRepository = movieRepository;
            this.loginRepository = loginRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public List<ReviewDTO> GetAllReviewsByMovieId(string movieId)
        {
            List<Review> reviews = this.reviews.Find(review => true && review.movieId == movieId).ToList();

            List<ReviewDTO> reviewsInfo = new List<ReviewDTO>();

            for (int i = 0; i < reviews.Count; i++)
            {
                ReviewDTO review = new ReviewDTO();
                review.username = this.loginRepository.FindById(reviews[i].userId).Username;
                review.reviewText = reviews[i].reviewText;

                reviewsInfo.Add(review);
            }
            return reviewsInfo;
        }

        public ReviewDTO CreateReview(Review review)
        {
            ReviewDTO reviewDTO = new ReviewDTO();

            this.reviews.InsertOne(review);

            reviewDTO.username = this.loginRepository.FindById(review.userId).Username;
            reviewDTO.reviewText = review.reviewText;

            return reviewDTO;
        }


        public List<Review> DeleteAllReviews()
        {
            this.reviews.DeleteMany(review => true);
            return this.reviews.Find(review => true).ToList();
        }

    }
}
