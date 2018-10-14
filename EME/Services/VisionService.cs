using EME.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EME.Services
{
    public class VisionService
    {
        public static void AnalyseImages(User u, List<Image> images, List<Paragraph> pars)
        {
            List<string> userFaceIds = new List<string>();
            foreach(String path in u.ImagePaths)
            {
                userFaceIds.Add(GetFaceID(path).Result);
            }

            foreach(Image i in images)
            {
                List<double> values = new List<double>();
                foreach(string faceID in userFaceIds)
                {
                    values.Add(CompareImages(faceID, i.ImageUrl).Result);
                }

                var confidenceBoost = values.Sum() / values.Count;             
                if (confidenceBoost > .6)
                    i.Confidence += confidenceBoost;
                else
                    i.Confidence -= (1 - confidenceBoost);

                List<Paragraph> matchingPars = pars.Where(p => p.Webpage.Title == i.Webpage.Title).ToList();
                foreach(Paragraph p in matchingPars)
                {
                    if (confidenceBoost > .6)
                        p.Confidence += (confidenceBoost / 2);
                }
            }
        }

        public static async Task<string> GetFaceID(string path)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fbe70a46c11a402b930d0452938ad89b");

            HttpResponseMessage response;

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            var uri2 = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?" + queryString;
            var content2 = new ByteArrayContent(File.ReadAllBytes(path));
            content2.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response = await client.PostAsync(uri2, content2);
            var jsonString2 = await response.Content.ReadAsStringAsync();
            JArray jot2 = JArray.Parse(jsonString2);
            JToken jo2 = jot2[0];

            return jo2["faceId"].ToString();
        }


        public static async Task<double> CompareImages(string faceID2, string url)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fbe70a46c11a402b930d0452938ad89b");

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?" + queryString;

            HttpResponseMessage response;

            // Request body
            string json = "{\"url\":\"" + url + "\"}";

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");        
            response = await client.PostAsync(uri, content);
            if (response.StatusCode.ToString() == "429") return 0;
            var jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);
            if (jsonString == "[]") return 0.0;
            JArray jot = JArray.Parse(jsonString);
            if (jot.Count == 0) return 0.0;
            JToken jo = jot[0];

            string faceID1 = jo["faceId"].ToString();

            var uri3 = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify";

            string json3 = "{\"faceId1\":\"" + faceID1 +"\", \"faceId2\":\"" + faceID2 + "\"}";

            StringContent content3 = new StringContent(json3, Encoding.UTF8, "application/json");
            response = await client.PostAsync(uri3, content3);
            var jsonString3 = await response.Content.ReadAsStringAsync();
            JObject jo3 = JObject.Parse(jsonString3);
            if (jo3["confidence"] == null) return 0;

            return Double.Parse(jo3["confidence"].ToString());
        }
    }
}
