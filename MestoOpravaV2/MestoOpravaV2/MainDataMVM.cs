using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using MestoOpravaV2.Utils;
using Rg.Plugins.Popup.Services;
using MestoOpravaV2.POPUPS;
using Xamarin.Forms;
using System.Windows.Input;

namespace MestoOpravaV2
{
    class MainDataMVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        



        private ObservableCollection<Post> Places;

        public ObservableCollection<Post> places
        {
            get { return Places; }
            set
            {
                Places = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("places"));
            }
        }
        private int _carouselPosition;
        public int CarouselPosition
        {
            get { return _carouselPosition; }
            set
            {
                _carouselPosition = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CarouselPosition"));
            }
        }
        public Post CurrentItem { get; set; }
        public MainDataMVM()
        {
            places = new ObservableCollection<Post>();
            addData();
        }


       
        private async void addData()
        {
            try
            {
                List<Post> posts = await ServerManager.serverManager.TryGetPostData();
                foreach (var item in posts)
                {
                    Places.Add(item);
                }
            }
            catch (Exception e)
            {
                PopupNavigation.PushAsync(new InternetError());
            }
            
        }
    }
}
