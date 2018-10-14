using EME.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Services
{
    public class SearchService
    {
        public static object[] PreformSearch(User user)
        {
            Dictionary<Name, List<string>> urls = BingService.Search(user.GetNames());

            object[] scrapeResult = ScrapeService.Scrape(urls);

            scrapeResult[1] = NaturalLanguageAnalysis.analyzeSentiment(scrapeResult[1] as List<Paragraph>);
            VisionService.AnalyseImages(user, (scrapeResult[0] as List<Image>), (scrapeResult[1] as List<Paragraph>));

            scrapeResult[0] = (scrapeResult[0] as List<Image>).OrderByDescending(i => i.Confidence).Take(20).ToList();
            scrapeResult[1] = (scrapeResult[1] as List<Paragraph>).OrderByDescending(i => i.Confidence).Take(40).ToList();

            return scrapeResult;
        }
    }
}
