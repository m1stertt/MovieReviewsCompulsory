using System;
using Moq;
using MovieReviewsCompulsory.Core.IServices;
using Xunit;

namespace Tests
{
    public class Tests
    {
        public Mock<IReviewService> mock = new Mock<IReviewService>();
        
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}