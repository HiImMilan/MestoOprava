using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
namespace OpravaMesta
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                Task<GetPostData> postData = GetResponse<GetPostData>("https://www.google.com/");
                GetPostData getPostData = await postData;

                editor.Text = getPostData.creator;
            });


        }

        async void LoginClicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new QRLoginPage());
        }

        public async Task<T> GetResponse<T>(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return default(T);
            }

            
        }
        
        
        async void NoLoginClicked(object sender, EventArgs e)
        {

        }

    }
}
