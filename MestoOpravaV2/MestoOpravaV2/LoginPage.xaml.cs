using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        string previousPage;

        public LoginPage()
        {
            InitializeComponent();
        }
        
        public LoginPage(string previousPage)
        {
            this.previousPage = previousPage;
            InitializeComponent();
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProblemsPage(), true);
        }

        async void RegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage(), true);
        }
    }
}