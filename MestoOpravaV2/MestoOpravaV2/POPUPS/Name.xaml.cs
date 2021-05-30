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
    public partial class Name : Rg.Plugins.Popup.Pages.PopupPage
    {
        public Name()
        {
            InitializeComponent();
        }

        async void ChangeNameClicked(object sender, EventArgs e)
        {
            EntryName.IsReadOnly = false;
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