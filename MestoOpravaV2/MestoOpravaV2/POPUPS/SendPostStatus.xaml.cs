using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2.POPUPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendPostStatus : Rg.Plugins.Popup.Pages.PopupPage
    {


        public SendPostStatus()
        {
            InitializeComponent();
        }

        public async void ClosePop(object sender, EventArgs e)
        {
            await PopupNavigation.PopAllAsync();
            await Navigation.PopAsync();
        }
    }
}