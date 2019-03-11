using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Phramd.Pages
{
    public class IndexModel : PageModel
    {
        JsonNinja jNinja;
        JsonNinja listNinja;
        public string display = "grid";
        public List<string> filter = new List<string>();
        // r = remember
        public List<string> rDT = new List<string>();
        public List<string> rNews = new List<string>();
        public List<string> rWeather = new List<string>();

        // DATE TIME \\
        // Coming from DATEFORMATS Class
        // s = short, n = number
        // date options (day of week - ie. Friday)
        public string selDate;
        public string sDate = Program.DateFormats.sDate; // abbreviated day of week
        public string date = Program.DateFormats.date; // day of week
        // day options (number of the month)
        public string selDay;
        public string sDay = Program.DateFormats.sDay; // number
        public string day = Program.DateFormats.day; // number starting with 0
        // month options
        public string selMonth;
        public string snMonth = Program.DateFormats.snMonth; // Month #
        public string nMonth = Program.DateFormats.nMonth; // Month # starting with 0
        public string sMonth = Program.DateFormats.sMonth; // abbreviated month
        public string month = Program.DateFormats.month;
        // year options
        public string selYear;
        public string sYear = Program.DateFormats.sYear; // 19
        public string year = Program.DateFormats.year; // 2019
        // time options
        public string selAP;
        public string sTime = Program.DateFormats.sTime; // A/P
        public string time = Program.DateFormats.time; // normal am/pm
        // hour options
        public string selHour;
        public string sHour = Program.DateFormats.sHour; // 12hr
        public string hour = Program.DateFormats.hour; // 12hr starting with 0 (06:00)
        public string military = Program.DateFormats.military; // 24hr
        // minutes
        public string selMin = Program.DateFormats.selMin;
        public string minutes = Program.DateFormats.minutes;
        // seconds
        public string selSec;
        public string seconds = Program.DateFormats.seconds;

        
        // WEATHER \\
        // location
        // Coming from Weather Class
        public string selCity;
        public string selCountry;
        public string selUnit;
        public string metric;
        public string imperial;
        public string kelvin;

        // Coming from WeatherData Class
        // weather
        public List<string> weather = new List<string>();
        public string wetId; // weather condition id
        // pull icons based off these ???? switch statement (probably better to just use the icon # that gets pulled in)
        public List<string> wetMain; // weather parameter ie. rain
        public string desc; // condition in group (light/hevy/thunderstorm)
        public List<string> dayIcon; // weather icon of day
        public string icon;
        public string iconShow;
        // main
        public string temp;
        public string tempHigh;
        public string tempLow;
        public string humidity;
        public string pressure;
        public string visibility;
        // wind
        public List<string> wind = new List<string>();
        public string windSpeed;
        public string windDir; // in degrees - set up if statement to get N/E/S/W
        public string windText;
        // length of day
        public string sunrise;
        public string riseTime;
        public string sunset;
        public string setTime;
        // clouds
        public List<string> clouds = new List<string>(); // cloudiness
        public string all;

        // 5 day - convert to lists (new Ninja?)

        // CALENDAR
        public string calendar = "";
        //events
        //people/colours

        // NEWS
        public string selCoun;
        public string numOfArticles;
        public string headline;
        public List<string> headlines;
        public List<string> headlineList;
        public string channel;
        public List<string> channels;
        public List<string> channelList;
        public string published;
        public List<string> publishDates;
        public List<string> publishedList;
        public DateTime publishedDate;
        public string selTime;
       

        public void OnGet()
        {
            Program.UserDetails.isAddUser = true;
            Program.Calendar.isAddCalendar = true;
        }

        public void OnPostLogin(string username, string password)
        {
            Program.UserDetails.CheckID(username, password);
            Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
            Program.UserDetails.PhotoChanges(Program.UserDetails.UserID);
            // Bring back DateTime, Weather and News
            // How?
            if (Program.WeatherData != null)
            {
                WeatherChanges(@Program.UserDetails.UserID);

            }
           if (Program.NewsData != null)
            {
                NewsChanges(@Program.UserDetails.UserID);

            }
           if (Program.DateFormats != null)
            {
                DTChanges(@Program.UserDetails.UserID); 
                
            }
        }

        public void OnPostLogout()
        {
            Program.UserDetails.UserID = 0;
            Program.DateFormats.selDay = null;
            Program.DateFormats.selDate = null;
            Program.DateFormats.selMonth = null;
            Program.DateFormats.selYear = null;
            Program.DateFormats.selHour = null;
            Program.DateFormats.selMin = null;
            Program.DateFormats.selSec = null;
            Program.DateFormats.selAP = null;
            Program.Weather.selCountry = null;
            Program.Weather.selCity = null;
            Program.Weather.selUnit = null;
            Program.News.selCoun = null;
            Program.News.selTime = null;
            Program.News.numOfArticles = null;
        }

        public void OnPostNewUser(string username, string email, string password)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                int userID = 0;
                SqlCommand addUser = new SqlCommand
                {
                    Connection = myConn
                };
                myConn.Open();

                addUser.Parameters.AddWithValue("@username", username);
                addUser.Parameters.AddWithValue("@email", email);
                addUser.Parameters.AddWithValue("@password", password);

                addUser.CommandText = ("[spAddUser]");
                addUser.CommandType = System.Data.CommandType.StoredProcedure;

                var result = addUser.ExecuteScalar();
                if (result != null)
                {
                    userID = Convert.ToInt32(result);
                }
                myConn.Close();
            }
        }

        public void OnPostCalendarGmail(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0 && Program.Calendar.isAddCalendar != false)
                {
                    SqlCommand addCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    addCal.Parameters.AddWithValue("@gmail", email);

                    addCal.CommandText = ("[spAddCalEmailGmail]");
                    addCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = addCal.ExecuteScalar();

                    if (result != null)
                    {
                        email = Program.CalendarDetails.Gmail;
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                        Program.Calendar.CalendarSetUp();
                    }

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarApple(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0 && Program.Calendar.isAddCalendar != false)
                {
                    SqlCommand addCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    addCal.Parameters.AddWithValue("@apple", email);

                    addCal.CommandText = ("[spAddCalEmailApple]");
                    addCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = addCal.ExecuteScalar();

                    if (result != null)
                    {
                        email = Program.CalendarDetails.Apple;
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                    }

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarMicro(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0 && Program.Calendar.isAddCalendar != false)
                {
                    SqlCommand addCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    addCal.Parameters.AddWithValue("@microsoft", email);

                    addCal.CommandText = ("[spAddCalEmailMicro]");
                    addCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = addCal.ExecuteScalar();

                    if (result != null)
                    {
                        email = Program.CalendarDetails.Microsoft;
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                    }

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarRemoveGmail(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    removeCal.Parameters.AddWithValue("@email", Program.UserDetails.emails);

                    removeCal.CommandText = ("[spRemoveCalEmail]");
                    removeCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeCal.ExecuteScalar();

                    if (result == null)
                    {
                        Program.UserDetails.EmailChanges(Program.UserDetails.UserID);
                    }

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarRemoveApple(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    removeCal.Parameters.AddWithValue("@email", Program.UserDetails.emailsA);

                    removeCal.CommandText = ("[spRemoveCalEmail]");
                    removeCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeCal.ExecuteScalar();

                    myConn.Close();
                }
            }
        }

        public void OnPostCalendarRemoveMicro(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeCal = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeCal.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    removeCal.Parameters.AddWithValue("@email", Program.UserDetails.emailsM);

                    removeCal.CommandText = ("[spRemoveCalEmail]");
                    removeCal.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeCal.ExecuteScalar();

                    myConn.Close();
                }
            }
        }

        public void OnPostGooglePhotos(string email)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand addGPhoto = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    addGPhoto.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);
                    addGPhoto.Parameters.AddWithValue("@GPhoto", email);

                    addGPhoto.CommandText = ("[spAddGPhotoAccount]");
                    addGPhoto.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = addGPhoto.ExecuteScalar();

                    if (result != null)
                    {
                        result = Program.UserDetails.GPhoto;
                        Program.UserDetails.PhotoChanges(Program.UserDetails.UserID);
                        GooglePhotos.GooglePhotosClientIntegrationTests GooglePhotos =
                            new GooglePhotos.GooglePhotosClientIntegrationTests();
                        GooglePhotos.Test_ListAlbums_GetFirstAlbum();
                        GooglePhotos.ListAlbumContent();

                    }

                    myConn.Close();
                }
            }
        }

        public async Task OnPostWeather(string City, string Country, string Unit)
        {
            display = "grid";
            // HAVE TO MAKE A DEFAULT - London, ON & Metric. DONE IN DB NOT DD

            // SETTINGS
            Program.Weather.selCity = City;
            Program.Weather.selCountry = Country;
            Program.Weather.selUnit = Unit;

            // Pulling in information from the API
            await Program.Fetch.GrabWeather(City, Country, Unit);

            jNinja = new JsonNinja(Program.Fetch.Data);
            List<string> names = jNinja.GetNames();
            List<string> vals = jNinja.GetVals();

            Program.Weather.selCity = jNinja.GetInfo("\"name\"");
            Program.Weather.selCountry = jNinja.GetInfo("\"country\"");

            // Retrieve information from Weather Class
            selCity = Program.Weather.selCity;
            selCountry = Program.Weather.selCountry;
            selUnit = Program.Weather.selUnit;

            selCity = selCity.Replace("\"", "");
            selCountry = selCountry.Replace("\"", "");

            // Retrieve information from WeatherData Class
            // weather
            weather = Program.WeatherData.weather;
            wetId = Program.WeatherData.wetId;
            wetMain = Program.WeatherData.wetMain;
            desc = Program.WeatherData.desc;
            dayIcon = Program.WeatherData.dayIcon;
            icon = Program.WeatherData.icon;
            iconShow = Program.WeatherData.iconShow;
            // main
            temp = Program.WeatherData.temp;
            tempHigh = Program.WeatherData.tempHigh;
            tempLow = Program.WeatherData.tempLow;
            humidity = Program.WeatherData.humidity;
            pressure = Program.WeatherData.pressure;
            visibility = Program.WeatherData.visibility;
            // wind
            wind = Program.WeatherData.wind;
            windSpeed = Program.WeatherData.windSpeed;
            windDir = Program.WeatherData.windDir;
            windText = Program.WeatherData.windText;
            // length of day
            sunrise = Program.WeatherData.sunrise;
            riseTime = Program.WeatherData.riseTime;
            sunset = Program.WeatherData.sunset;
            setTime = Program.WeatherData.setTime;
            // clouds
            clouds = Program.WeatherData.clouds;
            all = Program.WeatherData.all;

            // weather
            listNinja = new JsonNinja(Program.Fetch.Data);
            weather = listNinja.GetDetails("\"weather\"");
            wetId = jNinja.GetInfo("\"id\""); // might not need
            wetMain = jNinja.GetDetails("\"main\""); // ie. rain
            desc = jNinja.GetInfo("\"description\""); // ie. light rain
            desc = desc.Replace("\"", "");
            dayIcon = listNinja.GetDetails("\"icon\"");
            icon = dayIcon[0].Replace("\"]", "");
            icon = icon.Replace("\"", "");
            iconShow = "http://openweathermap.org/img/w/" + icon + ".png";

            // main
            temp = wetMain[1].Replace("\"temp\":", ""); // fix! if rain and mist etc temp doesn't show properly
            tempHigh = jNinja.GetInfo("\"temp_max\"");
            tempLow = jNinja.GetInfo("\"temp_min\"");
            humidity = jNinja.GetInfo("\"humidity\"");
            pressure = jNinja.GetInfo("\"pressure\"");
            visibility = jNinja.GetInfo("\"visibility\"");

            // wind
            wind = listNinja.GetDetails("\"wind\"");
            windSpeed = wind[0].Replace("\"speed\":", "");
            windDir = jNinja.GetInfo("\"deg\"");

            // length of day
            sunrise = jNinja.GetInfo("\"sunrise\"");
            riseTime = (new DateTime(1970, 1, 1)).AddMilliseconds(double.Parse(sunrise) * 1000).ToLocalTime().ToLongTimeString();
            sunset = jNinja.GetInfo("\"sunset\"");
            setTime = (new DateTime(1970, 1, 1)).AddMilliseconds(double.Parse(sunset) * 1000).ToLocalTime().ToLongTimeString();

            // clouds
            clouds = listNinja.GetDetails("\"clouds\"");
            all = clouds[0].Replace("\"all\":", "");

            metric = Program.Weather.metric;
            imperial = Program.Weather.imperial;
            kelvin = Program.Weather.kelvin;

            if (Unit == "Metric") // Metric
            {
                temp = temp + "°C";
                tempHigh = tempHigh + "°C";
                tempLow = tempLow + "°C";
                visibility = visibility + " meters";
                windSpeed = windSpeed + " meters/second";
            }
            else if (Unit == "Imperial")
            {
                temp = temp + "°F";
                tempHigh = tempHigh + "°F";
                tempLow = tempLow + "°F";
                visibility = visibility + " feet";
                windSpeed = windSpeed + " miles/hour";
            }
            else // Kelvin
            {
                temp = temp + "°K";
                tempHigh = tempHigh + "°K";
                tempLow = tempLow + "°K";
                visibility = visibility + " meters";
                windSpeed = windSpeed + " meters/second";
            }

            // When Imperial is selected the input string is not the correct type & only sometimes ??
            // Break down into only N/NE/E/SE/S/SW/W/NW ?? 
            // Take out decimal values?
            /*double windTemp = Convert.ToDouble(windDir);
            switch (windTemp)
            {
                case double windDir when (windDir >= 348.75 && windDir <= 11.25):
                    // 348.75 - 11.25 = N
                    windText = windDir + " °N";
                    break;
                case double windDir when (windDir >= 11.26 && windDir <= 33.75):
                    // 11.26 - 33.75 = NNE
                    windText = windDir + " °NNE";
                    break;
                case double windDir when (windDir >= 33.76 && windDir <= 56.25):
                    // 33.76 - 56.25 = NE
                    windText = windDir + " °NE";
                    break;
                case double windDir when (windDir >= 56.26 && windDir <= 78.75):
                    // 56.26 - 78.75 = ENE
                    windText = windDir + " °ENE";
                    break;
                case double windDir when (windDir >= 78.76 && windDir <= 101.25):
                    // 78.76 - 101.25 = E
                    windText = windDir + " °E";
                    break;
                case double windDir when (windDir >= 101.26 && windDir <= 123.75):
                    // 101.26 - 123.75 = ESE
                    windText = windDir + " °ESE";
                    break;
                case double windDir when (windDir >= 123.76 && windDir <= 146.25):
                    // 123.76 - 146.25 = SE
                    windText = windDir + " °SE";
                    break;
                case double windDir when (windDir >= 146.26 && windDir <= 168.75):
                    // 146.26 - 168.75 = SSE
                    windText = windDir + " °SSE";
                    break;
                case double windDir when (windDir >= 168.76 && windDir <= 191.25):
                    // 168.76 - 191.25 = S
                    windText = windDir + " °S";
                    break;
                case double windDir when (windDir >= 191.26 && windDir <= 213.75):
                    // 191.26 - 213.75 = SSW
                    windText = windDir + " °SSW";
                    break;
                case double windDir when (windDir >= 213.76 && windDir <= 236.25):
                    // 213.76 - 236.25 = SW
                    windText = windDir + " °SW";
                    break;
                case double windDir when (windDir >= 236.26 && windDir <= 258.75):
                    // 236.26 - 258.75 = WSW
                    windText = windDir + " °WSW";
                    break;
                case double windDir when (windDir >= 258.76 && windDir <= 281.25):
                    // 258.76 - 281.25 = W
                    windText = windDir + " °W";
                    break;
                case double windDir when (windDir >= 281.26 && windDir <= 303.75):
                    // 281.26 - 303.75 = WNW
                    windText = windDir + " °WNW";
                    break;
                case double windDir when (windDir >= 303.76 && windDir <= 326.25):
                    // 303.76 - 326.25 = NW
                    windText = windDir + " °NW";
                    break;
                case double windDir when (windDir >= 326.26 && windDir <= 348.74):
                    // 326.26 - 348.75 = NNW
                    windText = windDir + " °NNW";
                    break;
                default:
                    break;
            } //windTemp() - Wind Direction*/

            if (Program.UserDetails.UserID == 0) // not logged in
            {
                // only display the home page - no settings AKA no settings page to see these options.
            }

            else
            {
                using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
                {
                    SqlCommand getWeather = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    // Put in same order as the SP & Table (maybe change userId to last - since it's a FK ??)
                    // INSERT DEFAULT VALUES OF LONDON, CANADA AND METRIC - Done in Database????
                    getWeather.Parameters.AddWithValue("@userId", Program.UserDetails.UserID);
                    getWeather.Parameters.AddWithValue("@country", selCountry);
                    getWeather.Parameters.AddWithValue("@city", selCity);
                    getWeather.Parameters.AddWithValue("@unit", Unit);

                    getWeather.CommandText = ("[spWeatherSettings]");
                    getWeather.CommandType = System.Data.CommandType.StoredProcedure;

                    getWeather.ExecuteNonQuery();

                    myConn.Close();
                }
            }
            // Refresh the settings page @ weather pos on page
        } //OnPostWeather()
        public void WeatherChanges(int UserID)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                SqlCommand returnWeather = new SqlCommand();
                returnWeather.Connection = myConn;
                myConn.Open();

                returnWeather.Parameters.AddWithValue("@userId", Program.UserDetails.UserID);
                returnWeather.CommandText = ("[spReturnWeather]");
                returnWeather.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = returnWeather.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rWeather.Add(reader.GetString(0)); // country
                        rWeather.Add(reader.GetString(1)); // city
                        rWeather.Add(reader.GetString(2)); // unit

                        Program.Weather.selCountry = rWeather[0];
                        Program.Weather.selCountry.Replace("\"", "");
                        if (rWeather[0] == "CA")
                        {
                            rWeather[0] = "Canada";
                        }
                        Program.Weather.selCity = rWeather[1];
                        Program.Weather.selCity.Replace("\"", "");
                        Program.Weather.selUnit = rWeather[2];
                    }
                    reader.Close();
                }
                returnWeather.Cancel();
                myConn.Close();
            }
        } // WeatherChanges()
        public void OnPostRemoveWeather(string City, string Country, string Unit)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeWeather = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeWeather.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);

                    removeWeather.CommandText = ("[spRemoveWeather]");
                    removeWeather.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeWeather.ExecuteScalar();

                    myConn.Close();
                }
            }
        } // OnPostRemoveWeather()
        public async Task OnPostNews(string Coun, string Articles, int Time)
        {
            display = "grid";

            // SETTINGS
            Program.News.selCoun = Coun;
            Program.News.numOfArticles = Articles;
            Program.News.selTime = Convert.ToString(Time);

            // Pulling in information from the API
            await Program.Fetch.GrabNews(Coun, Articles);

            jNinja = new JsonNinja(Program.Fetch.Data);
            List<string> newsNames = jNinja.GetNames();
            List<string> newsVals = jNinja.GetVals();

            // Retrieve information from News Class
            selCoun = Program.News.selCoun;
            numOfArticles = Program.News.numOfArticles;
            selTime = Program.News.selTime;

            // Grab information from NewsDataClass
            headline = Program.NewsData.headline;
            headlineList = Program.NewsData.headlineList;
            published = Program.NewsData.published;
            publishedList = Program.NewsData.publishedList;
            publishedDate = Program.NewsData.publishedDate;
            headlines = Program.NewsData.headlines;
            publishDates = Program.NewsData.publishDates;

            int countArticle = Convert.ToInt32(Articles);
            for (int i = 0; i < countArticle; i++)
            {
                headlineList = jNinja.GetDetails("\"title\"");
                headline = headlineList[i];
                headline = headline.Replace("\"", "");
                Program.NewsData.AddHeadline(headline);
                publishedList = jNinja.GetDetails("\"publishedAt\"");
                published = publishedList[i];
                published = published.Replace("\"", "");
                published = published.Replace("T", " ");
                published = published.Replace("Z", "");
                publishedDate = DateTime.ParseExact(published, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture); // stops the next line from taking the default time value
                // ^ date format has to be in the exact format as how it is taken in - then you can change it after the fact
                published = publishedDate.ToString("dddd, MMMM dd yyyy HH:mm tt (zzz") + " time zone difference.)";
                Program.NewsData.AddPublished(published);
            }
            headline = Program.NewsData.GetHeadline();
            published = Program.NewsData.GetPublished();

            if (Program.UserDetails.UserID == 0) // not logged in
            {
                // only display the home page - no settings AKA no settings page to see these options.
            }

            else
            {
                using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
                {
                    SqlCommand getNews = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    // Put in same order as the SP & Table (maybe change userId to last - since it's a FK ??)
                    // INSERT DEFAULT VALUES OF canada, 10, 15
                    getNews.Parameters.AddWithValue("@userId", Program.UserDetails.UserID);
                    getNews.Parameters.AddWithValue("@country", selCoun);
                    getNews.Parameters.AddWithValue("@articles", numOfArticles);
                    getNews.Parameters.AddWithValue("@time", Time);

                    getNews.CommandText = ("[spNewsSettings]");
                    getNews.CommandType = System.Data.CommandType.StoredProcedure;

                    getNews.ExecuteNonQuery();

                    myConn.Close();
                }
            }
            // Refresh the settings page @ news pos on page
        } //OnPostNews()
        public void NewsChanges(int UserID)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                SqlCommand returnNews = new SqlCommand();
                returnNews.Connection = myConn;
                myConn.Open();

                returnNews.Parameters.AddWithValue("@userId", Program.UserDetails.UserID);
                returnNews.CommandText = ("[spReturnNews]");
                returnNews.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = returnNews.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rNews.Add(reader.GetString(0)); // country
                        rNews.Add(reader.GetString(1)); // article amount
                        rNews.Add(reader.GetString(2)); // time
                        
                        Program.News.selCoun = rNews[0];
                        Program.News.selCoun.Replace("\"", "");
                        if (Program.News.selCoun == "ca")
                        {
                            rNews[0] = "Canada";
                        }
                        if(Program.News.selCoun == "us")
                        {
                            rNews[0] = "United States";
                        }
                        Program.News.numOfArticles = rNews[1];
                        int numArticle = Convert.ToInt32(rNews[1]);
                        Program.News.selTime = rNews[2];
                        Program.News.selTime.Replace("\"", "");
                        if(Program.News.selTime == "15000")
                        {
                            rNews[2] = "15 Seconds";
                        }
                    }
                    reader.Close();
                }
                returnNews.Cancel();
                myConn.Close();
            }
        } // NewsChanges()
        public void OnPostRemoveNews(string Coun, string Articles, int Time)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeNews = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeNews.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);

                    removeNews.CommandText = ("[spRemoveNews]");
                    removeNews.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeNews.ExecuteScalar();

                    myConn.Close();
                }
            }
        } //OnPostRemoveNews
        public void OnPostDTFormat(string ddDay, string ddDate, string ddMonth, string ddYear,
            string ddHours, string ddMinutes, string ddSeconds, string ddTime)
        {
            display = "grid";

            Program.DateFormats.selDay = ddDay;
            Program.DateFormats.selDate = ddDate;
            Program.DateFormats.selMonth = ddMonth;
            Program.DateFormats.selYear = ddYear;
            Program.DateFormats.selHour = ddHours;
            Program.DateFormats.selMin = ddMinutes;
            Program.DateFormats.selSec = ddSeconds;
            Program.DateFormats.selAP = ddTime;

            if (Program.UserDetails.UserID == 0) // not logged in
            {
                // only display the home page - no settings AKA no settings page to see these options.
            }

            else
            {
                using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
                {
                    SqlCommand getDTFormats = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    // Put in same order as the SP & Table (maybe change userId to last - since it's a FK ??)
                    getDTFormats.Parameters.AddWithValue("@userId", Program.UserDetails.UserID);
                    getDTFormats.Parameters.AddWithValue("@day", ddDay);
                    getDTFormats.Parameters.AddWithValue("@date", ddDate);
                    getDTFormats.Parameters.AddWithValue("@month", ddMonth);
                    getDTFormats.Parameters.AddWithValue("@year", ddYear);
                    getDTFormats.Parameters.AddWithValue("@hour", ddHours);
                    getDTFormats.Parameters.AddWithValue("@minutes", ddMinutes);
                    getDTFormats.Parameters.AddWithValue("@seconds", ddSeconds);
                    getDTFormats.Parameters.AddWithValue("@time", ddTime);

                    getDTFormats.CommandText = ("[DTFormatSettings]");
                    getDTFormats.CommandType = System.Data.CommandType.StoredProcedure;

                    getDTFormats.ExecuteNonQuery();

                    myConn.Close();
                }
            }
        } //OnPostDTFormat
        public void DTChanges(int UserID)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                SqlCommand returnDT = new SqlCommand();
                returnDT.Connection = myConn;
                myConn.Open();

                returnDT.Parameters.AddWithValue("@userId", Program.UserDetails.UserID);
                returnDT.CommandText = ("[spReturnDT]");
                returnDT.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = returnDT.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        rDT.Add(reader.GetString(0)); // day
                        rDT.Add(reader.GetString(1)); // date
                        rDT.Add(reader.GetString(2)); // month
                        rDT.Add(reader.GetString(3)); // year
                        rDT.Add(reader.GetString(4)); // hour
                        rDT.Add(reader.GetString(5)); // minutes
                        rDT.Add(reader.GetString(6)); // seconds
                        rDT.Add(reader.GetString(7)); // time
                        
                        Program.DateFormats.selDay = rDT[0];
                        Program.DateFormats.selDate = rDT[1];
                        Program.DateFormats.selMonth = rDT[2];
                        Program.DateFormats.selYear = rDT[3];
                        Program.DateFormats.selHour = rDT[4];
                        Program.DateFormats.selMin = rDT[5];
                        Program.DateFormats.selSec = rDT[6];
                        Program.DateFormats.selAP = rDT[7];

                    }
                    reader.Close();
                }
                returnDT.Cancel();
                myConn.Close();
            }
        } // DTChanges()
        public void OnPostRemoveDT(string ddDay, string ddDate, string ddMonth, string ddYear,
            string ddHours, string ddMinutes, string ddSeconds, string ddTime)
        {
            using (SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                if (Program.UserDetails.UserID != 0)
                {
                    SqlCommand removeDT = new SqlCommand
                    {
                        Connection = myConn
                    };
                    myConn.Open();

                    removeDT.Parameters.AddWithValue("@UserID", Program.UserDetails.UserID);

                    removeDT.CommandText = ("[spRemoveDT]");
                    removeDT.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = removeDT.ExecuteScalar();

                    myConn.Close();
                }
            }
        }// OnPostRemoveDT
    } // Pagemodel
} // namespace


   

