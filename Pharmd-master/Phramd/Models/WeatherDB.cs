using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Phramd.Models
{
    public class WeatherDB
    {
        public int id { get; set; }

        [Required]
        public string country { get; set; } // default Canada
        [Required]
        public string city { get; set; } // London
        [Required]
        public string unit { get; set; } // Metric
        [Required]
        public string status { get; set; } // default Active (A)

        public int userId { get; set; }
        public User user { get; set; }

    }
}
