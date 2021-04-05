using System;
using System.ServiceModel.Syndication;
using System.Windows.Input;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IMyShow.ViewModels
{

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