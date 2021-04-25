namespace MestoOpravaV2
{
    internal class GPSData
    {
        private string latitude;
        private string longitude;


        public GPSData(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public string Latitude
        {
            get { return latitude; }   
            set { latitude = value; }  
        }

        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
    }
}