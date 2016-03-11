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
    public partial class _310X160 : PhoneApplicationPage
    {
        public _310X160()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //停止轮播
            this.AdItem.stop();
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //开始轮播
            this.AdItem.start();
            base.OnNavigatedTo(e);
        }
    }
}