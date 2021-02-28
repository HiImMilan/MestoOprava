using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpravaMesta.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GPSTestScreen : ContentPage
    {
        public GPSTestScreen()
        {
            InitializeComponent();
            getGPS();
        }

        async void getGPS() {

            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
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



        private async void Button_OnClicked(object sender, EventArgs e) { }
            //testImage.Source = await HelperMethods.CameraTakePhoto();


    }
}