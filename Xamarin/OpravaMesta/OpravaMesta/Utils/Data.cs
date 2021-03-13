using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OpravaMesta
{
    public class Data : INotifyPropertyChanged
    {
        

        private string creator;
        private string name;
        private string description;
        private string latitude;
        private string longitude;
        private string url;
        
        public string Creator {
            get { return creator; }
            set { creator = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public ObservableCollection<Data> Datas { get; set; }


    }
  }