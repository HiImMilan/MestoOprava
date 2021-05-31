using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MestoOpravaV2.Utils;
using Rg.Plugins.Popup.Services;

namespace MestoOpravaV2.POPUPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendingPost : Rg.Plugins.Popup.Pages.PopupPage
    {
        Task internetCheck;
        public SendingPost()
        {
            InitializeComponent();

        }


    }
}