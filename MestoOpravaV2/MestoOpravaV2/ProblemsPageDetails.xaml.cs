using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsPageDetails : ContentPage
    {
        public ProblemsPageDetails(int postID)
        {
            InitializeComponent();
        }
        
        private string _selectedPlaceId;
        public string SelectedPlaceId
        {
            get => _selectedPlaceId;
            set
            {
                _selectedPlaceId = value;
            }
        }

    }
}