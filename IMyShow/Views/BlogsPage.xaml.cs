using IMyShow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMyShow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogsPage : ContentPage
    {
        public BlogsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            ((BaseViewModel)this.BindingContext).OnAppearing();

            var children = blogsList.Children.Take(10).ToList();

            foreach (var item in children)
            {
                item.TranslationX = item.Width;
                item.Opacity = 0;
            }
            var time = 500u;
            foreach (var item in children)
            {
                item.FadeTo(1, time, Easing.SinIn);
                await item.TranslateTo(0, 0, time, Easing.SinIn);
            }

            base.OnAppearing();
        }
    }
}