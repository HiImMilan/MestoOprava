using System.IO;
using System.Threading.Tasks;


namespace MestoOpravaV2.Utils
{
    public class CameraManager
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