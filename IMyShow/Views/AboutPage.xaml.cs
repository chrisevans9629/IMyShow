using System;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMyShow.Views
{

    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            profileImage.Opacity = 0;


            profileImage.FadeTo(1, 2000);
        }
    }
}