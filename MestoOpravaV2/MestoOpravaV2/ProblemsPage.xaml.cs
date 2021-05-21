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
    public partial class ProblemsPage : ContentPage
    {
        public ProblemsPage()
        {
            InitializeComponent();
        }

        async void HomeClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        async void AddClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        async void SearchClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        async void SettingsClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SettingsPage(), true);
        }
    }
}