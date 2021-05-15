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
            if (LoginCheck(EntryEmail.Text, EntryPassword.Text))
                await Navigation.PushModalAsync(new ProblemsPage());
            else
                // tu dajte ten pop-up
                ;
        }
        
        async void RegisterClicked(object sender, EventArgs e)
        {
            if (previousPage == "RegisterPage")
                await Navigation.PopModalAsync();
            await Navigation.PushModalAsync(new RegisterPage("LoginPage"));
        }

        bool LoginCheck(string email, string password)
        {
            // tu pridajte to, čo to bude porovnávať s dátami v databáze
            // pokiaľ sa nezhoduje, nech vráti false
            
            return true;
        }
    }
}