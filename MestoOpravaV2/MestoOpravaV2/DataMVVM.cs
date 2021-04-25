using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MestoOpravaV2
{
    public class DataViewModel : INotifyPropertyChanged
    {
        readonly IList<Data> source;

        public ObservableCollection<Data> Datas { get; set; }

        public DataViewModel()
        {
            source = new List<Data>();
            Datas = new ObservableCollection<Data>(source);
        }

        void CreateDataCollection()
        {
            
            source.Add(new Data
            {
                Creator = "", Description = "idk"
            });

           
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        #endregion
    }
}