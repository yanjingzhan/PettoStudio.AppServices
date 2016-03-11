using System;
using System.Windows;
using OpenXLive.Advertising;

namespace OpenXLiveAdTest
{
    public partial class BannerPage
    {
        public BannerPage()
        {
            InitializeComponent();
        }

        private void BtnHideOrShow_OnClick(object sender, RoutedEventArgs e)
        {
            AdControl.Visibility = AdControl.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void BtnSize_OnClick(object sender, RoutedEventArgs e)
        {
            AdControl.Height = AdControl.RenderSize == new Size(480, 80) ? 70 : 80;
        }

        private void BtnRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            AdControl.Refresh();
        }

        private void BtnSuspend_OnClick(object sender, RoutedEventArgs e)
        {
            AdControl.Suspend();
        }

        private void BtnResume_OnClick(object sender, RoutedEventArgs e)
        {
            AdControl.Resume();
        }

        private void AdControl_OnAdRefreshed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad refreshed.");
        }

        private void AdControl_OnAdCompleted(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad load completed.");
        }

        private void AdControl_OnErrorOccurred(object sender, AdErrorEventArgs e)
        {
            MessageBox.Show(string.Format("Error: {0} {1}", e.Code, e.Message));
        }

        private void AdControl_OnIsEngagedChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad is engaged.");
        }

        private void BtnShowCloseIcon_OnClick(object sender, RoutedEventArgs e)
        {
            AdControl.IsCloseIconEnabled = !AdControl.IsCloseIconEnabled;
        }
    }
}