using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpravaMesta.Utils
{
    class HelperMethods
    {
        public static async Task<ImageSource> CameraTakePhoto()
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                return ImageSource.FromStream(() => { return photo.GetStream(); });
            else
            {
                return null;
            }
        }
    }
}
