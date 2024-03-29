﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MestoOpravaV2.Utils;
using Xamarin.Essentials;
using Plugin.SharedTransitions;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemsPage : ContentPage
    
    {
        private DateTime lastUpdate;
        private int updateInterval = 10;
        private Location lastLocation = new Location();
        
        public ProblemsPage()
        {
            getGPS();
            InitializeComponent();

        }

        async void getGPS()
        { 
            bool gpsLocationExpired = ((DateTime.Now - lastUpdate).Seconds > updateInterval);
            if (gpsLocationExpired || lastLocation == null) { 
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
                lastLocation = await Geolocation.GetLocationAsync(request);
                lastUpdate = DateTime.Now;
            }
            string test = lastLocation.Timestamp.ToString() + " " + lastLocation.Latitude.ToString();
            
            var placemarks = await Geocoding.GetPlacemarksAsync(lastLocation);
            var placemark = placemarks?.FirstOrDefault();
            
            if (placemark != null)
            {
                Location.Text = placemark.SubLocality;
            }
        }
        
        async void AddClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNewPost(), true);
        }
        
        async void SearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchPage(), true);
        }
        
        async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage(), true);
        }
        void onClickedProblem(object sender, EventArgs e)
        {
            
            var ID = (Frame) sender;
            int classIDD = int.Parse(ID.GetParent<StackLayout>().ClassId);
            Navigation.PushModalAsync(new ProblemsPageDetails(classIDD), true);

        }
        
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}