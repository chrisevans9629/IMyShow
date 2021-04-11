using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace IMyShow.ViewModels
{
    public class AboutService
    {
        public void Load()
        {
            var url = "https://raw.githubusercontent.com/chrisevans9629/chrisevans9629.github.io/master/_data/profile.yml";


        }
    }

    public class RssFeed
    {
        public static RssFeed Current { get; } = new RssFeed();
        private RssFeed()
        {
        }
        public ObservableCollection<RssItem> Items { get; set; } = new ObservableCollection<RssItem>();

        public async Task Load()
        {
            Items.Clear();
            string url = "https://chrisevans9629.github.io/feed.xml";
            var client = new HttpClient();

            var xmlStr = await client.GetStringAsync(url);

            var xml = XDocument.Parse(xmlStr);

            var nameSpace = "http://www.w3.org/2005/Atom";

            var entries = xml.Root.Elements(XName.Get("entry", nameSpace)).ToList();
            var media = "http://search.yahoo.com/mrss/";
            var blogs = entries.Select(p => new RssItem
            {
                Title = p.Element(XName.Get("title", nameSpace)).Value,
                Summary = p.Element(XName.Get("summary", nameSpace)).Value,
                ImageUrl = p.Element(XName.Get("content", media))?.Attribute(XName.Get("url"))?.Value,
                Date = DateTimeOffset.Parse(p.Element(XName.Get("published", nameSpace)).Value),
                Categories = p.Elements(XName.Get("category", nameSpace)).Select(r => r.Attribute(XName.Get("term")).Value).ToList(),
                Url = p.Element(XName.Get("link", nameSpace)).Attribute("href").Value,
            }).ToList();

            blogs.ForEach(p => Items.Add(p));
        }
    }
}