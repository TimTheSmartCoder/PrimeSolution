using System;
using System.Collections.Generic;
using System.Text;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class CalculateCircleAreaAsyncUnitTest
    {
        private IMath _math;

        public CalculateCircleAreaAsyncUnitTest()
        {
            //replaced by outsorced class
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalcualtion()
        {
            double radius = 10;

            double result = await this._math.CalculateCircleAreaAsync(radius);

            Assert.Equal(314.16, result);
        }

        [Fact]
        public async void ThrowArgumentExeptionIfRadiusIsZero()
        {
            double radius = 0;
            
            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateCircleAreaAsync(radius));
        }

        [Fact]
        public async void ThrowArgumentExeptionIfRadiusIsLowerThanZero()
        {
            double radius = -1;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateCircleAreaAsync(radius));
        }
    }
}
