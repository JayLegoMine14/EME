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

            List<Image> testImages = new List<Image>();
            testImages.Add(TestService.GetTestImage());
            testImages.Add(TestService.GetTestImage());
            testImages.Add(TestService.GetTestImage());

            List<Paragraph> testPars = new List<Paragraph>();
            testPars.Add(TestService.GetTestParagraph());
            testPars.Add(TestService.GetTestParagraph());
            testPars.Add(TestService.GetTestParagraph());

            object[] scrapeResult = new object[] { testImages, testPars };

            scrapeResult[0] = (scrapeResult[0] as List<Image>).OrderByDescending(i => i.Confidence);
            scrapeResult[1] = (scrapeResult[1] as List<Paragraph>).OrderByDescending(i => i.Confidence);

            return scrapeResult;
        }
    }
}
