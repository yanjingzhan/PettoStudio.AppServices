using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Sample.Resources;
using SurfaceAd.SDK.WP;

namespace Sample
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();

            //this.LoadScreenAd();
            //
            this.CreateScreenAd();
        }

        /// <summary>
        /// 开屏图片广告
        /// </summary>
        void LoadScreenAd()
        {
            new Utils().BindSurfaceAdInterstitialControlEvent(this.surfaceAdScreenImage);

            this.surfaceAdScreenImage.InitAdControl(AdModeType.Debug);
        }

        void CreateScreenAd()
        {
            SurfaceAdInterstitialControl surfaceAdControl = new SurfaceAdInterstitialControl()
            {
                //开发者Token
                AdToken = "Yg84XTVRYwpiAzhaNUdjCmIR",
                //开发者嵌入广告形式的广告位ID
                AdPosition = "efb305f6524e39a26ffeb07d4323c6e7",
                //广告类型为开屏广告
                InterstitialAdType = AdInterstitialType.FirstLanuche,
                //开屏广告展示时长，单位为秒
                InterstitialAdShowTime = 4
            };
            this.LayoutRoot.Children.Add(surfaceAdControl);
            new Utils().BindSurfaceAdInterstitialControlEvent(surfaceAdControl);
            surfaceAdControl.InitAdControl(AdModeType.Debug);
        }


        private void btnBannerImage_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate(typeof(Pages.BannerImagePage).Name);
        }

        private void btnBannerVideo_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate(typeof(Pages.BannerVideoPage).Name);
        }

        private void btnInterstitialImage_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate(typeof(Pages.InterstitialImagePage).Name);
        }

        private void btnInterstitialVideo_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate(typeof(Pages.InterstitialVideoPage).Name);
        }

        private void btnScreenImage_Click(object sender, RoutedEventArgs e)
        {
            //应用启动时调用实现
        }

        private void btnScreenVideo_Click(object sender, RoutedEventArgs e)
        {
            //应用启动时调用实现
        }

        void Navigate(string pageName)
        {
            this.NavigationService.Navigate(new Uri(string.Concat("/Pages/", pageName, ".xaml"), UriKind.Relative));
        }



    }
}