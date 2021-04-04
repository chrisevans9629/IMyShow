using System;
using System.Timers;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IMyShow.ViewModels
{
    public class Prompts : Bindable
    {
        Timer timer = new Timer();
        private string currentText;

        public Prompts()
        {
            TextPrompts = new[]
            {
              "Welcome to my site!",
              "I am a software developer",
              "Console.WriteLine(\"My favorite language is C#\");",
              "printfn \"But I also love F#\"",
              "print(\"and python!\")",
              "This site was built with jekyll...",
              "and is hosted by github pages.",
              "Hope you enjoy and please follow me on github!",
            };
            Delay = 1000;
            timer.AutoReset = true;
            timer.Interval = 100;
            timer.Start();

            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var prompt = TextPrompts[PromptIndex];
            if (TextIndex >= prompt.Length)
            {
                TextIndex = 0;
                PromptIndex++;
                CurrentText = "";
                if (PromptIndex >= TextPrompts.Length)
                {
                    PromptIndex = 0;
                }
            }
            CurrentText += TextPrompts[PromptIndex][TextIndex];
            TextIndex++;
        }
        public int PromptIndex { get; set; }
        public int TextIndex { get; set; }
        public string CurrentText
        {
            get => currentText;
            set => SetProperty(ref currentText, value);
        }
        public int Delay { get; set; }
        public string[] TextPrompts { get; set; }
    }

    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }
        public Prompts Prompts { get; set; } = new Prompts();
        public ICommand OpenWebCommand { get; }
    }
}