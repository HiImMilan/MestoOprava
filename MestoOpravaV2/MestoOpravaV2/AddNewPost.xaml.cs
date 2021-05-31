using MestoOpravaV2.Utils;
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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Stream stream = await CameraManager.CameraTakePhoto();
            if (stream == null)
                await Navigation.PopModalAsync();
            
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

        private void Send_Post(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}