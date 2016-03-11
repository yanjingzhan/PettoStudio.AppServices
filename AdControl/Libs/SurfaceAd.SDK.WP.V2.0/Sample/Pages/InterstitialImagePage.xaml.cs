using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SurfaceAd.SDK.WP;

namespace Sample.Pages
{
    public partial class InterstitialImagePage : PhoneApplicationPage
    {
        public InterstitialImagePage()
        {
            InitializeComponent();
            //
            //this.LoadInterstitialImageAd();
            //
            //this.CreateInterstitialImageAd();
        }

        void LoadInterstitialImageAd()
        {
            new Utils().BindSurfaceAdInterstitialControlEvent(this.surfaceInterstitialAdImageXaml);
            this.surfaceInterstitialAdImageXaml.InitAdControl(AdModeType.Debug);
        }

        void CreateInterstitialImageAd()
        {
            //string adToken = "Yg84XTVRYwpiAzhaNUdjCmIR";
            //string adPosition = "1d540a945bd2038404eb343ce8fda1c7";

            //int adRefreshInterval = 15;
            //var surfaceAdControl = new SurfaceAdControl(adToken, adPosition, adRefreshInterval);
            //surfaceAdControl.IsShowCloseIcon = true;
            //new Utils().BindSurfaceAdControlEvent(surfaceAdControl);

            //this.surfaceAdImageBackend.Children.Add(surfaceAdControl);
            //surfaceAdControl.InitAdControl(AdModeType.Debug);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            this.LoadInterstitialImageAd();

        }



    }
}