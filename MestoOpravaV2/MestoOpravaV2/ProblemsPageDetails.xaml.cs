using MestoOpravaV2.POPUPS;
using MestoOpravaV2.Utils;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsPageDetails : ContentPage
    {
        string postId;
        public ProblemsPageDetails(int postId)
        {
            InitializeComponent();
            this.postId = postId.ToString();
        }
        private async Task<List<Dictionary<string, string>>> getPostById()
        {
            return await ServerManager.serverManager.GetPostById(postId.ToString());
        }
        public async Task<float> CalculateDistance(string longy, string latty)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
            Location location = await Geolocation.GetLocationAsync(request);
            float longitude = float.Parse(longy) - (float)location.Longitude;
            float lattitude = float.Parse(latty) - (float)location.Latitude;
            return (float)(Math.Pow(longitude, 2) + Math.Pow(lattitude, 2));
        }
        protected override async void OnAppearing()
        {
            try
            {
                Dictionary<string,string> post = (await getPostById())[0];
                Console.WriteLine("Jebe tomu");
                
                Title.Text = post["title"];
                Rating.Text = post["rating"];
                float dist = await CalculateDistance(post["longitude"], post["latitude"]) / 1000;
                Distance.Text = $"{Math.Round(dist,2)} km";
                Description.Text = post["description"];
                Author.Text = post["authorName"];
                Image.Source = ImageSource.FromUri(new Uri(post["imageURL"]));

                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
                var location = await Geolocation.GetLocationAsync(request);

                var placemarks = await Geocoding.GetPlacemarksAsync(location);
                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    Location.Text = placemark.SubLocality;
                }
            }
            catch (Exception e)
            {
                PopupNavigation.PushAsync(new InternetError((() => OnAppearing())));
            }
        }
        private void RateProblem(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new Rating());
        }
    }
}