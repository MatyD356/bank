using System;

namespace CurrencyAccount
{
  public class Account
  {
    private decimal maxDebt { get; set; }
    private decimal accountBalance { get; set; }
    public void AccountConfig(decimal maxDebt, decimal accountBalance)
    {
      this.maxDebt = maxDebt;
      this.accountBalance = accountBalance;
    }
    public decimal MaxDebtInfo()
    {
      return this.maxDebt;
    }
    public decimal AccountBalanceInfo()
    {
      return this.accountBalance;
    }
    public void Add(decimal value)
    {
      if (value < 0) throw new ArgumentException("Number to add must be bigger than 0");
      this.accountBalance = this.accountBalance + value;
    }
    public void Withdraw(decimal value)
    {
      if (value < 0) throw new ArgumentException("Number to withdraw must be bigger than 0");
      var newBalance = this.accountBalance - value;
      if (newBalance < this.maxDebt) throw new ArgumentException("Excced max debt value");
      this.accountBalance -= value;
    }
  }
}
