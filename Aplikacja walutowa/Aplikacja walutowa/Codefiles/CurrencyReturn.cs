using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_walutowa
{
    class CurrencyReturn
    {
        public class Rate
        {
            public string no { get; set; }
            public string effectiveDate { get; set; }
            public double bid { get; set; }
            public double ask { get; set; }
        }

        public class Root
        {
            public string table { get; set; }
            public string currency { get; set; }
            public string code { get; set; }
            public List<Rate> rates { get; set; }
        }
    }
}
