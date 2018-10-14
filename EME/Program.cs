using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.Util;
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

            //var someText = "";
            //Google.Cloud.Language.V1.Sentiment sentiment = NaturalLanguageAnalysis.getSentiment(someText);
            //System.Diagnostics.Debug.WriteLine("Sentiment: " + sentiment.Score);
            //System.Diagnostics.Debug.WriteLine("Magnitude: " + sentiment.Magnitude);
            //System.Diagnostics.Debug.WriteLine(NaturalLanguageAnalysis.sentimentToString(sentiment));

            //Webpage w1 = new Webpage("https://www.nytimes.com/2018/07/09/opinion/editorials/trump-kavanaugh-supreme-court-senate.html"
            //                                , "There’s So Much You Don’t Know About Brett Kavanaugh");
            //Webpage w2 = new Webpage("https://www.forbes.com/sites/stevedenning/2018/10/11/chief-justice-roberts-requests-tenth-circuit-to-investigate-kavanaugh-ethics-questions/#452ff9e11877"
            //                                , "Chief Justice Roberts Requests Tenth Circuit To Investigate Kavanaugh Ethics Questions");
            //Webpage w3 = new Webpage("https://www.usatoday.com/story/news/politics/onpolitics/2018/10/12/brett-kavanaugh-poll-majority-americans-disapprove-new-justice/1616237002/"
            //                                , "Majority of Americans disapprove of Brett Kavanaugh, want further investigation: Poll");
            //Webpage w4 = new Webpage("https://nypost.com/2018/10/12/brooklyn-witches-are-planning-to-put-a-curse-on-brett-kavanaugh/"
            //                                , "Brooklyn witches are planning to put a curse on Brett Kavanaugh");
            //Webpage w5 = new Webpage("https://www.cnn.com/2018/09/17/politics/brett-kavanaugh-testimony/index.html"
            //                                , "Brett Kavanaugh, Christine Blasey Ford to testify on assault allegations in public Monday");

            //Paragraph p1 = new Paragraph(w1, 1, "So what can the American people hope to know in the days ahead about Brett Kavanaugh, President Trump’s latest candidate for the Supreme Court, who will very shortly hold one of the most powerful unelected jobs in government and wield profound influence over their daily lives? An awful lot, and yet, at the same time, so alarmingly little.", "Kavanaugh");
            //Paragraph p2 = new Paragraph(w2, 1, "The complaints were not made without legal basis. More than 2,400 law professors have determined that Kavanaugh has displayed a lack of judicial temperament that would be disqualifying for any court.", "Kavanaugh");
            //Paragraph p3 = new Paragraph(w3, 1, "The poll found 51 percent of Americans disapprove of Kavanaugh being on the Supreme Court while 41 percent approve. It also found a majority of people believed the Senate Judiciary Committee did not do enough to investigate the allegations of sexual assault by Kavanaugh. ", "Kavanaugh");
            //Paragraph p4 = new Paragraph(w4, 1, "The hex against Kavanaugh is about exacting justice that would otherwise be denied to you,” Bracciale said, and meant to be cathartic for survivors of sexual assault.", "Kavanaugh");
            //Paragraph p5 = new Paragraph(w5, 1, "According to multiple sources, Kavanaugh also has hired Beth Wilkinson, of the law firm Wilkinson Walsh and Eskovitz, to be his attorney. Wilkinson has not returned calls from CNN seeking comment.", "Kavanaugh");

            //List<Paragraph> ps = new List<Paragraph>();
            //ps.Add(p1);
            //ps.Add(p2);
            //ps.Add(p3);
            //ps.Add(p4);
            //ps.Add(p5);

            //ps = NaturalLanguageAnalysis.analyzeSentiment(ps);

            //foreach (Paragraph p in ps)
            //{
            //    System.Diagnostics.Debug.WriteLine(p.Text);
            //    System.Diagnostics.Debug.WriteLine("");
            //    System.Diagnostics.Debug.WriteLine("(" + p.Sentiment + ", " + p.Magnitude + ") " + p.sentimentString);
            //    System.Diagnostics.Debug.WriteLine("");
            //}
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
