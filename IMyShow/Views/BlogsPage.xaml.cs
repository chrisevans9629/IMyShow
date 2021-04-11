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

        protected override void OnAppearing()
        {
            ((BaseViewModel)this.BindingContext).OnAppearing();
            base.OnAppearing();
        }
    }
}