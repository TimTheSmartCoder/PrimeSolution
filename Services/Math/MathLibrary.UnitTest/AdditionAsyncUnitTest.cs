using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class AdditionAsyncUnitTest
    {
        private IMath _math;

        public AdditionAsyncUnitTest()
        {
            //Replace with outsourced class
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double result = await this._math.AdditionAsync(10.00, 11.00, 12.00);

            Assert.Equal(33.00, result);
        }

        [Fact]
        public async void ThrowArgumentExeptionIfParamsIsEmpty()
        {          
            await Assert.ThrowsAnyAsync<ArgumentException>(
                () => this._math.AdditionAsync());
        }
    }
}
