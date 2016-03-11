using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XAPADStatisticsTest.Resources;

namespace XAPADStatisticsTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void W480H80(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/480X80.xaml", UriKind.Relative));
        }

        private void W390H550(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/390X550.xaml", UriKind.Relative));
        }

        private void W550H390(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/550X390.xaml", UriKind.Relative));
        }

        private void W480H600(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/480X600.xaml", UriKind.Relative));
        }

        private void W600H480(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/600X480.xaml", UriKind.Relative));
        }

        private void W480H800(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/480X800.xaml", UriKind.Relative));
        }

        private void W310H160(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/310X160.xaml", UriKind.Relative));
        }

        private void AdCom390480(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/AdCom390+480.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/PersonalityAD.xaml", UriKind.Relative));
            base.OnBackKeyPress(e);
        }

        private void W300H50(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/300X50.xaml", UriKind.Relative));
        }
        private void W480H80Back(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/480X80BACk.xaml", UriKind.Relative));
        }
        //清空历史页面
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            while (App.RootFrame.BackStack.Count() > 0)
            {
                App.RootFrame.RemoveBackEntry();
            }
            base.OnNavigatedTo(e);
        }
    }
}