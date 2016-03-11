using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;

namespace OpenXLiveAdTest
{
    public partial class MainPage
    {
        private const string Folder = "OpenXLiveAdsCache";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Do();
        }

        void Do()
        {
            OpenXLive.Advertising.AdControl openXLiveBanner = new OpenXLive.Advertising.AdControl
            {
                ApplicationId = "aa5c1c3e-6cd7-4296-9d4e-c46fa192f85b",
                Type = OpenXLive.Advertising.AdType.Banner,
                AdUnitId = "cf14959a-399d-49c9-90c4-e39a3bb8cdad",
                IsCloseIconEnabled = false,
            };

            openXLiveBanner.AdCompleted += (s1, e1) =>
            {
                
            };

            openXLiveBanner.ErrorOccurred += (s1, e1) =>
            {

            };

            //openXLiveBanner.Opacity = 0;
            //openXLiveBanner.IsHitTestVisible = false;

            LayoutRoot.Children.Add(openXLiveBanner);
            System.Diagnostics.Debug.WriteLine("openXLiveBanner");
        }

        private void BtnFullScreen_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FullScreenPage.xaml", UriKind.Relative));
        }
        private void BtnFullScreenHorizontal_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HorizontalFullScreenPage.xaml", UriKind.Relative));
        }

        private void BtnBanner_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BannerPage.xaml", UriKind.Relative));
        }

        private void BtnInterstitial_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InterstitialPage.xaml", UriKind.Relative));
        }
        private void BtnInterstitialHorizontal_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HorizontalInterstitialPage.xaml", UriKind.Relative));
        }

        private void BtnClear_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    DeleteFolder(store, Folder);
                }
                Application.Current.Terminate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteFolder(IsolatedStorageFile store, string folder)
        {
            var pattern = folder + @"\*";
            var files = store.GetFileNames(pattern);
            foreach (var fName in files)
            {
                store.DeleteFile(Path.Combine(folder, fName));
            }
            var dirs = store.GetDirectoryNames(pattern);
            foreach (var dName in dirs)
            {
                DeleteFolder(store, Path.Combine(folder, dName));
            }
            store.DeleteDirectory(folder);
        }
    }
}