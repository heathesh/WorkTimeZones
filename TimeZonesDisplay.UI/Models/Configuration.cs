using System.Collections.Generic;
using TimeZonesDisplay.UI.Interfaces;

namespace TimeZonesDisplay.UI.Models
{
    public class Configuration : IConfiguration
    {
        public IEnumerable<CityModel> Cities { get; set; }
    }
}
