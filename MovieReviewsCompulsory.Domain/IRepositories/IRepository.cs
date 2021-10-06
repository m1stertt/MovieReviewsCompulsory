using System.Collections.Generic;
using MovieReviewsCompulsory.Core.Models;

namespace MovieReviewsCompulsory.Domain.IRepositories
{
    public interface IRepository<T>
    {
        public T[] Items { get;}
        T[] GetAllItems();
    }
}