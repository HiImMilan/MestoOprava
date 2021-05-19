using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        string previousPage;
        
        public RegisterPage()
        {
            InitializeComponent();
        }
        
        public RegisterPage(string previousPage)
        {
            this.previousPage = previousPage;
            InitializeComponent();
        }
        async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage("RegisterPage"));
        }
        
        async void RegisterClicked(object sender, EventArgs e)
        {
             await Navigation.PushModalAsync(new ProblemsPage());
        }

        
    }
}