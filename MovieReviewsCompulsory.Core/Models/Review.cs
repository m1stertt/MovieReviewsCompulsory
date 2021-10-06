using System;
using MovieReviewsCompulsory.Core.IServices;

namespace MovieReviewsCompulsory.Core.Models
{
    public class Review
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public Review(int r,int m, int g,DateTime d)
        {
            Reviewer = r;
            Movie = m;
            Grade = g;
            Date = d;
        }
        public override string ToString()
        {
            return $"Reviewer: {Reviewer,8}, Movie: {Movie,8}, Grade: {Grade}, Date: {Date}";
        }
    }
}