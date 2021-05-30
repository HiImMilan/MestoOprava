using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2.POPUPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theme : Rg.Plugins.Popup.Pages.PopupPage
    {
        public Theme()
        {
            InitializeComponent();
        }
        
        async void SaveClicked(object sender, EventArgs e)
        {
            
            BackClicked(sender, e);
        }
        
        async void BackClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAllAsync();
        }

        private void BlueRadioButton_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            btn1.BackgroundColor = Color.FromHex("#186AFF");
            btn2.BackgroundColor = Color.FromHex("#186AFF");
        }
        private void GreenRadioButton_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            btn1.BackgroundColor = Color.FromHex("#32cd32");
            btn2.BackgroundColor = Color.FromHex("#32cd32");
        }
        private void YellowRadioButton_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            btn1.BackgroundColor = Color.FromHex("#ccaa00");
            btn2.BackgroundColor = Color.FromHex("#ccaa00");
        }
        private void RedRadioButton_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            btn1.BackgroundColor = Color.FromHex("#bc0000");
            btn2.BackgroundColor = Color.FromHex("#bc0000");
        }
        private void PurpleRadioButton_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            btn1.BackgroundColor = Color.FromHex("#800080");
            btn2.BackgroundColor = Color.FromHex("#800080");
        }

    }
}