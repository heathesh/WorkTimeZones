using System;

namespace TimeZonesDisplay.UI.Models
{
    public class TimeZoneModel
    {
        public string Name { get; set; }

        public string TimeZoneName { get; set; }

        public DateTime CurrentTime { get; set; }

        public string DisplayDate => CurrentTime.ToString("dd MMM yyyy");

        public string DisplayTime => CurrentTime.ToString("HH:mm");

        public string DisplayStyle { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}

