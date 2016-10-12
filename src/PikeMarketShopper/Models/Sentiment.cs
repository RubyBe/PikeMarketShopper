using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikeMarketShopper.Models
{
  public class Sentiment
  {
    public int Id { get; set; }
    public string Language { get; set; }
    public string Text { get; set; }

    public void Send()
    {
      Console.WriteLine("Top Line of Send");
      var client = new RestClient("https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment");
      var request = new RestRequest("5d3daed372b24b6ab9c60c4c85694893", Method.POST);
      request.AddParameter("Id", Id);
      request.AddParameter("Language", Language);
      request.AddParameter("Text", Text);
      client.Authenticator = new HttpBasicAuthenticator("5d3daed372b24b6ab9c60c4c85694893", "0c40d770b6c84782b3500702769e9550");
      client.ExecuteAsync(request, response =>
      {
        Console.WriteLine(response.Content);
      });
    }
    public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
    {
      var tcs = new TaskCompletionSource<IRestResponse>();
      theClient.ExecuteAsync(theRequest, response => {
        tcs.SetResult(response);
      });
      return tcs.Task;
    }
  }
}
