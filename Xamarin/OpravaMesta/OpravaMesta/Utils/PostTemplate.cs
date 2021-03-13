using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OpravaMesta.Utils
{
    class PostTemplate
    {
        public string UUID { get; set; }
        public string ImageBase64 { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string PostLongitude { get; set; }
        public string PostLatitude { get; set; }
        public string OTPToken{ get; set; }

        public PostTemplate(string uuid, string imageBase64, string postTitle, string postDescription, string postLatitude, string postLongitude, string otptoken)
        {
            UUID = uuid;
            ImageBase64 = imageBase64;
            PostTitle = postTitle;
            PostDescription = postDescription;
            PostLongitude = postLongitude;
            PostLatitude = postLatitude;
            OTPToken = otptoken;
        }

        

        
    }
}
