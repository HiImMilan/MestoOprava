using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            if (Application.Current.RequestedTheme == OSAppTheme.Dark)
            {
                bg.BackgroundColor = Color.FromHex("000000");
                meno.TextColor = Color.FromHex("FFFFFF");
                priezvisko.TextColor = Color.FromHex("FFFFFF");
                mesto.TextColor = Color.FromHex("FFFFFF");
                hodnotenie.TextColor = Color.FromHex("FFFFFF");
                prispevky.TextColor = Color.FromHex("FFFFFF");
                btnLogin.BackgroundColor = Color.FromHex("31325C");
                btnLogin.TextColor = Color.FromHex("FFFFFF");
                btnNotMe.BackgroundColor = Color.FromHex("000000");
                btnNotMe.TextColor = Color.FromHex("31325C");
            }
            else
            {
                bg.BackgroundColor = Color.FromHex("FFFFFF");
                meno.TextColor = Color.FromHex("6E7C7D");
                priezvisko.TextColor = Color.FromHex("6E7C7D");
                mesto.TextColor = Color.FromHex("6E7C7D");
                hodnotenie.TextColor = Color.FromHex("6E7C7D");
                prispevky.TextColor = Color.FromHex("6E7C7D");
                btnLogin.BackgroundColor = Color.FromHex("4682D0");
                btnLogin.TextColor = Color.FromHex("FFFFFF");
                btnNotMe.BackgroundColor = Color.FromHex("FFFFFF");
                btnNotMe.TextColor = Color.FromHex("4682D0");
            }
        }

        async void NotMeClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProblemsMainPage());
        }
    }
}