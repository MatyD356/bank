using System;
using NUnit.Framework;
using Moq;

namespace CurrencyAccount.Test
{
  public class Tests
  {
    CurrencyAccount currencyAccount;
    CurrencyDataService currencyDataService;
    [SetUp]
    public void Setup()
    {
      currencyAccount = new CurrencyAccount();
      currencyAccount.AccountConfig(-100,100);
      currencyDataService = new CurrencyDataService();
    }

    [Test]
    public void GetCurrencyDataServiceUSDShoulDReturn383()
    {
      var result = currencyDataService.GetCurrencyDataService("USD");
      Assert.AreEqual(3.83, result);
    }
        [Test]
    public void GetCurrencyDataServiceXYZShouldThrowException()
    {
      Assert.Throws<ArgumentException>(() =>
            {
              currencyDataService.GetCurrencyDataService("XYZ");
            });
    }
    [Test]
    public void InheretanceWorks()
    {
      currencyAccount.AccountConfig(-200,200);
      var maxDebt = currencyAccount.MaxDebtInfo();
      Assert.AreEqual(-200, maxDebt);
    }

    [Test]
    public void IncomingMultiCurrencyTransactionInUSD()
    { 
      var currencyDataMock = new Mock<CurrencyDataService>();
      currencyDataMock.Setup(x => x.GetCurrencyDataService("USD")).Returns(new Decimal(3.83));
      var currencyRate = currencyDataMock.Object.GetCurrencyDataService("USD");

      currencyAccount.IncomingMultiCurrencyTransaction(currencyRate,100);
      var accBalance = currencyAccount.AccountBalanceInfo();
      Assert.AreEqual(483, accBalance);
      
      currencyDataMock.Verify(x=> x.GetCurrencyDataService("USD"),  Times.Once());
    }
    [Test]
    public void OutgoingMultiCurrencyTransactionInUSD()
    {
      var currencyDataMock = new Mock<CurrencyDataService>();
      currencyDataMock.Setup(x => x.GetCurrencyDataService("USD")).Returns(new Decimal(3.83));
      var currencyRate = currencyDataMock.Object.GetCurrencyDataService("USD");

      currencyAccount.OutgoingMultiCurrencyTransaction(currencyRate,10);
      var accBalance = currencyAccount.AccountBalanceInfo();
      Assert.AreEqual(100-38.30, accBalance);

      currencyDataMock.Verify(x=> x.GetCurrencyDataService("USD"),  Times.Once());
    }
    [Test]
    public void IncomingMultiCurrencyTransactionInEUR()
    { 
      var currencyDataMock = new Mock<CurrencyDataService>();
      currencyDataMock.Setup(x => x.GetCurrencyDataService("EUR")).Returns(new Decimal(4.59));
      var currencyRate = currencyDataMock.Object.GetCurrencyDataService("EUR");

      currencyAccount.IncomingMultiCurrencyTransaction(currencyRate,100);
      var accBalance = currencyAccount.AccountBalanceInfo();
      Assert.AreEqual(100+459, accBalance);
      
      currencyDataMock.Verify(x=> x.GetCurrencyDataService("EUR"),  Times.Once());
    }
    [Test]
    public void OutgoingMultiCurrencyTransactionInEUR()
    {
      var currencyDataMock = new Mock<CurrencyDataService>();
      currencyDataMock.Setup(x => x.GetCurrencyDataService("EUR")).Returns(new Decimal(4.59));
      var currencyRate = currencyDataMock.Object.GetCurrencyDataService("EUR");

      var currentRate = currencyDataService.GetCurrencyDataService("EUR");
      currencyAccount.OutgoingMultiCurrencyTransaction(currentRate,10);
      var accBalance = currencyAccount.AccountBalanceInfo();
      Assert.AreEqual(100-45.9, accBalance);
      currencyDataMock.Verify(x=> x.GetCurrencyDataService("EUR"),  Times.Once());
    }
        [Test]
    public void IncomingMultiCurrencyTransactionInGBP()
    { 
      var currencyDataMock = new Mock<CurrencyDataService>();
      currencyDataMock.Setup(x => x.GetCurrencyDataService("GBP")).Returns(new Decimal(5.35));
      var currencyRate = currencyDataMock.Object.GetCurrencyDataService("GBP");

      currencyAccount.IncomingMultiCurrencyTransaction(currencyRate,100);
      var accBalance = currencyAccount.AccountBalanceInfo();
      Assert.AreEqual(100+535, accBalance);
      
      currencyDataMock.Verify(x=> x.GetCurrencyDataService("GBP"),  Times.Once());
    }
    [Test]
    public void OutgoingMultiCurrencyTransactionInGBP()
    {
      var currencyDataMock = new Mock<CurrencyDataService>();
      currencyDataMock.Setup(x => x.GetCurrencyDataService("GBP")).Returns(new Decimal(5.35));
      var currencyRate = currencyDataMock.Object.GetCurrencyDataService("GBP");

      var currentRate = currencyDataService.GetCurrencyDataService("GBP");
      currencyAccount.OutgoingMultiCurrencyTransaction(currentRate,10);
      var accBalance = currencyAccount.AccountBalanceInfo();
      Assert.AreEqual(100-53.5, accBalance);
      currencyDataMock.Verify(x=> x.GetCurrencyDataService("GBP"),  Times.Once());
    }
  }
}