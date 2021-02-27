using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarouselView.FormsPlugin.Abstractions;
using OpravaMesta.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpravaMesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsPage : ContentPage
    {
        public ProblemsPage()
        {
            InitializeComponent();

            if (Application.Current.RequestedTheme == OSAppTheme.Dark)
            {
                bg.BackgroundColor = Color.FromHex("000000");
                activityIndicator.Color = Color.FromHex("31325C");
            }
            else
            {
                bg.BackgroundColor = Color.FromHex("FFFFFF");
                activityIndicator.Color = Color.FromHex("4682D0");
            }
            
            List<PostTemplate> postTemplates = new List<PostTemplate>()
            {
                new PostTemplate(){Name = "asdada"},
                new PostTemplate(){Name = "Abcd"}
            };
            CarouselView.ItemsSource = postTemplates;
            
        }
    }
}