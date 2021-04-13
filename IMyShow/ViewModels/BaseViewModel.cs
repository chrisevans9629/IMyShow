﻿using IMyShow.Models;
using IMyShow.Services;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IMyShow.ViewModels
{
    public class BaseViewModel : Bindable
    {
        public BaseViewModel()
        {
            //OpenWebCommand = new Command(async a => await Browser.OpenAsync(a.ToString()));
            OpenWebCommand = new Command(async a => await Shell.Current.GoToAsync($"BlogDetailPage?Url={a}", true));
            NavigateCommand = new Command(async a => await Shell.Current.GoToAsync(a.ToString(), true));
        }
        public ICommand OpenWebCommand { get; }
        public ICommand NavigateCommand { get; }
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public virtual void OnAppearing()
        {

        }
        
    }
}
