using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd
{
    public class CalendarDetails
    {
        public string email { get; set; }
        public int UserID { get; set; }
        public bool isAddUser { get; set; }
        public string Gmail { get; set; }
        public string Apple { get; set; }
        public string Microsoft { get; set; }

    }   
}

