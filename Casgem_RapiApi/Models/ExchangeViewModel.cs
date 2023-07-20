namespace Casgem_RapiApi.Models
{
    public class ExchangeViewModel
    {

     public string base_currency { get; set; } //kur bilgisi
     public Exchange_Rates[] exchange_rates { get; set; } //oranlar
      public string base_currency_date { get; set; }
      

        public class Exchange_Rates
        {
            public string exchange_rate_buy { get; set; }
            public string currency { get; set; }
        }

    }
}
