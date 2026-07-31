using System;
using System.Collections.Generic;

namespace AvaloniaMeteo.MODELS
{
    public class WeatherResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Tz_id { get; set; }
        public int Localtime_epoch { get; set; }
        public DateTime Localtime { get; set; }

        public string FullLocation => $"{Name},{Region}, {Country}";
        public string DisplayName => $"{Name}, {Region}, {Country}";
        public string SearchQuery => $"{Lat},{Lon}";
    }

    public class Current
    {
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public int is_day { get; set; }
        public Condition condition { get; set; }
        public double wind_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
        public double humidity { get; set; }
        public int cloud { get; set; }

    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }
    public class Hour
    {
        public int time_epoch { get; set; }
        public DateTime time { get; set; }
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public int is_day { get; set; }
        public Condition condition { get; set; }
        public double wind_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
        public double snow_cm { get; set; }
        public double humidity { get; set; }
        public double cloud { get; set; }
        public double feelslike_c { get; set; }
        public double feelslike_f { get; set; }
        public double dewpoint_f { get; set; }

    }
    public class Forecastday
    {
        public string date { get; set; }
        public int date_epoch { get; set; }
        public Day day { get; set; }
        public IList<Hour> hour { get; set; }

    }
    public class Day
    {
        public double maxtemp_c { get; set; }
        public double maxtemp_f { get; set; }
        public double mintemp_c { get; set; }
        public double mintemp_f { get; set; }
        public double avgtemp_c { get; set; }
        public double avgtemp_f { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }
        public double totalprecip_mm { get; set; }
        public double totalprecip_in { get; set; }
        public double totalsnow_cm { get; set; }
        public double avgvis_km { get; set; }
        public double avgvis_miles { get; set; }
        public double avghumidity { get; set; }
        public double daily_will_it_rain { get; set; }
        public double daily_chance_of_rain { get; set; }
        public double daily_will_it_snow { get; set; }
        public double daily_chance_of_snow { get; set; }
        public Condition condition { get; set; }
        public double uv { get; set; }

    }
    public class Forecast
    {
        public IList<Forecastday> forecastday { get; set; }

    }

}
