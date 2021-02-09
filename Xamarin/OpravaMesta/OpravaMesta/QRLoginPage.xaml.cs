using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRLoginPage : ContentPage
    {
        public QRLoginPage()
        {
            InitializeComponent();
        }

        async void QRCodeClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}