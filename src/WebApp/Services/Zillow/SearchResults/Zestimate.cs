namespace WebApp.Services.Zillow.SearchResults
{
  public class Zestimate
  {
    public decimal Amount { get; set; }

    public Zestimate(string amount)
    {
      this.Amount = decimal.Parse(amount);
    }
  }
}