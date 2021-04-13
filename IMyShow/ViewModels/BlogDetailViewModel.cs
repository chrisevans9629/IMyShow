using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IMyShow.ViewModels
{
    [QueryProperty(nameof(Url), nameof(Url))]
    public class BlogDetailViewModel : BaseViewModel
    {
        private string url;

        public string Url { get => url; set => SetProperty(ref url, Uri.UnescapeDataString(value ?? string.Empty)); }
    }
}
