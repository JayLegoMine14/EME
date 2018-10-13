using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EME.Services
{
    public class BingService
    {
        const string accessKey = "7f129a8e5e684a4386dac057694760c8";
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";

        struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }

        public static List<String> GetURLs(string searchTerm)
        {
            string JSONString = GetJSON(searchTerm);
            JObject jObject = JObject.Parse(JSONString);
            JToken jUser = jObject["webPages"];
            JToken[] sites = jUser["value"].ToArray();
            return sites.Select(s => s["url"].ToString()).ToList();
        }

        public static string GetJSON(string searchTerm)
        {
            return BingWebSearch(searchTerm).jsonResult;
        }

        static SearchResult BingWebSearch(string searchQuery)
        {
            // Construct the URI of the search request
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery) + "&count=50";

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // Create result object for return
            var searchResult = new SearchResult()
            {
                jsonResult = json,
                relevantHeaders = new Dictionary<String, String>()
            };

            // Extract Bing HTTP headers
            foreach (String header in response.Headers)
            {
                if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                    searchResult.relevantHeaders[header] = response.Headers[header];
            }

            return searchResult;
        }
    }
}
