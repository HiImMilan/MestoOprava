using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpravaMesta
{
    public partial class MainPage : ContentPage
    {
        class SendPostData
        {
            public string lat { get; set; }
            public string longy { get; set; }
            
        }
        public MainPage()
        {
            InitializeComponent();

            if (Application.Current.RequestedTheme == OSAppTheme.Dark)
            {
                bg.BackgroundColor = Color.FromHex("000000");
                lProfil.TextColor = Color.FromHex("FFFFFF");
                bLogin.BackgroundColor = Color.FromHex("31325C");
                bLogin.TextColor = Color.FromHex("FFFFFF");
                bNoLogin.BackgroundColor = Color.FromHex("000000");
                bNoLogin.TextColor = Color.FromHex("FFFFFF");
                lAgree.TextColor = Color.FromHex("FFFFFF");
            }
            else
            {
                bg.BackgroundColor = Color.FromHex("FFFFFF");
                lProfil.TextColor = Color.FromHex("6E7C7D");
                bLogin.BackgroundColor = Color.FromHex("4682D0");
                bLogin.TextColor = Color.FromHex("FFFFFF");
                bNoLogin.BackgroundColor = Color.FromHex("FFFFFF");
                bNoLogin.TextColor = Color.FromHex("4682D0");
                lAgree.TextColor = Color.FromHex("6E7C7D");
            }

            /*PacketSender<GetPostData, GetPostData> content =
                new PacketSender<GetPostData, GetPostData>(new GetPostData(),
                    "http://192.168.0.105/Server/GetData.php?lat=14.69000000&longy=18.42040000");

            Task abc = Task.Run( async () =>
            {
               editor.Text = await content.SendRequest();
            });
            Task.WaitAll(abc);*/
        }
        
        async void LoginClicked(object sender, EventArgs e)
        {

            // await Navigation.PushModalAsync(new QRLoginPage());
            await Navigation.PushModalAsync(new GPSTestScreen());
        }

        async void NoLoginClicked(object sender, EventArgs e)
        {

        }

    }
}
