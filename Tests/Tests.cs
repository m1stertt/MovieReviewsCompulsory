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
        private Mock<IRepository> _mock;

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
            _mock = new Mock<IRepository>();
            _mock.Setup(x => x.ReadAll()).Returns(data);
        }

        [Theory]
        [InlineData(1,2)]
        [InlineData(2,1)]
        [InlineData(3,2)]
        public void GetNumberOfReviewsFromReviewer(int reviewer, int expected)
        {
            var service = new ReviewService(_mock.Object);
            var actual = service.GetNumberOfReviewsFromReviewer(reviewer);
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(1,3)]
        [InlineData(2,5)]
        [InlineData(3,3)]
        public void GetAverageRateFromReviewer(int reviewer, double expected)
        {
            var service = new ReviewService(_mock.Object);
            var actual = service.GetAverageRateFromReviewer(reviewer);
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
            var service = new ReviewService(_mock.Object);
            var actual = service.GetNumberOfRatesByReviewer(reviewer,rate);
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(4, 0)]
        public void GetNumberOfReviews(int movie, int expected)
        {
            var service = new ReviewService(_mock.Object);
            var actual = service.GetNumberOfReviews(movie);
            Assert.Equal(expected,actual); 
        }
    }
}