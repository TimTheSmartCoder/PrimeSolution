using System;
using System.Collections.Generic;
using System.Text;
using MathLibary;
using Xunit;

namespace MathLibrary.UnitTest
{
    public class SubtracktionAsyncUnitTest
    {
        private IMath _math;

        public SubtracktionAsyncUnitTest()
        {
            //replace with outsourced class
            this._math = null;
        }

        [Fact]
        public async void ExpectCorrectCalculation()
        {
            double result = await this._math.SubtracktionAsync(10.00, 5.00);

            Assert.Equal(5.00, result);
        }

        [Fact]
        public async void ThrowArguentExeptionIfParamsIsEmpty()
        {
            await Assert.ThrowsAsync<ArgumentException>(
                () => this._math.SubtracktionAsync());
        }
    }
}
