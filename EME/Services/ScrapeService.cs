using EME.Objects;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EME.Services
{
    public class ScrapeService
    {
        private static readonly int NAME_INDEX = 0;
        private static readonly int URL_INDEX = NAME_INDEX + 1;
        private static readonly int TITLE_INDEX = URL_INDEX + 1;
        private static readonly int IMAGE_URLS_INDEX = TITLE_INDEX + 1;
        private static readonly int PARAGRAPHS_INDEX = IMAGE_URLS_INDEX + 1;

        public static object[] Scrape(Dictionary<Name, List<string>> scrapeCriteria)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            List<Image> images = new List<Image>();

            foreach (Name name in scrapeCriteria.Keys)
            {
                StringBuilder urls = new StringBuilder();
                foreach (string url in scrapeCriteria.GetValueOrDefault(name))
                    urls.Append(url + " ");
                string args = string.Format("C:\\Users\\Dakota.DESKTOP-R1IRH6L\\Documents\\GitHub\\EME\\get_text.py -name {0} -urls {1}", name.Value, urls.ToString().Trim());
                Process p = new Process
                {
                    StartInfo = new ProcessStartInfo("C:\\Users\\Dakota.DESKTOP-R1IRH6L\\Anaconda3\\python.exe"
                        , args)
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };

                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                foreach (string temp in output.Split("|"))
                {
                    string[] group = temp.Split(',');
                    if (group.Length > IMAGE_URLS_INDEX)
                    {
                        foreach (string imageUrl in group[IMAGE_URLS_INDEX].Split("\r\n"))
                        {
                            if (!string.IsNullOrEmpty(imageUrl)
                                && !string.IsNullOrWhiteSpace(imageUrl)
                                && (imageUrl.EndsWith(".jpeg")
                                || imageUrl.EndsWith(".jpg")))
                            {
                                images.Add(new Image
                                {
                                    Webpage = new Webpage { Url = group[URL_INDEX], Title = group[TITLE_INDEX] },
                                    ImageUrl = imageUrl,
                                    Confidence = name.Confidence
                                });
                            }
                        }
                    }
                }

                foreach (string url in scrapeCriteria.GetValueOrDefault(name))
                {
                    var data = WebScraper.GetText(url, name.Value);
                    List<string> pars = data[1] as List<string>;
                    string title = data[0] as string;

                    foreach (string par in pars)
                    {
                        paragraphs.Add(new Paragraph
                        {
                            Webpage = new Webpage { Title = title, Url = url },
                            Text = par,
                            Name = name.Value,
                            Confidence = name.Confidence
                        });
                    }
                }
            }
            return new object[] { images, paragraphs };
        }
    }
}