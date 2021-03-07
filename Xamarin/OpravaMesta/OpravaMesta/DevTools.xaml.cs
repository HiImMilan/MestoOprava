using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevTools : ContentPage
    {
        DateTime GPSTimeout = DateTime.Now;
        DataViewModel model = new DataViewModel();
        GPSData GPS = new GPSData("null", "null");
        public DevTools()
        {
            InitializeComponent();
            Start();
            Data data = new Data();
            data.Creator = "gay";

            Collection.ItemsSource = model.Datas;
            ICommand refreshCommand = new Command(() =>
            {
                Start();
            });
            refresh.Command = refreshCommand;
        }


        async void Start()
        {
            refresh.IsRefreshing = true;
            TimeSpan timespan = DateTime.Now - GPSTimeout;
            
            if (GPS.Latitude == "null" || GPS.Longitude == "null" || timespan.TotalSeconds > 10) // Opraviť
            {
                await GetGPS();
                GPSTimeout = DateTime.Now;
            }

            // Optimalizacia
            string dataString = null;
            try
            {
                string latitude = "&lat="+GPS.Latitude.Replace(",", ".");
                string longidute = "&longy=" + GPS.Longitude.Replace(",", ".");
                string arguments = latitude + longidute;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{InternetConnectivityCheck.ServerIP}/MestoOprava/Server/GetData.php?{arguments}");
                request.Timeout = 5000;
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
            } catch (Exception ex)
            {
                 await DisplayAlert("An error has occured", "Please screenshot this and sent this to Github Issues (Please note that this is usually by your internet connection): " + ex.Message + "\n STACKTRACE: " + ex.StackTrace + "\n" + ex.Source, "Cancel");
                 
                 return;
            }
           
            List<Data> var1 = JsonConvert.DeserializeObject<List<Data>>(dataString);
            Console.WriteLine("Done");
            refresh.IsRefreshing = false;
            ObservableCollection<Data> temp = new ObservableCollection<Data>(var1);
            model.Datas.Clear();
             foreach (Data data1 in var1) 
             {
                model.Datas.Add(data1);
             }
           
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
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}