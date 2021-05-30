using System.ComponentModel;
using System.Net.Security;
using System.Runtime.CompilerServices;
using MestoOpravaV2.POPUPS;
using Xamarin.Essentials;

namespace MestoOpravaV2
{
    public class UserDataMVM : INotifyPropertyChanged
    {
        private string name;
        private string email;
        private string password;


        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(name));
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(email));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}