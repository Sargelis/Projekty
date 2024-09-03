using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;

namespace Aplikacja_walutowa
{
    public partial class MainPage : ContentPage
    {
        private CurrencyReturn.Root currency1;
        private CurrencyReturn.Root currency2;
        public MainPage()
        {
            InitializeComponent();
            InputButton.IsEnabled = false;
            currencyShow.IsVisible = false;
        }
        private void Code_textchange(object sender, TextChangedEventArgs e)
        {
            if (UserInput() != string.Empty) InputButton.IsEnabled = true;
            else InputButton.IsEnabled = false;
        }
        string UserInput()
        {
            return CodeInput.Text.ToString();
        }

        async void GetCode(object sender, EventArgs e)
        {
            if (UserInput().Length > 7 | (UserInput().Length > 3 & UserInput().Length < 7))
            {
                DisplayAlert("ERROR", "Wrong currency code: " + UserInput(), "close");
            }
            else
            {
                if (UserInput().Length < 4)
                {
                    Connection conn = new Connection(UserInput());
                    try
                    {
                        currency1 = await conn.GetCurrency();
                        currencyShow.IsVisible = true;
                        FillCurrency1();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }
                }
                else
                {
                    String cur1 = UserInput().Substring(0, 3);
                    String cur2 = UserInput().Substring(4, 3); //drugi kod walutowy od 5 litery 3 litery pobierz i zrób string
                    Connection conn = new Connection(cur1);
                    Connection conn2 = new Connection(cur2);
                    try
                    {
                        currency1 = await conn.GetCurrency();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }

                    try
                    {
                        currency2 = await conn2.GetCurrency();
                        currencyShow.IsVisible = true;
                        FillCurrency();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling(ex);
                    }
                }
            }
        }

        void ExceptionHandling(Exception ex)
        {
            Connection conn = new Connection(UserInput());
            if (ex.HResult == -2146233088)
            {
                DisplayAlert("ERROR", "Wrong currency code: " + UserInput(), "close");
            }
            else DisplayAlert("ERROR", "ERROR: " + ex.Message, "close");
        }

        void FillCurrency()
        {
            new CurrencyDisplay(bid, ask, currency1, currency2);
        }
        void FillCurrency1()
        {
            new CurrencyDisplay(bid, ask, currency1);
        }
    }
}