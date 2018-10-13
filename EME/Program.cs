using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EME.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace EME
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // James' stuff
            //List<string> urls = BingService.GetURLs("Thomas Aquines");
            //BuildWebHost(args).Run();

            var someText = "Donald Trump sucks eggs.";
            Google.Cloud.Language.V1.Sentiment sentiment = NaturalLanguageAnalysis.getSentiment(someText);
            System.Diagnostics.Debug.WriteLine("Sentiment: " + sentiment.Score);
            System.Diagnostics.Debug.WriteLine("Magnitude: " + sentiment.Magnitude);
            System.Diagnostics.Debug.WriteLine(NaturalLanguageAnalysis.sentimentToString(sentiment));

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
