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
    public partial class AddNewPost : ContentPage
    {
        public AddNewPost()
        {
            InitializeComponent();
        }
        
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}