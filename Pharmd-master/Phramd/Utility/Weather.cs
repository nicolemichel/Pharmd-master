using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Utility
{
    public class Weather
    {
        public string selCity { get; set; }
        public string selCountry { get; set; }
        public string selUnit { get; set; }
        public string metric = "metric";
        public string imperial = "imperial";
        public string kelvin = "kelvin";
    }
}
