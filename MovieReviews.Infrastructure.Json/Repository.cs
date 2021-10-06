using System.Collections.Generic;
using System.Linq;
using MovieReviewsCompulsory.Core.Models;
using MovieReviewsCompulsory.Domain.IRepositories;

namespace MovieReviews.Infrastructure.JsonRepository
{
    public class Repository : IRepository<Review>
    {

        public Review[] Items { get; }
        public Review[] GetAllItems()
        {
            throw new System.NotImplementedException();
        }
    }
}