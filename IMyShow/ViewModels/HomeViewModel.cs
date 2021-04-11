using IMyShow.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows.Input;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IMyShow.ViewModels
{

    public class HomeViewModel : BaseViewModel
    {
        private List<RssItem> topItems;

        public HomeViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async a => await Browser.OpenAsync(a.ToString()));
            Load();
            RefreshCommand = new Command(Load);
            ViewAllCommand = new Command(ViewAll);
        }

        private async void ViewAll()
        {
            await Shell.Current.GoToAsync(nameof(BlogsPage));
        }

        async void Load()
        {
            IsBusy = true;
            try
            {
                await Feed.Load();
                TopItems = Feed.Items.Take(5).ToList();
            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
        public List<RssItem> TopItems { get => topItems; set => SetProperty(ref topItems, value); }
        public ICommand RefreshCommand { get; set; }
        public ICommand ViewAllCommand { get; set; }

        public Prompts Prompts { get; set; } = new Prompts();
        public ICommand OpenWebCommand { get; }
        public RssFeed Feed { get; set; } = new RssFeed();
    }
}