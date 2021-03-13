using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpravaMesta.Utils
{
    class HelperMethods
    {
        public static async Task<Stream> CameraTakePhoto()
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                return photo.GetStream();
            else
            {
                return null;
            }
        }
    }
}
