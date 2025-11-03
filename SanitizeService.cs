using Newtonsoft.Json;
using RestSharp;

namespace WFComments2025;

public class SanitizeService
{
    private static readonly string SanitizeURL = "http://www.purgomalum.com/service/";
    public static string SanitizeTextJSON(string rawValue)
    {
        var client = new RestClient(SanitizeURL + "json");
        var request = new RestRequest();

        request.AddParameter("text", rawValue);
        var response = client.Execute(request);
        if (!string.IsNullOrWhiteSpace(response.Content))
        {
            string receivedJSON = response.Content;
            PurgoMalumJSON? sanitizedResponse = JsonConvert.DeserializeObject<PurgoMalumJSON>(receivedJSON);
            return sanitizedResponse.result;
        }

        return string.Empty;
    }
}
public class PurgoMalumJSON
{
    public string result { get; set; }
}

