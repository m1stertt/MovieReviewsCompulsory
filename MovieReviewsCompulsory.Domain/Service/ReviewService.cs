using System;
using System.Collections.Generic;
using System.Linq;
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
            return reviews.Average(r => r.Grade);
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _repository.ReadAll().FindAll((r) => r.Reviewer == reviewer&&r.Grade==rate).Count;
        }

        public int GetNumberOfReviews(int movie)
        {
            return _repository.ReadAll().FindAll((r) => r.Movie == movie).Count;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            List<Review> reviews=_repository.ReadAll().FindAll((r) => r.Movie == movie);
            return reviews.Average(r => r.Grade);
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return _repository.ReadAll().FindAll((r) => r.Movie == movie&&r.Grade==rate).Count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates() //Not sure exactly what they want here
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