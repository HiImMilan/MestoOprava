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
    public partial class Rating : Rg.Plugins.Popup.Pages.PopupPage
    {
        public Rating()
        {
            InitializeComponent();
        }
        public void Rate(object sender, EventArgs e)
        {
            string score = ((Button)sender).BindingContext as string;

            Console.WriteLine(score);

            PopupNavigation.PushAsync( new RatingStatus());
        }
        public async void CloseRating(object sender, EventArgs e )
        {
           await PopupNavigation.PopAllAsync();
        }
    }
}