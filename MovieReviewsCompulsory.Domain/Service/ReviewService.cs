using System.Collections.Generic;
using MovieReviewsCompulsory.Core.IServices;
using MovieReviewsCompulsory.Core.Models;
using MovieReviewsCompulsory.Domain.IRepositories;

namespace MovieReviewsCompulsory.Domain.Service
{
    public class ReviewService : IReviewService
    {
        
        private readonly IRepository _repository;

        public ReviewService(IRepository repository)
        {
            _repository = repository;
        }
        
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<Review> reviews=_repository.ReadAll();
            return reviews.FindAll((r) => r.Reviewer == reviewer).Count;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            List<Review> reviews=_repository.ReadAll().FindAll((r) => r.Reviewer == reviewer);
            double count = 0;
            foreach (Review rev in reviews)
            {
                count += rev.Grade;
            }
            return count / reviews.Count;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new System.NotImplementedException();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new System.NotImplementedException();
        }
    }
}