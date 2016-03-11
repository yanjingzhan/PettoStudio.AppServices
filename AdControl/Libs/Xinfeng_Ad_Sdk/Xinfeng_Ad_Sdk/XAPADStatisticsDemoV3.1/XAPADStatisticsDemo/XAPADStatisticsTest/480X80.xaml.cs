using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace XAPADStatisticsTest
{
    public partial class _480X80 : PhoneApplicationPage
    {
        public _480X80()
        {
            InitializeComponent();
        }
        // v3.0 增加480*80 轮播设置。
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.MyAdItem.stop();
            base.OnNavigatedFrom(e);
        }
        // v3.0 增加480*80 轮播设置。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.MyAdItem.start();
            base.OnNavigatedTo(e);
        }

        private void Hide_OnClick(object sender, RoutedEventArgs e)
        {
            MyAdItem.HideAd();
            //如果是轮播类型的广告则调用stop（目前480*80 和310*160）
            MyAdItem.stop();
        }
        private void Show_OnClick(object sender, RoutedEventArgs e)
        {
            MyAdItem.ShowAd();

            //如果是轮播类型的广告则调用start（目前480*80 和310*160）
            MyAdItem.start();
        }
    }
}