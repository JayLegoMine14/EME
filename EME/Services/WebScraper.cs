using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EME.Objects;
using HtmlAgilityPack;

namespace EME.Services
{
    public class WebScraper
    {
        public static string GetTitle(string url)
        {
            var html = @url;
            HtmlWeb web = new HtmlWeb();
            try
            {
                var htmlDoc = web.Load(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

                return node == null ? url : node.InnerHtml;
            }
            catch (Exception ex)
            {
                return url;
            }
        }

        public static object[] GetText(string url, string name)
        {
            var html = @url;

            HtmlWeb web = new HtmlWeb();
            List<string> paragraphs = new List<string>();
            var title = "";
            try
            {
                var htmlDoc = web.Load(html);
                if (htmlDoc.DocumentNode.SelectNodes("//div/p") != null)
                {
                    foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//div/p"))
                    {
                        if (node.InnerText.ToLower().Contains(name.ToLower()))
                        {
                            paragraphs.Add(node.InnerText.Replace("\"", " "));
                        }
                    }
                }

                 var node2 = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
                 title = node2 == null ? url : node2.InnerHtml;
            }
            catch { };
            return new object[] { title, paragraphs };
        }
    }
}
