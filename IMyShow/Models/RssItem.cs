using System;
using System.Collections.Generic;

namespace IMyShow.ViewModels
{
    public class RssItem
    {
        public string Title { get; internal set; }
        public string Summary { get; internal set; }
        public IEnumerable<string> Categories { get; internal set; }
        public DateTimeOffset Date { get; internal set; }
        public string ImageUrl { get; set; }
        public string Url { get; internal set; }
    }
}