namespace WebApp.Services.Zillow.SearchResults
{
  public class RentZestimate
  {
    public ValuationRange ValuationRange{ get; set; }

    public RentZestimate()
    {
    }

    public RentZestimate(ValuationRange valuationRange)
    {
      this.ValuationRange = valuationRange;
    }
  }
}