using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2.POPUPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePicture : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ProfilePicture()
        {
            InitializeComponent();
        }
        
        async void ChangeProfilePictureClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            MediaFile image = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 400, CompressionQuality = 40
            });

            byte[] imageArray = System.IO.File.ReadAllBytes(image.Path);
            Stream stream = new MemoryStream(imageArray);    
            ImageProfilePicture.Source = ImageSource.FromStream(() => {return stream; });
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