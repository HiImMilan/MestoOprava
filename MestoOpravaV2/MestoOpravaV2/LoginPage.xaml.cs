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
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new UserDataMVM();
            base.OnAppearing();
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