using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MestoOpravaV2.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2.Utils
{
    public class GPSManager
    {
        private DateTime lastUpdate;
        private int updateInterval = 10;
        private Location lastLocation = new Location();
        public GPSManager()
        {
            lastUpdate = DateTime.Parse("1970/1/1 01:00");
        }
        public async Task<Location> GetGPS()
        {
            // bool gpsLocationExpired = ((DateTime.Now - lastUpdate).Seconds > updateInterval);
            //if (gpsLocationExpired || lastLocation == null)
            //{
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
            lastLocation = await Geolocation.GetLocationAsync(request);
            //    lastUpdate = DateTime.Now;
            //}
            
            return lastLocation;
        }
    }
}
