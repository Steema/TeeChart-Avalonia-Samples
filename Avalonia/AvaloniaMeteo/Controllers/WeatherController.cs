using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AvaloniaMeteo.MODELS;
using Newtonsoft.Json;

namespace AvaloniaMeteo.Controllers
{
    public class WeatherController
    {
        private HttpClient client;
        private const string API_KEY = "f55e1b187df24acd8d4104955251107";

        private static Dictionary<string, (WeatherResponse, DateTime)> cache = new Dictionary<string, (WeatherResponse, DateTime)>();
        private static readonly TimeSpan cacheDuration = TimeSpan.FromMinutes(10); // Duración de la caché

        private static Dictionary<string, (Forecast, DateTime)> forecastCache = new Dictionary<string, (Forecast, DateTime)>();
        private static readonly TimeSpan forecastCacheDuration = TimeSpan.FromHours(3);

        private static Dictionary<string, (Forecast, DateTime)> humidityTempCache = new Dictionary<string, (Forecast, DateTime)>();
        private static readonly TimeSpan humidityTempCacheDuration = TimeSpan.FromHours(1);

        private static Dictionary<string, (Forecast, DateTime)> tempCacheBy10Days = new Dictionary<string, (Forecast, DateTime)>();
        private static readonly TimeSpan tempCacheBy10DaysDuration = TimeSpan.FromHours(6);

        public WeatherController()
        {
            client = new HttpClient();
        }

        public async Task<List<Location>> GetLocationSuggestionsAsync(string cityQuery)
        {
            try
            {
                if (string.IsNullOrEmpty(cityQuery) || cityQuery.Length < 3)
                    return new List<Location>();

                string url = $"http://api.weatherapi.com/v1/search.json?key={API_KEY}&q={cityQuery}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                List<Location> suggestions = JsonConvert.DeserializeObject<List<Location>>(responseJson);

                return suggestions ?? new List<Location>();
            }
            catch (Exception ex)
            {
                return new List<Location>();
            }
        }

        public async Task<WeatherResponse> GetCurrentTemperatura(string city)
        {
            try
            {
                // Checks if there is data in the cache and if it is recent at the current time. 
                if (cache.ContainsKey(city))
                {
                    var (cachedResponse, timestamp) = cache[city];

                    if ((DateTime.Now - timestamp) < cacheDuration)
                    {
                        return cachedResponse;
                    }

                }

                // If not cached or expired, make the API call.
                string url = $"http://api.weatherapi.com/v1/current.json?key={API_KEY}&q={city}&aqi=no";


                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);

                // Saves the weather response in the cache with the current timestamp.
                cache[city] = (weatherResponse, DateTime.Now);
                return weatherResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la temperatura: {ex.Message}");
            }
        }

        /// <summary>
        /// Fetches the 3-day weather forecast for the specified city, using a cache to reduce API calls.
        /// </summary>
        /// <param name="city">The name of the city to fetch the weather forecast for.</param>
        /// <returns>A <see cref="Forecast"/> object containing the weather forecast data.</returns>
        /// <exception cref="Exception">Thrown when there is an error retrieving the weather data.</exception>
        public async Task<Forecast> GetEvolutionOfWeatherByCity(string city)
        {
            try
            {
                // Checks if there is data in the cache and if it is recent at the current time. 
                if (forecastCache.ContainsKey(city))
                {
                    // Extracts the cached weather forecast and its timestamp from the dictionary.
                    var (cachedForecast, timestamp) = forecastCache[city];

                    if ((DateTime.Now - timestamp) < forecastCacheDuration && cachedForecast.forecastday.Count == 3)
                    {
                        return cachedForecast;
                    }
                }
                // If the condition is not met, it makes a new API call.
                string url = $"http://api.weatherapi.com/v1/forecast.json?key={API_KEY}&q={city}&days=3";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();


                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);

                Forecast forecast = weatherResponse.Forecast;

                // Stores the forecast in the cache if it contains data for 3 days.
                if (forecast.forecastday.Count == 3)
                {
                    // Saves the weather response in the cache with the current timestamp.
                    forecastCache[city] = (forecast, DateTime.Now);
                }
                return forecast;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las temperaturas diarias: {ex.Message}");
            }
        }

        public async Task<Forecast> GetEvolutionOfHumidityAndTemperatureByCity(string city)
        {
            try
            {
                // Checks if there is data in the cache and if it is recent at the current time.
                if (humidityTempCache.ContainsKey(city))
                {
                    var (cachedForecast, timestamp) = humidityTempCache[city];

                    if ((DateTime.Now - timestamp) < humidityTempCacheDuration)
                    {
                        return cachedForecast;
                    }
                }

                // If the condition is not met, it makes a new API call.
                string url = $"http://api.weatherapi.com/v1/forecast.json?key={API_KEY}&q={city}&days=1";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);
                Forecast forecast = weatherResponse.Forecast;

                // Saves the weather response in the cache with the current timestamp.
                forecastCache[city] = (forecast, DateTime.Now);
                return forecast;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las temperaturas diarias: {ex.Message}");
            }
        }

        public async Task<Forecast> GetPrevisionBy10Days(string city)
        {
            try
            {
                // Checks if there is data in the cache and if it is recent at the current time.
                if (tempCacheBy10Days.ContainsKey(city))
                {
                    var (cachedForecast, timestamp) = tempCacheBy10Days[city];
                    if ((DateTime.Now - timestamp) < tempCacheBy10DaysDuration)
                    {
                        return cachedForecast;
                    }
                }

                // If the condition is not met, it makes a new API call.
                string url = $"http://api.weatherapi.com/v1/forecast.json?key={API_KEY}&q={city}&days=10";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);
                Forecast forecast = weatherResponse.Forecast;

                // Saves the weather response in the cache with the current timestamp.
                tempCacheBy10Days[city] = (forecast, DateTime.Now);
                return forecast;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las temperaturas diarias: {ex.Message}");
            }
        }




    }
}
