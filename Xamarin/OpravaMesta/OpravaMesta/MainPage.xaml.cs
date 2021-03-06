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

        int secret;
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
                bNoLogin.TextColor = Color.FromHex("31325C");
                lAgree.TextColor = Color.FromHex("FFFFFF");
                 devtools.BackgroundColor = Color.FromHex("000000");
                 devtools.TextColor= Color.FromHex("000000");
                //devtools.BackgroundColor = Color.FromHex("FFFFFF");
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
                devtools.BackgroundColor = Color.FromHex("FFFFFF");
                devtools.TextColor = Color.FromHex("FFFFFF");
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

            await Navigation.PushModalAsync(new QRLoginPage());
        }

        async void NoLoginClicked(object sender, EventArgs e)
        {

        }
        async void Secret(object sender, EventArgs e)
        {
            
            secret++;
            switch (secret) // Lebo C# 7.3 .....
            {              
                case 3:
                    if (Application.Current.RequestedTheme == OSAppTheme.Dark) devtools.TextColor = Color.FromHex("FFFFFF"); else devtools.TextColor = Color.FromHex("000000");
                    devtools.Text = "3";
                    break;
                case 4:
                    devtools.Text = "2";
                    break;
                case 5:
                    devtools.Text = "1";
                    break;
                case 6:
                    await Navigation.PushModalAsync(new DevTools());
                    break;
                default:
                    break;
            }
        }


    }
}
