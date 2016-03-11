using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XAPADStatistics;

namespace XAPADStatisticsTest
{
    public partial class _480X80BACk : PhoneApplicationPage
    {
        private AdItem adItem = null;
        public _480X80BACk()
        {
            InitializeComponent();

            adItem = new AdItem();
            adItem.ADKey = "d36beb4813815962";
            adItem.AppID = "10000626";
            adItem.Size = SizeMode.SizeW480H80;
            MyPopup.Child = adItem;
        }
        //离开页面关闭广告否则一直显示
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.adItem.stop();
            this.MyPopup.IsOpen = false;
            base.OnNavigatingFrom(e);
        }
        //进入页面显示广告
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.adItem.start();
            this.MyPopup.IsOpen = true;
            base.OnNavigatedTo(e);
        }
    }
}