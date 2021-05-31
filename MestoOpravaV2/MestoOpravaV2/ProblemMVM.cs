using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static IList<Problem> _IList { get; set; }

        public ProblemMVM()
        {
            _IList = new List<Problem>();
            _IList.Add(new Problem {CreationID = "1", ImageURL = "https://picjumbo.com/wp-content/uploads/the-golden-gate-bridge-sunset-1080x720.jpg", Title = "test1", Adress = "test1"});
            _IList.Add(new Problem {CreationID = "2", ImageURL = "https://picjumbo.com/wp-content/uploads/the-golden-gate-bridge-sunset-1080x720.jpg", Title = "test2", Adress = "test2"});
            _IList.Add(new Problem {CreationID = "3", ImageURL = "https://picjumbo.com/wp-content/uploads/the-golden-gate-bridge-sunset-1080x720.jpg", Title = "test3", Adress = "test3"});
            _IList.Add(new Problem {CreationID = "4", ImageURL = "https://picjumbo.com/wp-content/uploads/the-golden-gate-bridge-sunset-1080x720.jpg", Title = "test4", Adress = "test4"});
            _IList.Add(new Problem {CreationID = "5", ImageURL = "https://picjumbo.com/wp-content/uploads/the-golden-gate-bridge-sunset-1080x720.jpg", Title = "test5", Adress = "test5"});
            
            
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
            IEnumerable<Problem> searchresult = _IList.Where(c => c.Title.Contains(searchtext) || c.Adress.Contains(searchtext));
            return searchresult;
        }
    }
}