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
        }

        private Image _profilePhoto;
        async void QRCodeClicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                _profilePhoto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            MainViewModel.GetMainViewModel().ProfilePhoto = _profilePhoto;

        }
    }
}