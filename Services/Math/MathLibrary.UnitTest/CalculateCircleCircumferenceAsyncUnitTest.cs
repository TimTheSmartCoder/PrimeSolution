using System;
using System.Collections.Generic;
using System.Text;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class CalculateCircleCircumferenceAsyncUnitTest
    {
        private IMath _math;

        public CalculateCircleCircumferenceAsyncUnitTest()
        {
            //Replaced with outsourced api
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double radius = 10;

            double result = await this._math.CalculateCircleCircumferenceAsync(radius);

            Assert.Equal(62.83, result);
        }

        [Fact]
        public async void ThrowArgumentExeptionIfRadiusIsZero()
        {
            double radius = 0;
            
            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateCircleCircumferenceAsync(radius));
        }

        [Fact]
        public async void ThrowArgumentExeptionIfRadiusIsLowerThanZero()
        {
            double radius = -1;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateCircleCircumferenceAsync(radius));
        }

    }
}
