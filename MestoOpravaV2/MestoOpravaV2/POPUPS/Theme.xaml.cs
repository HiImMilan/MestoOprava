using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
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
    }
}