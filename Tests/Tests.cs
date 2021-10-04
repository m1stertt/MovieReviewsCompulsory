using System;
using System.Collections.Generic;
using Moq;
using MovieReviewsCompulsory.Core.IServices;
using MovieReviewsCompulsory.Core.Models;
using MovieReviewsCompulsory.Domain.IRepositories;
using MovieReviewsCompulsory.Domain.Service;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly IReviewService _service;

        public Tests()
        {
            var data = new List<Review>();
            data.Add(new Review
            {
                Reviewer = 1,
                Grade = 2,
                Movie = 1,
                Date = DateTime.Now
            });
            data.Add(new Review
            {
                Reviewer = 1,
                Grade = 4,
                Movie = 2,
                Date = DateTime.Now
            });
            data.Add(new Review
            {
                Reviewer = 2,
                Grade = 5,
                Movie = 1,
                Date = DateTime.Now
            });
            data.Add(new Review
            {
                Reviewer = 3,
                Grade = 3,
                Movie = 2,
                Date = DateTime.Now
            });
            data.Add(new Review
            {
                Reviewer = 3,
                Grade = 3,
                Movie = 3,
                Date = DateTime.Now
            });
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.ReadAll()).Returns(data);
            _service = new ReviewService(mock.Object);
        }

        [Theory]
        [InlineData(1,2)]
        [InlineData(2,1)]
        [InlineData(3,2)]
        public void GetNumberOfReviewsFromReviewer(int reviewer, int expected)
        {
            var actual = _service.GetNumberOfReviewsFromReviewer(reviewer);
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(1,3)]
        [InlineData(2,5)]
        [InlineData(3,3)]
        public void GetAverageRateFromReviewer(int reviewer, double expected)
        {
            var actual = _service.GetAverageRateFromReviewer(reviewer);
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(1,2,1)]
        [InlineData(1,1,0)]
        [InlineData(1,4,1)]
        [InlineData(2,5,1)]
        [InlineData(2,4,0)]
        [InlineData(3,3,2)]
        public void GetNumberOfRatesByReviewer(int reviewer, int rate, int expected)
        {
            var actual = _service.GetNumberOfRatesByReviewer(reviewer,rate);
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(4, 0)]
        public void GetNumberOfReviews(int movie, int expected)
        {
            var actual = _service.GetNumberOfReviews(movie);
            Assert.Equal(expected,actual); 
        }

        [Theory]
        [InlineData(1, 3.5)]
        [InlineData(2, 3.5)]
        [InlineData(3, 3)]
        [InlineData(4, 0)]
        public void GetAverageRateOfMovie(int movie, double expected)
        {
            var actual = _service.GetAverageRateOfMovie(movie);
            Assert.Equal(expected,actual); 
        }

        [Theory]
        [InlineData(1,2,1)]
        [InlineData(1,0,0)]
        public void GetNumberOfRates(int movie, int rate, int expected)
        {
            var actual = _service.GetNumberOfRates(movie,rate);
            Assert.Equal(expected,actual); 
        }
        
        public static IEnumerable<object[]> MoviesWithHighestNumberOfTopRates =>
            new List<object[]>
            {
                new object[]{ new List<int>{1} }
            };
        
        [Theory]
        [MemberData(nameof(MoviesWithHighestNumberOfTopRates))]
        public void GetMoviesWithHighestNumberOfTopRates(List<int> expected)
        {
            var actual = _service.GetMoviesWithHighestNumberOfTopRates();
            Assert.Equal(expected,actual); 
        }
        
        public static IEnumerable<object[]> MostProductiveReviewersData =>
            new List<object[]>
            {
                new object[]{ new List<int>{1,3,2} }
            };
        
        [Theory]
        [MemberData(nameof(MostProductiveReviewersData))]
        public void GetMostProductiveReviewers(List<int> expected)
        {
            var actual = _service.GetMostProductiveReviewers();
            Assert.Equal(expected,actual); 
        }
        
        public static IEnumerable<object[]> TopRatedMoviesData =>
            new List<object[]>
            {
                new object[]{ 3,new List<int>{1,2,3} },
                new object[]{ 1,new List<int>{1} }
            };
        
        [Theory]
        [MemberData(nameof(TopRatedMoviesData))]
        public void GetTopRatedMovies(int amount, List<int> expected)
        {
            var actual = _service.GetTopRatedMovies(amount);
            Assert.Equal(expected,actual); 
        }
        
        public static IEnumerable<object[]> TopMoviesByReviewer =>
            new List<object[]>
            {
                new object[]{ 1,new List<int>{2,1} },
                new object[]{ 2,new List<int>{1} },
                new object[]{ 3,new List<int>{3,2} }
            };
        
        [Theory]
        [MemberData(nameof(TopMoviesByReviewer))]
        public void GetTopMoviesByReviewer(int reviewer, List<int> expected)
        {
            var actual = _service.GetTopMoviesByReviewer(reviewer);
            Assert.Equal(expected,actual); 
        }
        
        public static IEnumerable<object[]> ReviewersByMovie =>
            new List<object[]>
            {
                new object[]{ 1,new List<int>{2,1} },
                new object[]{ 2,new List<int>{1,3} },
                new object[]{ 3,new List<int>{3} }
            };
        
        [Theory]
        [MemberData(nameof(ReviewersByMovie))]
        public void GetReviewersByMovie(int movie, List<int> expected)
        {
            var actual = _service.GetReviewersByMovie(movie);
            Assert.Equal(expected,actual); 
        }
    }
}