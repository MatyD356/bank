using NUnit.Framework;
using Moq;

namespace CurrencyAccount.Test
{
  public class Tests
  {
    CurrencyDataService currencyDataService;
    [SetUp]
    public void Setup()
    {
      currencyDataService = new CurrencyDataService();
    }

    [Test]
    public void GetCurrencyDataServiceUSDShoulDReturn383()
    {
      var result = currencyDataService.GetCurrencyDataService("USD");
      Assert.AreEqual(3.83, result);
    }
  }
}