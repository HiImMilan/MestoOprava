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
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage(), true);
        }

        async void RegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage(), true);
        }
    }
}