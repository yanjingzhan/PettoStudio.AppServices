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

namespace XAPADStatisticsTest
{
    public partial class PersonalityAD : PhoneApplicationPage
    {
        public PersonalityAD()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            base.OnBackKeyPress(e);
        }

        private void Instal_OnClick(object sender, RoutedEventArgs e)
        {
            //安装调用事件
            MyAdItem.SetupProgram();
        }

        private void Exit_Onclick(object sender, RoutedEventArgs e)
        {
            App.Current.Terminate();
        }
    }
}