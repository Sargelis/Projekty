using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    class Connection
    {
        private const string KEY = "6d72277605142d1c1acc518b5b9e8f80";
        private const string HTTPS = "https://api.openweathermap.org/data/2.5/";
        public string CITY;
        HttpClient httpClient = new HttpClient();

        public Connection(string city)
        {
            CITY = city;
        }
        public string test(string city)
        {
            CITY = city;
            return $"{HTTPS}weather?q={CITY}&appid={KEY}";
        }
        public async Task<WeatherReturn.RootObject> GetWeather()
        {
            var response = await httpClient.GetAsync($"{HTTPS}weather?q={CITY}&appid={KEY}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherReturn.RootObject>(content);
            }
            else
            {
                throw new Exception();
            }
        }
        ~Connection()
        {
            GC.Collect();
        }
    }
}
