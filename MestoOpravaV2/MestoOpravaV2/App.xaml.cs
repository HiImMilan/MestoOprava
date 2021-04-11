using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new IntroPage();
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
