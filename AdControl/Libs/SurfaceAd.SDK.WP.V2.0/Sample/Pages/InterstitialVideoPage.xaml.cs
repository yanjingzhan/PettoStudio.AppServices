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
    public partial class InterstitialVideoPage : PhoneApplicationPage
    {
        public InterstitialVideoPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            this.LoadInterstitialVideoAd();
        }

        void LoadInterstitialVideoAd()
        {
            new Utils().BindSurfaceAdInterstitialControlEvent(this.surfaceInterstitialAdVideoXaml);
            this.surfaceInterstitialAdVideoXaml.InitAdControl(AdModeType.Debug);
        }
    }
}