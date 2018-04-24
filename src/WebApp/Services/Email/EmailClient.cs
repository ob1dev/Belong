using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

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

    public async void SendSingleMessage(string emailAddress, string subject, string body)
    {
      var url = $"workflows/{configuration["EmailApi:WorkflowId"]}/triggers/manual/paths/invoke";
      var queryStringParam = $"?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig={configuration["EmailApi:SAS"]}";

      try
      {
        var contentObject = new { Email = emailAddress, Subject = subject, Body = body };
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
  }
}