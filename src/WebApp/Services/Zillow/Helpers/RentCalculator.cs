using System;
using WebApp.Services.Zillow.SearchResults;

namespace WebApp.Services.Zillow.Helpers
{
  public class RentCalculator
  {
    private readonly int Rate = 5;
    private readonly int Months = 12;
    private readonly int Range = 10;

    public ValuationRange GetRentBasedOnHomePrice(decimal homePrice)
    {
      var estimateRent = (homePrice * Rate / 100) / Months;
      var rangeValue = estimateRent * Range / 100;
      var low = Math.Truncate(estimateRent - rangeValue);
      var high = Math.Truncate(estimateRent + rangeValue);

      return new ValuationRange(low, high);
    }
  }
}