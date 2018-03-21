using System;
using System.Collections.Generic;
using System.Text;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class DivisionAsyncUnitTest
    {
        private IMath _math;

        public DivisionAsyncUnitTest()
        {
            //replace with outsourcced class
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double result = await this._math.DivisionAsync(10.00, 2.00);

            Assert.Equal(5.00, result);
        }

        [Fact]
        public async void ThrowArgumentExpetionIfParamsIsEmpty()
        {            
            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.DivisionAsync());
        }
    }
}
