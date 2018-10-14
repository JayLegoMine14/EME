using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Objects
{
    public class Paragraph
    {
        public Paragraph() { }
        public Paragraph(Webpage pWebpage, double pConfidence, string pText, string pName)
        {
            Webpage = pWebpage;
            Confidence = pConfidence;
            Text = pText;
            Name = pName;
        }
        public Webpage Webpage { get; set; }
        public double Confidence { get; set; }
        public string Text { get; set; }
        public string Name {get; set;}
        public double Sentiment { get; set; }
        public double Magnitude { get; set; }
        public string SentimentString { get; set; }
    }
}
