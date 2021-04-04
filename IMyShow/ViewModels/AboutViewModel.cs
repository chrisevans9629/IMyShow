using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows.Input;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;

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
        public DateTime Date { get; internal set; }
        public string ImageUrl { get; set; }
    }

    public class RssFeed
    {
        public RssFeed()
        {

        }
        public ObservableCollection<RssItem> Items { get; set; } = new ObservableCollection<RssItem>();

        public void Load()
        {
            string url = "https://chrisevans9629.github.io/feed.xml";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                
                String summary = item.Summary.Text;
                
                Items.Add(new RssItem
                {
                    Title = item.Title.Text,
                    Summary = item.Title.Text,
                    Categories = item.Categories.Select(p => p.Name),
                    Date = item.PublishDate.LocalDateTime,
                    //ImageUrl = 
                });
            }
        }
    }

    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            Feed.Load();
            OpenWebCommand = new Command(async a => await Browser.OpenAsync(a.ToString()));
        }
        public Prompts Prompts { get; set; } = new Prompts();
        public ICommand OpenWebCommand { get; }
        public RssFeed Feed { get; set; } = new RssFeed();
    }
}