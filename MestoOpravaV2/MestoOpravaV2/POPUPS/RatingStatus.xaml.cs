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
    public partial class RatingStatus : Rg.Plugins.Popup.Pages.PopupPage
    {


        public RatingStatus()
        {
            InitializeComponent();
        }

        public async void ClosePop(object sender, EventArgs e)
        {
            await PopupNavigation.PopAllAsync();
        }
    }
}