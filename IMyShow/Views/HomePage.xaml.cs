using IMyShow.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMyShow.Views
{

    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((BaseViewModel)this.BindingContext).OnAppearing();

            this.Opacity = 0;
            this.FadeTo(1, 500);
            profileImg.TranslationY = -200;
            profileImg.TranslateTo(0, 0, 1000, Easing.SinInOut);

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((BaseViewModel)this.BindingContext).OnDisappearing();
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

        private void collection_ScrollToRequested(object sender, ScrollToRequestEventArgs e)
        {
            
        }

        private void collection_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            Console.WriteLine(e.VerticalOffset);
        }
    }
}