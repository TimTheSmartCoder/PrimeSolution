using System;
using System.Collections.Generic;
using System.Text;
using MathLibary;
using Xunit;

namespace MathLibreplacerary.UnitTest
{
    public class MultiplicationAsyncUnitTest
    {
        private IMath _math;

        public MultiplicationAsyncUnitTest()
        {
            //replace with outsourced class
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double result = await this._math.MultiplicationAsync(10.00, 10.00);

            Assert.Equal(100.00, result);
        }

        [Fact]
        public async void ThrowArgumentExeptionIfParamsIsEmpty()
        {           
            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.MultiplicationAsync());
        }
    }
}
