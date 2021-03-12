using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevTools : ContentPage
    {
        private static DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public DevTools()
        {
            InitializeComponent();
            DataPlaceholder.Text = InternetConnectivityCheck.ServerIP;
            try
            {
                RollingCodeSecret.Text = (string)Application.Current.Properties["OTPStore"];
            } catch (System.Collections.Generic.KeyNotFoundException)
            {
                RollingCodeSecret.Text = "";
            }
        }
        async void StartApp(object sender, EventArgs e)
        {
            InternetConnectivityCheck.ServerIP = DataPlaceholder.Text;
            await Navigation.PushModalAsync(new ProblemsMainPage());
        }
        async void OTPChange(object sender, EventArgs e)
        {
            Application.Current.Properties["OTPStore"] = RollingCodeSecret.Text;
        }
        void Crash(object sender, EventArgs e) => throw new Exception("User Requested Exception");

        void GetCodeButton(object sender, EventArgs e) => DisplayAlert("Code", GetCode((string)Application.Current.Properties["OTPStore"], GetInterval(DateTime.Now)), "OK");
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