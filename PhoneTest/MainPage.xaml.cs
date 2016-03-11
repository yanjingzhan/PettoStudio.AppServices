using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneTest.Resources;
using PAdControl.Models;
using Microsoft.Phone.Tasks;
using System.Threading.Tasks;

namespace PhoneTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            //this.Loaded += MainPage_Loaded;
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
            GetAD();
            GetRecommendAppList();
        }

        //void MainPage_Loaded(object sender, RoutedEventArgs e)
        async void GetAD()
        {
            PAdControl.AdContainer ad = new PAdControl.AdContainer();
            ad.AddAdData("surfaceadbottom", "xx", "1.0", "1",
                new List<PAdControl.Models.AdBaseModel> 
                {
                    //new PAdControl.Models.XapcnBannerModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "xapcn_banner",
                    //    AdType = "banner",
                    //    ADKey = "9df1d1dc45d57c02",
                    //    AppID = "10000595",
                    //},
                    //new PAdControl.Models.SurfaceAdBannerModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "surfacead_banner",
                    //    AdType = "banner",
                    //    IsShowCloseIcon=false,
                    //    AdPosition = "ac50871094eaba78d24f754adc4e6614",
                    //    AdToken = "Zgs2UzVRMVhmBzZUNUcxWGYV"
                    //},

                    //new PAdControl.Models.JiuUBannerModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "9u_banner",
                    //    AdType = "banner",
                    //    DeveloperAdID = "1205564ae13d846cc2e2febbb7c002e3"
                    //},

                    //new PAdControl.Models.OpenXLiveBannerModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "openxlive_banner",
                    //    AdType = "banner",
                    //    AdUnitId = "83520b1f-8fbc-4663-ad22-641869ec2a14",
                    //    ApplicationId = "091386fe-74d4-4c4b-ae43-be48c97afaac"
                    //},

                    //new PAdControl.Models.GoogleBannerModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "admob_banner",
                    //    AdType = "banner",
                    //    AdUnitID = "ca-app-pub-9032192534051324/7468422697"
                    //},

                    //new PAdControl.Models.PubCenterBannerModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "pubcenter_banner",
                    //    AdType = "banner",
                    //    //AdUnitId=new string[]{"11317482","11317483","11317484","11317485","11317486"},
                    //    //ApplicationId ="ce0d0061-8479-41a9-9924-8be3efe54eb4"
                        
                    //      AdUnitId= new string[]{"11381190","11381191","11381192","11381193","11381194"},
                    //    ApplicationId ="5f5f0af3-f07b-4c4b-9f79-541a3e1eef7d"
                    //},

                    //new PAdControl.Models.OpenXLiveChaPingModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "openxlive_chaping",
                    //    AdType = "chaping",
                    //    AdUnitId = "29ec76d9-d153-4213-9244-0ede9b00795d",
                    //    ApplicationId = "830d59de-ea15-4d37-b043-90333d6b94df"
                    //},

                    //new PAdControl.Models.GoogleChaPingModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "admob_chaping",
                    //    AdType = "chaping",
                    //    AdUnitID = "ca-app-pub-9032192534051324/2112683494"
                    //    //AdUnitID = "ca-app-pub-9032192534051324/7735571492";
                    //},

                    //new PAdControl.Models.XapcnChaPingModel
                    //{
                    //    IsAdRequestAdOk = false,
                    //    AdName = "xapcn_chaping",
                    //    AdType = "chaping",
                    //    ADKey = "9b5105a85dc50e12",
                    //    AppID = "10000758",
                    //},

                //new PAdControl.Models.SurfaceAdBannerModel
                //    {
                //        IsAdRequestAdOk = false,
                //        AdName = "surfacead_banner",
                //        AdType = "banner",
                //        AdPosition="98cd2075f1c4bc1b93d3a160039a090b",
                //        AdToken = "Zgs2UzVRMVhmBzZUNUcxWGYV"
                //    },

                    new PAdControl.Models.GoogleBannerModel
                    {
                        IsAdRequestAdOk = false,
                        AdName = "admob_banner",
                        AdType = "banner",
                        //AdUnitID = "ca-app-pub-9032192534051324/7468422697"
                        AdUnitID = "ca-app-pub-9032192534051324/8611811494"
                    },

                    new PAdControl.Models.PubCenterBannerModel
                    {
                        IsAdRequestAdOk = false,
                        AdName = "pubcenter_banner",
                        AdType = "banner",
                        AdUnitId= new string[]{"11011069"},
                        ApplicationId ="0d8852ec-2236-42c6-92c1-b007ca1ebc3b"
                    },
                                     
                    new PAdControl.Models.GoogleChaPingModel
                    {
                        IsAdRequestAdOk = false,
                        AdName = "admob_chaping",
                        AdType = "chaping",
                        //AdUnitID = "ca-app-pub-9032192534051324/8945155894"
                        AdUnitID = "ca-app-pub-9032192534051324/2565277895"
                    }
                });

            //ad.GetAdInfo();


            PAdControl.AdEventArgs sysE = new PAdControl.AdEventArgs();
            sysE.AdInfoList = new List<AdInfo>
            {
                new AdInfo
                {
                    AdIndex = 1,
                    AdName= "pubcenter_banner",
                    AdTpye = "banner",
                    CarouselBannersInterval = 20,
                    ClickCountToHide = 0,
                    IsDontRefresh = false,
                    Position = "center_bottom",
                    PRI = 1,
                    RefreshBannersInterval = 27,
                    ShowFullAdCount = -1
                },
                new AdInfo
                {
                    AdIndex = 1,
                    AdName= "admob_banner",
                    AdTpye = "banner",
                    CarouselBannersInterval = 20,
                    ClickCountToHide = 0,
                    IsDontRefresh = false,
                    Position = "center_bottom",
                    PRI = 2,
                    RefreshBannersInterval = 27,
                    ShowFullAdCount = -1
                },

                new AdInfo
                {
                    AdIndex = 1,
                    AdName= "surfacead_banner",
                    AdTpye = "banner",
                    CarouselBannersInterval = 20,
                    ClickCountToHide = 0,
                    IsDontRefresh = false,
                    Position = "center_bottom",
                    PRI = 3,
                    RefreshBannersInterval = 27,
                    ShowFullAdCount = -1
                },

                new AdInfo
                {
                    AdIndex = 1,
                    AdName= "admob_chaping",
                    AdTpye = "chaping",
                    CarouselBannersInterval = 20,
                    ClickCountToHide = 0,
                    IsDontRefresh = false,
                    Position = "center_center",
                    PRI = 3,
                    RefreshBannersInterval = 27,
                    ShowFullAdCount = 3
                }
            };

            ad.InitLocalInfo(sysE);

            LayoutRoot.Children.Add(ad);

            await Task.Delay(TimeSpan.FromSeconds(10));

            PAdControl.Models.AdInfo t = null;
            foreach (var item in ad.ChaPingAdInfoList)
            {
                if (item.AdName == "admob_chaping")
                {
                    t = item;
                    break;
                }
            }
            if (t != null &&
                (t.ShowFullAdCount == 0 || t.ShowFullAdCount > new PAdControl.Handlers.BannerAdHandlerBase().GetAdClickCount("admob_chaping")))
            {
                ad.ShowGoogleChaPing();
            }

        }

        void GetRecommendAppList()
        {
            PAdControl.Handlers.RecommandAppHandlerBase.Instance.GetRecommendAppListAsync("tiequan3", "emu_en");
            PAdControl.Handlers.RecommandAppHandlerBase.Instance.GetRecommendAppListCompleted += Instance_GetRecommendAppListCompleted;
        }

        void Instance_GetRecommendAppListCompleted(object sender, PAdControl.RecommendAppEventArgs e)
        {
            List<RecommendAppModel> r = e.RecommendAppList;
            r.Sort((left, right) =>
                {
                    if (left.PRI > right.PRI)
                        return 1;
                    else if (left.PRI == right.PRI)
                        return 0;
                    else
                        return -1;
                });

            ListBox_RecommendApp.ItemsSource = r;
        }

        private void Grid_GetApp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask ie = new WebBrowserTask();
            ie.Uri = new Uri((sender as FrameworkElement).Tag.ToString(), UriKind.Absolute);
            ie.Show();
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("xx");
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}