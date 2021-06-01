using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MestoOpravaV2.Utils;
using Plugin.Media;
using Xamarin.Forms;

namespace MestoOpravaV2
{
    public class ProblemMVM : INotifyPropertyChanged
    {
        private string creationID;
        private string imageURL;
        private string title;
        private string adress;


        public ProblemMVM()
        {
            InitializeAsync();
        }
        public async void InitializeAsync()
        {
            List<Post> posts = await ServerManager.serverManager.TryGetPostData();
            places = new ObservableCollection<Post>();
            places.Clear();
            foreach (var item in posts)
            {
                places.Add(item);
            }
        }
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
        public string CreationID
        {
            get => creationID;
            set
            {
                creationID = value;
                OnPropertyChanged(nameof(creationID));
            }
        }
        
        public string ImageURL
        {
            get => imageURL;
            set
            {
                imageURL = value;
                OnPropertyChanged(nameof(imageURL));
            }
        }
        
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(title));
            }
        }
        
        public string Adress
        {
            get => adress;
            set
            {
                adress = value;
                OnPropertyChanged(nameof(adress));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static IEnumerable<Problem> GetSearchResult(string searchtext)
        {
            //TODO
            return null;
        }
    }
}