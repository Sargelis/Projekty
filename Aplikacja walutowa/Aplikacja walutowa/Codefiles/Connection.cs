using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; //intstalcja z NuGet
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Aplikacja_walutowa
{
    class Connection
    {
        private const string HTTPS = "https://api.nbp.pl/api/exchangerates/rates/C";
        public string CODE;
        HttpClient httpClient = new HttpClient();

        public Connection(string code)
        {
            CODE = code;
        }
        public string test(string code)
        {
            CODE = code;
            return $"{HTTPS}/{CODE}/?format=json";
        }
        public async Task<CurrencyReturn.Root> GetCurrency()
        {
            var response = await httpClient.GetAsync($"{HTTPS}/{CODE}/?format=json");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CurrencyReturn.Root>(content);
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
