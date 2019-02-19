using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phramd.Utility
{
    public class DateFormats
    {
        // s = short, n = number
        // DATE
        // day options (number of the month)
        public string selDay { get; set; }
        public string sDay = DateTime.Now.ToString("d"); // number
        public string day = DateTime.Now.ToString("dd"); // number starting with 0
        // date options (day of week - ie. Friday)
        public string selDate { get; set; }
        public string sDate = DateTime.Now.ToString("ddd"); // abbreviated day of week
        public string date = DateTime.Now.ToString("dddd"); // day of week
        // month options
        public string selMonth { get; set; }
        public string snMonth = DateTime.Now.ToString("M"); // Month #
        public string nMonth = DateTime.Now.ToString("MM"); // Month # starting with 0
        public string sMonth = DateTime.Now.ToString("MMM"); // abbreviated month
        public string month = DateTime.Now.ToString("MMMM");
        // year options
        public string selYear { get; set; }
        public string sYear = DateTime.Now.ToString("y"); // 19
        // 019 looks stupid not an option
        public string year = DateTime.Now.ToString("yyyy"); // 2019

        // TIME
        // hour options
        public string selHour { get; set; }
        //public string sHour = DateTime.Now.ToString("h"); // 12hr
        public string hour = DateTime.Now.ToString("hh"); // 12hr starting with 0 (06:00)
        //public string military = DateTime.Now.ToString("H"); // 24hr
        // not giving a military starting with 0 option (looks stupid)
        // minutes - don't want to give the option to have 8:5 AM (looks stupid)
        public string selMin { get; set; }
        public string minutes = DateTime.Now.ToString("mm");
        // seconds
        // not giving the no 0 option (looks stupid)
        public string selSec { get; set; }
        public string seconds = DateTime.Now.ToString("ss");
        // time options
        public string selTime { get; set; }
        public string sTime = DateTime.Now.ToString("t"); // A/P
        public string time = DateTime.Now.ToString("tt"); // normal am/pm
    }
}