using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Push;
using QAFoodBank.Helpers;
using System;

using Xamarin.Forms;

namespace QAFoodBank
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "http://qafb-mobilapi.azurewebsites.net/";

        public App()
        {
            InitializeComponent();

			Push.PushNotificationReceived += (sender, e) => {

                string summary = String.Empty;

				if (e.CustomData != null)
				{
					summary = "\n\tCustom data:\n";
					foreach (var key in e.CustomData.Keys)
					{
						summary += $"\t\t{key} : {e.CustomData[key]}\n";
					}

                    System.Diagnostics.Debug.WriteLine(summary);
				}

                if (MainPage != null)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(()=>
                    {
                        MainPage.DisplayAlert(e.Title ?? String.Empty, e.Message + summary, "OK");
                    });
                }
			};

            MobileCenter.Start($"android={Constants.MobileCenterAndroid};" +
                   $"uwp={Constants.MobileCenterUWP};" +
                   $"ios={Constants.MobileCenteriOS}",
                   typeof(Analytics), typeof(Crashes), typeof(Push));

			Push.SetEnabledAsync(true);

			if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
