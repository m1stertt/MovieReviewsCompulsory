using Newtonsoft.Json;
using System;
using System.IO;
using MovieReviewsCompulsory.Core.Models;

namespace MovieReviews.Infrastructure.JsonRepository
{
    public class MovieRatingJsonRepository : JsonFileRepository<Review>
    {
        public MovieRatingJsonRepository(TextReader reader) : base(reader)
        {

        }

        public override Review ReadOneItem(JsonTextReader reader)
        {
            reader.Read();
            int r = (int)reader.ReadAsInt32();

            reader.Read();
            int m = (int) reader.ReadAsInt32();

            reader.Read();
            int g = (int) reader.ReadAsInt32();

            reader.Read();
            DateTime d = (DateTime) reader.ReadAsDateTime();

            return new Review(r, m, g, d);
        }
    }
}