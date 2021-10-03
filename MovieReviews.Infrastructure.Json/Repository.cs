using System.Collections.Generic;
using MovieReviewsCompulsory.Core.Models;
using MovieReviewsCompulsory.Domain.IRepositories;

namespace MovieReviews.Infrastructure.JsonRepository
{
    public class Repository : IRepository
    {
        public List<Review> ReadAll()
        {
            throw new System.NotImplementedException();
        }
    }
}