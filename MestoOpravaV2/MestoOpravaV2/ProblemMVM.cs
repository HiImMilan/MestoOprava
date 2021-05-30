using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MestoOpravaV2
{
    public class ProblemMVM : INotifyPropertyChanged
    {
        private string name;
        private string email;
        public static IList<Problem> _IList { get; set; }

        public ProblemMVM()
        {
            _IList = new List<Problem>();
            _IList.Add(new Problem {Name = "Erika", Email = "slovencina@spsit.com"});
            _IList.Add(new Problem {Name = "Pave IV", Email = "vipipavel@spsit.com"});
            _IList.Add(new Problem {Name = "OSY", Email = "srsne@spsit.com"});
            
            
        }
        
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static IEnumerable<Problem> GetSearchResult(string searchtext)
        {
            IEnumerable<Problem> searchresult = _IList.Where(c => c.Name.Contains(searchtext));
            return searchresult;
        }
    }
}