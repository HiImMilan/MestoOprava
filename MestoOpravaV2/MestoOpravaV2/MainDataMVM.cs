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
using System.Threading.Tasks;

namespace MestoOpravaV2
{
    class MainDataMVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Task postRefresh;
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
        public ICommand RefreshCommand { get; set; }
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainDataMVM()
        {
            places = new ObservableCollection<Post>();
            updateData();
            RefreshCommand = new Command(async () =>
            {
                Console.WriteLine("Post refresh");
                await updateData();
                IsRefreshing = false;
            });
        }


       
        private async Task updateData()
        {
            try
            {
                
                List<Post> posts = await ServerManager.serverManager.TryGetPostData();
                Places.Clear();
                foreach (var item in posts)
                {
                    Places.Add(item);
                }
            }
            catch (Exception e)
            {
                PopupNavigation.PushAsync(new InternetError(() => this.updateData()));
            }
        }
    }
}
