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
    public partial class BannerVideoPage : PhoneApplicationPage
    {
        public BannerVideoPage()
        {
            InitializeComponent();
            //
            LoadBannerVideoAd();
            //
            //this.CreateBannerVideoAd();
        }

        void LoadBannerVideoAd()
        {
            new Utils().BindSurfaceAdControlEvent(this.surfaceAdVideoXaml);
            this.surfaceAdVideoXaml.InitAdControl(AdModeType.Debug);
        }

        void CreateBannerVideoAd()
        {
            string adToken = "Yg84XTVRYwpiAzhaNUdjCmIR";
            string adPosition = "6a4af36efb2e3099745256e5ec5f7a31";

            int adRefreshInterval = 15;
            var surfaceAdControl = new SurfaceAdControl(adToken, adPosition, adRefreshInterval);
            surfaceAdControl.IsShowCloseIcon = true;
            new Utils().BindSurfaceAdControlEvent(surfaceAdControl);

            this.surfaceAdVideoBackend.Children.Add(surfaceAdControl);
            surfaceAdControl.InitAdControl(AdModeType.Debug);
        }
    }
}