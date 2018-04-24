namespace WebApp.Services.Zillow.SearchResults
{
  public class ValuationRange
  {
    public decimal Low { get; set; }

    public decimal High { get; set; }

    public static ValuationRange Empty => new ValuationRange(decimal.Zero, decimal.Zero);

    public ValuationRange(decimal low, decimal high)
    {
      this.Low = low;
      this.High = high;
    }

    public ValuationRange(string low, string high)
    {
      this.Low = decimal.Parse(low);
      this.High = decimal.Parse(high);
    }
  }
}