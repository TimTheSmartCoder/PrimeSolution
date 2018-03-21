using System;
using System.Collections.Generic;
using System.Text;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class CalculateTriangleCircumferenceAsyncUnitTest
    {
        private IMath _math;

        public CalculateTriangleCircumferenceAsyncUnitTest()
        {
            // Add Math class here instead of null for unittesting.
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double sideA = 10;
            double sideB = 10;
            double sideC = 10;

            double result = await this._math.CalculateTriangleCircumferenceAsync(sideA, sideB, sideC);

            Assert.Equal(30.00, result);
        }

        [Fact]
        public async void ThrowArgumentExeptionIfSideAIsZero()
        {
            double sideA = 0;
            double sideB = 10;
            double sideC = 10;

            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._math.CalculateTriangleCircumferenceAsync(sideA, sideB, sideC));
        }

        [Fact]
        public async void ThrowArgumentExeptionIfSideAIsLowerThanZero()
        {
            double sideA = -1;
            double sideB = 10;
            double sideC = 10;

            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._math.CalculateTriangleCircumferenceAsync(sideA, sideB, sideC));
        }

        [Fact]
        public async void ThrowArgumentExeptionIfSideBIsZero()
        {
            double sideA = 10;
            double sideB = 0;
            double sideC = 10;

            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._math.CalculateTriangleCircumferenceAsync(sideA, sideB, sideC));
        }

        [Fact]
        public async void ThrowArgumentExeptionIfSideBIsLowerThanZero()
        {
            double sideA = 10;
            double sideB = -1;
            double sideC = 10;

            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._math.CalculateTriangleCircumferenceAsync(sideA, sideB, sideC));
        }

        [Fact]
        public async void ThrowArgumentExeptionIfSideCIsZero()
        {
            double sideA = 10;
            double sideB = 10;
            double sideC = 0;

            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._math.CalculateTriangleCircumferenceAsync(sideA, sideB, sideC));
        }

        [Fact]
        public async void ThrowArgumentExeptionIfSideCIsLowerThanZero()
        {
            double sideA = 10;
            double sideB = 10;
            double sideC = -1;

            await Assert.ThrowsAsync<ArgumentException>(() =>
                this._math.CalculateTriangleCircumferenceAsync(sideA, sideB, sideC));
        }
    }
}
