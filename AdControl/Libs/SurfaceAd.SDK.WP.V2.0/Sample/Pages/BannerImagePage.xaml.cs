using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class BannerImagePage : PhoneApplicationPage
    {
        public BannerImagePage()
        {
            InitializeComponent();

            //
            this.LoadBannerImageAd();
            //
            this.CreateBannerImageAd();
        }

        void LoadBannerImageAd()
        {
            new Utils().BindSurfaceAdControlEvent(this.surfaceAdImageXaml);
            this.surfaceAdImageXaml.InitAdControl(AdModeType.Debug);
        }

        void CreateBannerImageAd()
        {
            //开发者Token
            string adToken = "Yg84XTVRYwpiAzhaNUdjCmIR";
            //开发者嵌入广告形式的广告位ID
            string adPosition = "1d540a945bd2038404eb343ce8fda1c7";
            //广告请求间隔时间
            int adRefreshInterval = 15;
            //实例SurfaceAdControl广告控件
            var surfaceAdControl = new SurfaceAdControl(adToken, adPosition, adRefreshInterval);
            //广告控件是否显示关闭图标按钮
            surfaceAdControl.IsShowCloseIcon = true;            
            //广告控件事件绑定
            new Utils().BindSurfaceAdControlEvent(surfaceAdControl);
            //将广告控件加入页面容器中
            this.surfaceAdImageBackend.Children.Add(surfaceAdControl);
            //初始化广告控件并请求测试广告,Normal则是请求正式广告
            surfaceAdControl.InitAdControl(AdModeType.Debug);
        }


    }
}