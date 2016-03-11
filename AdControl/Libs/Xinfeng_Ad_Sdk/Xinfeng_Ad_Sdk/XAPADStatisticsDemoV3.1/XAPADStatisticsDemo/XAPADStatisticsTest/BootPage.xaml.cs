using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Shell;

namespace XAPADStatisticsTest
{
    public partial class BootPage : PhoneApplicationPage
    {
        public BootPage()
        {
            //可以根据 开发者需求 是否添加 第一次未缓存时引导图片。
            InitializeComponent();
            //是否缓存
            if (this.AdItem.isCache())
            {
                this.AdItem.ADClosed += (s, e) =>
                {
                    //跳转页面为应用主页面
                    App.RootFrame.Navigate(new Uri("/MainPage.xaml？Protocol=true", UriKind.Relative));
                };
            }
            //没有缓存显示本地引导图片自定义跳转
            else
            {
                //触发跳转事件
                this.AdItem.jumpStart();
                this.AdItem.ADJumpStart += (sender, args) =>
                {
                    //跳转页面为应用主页面
                    App.RootFrame.Navigate(new Uri("/MainPage.xaml？Protocol=true", UriKind.Relative));

                };
                BootBack.Visibility = Visibility.Visible;
            }
        }
    }
}