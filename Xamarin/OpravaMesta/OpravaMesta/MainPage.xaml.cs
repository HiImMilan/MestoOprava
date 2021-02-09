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
