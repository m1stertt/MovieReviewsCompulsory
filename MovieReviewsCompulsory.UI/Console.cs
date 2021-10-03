using MovieReviewsCompulsory.Core.IServices;
using MovieReviewsCompulsory.Domain.IRepositories;

namespace MovieReviewsCompulsory.UI
{
    public class Console
    {

        private IReviewService _reviewService;
        public Console(IReviewService reviewService)
        {
            this._reviewService = reviewService;
        }
    }
}