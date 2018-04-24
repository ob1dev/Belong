namespace WebApp.Services.Zillow.SearchResults
{
  public class DeepSearchResults
  {
    public Zestimate Zestimate { get; set; }

    public RentZestimate RentZestimate { get; set; }

    public DeepSearchResults()
    {
    }

    public DeepSearchResults(Zestimate zestimate, RentZestimate rentZestimate)
    {
      this.Zestimate = zestimate;
      this.RentZestimate = rentZestimate;
    }
  }
}