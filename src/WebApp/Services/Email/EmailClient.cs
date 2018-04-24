using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using WebApp.Models;

namespace WebApp.Services.Email
{
  public class EmailClient
  {
    private HttpClient client;
    private ILogger<EmailClient> logger;
    private IConfiguration configuration;

    public EmailClient(HttpClient client, ILogger<EmailClient> logger, IConfiguration configuration)
    {
      this.client = client;
      this.logger = logger;
      this.configuration = configuration;
    }

    public async void SendSingleMessage(string emailAddress, string messageSubject, string messageBody)
    {
      var url = $"workflows/{configuration["EmailApi:WorkflowId"]}/triggers/manual/paths/invoke";
      var queryStringParam = $"?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig={configuration["EmailApi:SAS"]}";

      try
      {
        var contentObject = new { Email = emailAddress, Subject = messageSubject, Body = messageBody };
        var content = new StringContent(JsonConvert.SerializeObject(contentObject), System.Text.Encoding.UTF8, "application/json");

        var response = await this.client.PostAsync(url + queryStringParam, content);
        response.EnsureSuccessStatusCode();

        return;
      }
      catch (HttpRequestException ex)
      {
        this.logger.LogError($"An error occured connecting to values API {ex.ToString()}");
      }
    }

    public void SendSignupMessage (AccountModel account)
    {
      this.SendSingleMessage(account.Email, this.BuildMessaageSubject(account), BuildMessaageBody(account));
    }

    private string BuildMessaageSubject(AccountModel account)
    {
      return "Welcome to B4G";
    }

    private string BuildMessaageBody(AccountModel account)
    {
      var rentEstimates = account.RentEstimates.First();
      var address = rentEstimates.Address;

      var message = new StringBuilder();

      message.Append($@"<p>Hi <strong>{account.FirstName}</strong>,</p>
                        <p>Thanks for joining, we can’t wait to see what your next home will look like!</p>");

      message.Append($@"<p>Account Info:</p>
                        <ul>
                          <li><strong>First name:</strong> {account.FirstName}</li>
                          <li><strong>Last name:</strong> {account.LastName}</li>
                          <li><strong>Email address:</strong> {account.Email}</li>
                          <li><strong>Phone number:</strong> {account.Phone}</li>
                          <li><strong>IP address:</strong> {new IPAddress(account.IpAddress).ToString()}</li>
                        </ul>");

      message.Append($@"<p>Address Info:</p> 
                        <ul>
                          <li><strong>Address:</strong> {address.StreetNumber} {address.StreetName}</li>
                          <li><strong>City:</strong> {address.City}</li>
                          <li><strong>State:</strong> {address.State}</li>
                          <li><strong>Postal Code:</strong> {address.PostalCode}</li>
                          <li><strong>Country:</strong> {address.Country}</li>
                        </ul>");

      message.Append($@"<p>Rent Estimate Info:</p>
                        <ul>
                          <li><strong>Estimate rent:</strong> between ${rentEstimates.RentZestimateLow} and ${rentEstimates.RentZestimateLow}</li>
                          <li><strong>Expected rent:</strong> {rentEstimates.ExpectedRent}</li>
                        </ul> ");

      message.Append("Sincerely,<br />");
      message.Append("The B4G Team.");

      return message.ToString();
    }
  }
}