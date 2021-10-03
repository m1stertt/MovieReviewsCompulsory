using System;
using Microsoft.Extensions.DependencyInjection;
using MovieReviewsCompulsory.Core.IServices;

namespace MovieReviewsCompulsory.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IReviewService>();
        }
    }
}