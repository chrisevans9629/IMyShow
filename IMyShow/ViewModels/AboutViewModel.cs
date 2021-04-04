using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IMyShow.ViewModels
{
    public enum PromptState
    {
        Adding,
        Removing
    }

    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async a => await Browser.OpenAsync(a.ToString()));
        }
        public Prompts Prompts { get; set; } = new Prompts();
        public ICommand OpenWebCommand { get; }
    }
}