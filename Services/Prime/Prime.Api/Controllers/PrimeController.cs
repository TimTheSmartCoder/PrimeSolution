using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prime.Api.Utils;

namespace Prime.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PrimeController : Controller
    {       
        
        [HttpGet]
        public async Task<IActionResult> IsPrime(long number)
        {           
            var result = await Calculator.CheckIfPrime(number);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CountPrimes(long startNum, long endNum)
        {
            int result = await Calculator.GetPrimes(startNum, endNum);

            return Ok(result);
        }



    }
}