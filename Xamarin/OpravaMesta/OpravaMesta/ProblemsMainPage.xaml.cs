using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using OpravaMesta.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsMainPage : ContentPage
    {
        DateTime GPSTimeout = DateTime.Now;
        DataViewModel model = new DataViewModel();
        GPSData GPS = new GPSData("null", "null");
        public ProblemsMainPage()
        {
            InitializeComponent();
            Start();
            Data data = new Data();

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
                Console.WriteLine($"http://{InternetConnectivityCheck.ServerIP}/MestoOprava/Server/GetData.php?{arguments}");
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

        private async void Add_Post(object sender, EventArgs e)
        {
            var imageStream = await HelperMethods.CameraTakePhoto();
            byte[] imageArray = new byte[0];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                imageStream.CopyTo(memoryStream);
                imageArray = memoryStream.ToArray();
            }
            //Convert.ToBase64String(imageArray)
            var url = "http://192.168.0.105/MestoOprava/Server/test.php";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            
            string imageBase64 = Regex.Replace(Convert.ToBase64String(imageArray), "\n", "");
            PostTemplate postTemplate = new PostTemplate("Milos",imageBase64,"Sample Text","Lorem ipsum",14.5,20.5);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(postTemplate);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        }
    }
}