using cinemas.DTO;
using cinemas.Exceptions;
using cinemas.Models;
using cinemas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemas.Services
{
    public class ReviewService
    {
        private ReviewRepository repository;
        private LoginRepository loginRepo;
        public ReviewService(ReviewRepository repository, LoginRepository loginRepo)
        {
            this.repository = repository;
            this.loginRepo = loginRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public List<ReviewDTO> GetAllReviewsByMovieId(string movieId)
        {
            return this.repository.GetAllReviewsByMovieId(movieId);
        }


        public ReviewDTO CreateReview(Review review)
        {
            return this.repository.CreateReview(review);
        }

        public ReviewDTO CreateReview(ReviewDTO2 reviewInfo)
        {
            string userId = this.loginRepo.FindUserByUsername(reviewInfo.username).Id;
            Review review = new Review();
            review.movieId = reviewInfo.movieId;
            review.userId = userId;
            review.reviewText = reviewInfo.reviewText;

            return this.repository.CreateReview(review);
        }

        public List<Review> DeleteAllReviews()
        {
            return this.repository.DeleteAllReviews();
        }

    }
}
