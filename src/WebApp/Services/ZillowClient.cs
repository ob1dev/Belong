using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApp.Models;
using WebApp.Services.SearchResults;

namespace WebApp.Services
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
    
    public async Task<System.Xml.Linq.XDocument> GetDeepSearchResults(AddressModel address, bool rentzestimate)
    {
      var streetNumberName = $"{address.StreetNumber}+{address.StreetName}";
      var cityStateZip = $"{address.City},+{address.State},+{address.PostalCode}";
      var url = "webservice/GetDeepSearchResults.htm";
      var queryStringParam = $"?zws-id={this.configuration["ZillowApi:ZWSID"]}&address={streetNumberName}&citystatezip={cityStateZip}&rentzestimate={rentzestimate}";
      
      try
      {
        var response = await this.client.GetAsync(url + queryStringParam);
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();
        var reader = new StreamReader(stream);
        return await XDocument.LoadAsync(reader, LoadOptions.None, CancellationToken.None);

      }
      catch (HttpRequestException ex)
      {
        this.logger.LogError($"An error occured connecting to values API {ex.ToString()}");
        return new XDocument();
      }
    }

    public async Task<RentZestimate> GetRentZestimate(AddressModel address)
    {
      var searchResults = await this.GetDeepSearchResults(address, true);

      var valuationRange = searchResults.Descendants("rentzestimate")
                                        .Select(pv => pv.Element("valuationRange"))
                                        .FirstOrDefault();

      var rentZestimate = new RentZestimate();
      if (valuationRange != null)
      {
        rentZestimate.ValuationRangeLow = valuationRange.Element("low").Value;
        rentZestimate.ValuationRangeHigh = valuationRange.Element("high").Value;
      }

      return rentZestimate;
    }
  }
}