using System;
using System.Collections.Generic;
using System.Text;

namespace MestoOpravaV2.JsonTempates
{
    class LocationArgsTemplate
    {
        public string lat;
        public string longy;
        public LocationArgsTemplate(string lat,string longy)
        {
            this.lat = lat;
            this.longy = longy;
        }
    }
}
