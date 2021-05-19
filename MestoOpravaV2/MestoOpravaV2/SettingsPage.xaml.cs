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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        async void NameChangeClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        async void PasswordChangeClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        async void ProfilePictureChangeClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}