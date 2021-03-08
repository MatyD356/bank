using System;

namespace CurrencyAccount
{
  
    public class CurrencyAccount : Account
    {
      public void IncomingMultiCurrencyTransaction(Decimal rate, Decimal value)
      {
        this.Add(value*rate);
      }
      public void OutgoingMultiCurrencyTransaction(Decimal rate, Decimal value)
      {
        this.Withdraw(value*rate);
      }
    }
}
