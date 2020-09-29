﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountOwnerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private IRepositoryWrapper _repoWrapper;

        public WeatherForecastController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAccounts = _repoWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owners = _repoWrapper.Owner.FindAll();

            return new string[] { "value1", "value2" };
        }
        //private readonly ILoggerManager _logger;

        //private IRepositoryWrapper _repoWrapper;

        //public ValuesControler(IRepositoryWrapper repoWrapper) {
        //    _repoWrapper = repoWrapper;
        //}

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        ////private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILoggerManager logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<String> Get() {
        //    _logger.LogInfo("Here is info message from the controller");
        //    _logger.LogDebug("Here is debug message from the controller");
        //    _logger.LogWarn("Here is a warn message from the controller");
        //    _logger.LogError("Here is a error message from the controller");

        //    return new string[] {"value 1", "value 2" };
        //}

        //[HttpGet]
        //public IEnumerable<String> Get() {
        //    _logger.LogInfo("Here is info message from the controller");
        //    _logger.LogDebug("Here is debug message from the controller");
        //    _logger.LogWarn("Here is a warn message from the controller");
        //    _logger.LogError("Here is a error message from the controller");

        //    return new string[] {"value 1", "value 2" };
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
