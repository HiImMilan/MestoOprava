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
using System.Security.Cryptography;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsMainPage : ContentPage
    {
        private static DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        DateTime GPSTimeout = DateTime.Now;
        DataViewModel model = new DataViewModel();
        GPSData GPS = new GPSData("null", "null");
        public ProblemsMainPage()
        {
            InitializeComponent();
            Start();
            Data data = new Data();

            if (Application.Current.RequestedTheme == OSAppTheme.Dark)
            {
                bg.BackgroundColor = Color.FromHex("#18192B");
            }
            else
            {

            }

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
                Console.WriteLine($"http://{InternetConnectivityCheck.ServerIP}/Server/GetData.php?{arguments}");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{InternetConnectivityCheck.ServerIP}/Server/GetData.php?{arguments}");
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
           // await DisplayAlert("Response:",dataString,"OK"); 
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
            TimeSpan timespan = DateTime.Now - GPSTimeout;
            if (GPS.Latitude == "null" || GPS.Longitude == "null" || timespan.TotalSeconds > 10) // Opraviť
            {
                await GetGPS();
                GPSTimeout = DateTime.Now;
            }

            var imageStream = await HelperMethods.CameraTakePhoto();
            byte[] imageArray = new byte[0];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                imageStream.CopyTo(memoryStream);
                imageArray = memoryStream.ToArray();
            }
            //Convert.ToBase64String(imageArray)
            var url = "http://192.168.50.34/Server/PushData.php";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

        

            string imageBase64 = Regex.Replace(Convert.ToBase64String(imageArray), "\n", "");
            PostTemplate postTemplate = new PostTemplate("45fa1bad-e41a-440a-9f96-c9aac42ffd8a", imageBase64,"Sample Text","Lorem ipsum", GPS.Latitude, GPS.Longitude, GetCode("so4md2d27coeiyepjgvxwddqelimty5p272wprp7owtypowafvl2dsf7", GetInterval(DateTime.Now)));

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(postTemplate);
                streamWriter.Write(json);
            }
            var result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            await DisplayAlert("Response:", result, "OK");

        }

        //  void GetCodeButton(object sender, EventArgs e) => DisplayAlert("Code", GetCode((string)Application.Current.Properties["OTPStore"], GetInterval(DateTime.Now)), "OK");
        // https://docs.microsoft.com/sk-sk/archive/blogs/cloudpfe/using-time-based-one-time-passwords-for-multi-factor-authentication-in-ad-fs-3-0
        private static string GetCode(string secretKey, long timeIndex)
        {
            var secretKeyBytes = Base32Encode(secretKey);
            HMACSHA1 hmac = new HMACSHA1(secretKeyBytes);
            byte[] challenge = BitConverter.GetBytes(timeIndex);
            if (BitConverter.IsLittleEndian) Array.Reverse(challenge);
            byte[] hash = hmac.ComputeHash(challenge);
            int offset = hash[19] & 0xf;
            int truncatedHash = hash[offset] & 0x7f;
            for (int i = 1; i < 4; i++)
            {
                truncatedHash <<= 8;
                truncatedHash |= hash[offset + i] & 0xff;
            }
            truncatedHash %= 1000000;
            return truncatedHash.ToString("D6");
        }
        private static long GetInterval(DateTime dateTime)
        {
            TimeSpan elapsedTime = dateTime.ToUniversalTime() - unixEpoch;
            return (long)elapsedTime.TotalSeconds / 30;
        }
        private static byte[] Base32Encode(string source)
        {
            string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            var bits = source.ToUpper().ToCharArray().Select(c =>
                Convert.ToString(allowedCharacters.IndexOf(c), 2).PadLeft(5, '0')).Aggregate((a, b) => a + b);
            return Enumerable.Range(0, bits.Length / 8).Select(i => Convert.ToByte(bits.Substring(i * 8, 8), 2)).ToArray();
        }
    }
}