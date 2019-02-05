using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Models
{
    public class PhotoAccounts
    {
        public int id { get; set; }

        [MaxLength(100)]
        public string gmail { get; set; }

        [MaxLength(100)]
        public string apple { get; set; }

        [MaxLength(100)]
        public string microsoft { get; set; }

        [Required]
        public DateTime emailadded { get; set; }

        public DateTime emailremoved { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
