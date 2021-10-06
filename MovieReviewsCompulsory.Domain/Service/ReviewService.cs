using System.Collections.Generic;
using System.Linq;
using MovieReviewsCompulsory.Core.IServices;
using MovieReviewsCompulsory.Core.Models;
using MovieReviewsCompulsory.Domain.IRepositories;

namespace MovieReviewsCompulsory.Domain.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;

        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }
        
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _repository.GetAllItems().ToList().FindAll((r) => r.Reviewer == reviewer).Count;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            List<Review> reviews=_repository.GetAllItems().ToList().FindAll((r) => r.Reviewer == reviewer);
            if (reviews.Count == 0) return 0;
            return reviews.Average(r => r.Grade);
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _repository.GetAllItems().ToList().FindAll((r) => r.Reviewer == reviewer&&r.Grade==rate).Count;
        }

        public int GetNumberOfReviews(int movie)
        {
            return _repository.GetAllItems().ToList().FindAll((r) => r.Movie == movie).Count;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            List<Review> reviews=_repository.GetAllItems().ToList().FindAll((r) => r.Movie == movie);
            if (reviews.Count == 0) return 0;
            return reviews.Average(r => r.Grade);
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return _repository.GetAllItems().ToList().FindAll((r) => r.Movie == movie&&r.Grade==rate).Count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return _repository.
                GetAllItems().ToList().
                FindAll(r=>(r.Grade==5)).
                GroupBy(r=>r.Movie).
                Select(r=>new {movie=r.Key,toprates=r.Count()}).
                OrderByDescending(r=>r.toprates).
                Select(r=>r.movie).
                Distinct().
                ToList();
        }

        public List<int> GetMostProductiveReviewers()
        {
            return _repository.
                GetAllItems().ToList().
                GroupBy(r =>r.Reviewer).
                Select(r=>new {reviewer=r.Key,reviews=r.Count()}).
                OrderByDescending(r=>r.reviews).
                Select(r=>r.reviewer).
                Distinct().
                ToList();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return _repository.
                GetAllItems().ToList().
                GroupBy(r =>r.Movie).
                Select(r=>new {Movie=r.Key,avg=r.Average(rr=>rr.Grade)}).
                OrderByDescending(r=>r.avg).
                Select(r=>r.Movie).
                Take(amount).
                Distinct().
                ToList();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _repository.
                GetAllItems().ToList().
                FindAll((r) => r.Reviewer == reviewer).
                OrderByDescending(r=>r.Grade).
                ThenByDescending(r=>r.Date).
                Select(r=>r.Movie).
                ToList();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return _repository.
                GetAllItems().ToList().
                FindAll((r) => r.Movie == movie).
                OrderByDescending(r=>r.Grade).
                ThenByDescending(r=>r.Date).
                Select(c=>c.Reviewer).
                ToList();
        }
    }
}