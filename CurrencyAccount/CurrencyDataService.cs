using System;

namespace CurrencyAccount
{
    public class CurrencyDataService
    {
      public decimal GetCurrencyDataService(String currencyName){
        //this should call NBP api to get currency rate'
        switch (currencyName)
        { 
            case "EUR":
            return 4.59m;
            case "GBP":
            return 5.35m;
            case "USD":
            return 3.83m;
            default:
            return 1;
        }
      }
    }
}
