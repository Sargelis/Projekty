using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Aplikacja_walutowa
{
    class CurrencyDisplay
    {
        public CurrencyDisplay(Label label, Label label1, CurrencyReturn.Root curr1, CurrencyReturn.Root curr2)
        {
            double value_ask = curr1.rates[0].ask / curr2.rates[0].bid;
            double value_bid = curr1.rates[0].bid / curr2.rates[0].ask;
            label.Text = "BID: " + String.Format("{0:N4}", value_bid);
            label1.Text = "ASK: " + String.Format("{0:N4}", value_ask);
        }
        public CurrencyDisplay(Label label, Label label1, CurrencyReturn.Root curr)
        {
            label.Text = "BID: " + curr.rates[0].bid;
            label1.Text = "ASK: " + curr.rates[0].ask;
        }
    }
}
