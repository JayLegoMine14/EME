using EME.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Services
{
    public class TestService
    {
        public static Image GetTestImage()
        {
            return new Image()
            {
                Webpage = new Webpage()
                {
                    Url = "www.google.com",
                    Title = "Google"
                },
                Confidence = .8,
                ImageUrl = "https://www.catster.com/wp-content/uploads/2017/08/A-brown-cat-licking-its-lips.jpg",
                Sentiment = .8
            };
        }

        public static Paragraph GetTestParagraph()
        {
            return new Paragraph()
            {
                Webpage = new Webpage()
                {
                    Url = "www.google.com",
                    Title = "Google"
                },
                Confidence = .8,
                Text = "Hey, James Allison is an awesome person.",
                Name = "James Allison",
                Sentiment = .8,
                Magnitude = .6,
                SentimentString = "Positive"
            };
        }
    }
}
