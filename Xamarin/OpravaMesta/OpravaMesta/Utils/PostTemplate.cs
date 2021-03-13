using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OpravaMesta.Utils
{
    class PostTemplate
    {
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public double PostLongitude { get; set; }
        public double PostLatitude { get; set; }

        public PostTemplate(string name, string imageBase64, string postTitle, string postDescription, double postLongitude, double postLatitude)
        {
            Name = name;
            ImageBase64 = imageBase64;
            PostTitle = postTitle;
            PostDescription = postDescription;
            PostLongitude = postLongitude;
            PostLatitude = postLatitude;
        }

        

        
    }
}
