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
            await Navigation.PopModalAsync(true);
        }
        
        async void RegisterClicked(object sender, EventArgs e)
        {   if (EntryPassword.Text == EntryPasswordConfirmation.Text)
                await Navigation.PushModalAsync(new ProblemsPage(), true);
        }
        
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        
    }
}