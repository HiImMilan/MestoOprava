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
            await Navigation.PushModalAsync(new RegisterPage());
        }

        bool LoginCheck(string email, string password)
        {
            // tu pridajte to, čo to bude porovnávať s dátami v databáze
            // pokiaľ sa nezhoduje, nech vráti false
            
            return true;
        }
    }
}