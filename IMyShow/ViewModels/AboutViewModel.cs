using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows.Input;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace IMyShow.ViewModels
{
    public enum PromptState
    {
        Adding,
        Removing
    }
    public class RssItem
    {
        public string Title { get; internal set; }
        public string Summary { get; internal set; }
        public IEnumerable<string> Categories { get; internal set; }
        public DateTimeOffset Date { get; internal set; }
        public string ImageUrl { get; set; }
    }

    public class RssFeed
    {
        public RssFeed()
        {

        }
        public ObservableCollection<RssItem> Items { get; set; } = new ObservableCollection<RssItem>();

        public async Task Load()
        {
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
                Categories = p.Elements(XName.Get("category", nameSpace)).Select(r => r.Attribute(XName.Get("term")).Value).ToList()
            }).ToList();

            blogs.ForEach(p => Items.Add(p));
        }
    }

    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async a => await Browser.OpenAsync(a.ToString()));
            Load();
        }

        async void Load()
        {
            IsBusy = true;
            try
            {
                await Feed.Load();
            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
        public Prompts Prompts { get; set; } = new Prompts();
        public ICommand OpenWebCommand { get; }
        public RssFeed Feed { get; set; } = new RssFeed();
    }
}