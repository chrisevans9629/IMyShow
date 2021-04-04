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
            profileImage.Opacity = 0;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            profileImage.FadeTo(1);
        }
    }
}