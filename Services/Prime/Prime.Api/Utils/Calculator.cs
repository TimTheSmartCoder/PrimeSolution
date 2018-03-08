using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prime.Api.Utils
{
    public class Calculator
    {
        public static async Task<bool> CheckIfPrime(long number)
        {
            return await IsPrime(number);
        }

        private static Task<bool> IsPrime(long number)
        {
            long i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return Task.FromResult(false);
                }
            }
            if (i == number)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public static async Task<int> GetPrimes(long startNumber, long endNumber)
        {
            return await CalcPrimes(startNumber, endNumber);
        }

        private static Task<int> CalcPrimes(long startNumber, long endNumber)
        {
            int primeAmount = 0;

            for (var num = startNumber; num <= endNumber; num++)
            {
                var ctr = 0;

                for (var i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        ctr++;
                        break;
                    }
                }

                if (ctr == 0 && num != 1)
                    primeAmount++;
            }

            return Task.FromResult(primeAmount);
        }
    }
}
