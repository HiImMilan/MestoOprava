using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using MestoOpravaV2.Utils;
using Rg.Plugins.Popup.Services;
using MestoOpravaV2.POPUPS;

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

        
        public MainDataMVM()
        {
            places = new ObservableCollection<Post>();
            addData();
        }

        private async void addData()
        {
            try
            {
                List<Post> posts = await ServerManager.serverManager.GetPostData();
                foreach (var item in posts)
                {
                    Places.Add(item);
                }
            }
            catch (Exception e)
            {
                throw e; 
            }
            
        }
    }
}
