using System;
using System.Collections.Generic;
using System.Text;

namespace IMyShow.ViewModels
{



    public class BlogsViewModel : BaseViewModel
    {
        public BlogsViewModel()
        {

        }
        public RssFeed Feed { get; set; } = RssFeed.Current;
        public override void OnAppearing()
        {

            base.OnAppearing();
        }

    }
}
