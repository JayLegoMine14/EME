using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Objects
{
    public class Webpage
    {
        public Webpage(string pUrl, string pTitle)
        {
            Url = pUrl;
            Title = pTitle;
        }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
