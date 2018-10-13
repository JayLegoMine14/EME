using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Objects
{
    public class Image
    {
        public Webpage Webpage { get; set; }
        public double Confidence { get; set; }
        public string ImageUrl { get; set; }
        public double Sentiment { get; set; }
    }
}
