using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using MovieReviews.Infrastructure.JsonRepository;
using MovieReviewsCompulsory.Core.IServices;
using MovieReviewsCompulsory.Core.Models;
using MovieReviewsCompulsory.Domain.IRepositories;

namespace MovieReviewsCompulsory.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var serviceCollection = new ServiceCollection();
            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //var petService = serviceProvider.GetRequiredService<IReviewService>();
            
            Stopwatch sw = Stopwatch.StartNew();

            IRepository<Review> repo = new MovieRatingJsonRepository(new StreamReader("../../../../Data/ratings.json"));

            sw.Stop();
            System.Console.WriteLine("Time = {0:f4} seconds", sw.ElapsedMilliseconds /1000d);

            System.Console.WriteLine($"\nTotal items: {repo.Items.Length:N0}");

            System.Console.WriteLine("\nFirst 3 ratings:");
            for (int i = 0; i < 3; i++)
            {
                System.Console.WriteLine(repo.Items[i].ToString());
            }

            System.Console.WriteLine("\nLast 3 ratings:");
            for (int i = repo.Items.Length - 3; i < repo.Items.Length; i++)
            {
                System.Console.WriteLine(repo.Items[i].ToString());
            }
        }
    }
}