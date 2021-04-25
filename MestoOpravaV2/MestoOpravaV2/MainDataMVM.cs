using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using MestoOpravaV2.Utils;
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

        private void addData()
        {
            List<Post> posts = ServerManager.serverManager.GetPostData();
            foreach(var item in posts)
            {
                Places.Add(item);
            }
        }
    }
}
