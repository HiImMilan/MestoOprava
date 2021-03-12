using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if ((string)Application.Current.Properties["OTPStore"] == "" || (string)Application.Current.Properties["OTPStore"] == null)
             MainPage = new MainPage();
            else  MainPage = new ProblemsMainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
