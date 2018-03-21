using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class CalculateTriangleHypotenuseAsyncUnitTest
    {
        private IMath _math;

        public CalculateTriangleHypotenuseAsyncUnitTest()
        {
            //To be replaced with outsourced class
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double leg1 = 5;
            double leg2 = 10;

            double result = await this._math.CalculateTriangleHypotenuseAsync(leg1, leg2);

            Assert.Equal(11.18, result);
        }

        [Fact]
        public async void ThowArgumentExeptionIfLeg1IsZero()
        {
            double leg1 = 0;
            double leg2 = 10;
            
            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateTriangleHypotenuseAsync(leg1, leg2));
        }

        [Fact]
        public async void ThowArgumentExeptionIfLeg1IsLowerThanZero()
        {
            double leg1 = -1;
            double leg2 = 10;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateTriangleHypotenuseAsync(leg1, leg2));
        }

        [Fact]
        public async void ThowArgumentExeptionIfLeg2IsZero()
        {
            double leg1 = 5;
            double leg2 = 0;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateTriangleHypotenuseAsync(leg1, leg2));
        }

        [Fact]
        public async void ThowArgumentExeptionIfLeg2IsLowerThanZero()
        {
            double leg1 = 5;
            double leg2 = -1;

            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.CalculateTriangleHypotenuseAsync(leg1, leg2));
        }


    }
}
