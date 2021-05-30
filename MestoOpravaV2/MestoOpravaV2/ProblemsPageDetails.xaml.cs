using MestoOpravaV2.POPUPS;
using MestoOpravaV2.Utils;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsPageDetails : ContentPage
    {
        string postId;
        public ProblemsPageDetails(int postId)
        {
            InitializeComponent();
            this.postId = postId.ToString();
        }
        private async Task<List<Dictionary<string, string>>> getPostById()
        {
            return await ServerManager.serverManager.GetPostById(postId.ToString());
        }
        protected override async void OnAppearing()
        {
          
            try
            {
                Dictionary<string,string> post = (await getPostById())[0];
                Title.Text = post["title"];
                Location.Text = post["adress"];
                Rating.Text = post["rating"];
                Distance.Text = "30km";
                Description.Text = post["description"];
            }
            catch (Exception e)
            {
                PopupNavigation.PushAsync(new InternetError((() => OnAppearing())));
            }

            
        }
    }
}