using System;
namespace RapidAPIExample.Models
{
	public class ExchangeViewModel
	{
        public class ExchangeRate
        {
            public string exchange_rate_buy { get; set; }
            public string currency { get; set; }
            public string base_currency_date { get; set; }
            public string base_currency { get; set; }
        }

            public List<ExchangeRate> exchange_rates { get; set; }

        
    }
}

