using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XAPADStatistics;


namespace XAPADStatisticsTest
{
    public partial class AdCom390_480 : PhoneApplicationPage
    {
        DispatcherTimer dispatcher = new DispatcherTimer();
        public AdCom390_480()
        {
            InitializeComponent();
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 300);
            dispatcher.Tick += (sender, args) =>
            {
                //新的广告 参数需要重新配置 此种广告为动画广告
                AdItem adItem = new AdItem();
                adItem.ADKey = "70f86bba4fba8676400c71ede303558c";
                adItem.AppID = "10000078";
                adItem.Size = SizeMode.SizeW390H550;
                MyPopup.Child = adItem;
                MyPopup.IsOpen = true;
                dispatcher.Stop();
            };
            this.Loaded += (sender, args) =>
            {
                dispatcher.Start();
            };
        }
    }
}