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
        protected override void OnSizeAllocated(double width, double height)
        {
            if (width > height)
            {
                layout.Span = 2;
            }
            else
            {
                layout.Span = 1;
            }
            base.OnSizeAllocated(width, height);
        }
    }
}