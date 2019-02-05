using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Phramd.Models
{
    public class NewsDB
    {
        public int id { get; set; }

        [Required]
        public string country { get; set; } // default Canada
        [Required]
        public string articles { get; set; } // default 10
        [Required]
        public string time { get; set; } // default 15
        [Required]
        public string status { get; set; } // default Active (A)

        public int userId { get; set; }
        public User user { get; set; }
    }
}
