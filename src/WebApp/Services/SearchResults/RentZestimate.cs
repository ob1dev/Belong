using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace WebApp.Services.SearchResults
{
  public class RentZestimate
  {
    public string ValuationRangeLow { get; set; }

    public string ValuationRangeHigh { get; set; }

    public RentZestimate()
    {
    }

    public RentZestimate(string valuationRangeLow, string valuationRangeHigh)
    {
      this.ValuationRangeLow = valuationRangeLow;
      this.ValuationRangeHigh = valuationRangeHigh;
    }
  }
}