using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp
{
    class WeatherDisplay
    {
        //Wyświetlenie pogody
        public WeatherDisplay(string userInput, Label cityLabel, Label skyLabel, Label tempLabel, Label preassureLabel, Label humidityLabel, WeatherReturn.RootObject root)
        {
            skyLabel.Text = "Sky: " + root.weather[0].description;
            tempLabel.Text = "Temperature: " + Math.Round(Convert.ToDecimal(root.main.temp - 273.15)).ToString() + " C";
            cityLabel.Text = "City: " + userInput;
            preassureLabel.Text = "Pressure: " + root.main.pressure + " hPa";
            humidityLabel.Text = "Humidity: " + root.main.humidity + " %";
        }
    }
}
