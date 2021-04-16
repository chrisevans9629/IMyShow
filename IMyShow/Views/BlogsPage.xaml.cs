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
            base.OnAppearing();

            blogsList.ItemAppearing += BlogsList_ItemAppearing;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            blogsList.ItemAppearing -= BlogsList_ItemAppearing;
        }

        private void BlogsList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
        }
    }
}