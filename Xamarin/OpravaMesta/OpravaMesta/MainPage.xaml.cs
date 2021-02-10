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

            PacketSender<GetPostData, GetPostData> content =
                new PacketSender<GetPostData, GetPostData>(new GetPostData(),
                    "http://192.168.0.105/Server/GetData.php?lat=14.69000000&longy=18.42040000");

            Task abc = Task.Run( async () =>
            {
               editor.Text = await content.SendRequest();
            });
            Task.WaitAll(abc);
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
