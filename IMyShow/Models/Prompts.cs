using System.Threading.Tasks;
using System.Timers;

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
              "Welcome to my App!",
              "I am a software developer",
              "Console.WriteLine(\"My favorite language is C#\");",
              "printfn \"But I also love F#\"",
              "print(\"and python!\")",
              "This app was built with Xamarin Forms",
              "Hope you enjoy and please follow me on github!",
            };
            Delay = 2000;
            timer.AutoReset = true;
            timer.Interval = 50;
            timer.Start();

        }

        public void Stop()
        {
            timer.Elapsed -= Timer_Elapsed;
        }

        public void Start()
        {
            timer.Elapsed += Timer_Elapsed;
        }


        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var str = CurrentText;

            var prompt = TextPrompts[PromptIndex];
            if (State == PromptState.Adding)
            {
                str += TextPrompts[PromptIndex][TextIndex];
                TextIndex++;

                if (TextIndex >= prompt.Length)
                {
                    timer.Stop();
                    await Task.Delay(Delay);
                    timer.Start();
                    State = PromptState.Removing;
                }
            }
            else
            {
                str = str.Remove(str.Length - 1, 1);

                if (str.Length <= 0)
                {
                    TextIndex = 0;
                    PromptIndex++;
                    if (PromptIndex >= TextPrompts.Length)
                    {
                        PromptIndex = 0;
                    }


                    State = PromptState.Adding;
                }
            }

            CurrentText = str;
        }
        private PromptState State;
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
}