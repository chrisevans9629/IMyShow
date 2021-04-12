using IMyShow.Themes;
using IMyShow.ViewModels;
using IMyShow.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IMyShow
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private void Dark_Clicked(object sender, EventArgs e)
        {
            ChangeTheme(new DarkTheme());
        }

        private void Light_Clicked(object sender, EventArgs e)
        {
            ChangeTheme(new LightTheme());
        }

        void ChangeTheme(ResourceDictionary dict)
        {
            var themes = Application.Current.Resources.MergedDictionaries;
            if (themes != null)
            {
                themes.Clear();
                themes.Add(dict);
            }
        }
    }
}
