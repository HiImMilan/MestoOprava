using MestoOpravaV2.POPUPS;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        async void NameClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new Name());
        }

        [Obsolete]
        async void PasswordeClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new Password());
        }

        [Obsolete]
        async void ProfilePictureClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new ProfilePicture());
        }

        [Obsolete]
        async void CityClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new City());
        }

        [Obsolete]
        async void NotificationsClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new Notifications());
        }

        [Obsolete]
        async void ThemeClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new Theme());
        }

        [Obsolete]
        async void LogOutClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new LogOut());
        }
        
        protected override bool OnBackButtonPressed()
        {
            Task.Run(async () =>
            {
                try { await PopupNavigation.PopAllAsync(); }
                catch (Exception) { await Navigation.PopModalAsync(); }
            });
            return true;
        }
    }
}