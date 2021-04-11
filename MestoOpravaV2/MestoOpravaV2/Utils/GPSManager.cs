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
        private Location lastLocation;
        public GPSManager()
        {
            lastUpdate = DateTime.Now;
        }
        public async Task<string> TryGetGPSCords()
        {
            try
            {
                await GetGPSCords();
            }
            catch (Exception e)
            {
               throw new Exception("Prístup k vašej polohe bol zamietnutý, ak chcete získať informácie o problémoch v okolí povolte prístup k GPS.");
            }
            return $"Latitude: {lastLocation.Latitude}, Longitude: {lastLocation.Longitude}, Altitude: {lastLocation.Altitude}";
        }
        private async Task GetGPSCords()
        {
            bool gpsLocationExpired = ((DateTime.Now - lastUpdate).Seconds > updateInterval);
            if (gpsLocationExpired || lastLocation == null)
            {
                lastLocation = await Geolocation.GetLocationAsync();
                lastUpdate = DateTime.Now;
            }
            
        }
    }
}
