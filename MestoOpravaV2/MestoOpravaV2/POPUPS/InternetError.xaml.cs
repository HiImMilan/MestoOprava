using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MestoOpravaV2.Utils;
using Rg.Plugins.Popup.Services;

namespace MestoOpravaV2.POPUPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InternetError : Rg.Plugins.Popup.Pages.PopupPage
    {
        Task internetCheck;
        public InternetError(Action action)
        {
            InitializeComponent();


            internetCheck = Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        ServerManager.serverManager.checkDebug();
                        await PopupNavigation.PopAsync();
                        Console.WriteLine("Internet success");
                        action();
                        break;
                    }
                    catch (Exception)
                    {

                    }

                    Task.Delay(2000);
                    Console.WriteLine("Waiting");

                }
            });

        }


    }
}