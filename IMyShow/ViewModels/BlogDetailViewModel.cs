using System;
using System.Collections.Generic;
using System.Text;

namespace IMyShow.ViewModels
{
    public class BlogDetailViewModel : BaseViewModel
    {
        private string url;

        public string Url { get => url; set => SetProperty(ref url, value); }
    }
}
