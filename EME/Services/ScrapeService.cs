using EME.Objects;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EME.Services
{
    public class ScrapeServices
    {
        private static readonly int URL_INDEX = 0;
        private static readonly int TITLE_INDEX = 1;
        private static readonly int IMAGE_URLS_INDEX = 2;
        private static readonly int PARAGRAPHS_INDEX = 3;

        public static object[] Scrape(Dictionary<Name, List<string>> scrapeCriteria)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            List<Image> images = new List<Image>();

            foreach (Name name in scrapeCriteria.Keys)
            {
                StringBuilder urls = new StringBuilder();
                foreach (string url in scrapeCriteria.GetValueOrDefault(name))
                    urls.Append(url + ",");
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = "C:\\Users\\Dakota.DESKTOP-R1IRH6L\\Anaconda3\\python.exe",
                    Arguments = string.Format("{0} {1}", name.Value, urls.ToString()),
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        foreach (string temp in reader.ReadToEnd().Split("|"))
                        {
                            string[] group = temp.Split(',');

                            foreach (string imageUrl in group[IMAGE_URLS_INDEX].Split(' '))
                            {
                                images.Add(new Image
                                {
                                    Webpage = new Webpage { Url = group[URL_INDEX], Title = group[TITLE_INDEX]},
                                    ImageUrl = imageUrl
                                });
                            }

                            foreach (string paragraph in group[PARAGRAPHS_INDEX].Split(' '))
                            {
                                paragraphs.Add(new Paragraph {
                                    Webpage = new Webpage { Title = group[TITLE_INDEX], Url = group[URL_INDEX] },
                                    Text = paragraph
                                });
                            }
                        }
                    }
                }
            }
            return new object[] { images, paragraphs };
        }
    }
}