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
        public RegisterPage()
        {
            InitializeComponent();
        }
        async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        
        async void RegisterClicked(object sender, EventArgs e)
        {
            if (SendData(EntryName.Text, EntryEmail.Text, EntryPassword.Text, EntryPasswordConfirmation.Text));
                await Navigation.PushModalAsync(new ProblemsPage());
        }

        bool SendData(string name, string email, string password, string passwordConfirmation)
        {
            if (password != passwordConfirmation)
            {
                // sem hodte pop-up, že sa heslá nezhodovali
                return false;
            }
            
            // sem dajte niečo, čo tie dáta na server pošle
            
            return true;
        }
    }
}