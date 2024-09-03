using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private WeatherReturn.RootObject root;
        public MainPage()
        {
            InitializeComponent();
            SearchButton.IsEnabled = false;
            weatherShow.IsVisible = false;
        }
        private void City_textchange(object sender, TextChangedEventArgs e)
        {
            if (UserInput() != string.Empty) SearchButton.IsEnabled = true;
            else SearchButton.IsEnabled = false;
        }
        async void getCity(object sender, EventArgs e)
        {
            Connection conn = new Connection(UserInput());
            try
            {
                root = await conn.GetWeather();
                weatherShow.IsVisible = true;
                FillWeather();
            }
            catch (Exception ex)
            {
                ExceptionHandling(ex);
            }
        }
        void ExceptionHandling(Exception ex)
        {
            Connection conn = new Connection(UserInput());
            if (ex.HResult == -2146233088)
            {
                DisplayAlert("error", conn.test(UserInput()), "close");
            }
            else DisplayAlert("ERROR", "blad " + ex.Message, "close");
        }
        string UserInput()
        {
            return SearchCity.Text.ToString();
        }
        void FillWeather()
        {
            new WeatherDisplay(UserInput(), cityLabel, skyLabel, tempLabel, preassureLabel, humidityLabel, root);
        }
    }
}
