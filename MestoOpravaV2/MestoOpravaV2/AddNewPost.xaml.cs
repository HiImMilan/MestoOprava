using MestoOpravaV2.POPUPS;
using MestoOpravaV2.Utils;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPost : ContentPage
    {
        public AddNewPost()
        {
            InitializeComponent();
        }
        Stream postPhoto = new MemoryStream();
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Stream stream = await CameraManager.CameraTakePhoto();
            if (stream == null)
            {
                await Navigation.PopModalAsync();
                return;
            }
                

            stream.CopyTo(postPhoto);
            stream.Position = 0;
            image.Source = ImageSource.FromStream((() => stream));
            
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
            Location location = await Geolocation.GetLocationAsync(request);
            
            var placemarks = await Geocoding.GetPlacemarksAsync(location);
            var placemark = placemarks?.FirstOrDefault();
            
            if (placemark != null)
            {
                Location.Text = placemark.SubLocality;
            }
            
        }

        private async void Send_Post(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new SendingPost());
            string userId = "10";
            string userName = "MilosM";
            string title = Title.Text;

            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
            Location location = await Geolocation.GetLocationAsync(request);
            string longitude = location.Longitude.ToString();
            string latitude = location.Latitude.ToString();
            string text = Description.Text;
            string imageBase64 = "";

            byte[] buffer = new byte[16 * 1024];
            postPhoto.Position = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                postPhoto.CopyTo(ms);
                ms.Position = 0;
                imageBase64 = Convert.ToBase64String(ms.ToArray());
            }

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"userId",userId },
                {"userName",userName },
                {"title",title },
                {"text",text },
                {"image",imageBase64 },
                {"longitude",longitude },
                {"latitude",latitude },

            };

            await ServerManager.serverManager.SendRawPost("sendData", data);
            await PopupNavigation.PushAsync(new SendPostStatus(this));
        }
    }
}