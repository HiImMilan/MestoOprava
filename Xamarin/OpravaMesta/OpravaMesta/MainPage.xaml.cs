using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpravaMesta
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            image.Source = new UriImageSource()
            {
                Uri = new Uri("https://is5-ssl.mzstatic.com/image/thumb/Purple124/v4/49/24/c6/4924c69e-f6ac-0549-5631-3396e0d279d9/logo_gsa_ios_color-0-0-1x_U007emarketing-0-0-0-6-0-0-sRGB-0-0-0-GLES2_U002c0-512MB-85-220-0-0.png/1200x630wa.png")
            };
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QRLoginPage());
        }

        async void NoLoginClicked(object sender, EventArgs e)
        {

        }
    }
}
