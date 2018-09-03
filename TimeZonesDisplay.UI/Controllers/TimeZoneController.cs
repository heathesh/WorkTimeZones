using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TimeZonesDisplay.UI.Interfaces;
using TimeZonesDisplay.UI.Models;

namespace TimeZonesDisplay.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeZoneController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TimeZoneController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("All")]
        public IActionResult All()
        {
            var result = from timeZone in TimeZoneInfo.GetSystemTimeZones()
                select new
                {
                    timeZone.DisplayName,
                    timeZone.BaseUtcOffset
                };

            return Ok(result);
        }

        [HttpGet("Configuration")]
        public IActionResult Configuration()
        {
            return Ok(_configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var timeZones = from timeZone in TimeZoneInfo.GetSystemTimeZones()
                join city in _configuration.Cities on timeZone.DisplayName equals city.TimeZoneName
                select new TimeZoneModel
                {
                    Name = city.Name,
                    TimeZoneName = city.TimeZoneName,
                    CurrentTime = DateTime.UtcNow.Add(timeZone.BaseUtcOffset)
                };

            return Ok(timeZones);
        }
    }
}
