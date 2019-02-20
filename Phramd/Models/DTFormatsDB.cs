using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phramd.Models
{
    public class DTFormatsDB
    {
        public int id { get; set; }

        public string Day { get; set; } // default "dd" (number starting with 0)
        public string Date { get; set; } // default "ddd" abbreviated day of week
        public string Month { get; set; } // default "MMMM" full month
        public string Year { get; set; } // default "yyyy" full year

        public string Hour { get; set; } // default "hh" 12hr starting with 0
        public string Minutes { get; set; } // default only mm option
        public string Seconds { get; set; } // default only ss option
        public string Time { get; set; } // default "tt" AM

        public int userId { get; set; }
        public User user { get; set; }
    }
}