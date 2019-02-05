using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Phramd;
using Phramd.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phramd
{
    public class Program
    {
        public static UserDetails UserDetails = new UserDetails();
        public static Calendar Calendar = new Calendar();
        public static CalendarDetails CalendarDetails = new CalendarDetails();
        public static Fetch Fetch = new Fetch();
        public static GooglePhotos.PhotoDetails PhotoDetails = new GooglePhotos.PhotoDetails();
        public static Weather Weather = new Weather();
        public static WeatherData WeatherData = new WeatherData();
        public static News News = new News();
        public static NewsData NewsData = new NewsData();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

