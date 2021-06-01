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

        Page page;
        public SendPostStatus(Page page)
        {
            InitializeComponent();
            this.page = page;
        }

        public async void ClosePop(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            await PopupNavigation.PopAllAsync();
        }
    }
}