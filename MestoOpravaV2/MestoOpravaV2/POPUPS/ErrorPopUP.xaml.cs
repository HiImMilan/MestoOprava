﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2.POPUPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPopUP : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ErrorPopUP()
        {
            InitializeComponent();
        }
    }
}