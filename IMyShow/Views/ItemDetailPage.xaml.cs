using IMyShow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IMyShow.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}