using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MestoOpravaV2.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsPage : ContentPage
    {
        public GPSManager gpsManager = new GPSManager();
        public ProblemsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            
        }
        public async void AddPost(object o, EventArgs args)
        {
            ServerManager serverManager = new ServerManager("http://192.168.0.106/MestoOpravaV2/Server/ping.php");
            try
            {
                score.Text = serverManager.Add_Post();
            }
            catch (PermissionException e)
            {
                await DisplayAlert("Chyba", e.Message, "ok");
            }
        }
    }
}