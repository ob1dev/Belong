using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApp.Models;
using WebApp.Services.Zillow.SearchResults;

namespace WebApp.Services.Zillow
{
  public class ZillowClient
  {
    private HttpClient client;
    private ILogger<ZillowClient> logger;
    private IConfiguration configuration;

    public ZillowClient(HttpClient client, ILogger<ZillowClient> logger, IConfiguration configuration)
    {
      this.client = client;
      this.logger = logger;
      this.configuration = configuration;
    }

    public async Task<DeepSearchResults> GetDeepSearchResults(AddressModel address)
    {
      return await this.GetDeepSearchResults(address, true);
    }

    public async Task<DeepSearchResults> GetDeepSearchResults(AddressModel address, bool includeRentZestimate)
    {
      var streetNumberName = $"{address.StreetNumber}+{address.StreetName}";
      var cityStateZip = $"{address.City},+{address.State},+{address.PostalCode}";
      var url = "webservice/GetDeepSearchResults.htm";
      var queryStringParam = $"?zws-id={this.configuration["ZillowApi:ZWSID"]}&address={streetNumberName}&citystatezip={cityStateZip}&rentzestimate={includeRentZestimate}";
      
      try
      {
        var response = await this.client.GetAsync(url + queryStringParam);
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();
        var reader = new StreamReader(stream);
        var result = await XDocument.LoadAsync(reader, LoadOptions.None, CancellationToken.None);

        var zestimate = this.GetZestimate(result);
        var rentZestimate = (zestimate != null && includeRentZestimate) ? this.GetRentZestimate(result) : null;

        return new DeepSearchResults(zestimate, rentZestimate);
      }
      catch (HttpRequestException ex)
      {
        this.logger.LogError($"An error occured connecting to values API {ex.ToString()}");
        return new DeepSearchResults();
      }
    }

    private Zestimate GetZestimate(XDocument searchResult)
    {
      var amount = searchResult.Descendants("zestimate")
                               .Select(z => (string)z.Element("amount"))
                               .FirstOrDefault();

      return (amount != null) ? new Zestimate(amount) : null;
    }

    private RentZestimate GetRentZestimate(XDocument searchResult)
    {
      var valuationRange = searchResult.Descendants("rentzestimate")
                                       .Select(rs => rs.Element("valuationRange"))
                                       .FirstOrDefault();

      var rentZestimate = new RentZestimate();
      if (valuationRange != null)
      {
        rentZestimate.ValuationRange = new ValuationRange(valuationRange.Element("low").Value, valuationRange.Element("high").Value);
      }

      return rentZestimate;
    }
  }
}