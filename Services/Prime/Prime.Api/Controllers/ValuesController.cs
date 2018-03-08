using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prime.Api.Utils;

namespace Prime.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }

      

        [HttpGet]
        public string IsPrime(long number)
        {
            return "prime";
        }
    }
}
