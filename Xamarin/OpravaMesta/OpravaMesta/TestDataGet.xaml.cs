using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestDataGet : ContentPage
    {
        GPSData GPS = new GPSData("none", "none");

        public TestDataGet()
        {
            InitializeComponent();
            

        }

        async void getGPS()
        {

            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"[DEBUG] TestDataGPS[33]: Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    GPS.Longitude = location.Longitude.ToString();
                    GPS.Latitude = location.Latitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + fnsEx.Message + "\n STACKTRACE: " + fnsEx.StackTrace + "\n" + fnsEx.Source, "Cancel");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + fneEx.Message + "\n STACKTRACE: " + fneEx.StackTrace + "\n" + fneEx.Source, "Cancel");
            }
            catch (PermissionException pEx)
            {
                DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + pEx.Message + "\n STACKTRACE: " + pEx.StackTrace + "\n" + pEx.Source, "Cancel");
            }
            catch (Exception ex)
            {
                DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + ex.Message + "\n STACKTRACE: " + ex.StackTrace + "\n" + ex.Source, "Cancel");
            }
        }
    }
}