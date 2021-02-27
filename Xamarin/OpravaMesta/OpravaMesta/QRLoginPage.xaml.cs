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
    public partial class QRLoginPage : ContentPage
    {
        public QRLoginPage()
        {
            InitializeComponent();

              if (Application.Current.RequestedTheme == OSAppTheme.Dark)
            {
                bg.BackgroundColor = Color.FromHex("000000");
                text1.TextColor = Color.FromHex("FFFFFF");
                text2.TextColor = Color.FromHex("FFFFFF");
                button.BackgroundColor = Color.FromHex("31325C");
                button.TextColor = Color.FromHex("FFFFFF");
            }
            else
            {
                bg.BackgroundColor = Color.FromHex("FFFFFF");
                text1.TextColor = Color.FromHex("6E7C7D");
                text2.TextColor = Color.FromHex("6E7C7D");
                button.BackgroundColor = Color.FromHex("4682D0");
                button.TextColor = Color.FromHex("FFFFFF");
            }
        }
        }

        private Image _profilePhoto;
        async void QRCodeClicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                _profilePhoto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            MainViewModel.GetMainViewModel().ProfilePhoto = _profilePhoto;
            
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}