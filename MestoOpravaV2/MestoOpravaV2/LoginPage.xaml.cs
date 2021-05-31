using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MestoOpravaV2.Utils;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            BindingContext = new UserDataMVM();
            base.OnAppearing();
            StorageManager storageManager = new StorageManager("data.json");
            if (storageManager.CheckFile())
            {
                Dictionary<string, string> data = storageManager.ReadFile();

                if (data.ContainsKey("userId") && data.ContainsKey("login") && data.ContainsKey("password"))
                {
                    await Navigation.PushModalAsync(new ProblemsPage(), true);
                }
            }
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProblemsPage(), true);

            
        }

        async void RegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage(), true);
        }
        
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}