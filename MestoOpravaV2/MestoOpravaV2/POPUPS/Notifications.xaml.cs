﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2.POPUPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notifications : Rg.Plugins.Popup.Pages.PopupPage
    {
        public Notifications()
        {
            InitializeComponent();
        }
    }
}