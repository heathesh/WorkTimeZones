using System.Collections.Generic;
using TimeZonesDisplay.UI.Models;

namespace TimeZonesDisplay.UI.Interfaces
{
    public interface IConfiguration
    {
        IEnumerable<CityModel> Cities { get; set; }
    }
}
