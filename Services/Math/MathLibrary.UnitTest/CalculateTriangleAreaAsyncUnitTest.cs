using System;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class CalculateTriangleAreaAsyncUnitTest
    {
        private IMath _math;

        public CalculateTriangleAreaAsyncUnitTest()
        {
            // Add Math class here instead of null for unittesting.
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double @base = 5;
            double height = 10;

            double resutl = await this._math.CalculateTriangleAreaAsync(@base, height);

            Assert.Equal(25.00, resutl);
        }

        [Fact]
        public async void ThrowsArgumentExeptionIfHeightIsZero()
        {
            double @base = 5;
            double height = 0;     

            await Assert.ThrowsAsync<ArgumentException>(
                 () => this._math.CalculateTriangleAreaAsync(@base, height));
        }

        [Fact]
        public async void ThrowsArgumentExeptionIfHeightLowerThanZero()
        {
            double @base = 5;
            double height = -1;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateTriangleAreaAsync(@base, height));
        }

        [Fact]
        public async void ThrowsArgumentExeptionIfBaseIsZero()
        {
            double @base = 0;
            double height = 10;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateTriangleAreaAsync(@base, height));
        }

        [Fact]
        public async void ThrowsArgumentExeptionIfBaseLowerThanZero()
        {
            double @base = -1;
            double height = 10;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateTriangleAreaAsync(@base, height));
        }
    }
}
