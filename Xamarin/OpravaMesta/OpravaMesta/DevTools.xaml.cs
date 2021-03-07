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
    public partial class DevTools : ContentPage
    {
        public DevTools()
        {
            InitializeComponent();
            DataPlaceholder.Text = InternetConnectivityCheck.ServerIP;
            try
            {
                RollingCodeSecret.Text = (string)Application.Current.Properties["OTPStore"];
            } catch (System.Collections.Generic.KeyNotFoundException)
            {
                RollingCodeSecret.Text = "";
            }
        }
        async void StartApp(object sender, EventArgs e)
        {
            InternetConnectivityCheck.ServerIP = DataPlaceholder.Text;
            await Navigation.PushModalAsync(new ProblemsMainPage());
        }
        void Crash(object sender, EventArgs e) => throw new Exception("User Requested Exception");
    }
}