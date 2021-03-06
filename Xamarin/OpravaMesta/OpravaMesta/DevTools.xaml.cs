using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevTools : ContentPage
    {

        public Data Datas = new Data();

        GPSData GPS = new GPSData("null", "null");
        public DevTools()
        {
            InitializeComponent();
            Start();
        }


        async void Start()
        {
            await GetGPS();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.50.34/Server/GetData.php?&lat=" + GPS.Latitude.Replace(",",".") + "&longy=" + GPS.Longitude.Replace(",", "."));
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            string dataString;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                dataString = reader.ReadToEnd();
            }
            var var1 = JsonConvert.DeserializeObject<List<Data>>(dataString);
            Console.WriteLine("Done");
            foreach (Data data1 in var1) 
            {
              //  Datas.Add(data1);
            }

              //foreach (Data data2 in Datas) {
         //       Console.WriteLine(data2.Creator);
       //     }
            
        }
        async Task GetGPS()
        {

            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    GPS.Longitude = location.Longitude.ToString();
                    GPS.Latitude = location.Latitude.ToString();
                   
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
               await DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + fnsEx.Message + "\n STACKTRACE: " + fnsEx.StackTrace + "\n" + fnsEx.Source, "Cancel");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + fneEx.Message + "\n STACKTRACE: " + fneEx.StackTrace + "\n" + fneEx.Source, "Cancel");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + pEx.Message + "\n STACKTRACE: " + pEx.StackTrace + "\n" + pEx.Source, "Cancel");
            }
            catch (Exception ex)
            {
                await DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues: " + ex.Message + "\n STACKTRACE: " + ex.StackTrace + "\n" + ex.Source, "Cancel");
            }
        }

    }
}