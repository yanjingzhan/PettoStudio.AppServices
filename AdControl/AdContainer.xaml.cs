using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PAdControl.Models;
using PAdControl.Handlers;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PAdControl
{
    public partial class AdContainer : UserControl
    {
        public List<AdBaseModel> ModelList;
        private BannerAdHandlerBase _adHandler;
        private string _appName;
        private string _appId;
        private string _appVersion;
        private string _adIndex;

        public List<AdInfo> BannerAndDiyAdInfoList;
        public List<AdInfo> ChaPingAdInfoList;

        private int _currentBannerAdIndex = 0;

        private DispatcherTimer _refreshBannersTimer;
        private DispatcherTimer _carouselBannersTimer;

        public int CarouselTimespan = 30;

        private int _currentChaPingAdIndex = 0;
        private DispatcherTimer _chaPingTimer;

        //Surfacead banners

        Grid surfaceAdContainer = null;
        Grid xapAdContainer = null;
        Grid openAdContainer = null;
        Grid jiuUAdContainer = null;
        Grid googleAdContainer = null;
        Grid pubcenterAdContainer = null;


        //SurfaceAd.SDK.WP.SurfaceAdControl surfaceAdBanner = null;
        //XAPADStatistics.AdItem xapcnBanner = null;
        //OpenXLive.Advertising.AdControl openXLiveBanner = null;
        //JiuYouWp8Ad.JiuYouWp8AdControl jiuUBanner = null;
        GoogleAds.AdView googleBanner = null;
        Microsoft.Advertising.Mobile.UI.AdControl pubCenterBanner = null;

        public AdContainer()
        {
            InitializeComponent();

            _adHandler = new BannerAdHandlerBase();
            _adHandler.GetAdInfoCompleted += adHandler_GetAdInfoCompleted;

            BannerAndDiyAdInfoList = new List<AdInfo>();
            ChaPingAdInfoList = new List<AdInfo>();

            _refreshBannersTimer = new DispatcherTimer();
            _carouselBannersTimer = new DispatcherTimer();
            _chaPingTimer = new DispatcherTimer();

            surfaceAdContainer = new Grid { Name = "surfaceAdContainer" };
            xapAdContainer = new Grid { Name = "xapAdContainer" };
            openAdContainer = new Grid { Name = "openAdContainer" };
            jiuUAdContainer = new Grid { Name = "jiuUAdContainer" };
            googleAdContainer = new Grid { Name = "googleAdContainer" };
            pubcenterAdContainer = new Grid { Name = "pubcenterAdContainer" };
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appId"></param>
        /// <param name="appVersion"></param>
        /// <param name="models"></param>
        public void AddAdData(string appName, string appId, string appVersion, string adIndex, List<AdBaseModel> models)
        {
            _appName = appName;
            _appId = appId;
            _appVersion = appVersion;
            _adIndex = adIndex;
            ModelList = new List<AdBaseModel>(models.ToArray());
        }

        /// <summary>
        /// 获取广告
        /// </summary>
        public void GetAdInfo()
        {
            _adHandler.GetAdInfoAsync(_appName, _appVersion, _appId, _adIndex);
        }

        /// <summary>
        /// 获取到广告了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void adHandler_GetAdInfoCompleted(object sender, AdEventArgs e)
        {
            if (e.AdInfoList != null && e.AdInfoList.Count > 0)
            {
                foreach (var item in e.AdInfoList)
                {
                    var t = GetAdBaseModelByAdName(item.AdName);

                    if (t != null)
                    {
                        if (item.AdTpye.ToLower() == "banner" || item.AdTpye.ToLower() == "diy")
                        {
                            BannerAndDiyAdInfoList.Add(item);
                        }
                        else if (item.AdTpye.ToLower() == "chaping")
                        {
                            ChaPingAdInfoList.Add(item);
                        }
                    }
                }

                BannerAndDiyAdInfoList.Sort((left, right) =>
                {
                    if (left.PRI > right.PRI)
                        return 1;
                    else if (left.PRI == right.PRI)
                        return 0;
                    else
                        return -1;
                });

                ChaPingAdInfoList.Sort((left, right) =>
                {
                    if (left.PRI > right.PRI)
                        return 1;
                    else if (left.PRI == right.PRI)
                        return 0;
                    else
                        return -1;
                });

                #region Banner

                InitAdBanners();

                _refreshBannersTimer.Interval = TimeSpan.FromSeconds(new Random().Next(25, 30));
                _refreshBannersTimer.Tick -= _refreshBannersTimer_Tick;
                _refreshBannersTimer.Tick += _refreshBannersTimer_Tick;

                _refreshBannersTimer.Start();

                _carouselBannersTimer.Interval = TimeSpan.FromSeconds(CarouselTimespan);
                //_carouselBannersTimer.Interval = TimeSpan.FromSeconds(5);
                _carouselBannersTimer.Tick -= _carouselBannersTimer_Tick;
                _carouselBannersTimer.Tick += _carouselBannersTimer_Tick;

                _carouselBannersTimer.Start();

                #endregion

                #region ChaPing

                //_chaPingTimer.Tick -= _chaPingTimer_Tick;
                //_chaPingTimer.Tick += _chaPingTimer_Tick;

                //InitChaPing();
                #endregion
            }
        }

        private bool _fromLocal = false;
        /// <summary>
        /// 本地数据
        /// </summary>
        /// <param name="e"></param>
        public void InitLocalInfo(AdEventArgs e)
        {
            if (e.AdInfoList != null && e.AdInfoList.Count > 0)
            {
                _fromLocal = true;
                foreach (var item in e.AdInfoList)
                {
                    var t = GetAdBaseModelByAdName(item.AdName);

                    if (t != null)
                    {
                        if (item.AdTpye.ToLower() == "banner" || item.AdTpye.ToLower() == "diy")
                        {
                            BannerAndDiyAdInfoList.Add(item);
                        }
                        else if (item.AdTpye.ToLower() == "chaping")
                        {
                            ChaPingAdInfoList.Add(item);
                        }
                    }
                }

                BannerAndDiyAdInfoList.Sort((left, right) =>
                {
                    if (left.PRI > right.PRI)
                        return 1;
                    else if (left.PRI == right.PRI)
                        return 0;
                    else
                        return -1;
                });

                ChaPingAdInfoList.Sort((left, right) =>
                {
                    if (left.PRI > right.PRI)
                        return 1;
                    else if (left.PRI == right.PRI)
                        return 0;
                    else
                        return -1;
                });

                #region Banner

                InitAdBanners();

                _refreshBannersTimer.Interval = TimeSpan.FromSeconds(new Random().Next(25, 30));
                _refreshBannersTimer.Tick -= _refreshBannersTimer_Tick;
                _refreshBannersTimer.Tick += _refreshBannersTimer_Tick;

                _refreshBannersTimer.Start();

                _carouselBannersTimer.Interval = TimeSpan.FromSeconds(CarouselTimespan);
                //_carouselBannersTimer.Interval = TimeSpan.FromSeconds(5);
                _carouselBannersTimer.Tick -= _carouselBannersTimer_Tick;
                _carouselBannersTimer.Tick += _carouselBannersTimer_Tick;

                _carouselBannersTimer.Start();

                #endregion

                #region ChaPing

                //_chaPingTimer.Tick -= _chaPingTimer_Tick;
                //_chaPingTimer.Tick += _chaPingTimer_Tick;

                //InitChaPing();
                #endregion
            }
        }


        #region Banner
        void _refreshBannersTimer_Tick(object sender, EventArgs e)
        {
            _refreshBannersTimer.Stop();
            InitAdBanners();

            _refreshBannersTimer.Interval = TimeSpan.FromSeconds(new Random().Next(25, 30));
            _refreshBannersTimer.Tick -= _refreshBannersTimer_Tick;
            _refreshBannersTimer.Tick += _refreshBannersTimer_Tick;

            _refreshBannersTimer.Start();
        }

        void _carouselBannersTimer_Tick(object sender, EventArgs e)
        {
            _carouselBannersTimer.Stop();

            CarouselBanners();

            _carouselBannersTimer.Tick -= _carouselBannersTimer_Tick;
            _carouselBannersTimer.Tick += _carouselBannersTimer_Tick;

            _carouselBannersTimer.Start();
        }

        /// <summary>
        /// 初始化Banner信息
        /// </summary>
        void InitAdBanners()
        {
            foreach (var item in BannerAndDiyAdInfoList)
            {
                if (item.IsDontRefresh)
                {
                    continue;
                }

                item.IsDontRefresh = item.RefreshBannersInterval == 0;

                /*2015年4月30日
                if (item.AdName == "surfacead_banner")
                {
                    InitSurfaceAdBanner();
                    continue;
                }
                 */

                //if (item.AdName == "xapcn_banner")
                //{
                //    InitXapcnBanner();
                //    continue;
                //}

                //if (item.AdName == "openxlive_banner")
                //{
                //    InitOpenXLiveBanner();
                //    continue;
                //}

                //if (item.AdName == "9u_banner")
                //{
                //    InitJiuUBanner();
                //    continue;
                //}

                if (item.AdName == "admob_banner")
                {
                    InitGoogleBanner();
                    continue;
                }

                if (item.AdName == "pubcenter_banner")
                {
                    InitPubCenterBanner();
                    continue;
                }
            }

            if (LayoutRoot.Children.Count == 0)
            {
                return;
            }

            for (int i = 0; i < LayoutRoot.Children.Count; i++)
            {
                if (_currentBannerAdIndex >= LayoutRoot.Children.Count)
                {
                    _currentBannerAdIndex = 0;
                }

                AdInfo adinfo_t = BannerAndDiyAdInfoList[_currentBannerAdIndex];
                AdBaseModel a_t = GetAdBaseModelByAdName(adinfo_t.AdName);

                if ((adinfo_t.ClickCountToHide == 0 ||
                    adinfo_t.ClickCountToHide > _adHandler.GetAdClickCount(adinfo_t.AdName)))
                {
                    break;
                }
                _currentBannerAdIndex++;

                if (_currentBannerAdIndex >= LayoutRoot.Children.Count)
                {
                    _currentBannerAdIndex = 0;
                }
            }

            AdInfo adinfo_to = BannerAndDiyAdInfoList[_currentBannerAdIndex];
            AdBaseModel a_to = GetAdBaseModelByAdName(adinfo_to.AdName);

            foreach (var item in LayoutRoot.Children)
            {
                //if (((adinfo_to.AdName == "surfacead_banner" && item is SurfaceAd.SDK.WP.SurfaceAdControl)
                //    || (adinfo_to.AdName == "xapcn_banner" && item is XAPADStatistics.AdItem)
                //    || (adinfo_to.AdName == "openxlive_banner" && item is OpenXLive.Advertising.AdControl)
                //    || (adinfo_to.AdName == "9u_banner" && item is OpenXLive.Advertising.AdControl)
                //    || (adinfo_to.AdName == "admob_banner" && item is GoogleAds.AdView)
                //    || (adinfo_to.AdName == "pubcenter_banner" && item is Microsoft.Advertising.Mobile.UI.AdControl))
                //    && (adinfo_to.ClickCountToHide == 0 || adinfo_to.ClickCountToHide > _adHandler.GetAdClickCount(adinfo_to.AdName)))

                if ((
                    //(adinfo_to.AdName == "surfacead_banner" && item is Grid && (item as Grid).Name == "surfaceAdContainer")
                    //|| (adinfo_to.AdName == "xapcn_banner" && item is Grid && (item as Grid).Name == "xapAdContainer")
                    //|| (adinfo_to.AdName == "openxlive_banner" && item is Grid && (item as Grid).Name == "openAdContainer")
                    //|| (adinfo_to.AdName == "9u_banner" && item is Grid && (item as Grid).Name == "jiuUAdContainer")
                  //|| 
                  (adinfo_to.AdName == "admob_banner" && item is Grid && (item as Grid).Name == "googleAdContainer")
                  || (adinfo_to.AdName == "pubcenter_banner" && item is Grid && (item as Grid).Name == "pubcenterAdContainer"))
                  && (adinfo_to.ClickCountToHide == 0 || adinfo_to.ClickCountToHide > _adHandler.GetAdClickCount(adinfo_to.AdName)))
                {
                    item.Opacity = 1;
                    item.IsHitTestVisible = true;

                    continue;
                }
                else
                {
                    item.Opacity = 0;
                    item.IsHitTestVisible = false;
                }
            }

            SetAdPosition(adinfo_to.Position);

            int refreshInterval_t = adinfo_to.RefreshBannersInterval >= 20 ? adinfo_to.RefreshBannersInterval : 27;
            _refreshBannersTimer.Interval = TimeSpan.FromSeconds(new Random().Next(refreshInterval_t - 3, refreshInterval_t + 3));

            int carouselInterval_t = adinfo_to.CarouselBannersInterval >= 20 ? adinfo_to.CarouselBannersInterval : 30;
            _carouselBannersTimer.Interval = TimeSpan.FromSeconds(carouselInterval_t);
        }

        void CarouselBanners()
        {
            if (LayoutRoot.Children.Count == 0)
            {
                return;
            }

            for (int i = 0; i < LayoutRoot.Children.Count; i++)
            {
                _currentBannerAdIndex++;

                if (_currentBannerAdIndex >= LayoutRoot.Children.Count)
                {
                    _currentBannerAdIndex = 0;
                }

                AdInfo adinfo_t = BannerAndDiyAdInfoList[_currentBannerAdIndex];
                AdBaseModel a_t = GetAdBaseModelByAdName(adinfo_t.AdName);
                if (a_t.IsAdRequestAdOk && (adinfo_t.ClickCountToHide == 0 ||
                    adinfo_t.ClickCountToHide > _adHandler.GetAdClickCount(adinfo_t.AdName)))
                {
                    foreach (var item in LayoutRoot.Children)
                    {
                        //if (((adinfo_t.AdName == "surfacead_banner" && item is SurfaceAd.SDK.WP.SurfaceAdControl)
                        //    || (adinfo_t.AdName == "xapcn_banner" && item is XAPADStatistics.AdItem)
                        //    || (adinfo_t.AdName == "openxlive_banner" && item is OpenXLive.Advertising.AdControl)
                        //    || (adinfo_t.AdName == "9u_banner" && item is OpenXLive.Advertising.AdControl)
                        //    || (adinfo_t.AdName == "admob_banner" && item is GoogleAds.AdView)
                        //    || (adinfo_t.AdName == "pubcenter_banner" && item is Microsoft.Advertising.Mobile.UI.AdControl))
                        //    && (adinfo_t.ClickCountToHide == 0 || adinfo_t.ClickCountToHide > _adHandler.GetAdClickCount(adinfo_t.AdName)))

                        if ((
                            //(adinfo_t.AdName == "surfacead_banner" && item is Grid && (item as Grid).Name == "surfaceAdContainer")
                            //|| (adinfo_t.AdName == "xapcn_banner" && item is Grid && (item as Grid).Name == "xapAdContainer")
                            //|| (adinfo_t.AdName == "openxlive_banner" && item is Grid && (item as Grid).Name == "openAdContainer")
                            //|| (adinfo_t.AdName == "9u_banner" && item is Grid && (item as Grid).Name == "jiuUAdContainer")
                            //|| 
                            (adinfo_t.AdName == "admob_banner" && item is Grid && (item as Grid).Name == "googleAdContainer")
                            || (adinfo_t.AdName == "pubcenter_banner" && item is Grid && (item as Grid).Name == "pubcenterAdContainer"))
                            && (adinfo_t.ClickCountToHide == 0 || adinfo_t.ClickCountToHide > _adHandler.GetAdClickCount(adinfo_t.AdName)))
                        {
                            item.Opacity = 1;
                            item.IsHitTestVisible = true;

                            continue;
                        }
                        else
                        {
                            item.Opacity = 0;
                            item.IsHitTestVisible = false;
                        }
                    }

                    SetAdPosition(adinfo_t.Position);
                    break;
                }
            }
        }

      
        /*2015年4月30日
         /// <summary>
        /// Surfacead
        /// </summary>
        void InitSurfaceAdBanner()
        {
            SurfaceAdBannerModel surfaceAdBannerModel = GetAdBaseModelByAdName("surfacead_banner") as SurfaceAdBannerModel;

            if (surfaceAdBannerModel != null)
            {
                surfaceAdBannerModel.IsAdRequestAdOk = false;

                //if (LayoutRoot.Children.Contains(surfaceAdBanner))
                //{
                //    LayoutRoot.Children.Remove(surfaceAdBanner);
                //}

                if (LayoutRoot.Children.Contains(surfaceAdContainer))
                {
                    LayoutRoot.Children.Remove(surfaceAdContainer);
                }

                surfaceAdBanner = new SurfaceAd.SDK.WP.SurfaceAdControl(surfaceAdBannerModel.AdToken, surfaceAdBannerModel.AdPosition);
                surfaceAdBanner.InitAdControl(SurfaceAd.SDK.WP.AdModeType.Normal);
                surfaceAdBanner.IsShowCloseIcon = surfaceAdBannerModel.IsShowCloseIcon;

                surfaceAdBanner.OnAdRequestLoaded -= surfaceAdBanner_OnAdRequestLoaded;
                surfaceAdBanner.OnAdRequestLoaded += surfaceAdBanner_OnAdRequestLoaded;

                surfaceAdBanner.OnAdRequestFailed -= surfaceAdBanner_OnAdRequestFailed;
                surfaceAdBanner.OnAdRequestFailed += surfaceAdBanner_OnAdRequestFailed;

                //surfaceAdBanner.Opacity = 0;
                //surfaceAdBanner.IsHitTestVisible = false;

                surfaceAdContainer.Children.Clear();
                surfaceAdContainer.Children.Add(surfaceAdBanner);
                surfaceAdContainer.Opacity = 0;
                surfaceAdContainer.IsHitTestVisible = false;

                //if (!LayoutRoot.Children.Contains(surfaceAdBanner))
                //{
                //    LayoutRoot.Children.Add(surfaceAdBanner);
                //}

                if (!LayoutRoot.Children.Contains(surfaceAdContainer))
                {
                    LayoutRoot.Children.Add(surfaceAdContainer);
                }
                System.Diagnostics.Debug.WriteLine("Surfacead");
            }
        }

        void surfaceAdBanner_OnAdRequestFailed(object sender, SurfaceAd.SDK.WP.SurfaceAdEventArgs e)
        {
            InitSurfaceAdBanner();
        }

        void surfaceAdBanner_OnAdRequestLoaded(object sender, EventArgs e)
        {
            SurfaceAdBannerModel surfaceAdBannerModel = GetAdBaseModelByAdName("surfacead_banner") as SurfaceAdBannerModel;

            if (surfaceAdBannerModel != null)
            {
                surfaceAdBannerModel.IsAdRequestAdOk = true;

                //标志此轮可以点击了
                surfaceAdBannerModel.IsShouldShowThisRound = true;

                AdInfo adInfo_t = GetAdInfoByAdName("surfacead_banner");
                _adHandler.PostAdShowCount(_appName, _appId, _appVersion, adInfo_t.AdName, adInfo_t.AdTpye, "0", "1", adInfo_t.AdIndex.ToString());
            };
        }
        */

        /* 
        /// <summary>
        /// Xapcn
        /// </summary>
        void InitXapcnBanner()
        {
            XapcnBannerModel xapcnBannerModel = GetAdBaseModelByAdName("xapcn_banner") as XapcnBannerModel;

            if (xapcnBannerModel != null)
            {
                xapcnBannerModel.IsAdRequestAdOk = false;

                //if (LayoutRoot.Children.Contains(xapcnBanner))
                //{
                //    LayoutRoot.Children.Remove(xapcnBanner);
                //}

                if (LayoutRoot.Children.Contains(xapAdContainer))
                {
                    LayoutRoot.Children.Remove(xapAdContainer);
                }

                xapcnBanner = new XAPADStatistics.AdItem();

                xapcnBanner.ADKey = xapcnBannerModel.ADKey;
                xapcnBanner.AppID = xapcnBannerModel.AppID;
                xapcnBanner.Size = XAPADStatistics.SizeMode.SizeW480H80;

                xapcnBanner.start();

                xapcnBanner.ADReqeustSuccessed -= xapcnBanner_ADReqeustSuccessed;
                xapcnBanner.ADReqeustSuccessed += xapcnBanner_ADReqeustSuccessed;

                xapcnBanner.ADRequestFaile -= xapcnBanner_ADRequestFaile;
                xapcnBanner.ADRequestFaile += xapcnBanner_ADRequestFaile;

                //xapcnBanner.Opacity = 0;
                //xapcnBanner.IsHitTestVisible = false;
                xapAdContainer.Children.Clear();
                xapAdContainer.Children.Add(xapcnBanner);
                xapAdContainer.Opacity = 0;
                xapAdContainer.IsHitTestVisible = false;

                //if (!LayoutRoot.Children.Contains(xapcnBanner))
                //{
                //    LayoutRoot.Children.Add(xapcnBanner);
                //}

                if (!LayoutRoot.Children.Contains(xapAdContainer))
                {
                    LayoutRoot.Children.Add(xapAdContainer);
                }

                System.Diagnostics.Debug.WriteLine("xapcnBanner");
            }
        }

        void xapcnBanner_ADRequestFaile(object sender, EventArgs e)
        {
            InitXapcnBanner();
        }

        void xapcnBanner_ADReqeustSuccessed(object sender, EventArgs e)
        {
            XapcnBannerModel xapcnBannerModel = GetAdBaseModelByAdName("xapcn_banner") as XapcnBannerModel;

            if (xapcnBannerModel != null)
            {
                xapcnBannerModel.IsAdRequestAdOk = true;
                //标志此轮初始化完了
                xapcnBannerModel.IsShouldShowThisRound = true;

                AdInfo adInfo_t = GetAdInfoByAdName("xapcn_banner");
                _adHandler.PostAdShowCount(_appName, _appId, _appVersion, adInfo_t.AdName, adInfo_t.AdTpye, "0", "1", adInfo_t.AdIndex.ToString());
            };
        }

        /// <summary>
        /// OpenXLive
        /// </summary>
        void InitOpenXLiveBanner()
        {
            OpenXLiveBannerModel openXLiveBannerModel = GetAdBaseModelByAdName("openxlive_banner") as OpenXLiveBannerModel;

            if (openXLiveBannerModel != null)
            {
                openXLiveBannerModel.IsAdRequestAdOk = false;

                //if (LayoutRoot.Children.Contains(openXLiveBanner))
                //{
                //    LayoutRoot.Children.Remove(openXLiveBanner);
                //}

                if (LayoutRoot.Children.Contains(openAdContainer))
                {
                    LayoutRoot.Children.Remove(openAdContainer);
                }


                openXLiveBanner = new OpenXLive.Advertising.AdControl
                {
                    ApplicationId = openXLiveBannerModel.ApplicationId,
                    Type = OpenXLive.Advertising.AdType.Banner,
                    AdUnitId = openXLiveBannerModel.AdUnitId,
                    IsCloseIconEnabled = false
                };

                openXLiveBanner.AdCompleted -= openXLiveBanner_AdCompleted;
                openXLiveBanner.AdCompleted += openXLiveBanner_AdCompleted;

                openXLiveBanner.ErrorOccurred -= openXLiveBanner_ErrorOccurred;
                openXLiveBanner.ErrorOccurred += openXLiveBanner_ErrorOccurred;

                //openXLiveBanner.Opacity = 0;
                //openXLiveBanner.IsHitTestVisible = false;

                openAdContainer.Children.Clear();
                openAdContainer.Children.Add(openXLiveBanner);
                openAdContainer.Opacity = 0;
                openAdContainer.IsHitTestVisible = false;

                //if (!LayoutRoot.Children.Contains(openXLiveBanner))
                //{
                //    LayoutRoot.Children.Add(openXLiveBanner);
                //}


                if (!LayoutRoot.Children.Contains(openAdContainer))
                {
                    LayoutRoot.Children.Add(openAdContainer);
                }

                System.Diagnostics.Debug.WriteLine("openXLiveBanner");
            }
        }

        void openXLiveBanner_ErrorOccurred(object sender, OpenXLive.Advertising.AdErrorEventArgs e)
        {
            //InitOpenXLiveBanner();
        }

        void openXLiveBanner_AdCompleted(object sender, EventArgs e)
        {
            OpenXLiveBannerModel openXLiveBannerModel = GetAdBaseModelByAdName("openxlive_banner") as OpenXLiveBannerModel;

            if (openXLiveBannerModel != null)
            {
                openXLiveBannerModel.IsAdRequestAdOk = true;

                //标志此轮初始化完了
                openXLiveBannerModel.IsShouldShowThisRound = true;

                AdInfo adInfo_t = GetAdInfoByAdName("openxlive_banner");
                _adHandler.PostAdShowCount(_appName, _appId, _appVersion, adInfo_t.AdName, adInfo_t.AdTpye, "0", "1", adInfo_t.AdIndex.ToString());
            };
        }

        /// <summary>
        /// 9U
        /// </summary>
        void InitJiuUBanner()
        {
            JiuUBannerModel jiuUBannerModel = GetAdBaseModelByAdName("9u_banner") as JiuUBannerModel;

            if (jiuUBannerModel != null)
            {
                jiuUBannerModel.IsAdRequestAdOk = false;

                //if (LayoutRoot.Children.Contains(jiuUBanner))
                //{
                //    LayoutRoot.Children.Remove(jiuUBanner);
                //}

                if (LayoutRoot.Children.Contains(jiuUAdContainer))
                {
                    LayoutRoot.Children.Remove(jiuUAdContainer);
                }


                jiuUBanner = new JiuYouWp8Ad.JiuYouWp8AdControl();
                jiuUBanner.DeveloperAdID = jiuUBannerModel.DeveloperAdID;


                jiuUBanner.GetAdBackMessageEvent -= jiuUBanner_GetAdBackMessageEvent;
                jiuUBanner.GetAdBackMessageEvent += jiuUBanner_GetAdBackMessageEvent;

                jiuUBanner.Start();

                //jiuUBanner.Opacity = 0;
                //jiuUBanner.IsHitTestVisible = false;

                jiuUAdContainer.Children.Clear();
                jiuUAdContainer.Children.Add(jiuUBanner);
                jiuUAdContainer.Opacity = 0;
                jiuUAdContainer.IsHitTestVisible = false;

                //if (!LayoutRoot.Children.Contains(jiuUBanner))
                //{
                //    LayoutRoot.Children.Add(jiuUBanner);
                //}

                if (!LayoutRoot.Children.Contains(jiuUAdContainer))
                {
                    LayoutRoot.Children.Add(jiuUAdContainer);
                }

                System.Diagnostics.Debug.WriteLine("jiuUBanner");
            }
        }

        void jiuUBanner_GetAdBackMessageEvent(object sender, JiuYouWp8Ad.GetAdBackMessage e)
        {
            JiuUBannerModel jiuUBannerModel = GetAdBaseModelByAdName("9u_banner") as JiuUBannerModel;

            if (jiuUBannerModel != null)
            {
                if (e.GetAdBackMessageNo == 1)
                {
                    jiuUBannerModel.IsAdRequestAdOk = true;

                    //标志此轮初始化完了
                    jiuUBannerModel.IsShouldShowThisRound = true;

                    AdInfo adInfo_t = GetAdInfoByAdName("9u_banner");
                    _adHandler.PostAdShowCount(_appName, _appId, _appVersion, adInfo_t.AdName, adInfo_t.AdTpye, "0", "1", adInfo_t.AdIndex.ToString());
                }
                else
                {
                    InitJiuUBanner();
                }
            };
        }

         */

        /// <summary>
        /// Admob
        /// </summary>
        void InitGoogleBanner()
        {
            System.Diagnostics.Debug.WriteLine("InitGoogleBanner");

            //try
            //{
                GoogleBannerModel googleBannerModel = GetAdBaseModelByAdName("admob_banner") as GoogleBannerModel;

                if (googleBannerModel != null)
                {
                    //请求到了就不再请求了
                    if (googleBannerModel.IsAdRequestAdOk)
                    {
                        return;
                    }

                    googleBannerModel.IsAdRequestAdOk = false;

                    //if (LayoutRoot.Children.Contains(googleBanner))
                    //{
                    //    LayoutRoot.Children.Remove(googleBanner);
                    //}

                    if (LayoutRoot.Children.Contains(googleAdContainer))
                    {
                        LayoutRoot.Children.Remove(googleAdContainer);
                    }

                    googleBanner = new GoogleAds.AdView();
                    googleBanner.AdUnitID = googleBannerModel.AdUnitID;
                    googleBanner.Format = GoogleAds.AdFormats.Banner;

                    googleBanner.ReceivedAd -= googleBanner_ReceivedAd;
                    googleBanner.ReceivedAd += googleBanner_ReceivedAd;

                    googleBanner.FailedToReceiveAd -= googleBanner_FailedToReceiveAd;
                    googleBanner.FailedToReceiveAd += googleBanner_FailedToReceiveAd;

                    googleBanner.LoadAd(new GoogleAds.AdRequest { ForceTesting = false }
                        );
                    //googleBanner.Opacity = 0;
                    //googleBanner.IsHitTestVisible = false;

                    googleAdContainer.Children.Clear();
                    googleAdContainer.Children.Add(googleBanner);
                    googleAdContainer.Opacity = 0;
                    googleAdContainer.IsHitTestVisible = false;


                    //if (!LayoutRoot.Children.Contains(googleBanner))
                    //{
                    //    LayoutRoot.Children.Add(googleBanner);
                    //}


                    if (!LayoutRoot.Children.Contains(googleAdContainer))
                    {
                        LayoutRoot.Children.Add(googleAdContainer);
                    }

                    System.Diagnostics.Debug.WriteLine("googleBanner");
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        void googleBanner_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("googleBanner_ReceivedAd");

            GoogleBannerModel googleBannerModel = GetAdBaseModelByAdName("admob_banner") as GoogleBannerModel;

            if (googleBannerModel != null)
            {
                googleBannerModel.IsAdRequestAdOk = true;

                //标志此轮初始化完了
                googleBannerModel.IsShouldShowThisRound = true;

                AdInfo adInfo_t = GetAdInfoByAdName("admob_banner");
                _adHandler.PostAdShowCount(_appName, _appId, _appVersion, adInfo_t.AdName, adInfo_t.AdTpye, "0", "1", adInfo_t.AdIndex.ToString());
            };
        }

        void googleBanner_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("googleBanner_FailedToReceiveAd," + e.ErrorCode.ToString());
            //InitGoogleBanner();
        }


        /// <summary>
        /// PubCenter
        /// </summary>
        void InitPubCenterBanner()
        {
            System.Diagnostics.Debug.WriteLine("InitPubCenterBanner");

            PubCenterBannerModel pubCenterBannerModel = GetAdBaseModelByAdName("pubcenter_banner") as PubCenterBannerModel;
            AdInfo adInfo_t = GetAdInfoByAdName("pubcenter_banner");

            if (pubCenterBannerModel != null)
            {
                //请求到了就不再请求了
                if (pubCenterBannerModel.IsAdRequestAdOk)
                {
                    return;
                }

                pubCenterBannerModel.IsAdRequestAdOk = false;

                //if (LayoutRoot.Children.Contains(pubCenterBanner))
                //{
                //    LayoutRoot.Children.Remove(pubCenterBanner);
                //}

                if (LayoutRoot.Children.Contains(pubcenterAdContainer))
                {
                    LayoutRoot.Children.Remove(pubcenterAdContainer);
                }

                int index_t = new Random().Next(0, pubCenterBannerModel.AdUnitId.Length);
                Debug.WriteLine(index_t.ToString());

                pubCenterBanner =
                    new Microsoft.Advertising.Mobile.UI.AdControl(pubCenterBannerModel.ApplicationId, pubCenterBannerModel.AdUnitId[index_t], true);
                //new Microsoft.Advertising.Mobile.UI.AdControl("test_client", pubCenterBannerModel.AdUnitId, false);

                pubCenterBanner.Height = 80;
                pubCenterBanner.Width = 480;

                pubCenterBanner.AdRefreshed -= pubCenterBanner_AdRefreshed;
                pubCenterBanner.AdRefreshed += pubCenterBanner_AdRefreshed;

                pubCenterBanner.ErrorOccurred -= pubCenterBanner_ErrorOccurred;
                pubCenterBanner.ErrorOccurred += pubCenterBanner_ErrorOccurred;

                pubCenterBanner.PublisherMessageEvent += pubCenterBanner_PublisherMessageEvent;

                //pubCenterBanner.Opacity = 0;
                //pubCenterBanner.IsHitTestVisible = false;

                pubcenterAdContainer.Children.Clear();
                pubcenterAdContainer.Children.Add(pubCenterBanner);
                pubcenterAdContainer.Opacity = 0;
                pubcenterAdContainer.IsHitTestVisible = false;

                //if (!LayoutRoot.Children.Contains(pubCenterBanner))
                //{
                //    //LayoutRoot.Children.Insert(0, pubCenterBanner);
                //    LayoutRoot.Children.Add(pubCenterBanner);
                //}

                if (!LayoutRoot.Children.Contains(pubcenterAdContainer))
                {
                    LayoutRoot.Children.Add(pubcenterAdContainer);
                }

                System.Diagnostics.Debug.WriteLine("pubCenterBanner");
            }
        }

        void pubCenterBanner_PublisherMessageEvent(object sender, Microsoft.Advertising.Shared.PublisherMessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        void pubCenterBanner_AdRefreshed(object sender, EventArgs e)
        {
            PubCenterBannerModel pubCenterBannerModel = GetAdBaseModelByAdName("pubcenter_banner") as PubCenterBannerModel;

            if (pubCenterBannerModel != null)
            {
                AdInfo adInfo_t = GetAdInfoByAdName("pubcenter_banner");

                pubCenterBannerModel.IsAdRequestAdOk = true;
                //标志此轮初始化完了
                pubCenterBannerModel.IsShouldShowThisRound = true;

                //DispatcherTimer t_t = new DispatcherTimer();
                //t_t.Interval = TimeSpan.FromSeconds(0.2);
                //t_t.Tick += (s1, e1) =>
                //{
                //    t_t.Stop();

                //    if (adInfo_t.ClickCountToHide == 0)
                //    {
                //        return;
                //    }

                //    if (adInfo_t.ClickCountToHide < 0 || adInfo_t.ClickCountToHide <= _adHandler.GetAdClickCount("pubcenter_banner"))
                //    {
                //        pubCenterBanner.Opacity = 0;
                //        pubCenterBanner.IsHitTestVisible = false;
                //    }
                //};

                //t_t.Start();

                _adHandler.PostAdShowCount(_appName, _appId, _appVersion, adInfo_t.AdName, adInfo_t.AdTpye, "0", "1", adInfo_t.AdIndex.ToString());
            };
        }

        void pubCenterBanner_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
            //InitPubCenterBanner();
        }


        #endregion

        #region ChaPing

        void _chaPingTimer_Tick(object sender, EventArgs e)
        {
            _chaPingTimer.Stop();

            switch (ChaPingAdInfoList[_currentChaPingAdIndex].AdName)
            {
                case "admob_chaping":
                    ShowGoogleChaPing();
                    break;

                //case "xapcn_chaping":
                //    ShowXapcnChaPing();
                //    break;

                //case "openxlive_chaping":
                //    ShowOpenXLiveChaPing();
                //    break;

                default:
                    break;
            }

            InitChaPing();
        }

        void InitChaPing()
        {
            if (ChaPingAdInfoList.Count == 0)
            {
                return;
            }

            for (int i = 0; i < ChaPingAdInfoList.Count; i++)
            {
                if (_currentChaPingAdIndex >= ChaPingAdInfoList.Count)
                {
                    _currentChaPingAdIndex = 0;
                }

                if (ChaPingAdInfoList[_currentChaPingAdIndex].ShowFullAdCount == 0 ||
                    ChaPingAdInfoList[_currentChaPingAdIndex].ShowFullAdCount > _adHandler.GetAdClickCount(ChaPingAdInfoList[_currentChaPingAdIndex].AdName))
                {
                    _chaPingTimer.Interval = TimeSpan.FromSeconds(ChaPingAdInfoList[_currentChaPingAdIndex].ShowFullAdTime);
                    _chaPingTimer.Start();
                    break;
                }

                _currentChaPingAdIndex++;
            }
        }


        GoogleAds.InterstitialAd interstitialAd;
        /// <summary>
        /// Google
        /// </summary>
        public void ShowGoogleChaPing()
        {
            GoogleChaPingModel googleChaPingModel = GetAdBaseModelByAdName("admob_chaping") as GoogleChaPingModel;

            if (googleChaPingModel != null)
            {
                interstitialAd = new GoogleAds.InterstitialAd(googleChaPingModel.AdUnitID);
                GoogleAds.AdRequest adRequest = new GoogleAds.AdRequest();

                interstitialAd.ReceivedAd -= interstitialAd_ReceivedAd;
                interstitialAd.ReceivedAd += interstitialAd_ReceivedAd;

                //interstitialAd.ReceivedAd += (s1, e1) =>
                //    {
                //        interstitialAd.ShowAd();
                //        _adHandler.AdClicked("admob_chaping");
                //    };

                //interstitialAd.FailedToReceiveAd += (s1, e1) =>
                //    {
                //        interstitialAd.LoadAd(adRequest);
                //    };

                interstitialAd.LoadAd(adRequest);

                System.Diagnostics.Debug.WriteLine("admob_chaping");
            }
        }

        void interstitialAd_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            interstitialAd.ShowAd();
            _adHandler.AdClicked("admob_chaping");
        }

        /// <summary>
        /// XAPCN
        /// </summary>
        public void ShowXapcnChaPing()
        {
            /*
            XapcnChaPingModel xapcnChaPingModel = GetAdBaseModelByAdName("xapcn_chaping") as XapcnChaPingModel;

            if (xapcnChaPingModel != null)
            {
                XAPADStatistics.AdItem xapcnChaPing = new XAPADStatistics.AdItem();

                xapcnChaPing.ADKey = xapcnChaPingModel.ADKey;
                xapcnChaPing.AppID = xapcnChaPingModel.AppID;
                xapcnChaPing.Size = XAPADStatistics.SizeMode.Size400X400;

                xapcnChaPing.start();

                LayoutRootChaPing.Children.Clear();

                xapcnChaPing.ADReqeustSuccessed += (s1, e1) =>
                    {
                        LayoutRootChaPing.Children.Add(xapcnChaPing);
                        _adHandler.AdClicked("xapcn_chaping");
                    };

                xapcnChaPing.ADClickSuccess += (s1, e1) =>
                    {
                        LayoutRootChaPing.Children.Remove(xapcnChaPing);                        
                    };

                xapcnChaPing.ADClosed += (s1, e1) =>
                    {
                        LayoutRootChaPing.Children.Remove(xapcnChaPing);
                    };

                LayoutRootChaPing.Children.Add(xapcnChaPing);

                System.Diagnostics.Debug.WriteLine("xapcnChaPing");
             
            }
             */
        }

        /// <summary>
        /// OpenXLive
        /// </summary>
        public void ShowOpenXLiveChaPing()
        {
            /*
                    OpenXLiveChaPingModel openXLiveChaPingModel = GetAdBaseModelByAdName("openxlive_chaping") as OpenXLiveChaPingModel;

                    if (openXLiveChaPingModel != null)
                    {
                        OpenXLive.Advertising.AdControl openXLiveChaPing = new OpenXLive.Advertising.AdControl
                        {
                            ApplicationId = openXLiveChaPingModel.ApplicationId,
                            Type = OpenXLive.Advertising.AdType.FullScreen,
                            AdUnitId = openXLiveChaPingModel.AdUnitId,
                            IsCloseIconEnabled = false

                            //ApplicationId = "aa5c1c3e-6cd7-4296-9d4e-c46fa192f85b",
                            //Type = OpenXLive.Advertising.AdType.Banner,
                            //AdUnitId = "cf14959a-399d-49c9-90c4-e39a3bb8cdad",
                            //IsCloseIconEnabled = false,
                        };

                        LayoutRootChaPing.Children.Clear();

                        openXLiveChaPing.AdCompleted += (s1, e1) =>
                            {
                                LayoutRootChaPing.Children.Add(openXLiveChaPing);
                                _adHandler.AdClicked("openxlive_chaping");
                            };

                        openXLiveChaPing.IsEngagedChanged += (s1, e1) =>
                            {
                                LayoutRootChaPing.Children.Remove(openXLiveChaPing);
                            };

                        System.Diagnostics.Debug.WriteLine("openxlive_chaping");
                    }
              */
        }
        #endregion

        private void SetAdPosition(string position)
        {
            switch (position)
            {
                case "left_top":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    break;

                case "left_center":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    break;

                case "left_bottom":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                    break;

                case "center_top":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    break;

                case "center_center":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    break;

                case "center_bottom":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                    break;

                case "right_top":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    break;

                case "right_center":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    break;

                case "right_bottom":
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                    break;

                default:
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                    break;
            }
        }

        /// <summary>
        /// 根据名称获取传入的广告信息
        /// </summary>
        /// <param name="adName"></param>
        /// <returns></returns>
        public AdBaseModel GetAdBaseModelByAdName(string adName)
        {
            var adModels = (from m in ModelList
                            where m.AdName == adName
                            select m).ToList();

            if (adModels != null && adModels.Count > 0)
            {
                return adModels[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据名称获取从服务端得到的广告信息
        /// </summary>
        /// <param name="adName"></param>
        /// <returns></returns>
        public AdInfo GetAdInfoByAdName(string adName)
        {
            var adInfos = (from b in BannerAndDiyAdInfoList
                           where b.AdName == adName
                           select b).ToList();

            if (adInfos != null && adInfos.Count > 0)
            {
                return adInfos[0];
            }
            else
            {
                return null;
            }
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (BannerAndDiyAdInfoList.Count == 0)
            {
                return;
            }

            AdBaseModel a_t = GetAdBaseModelByAdName(BannerAndDiyAdInfoList[_currentBannerAdIndex].AdName);
            if (a_t.IsShouldShowThisRound)
            {
                _adHandler.AdClicked(BannerAndDiyAdInfoList[_currentBannerAdIndex].AdName);

                if (!_fromLocal)
                {
                    _adHandler.PostAdClickCount(_appName, _appId, _appVersion,
                        BannerAndDiyAdInfoList[_currentBannerAdIndex].AdName,
                        BannerAndDiyAdInfoList[_currentBannerAdIndex].AdTpye, "1", "0",
                        BannerAndDiyAdInfoList[_currentBannerAdIndex].AdIndex.ToString());
                }
                a_t.IsShouldShowThisRound = false;
            }

            DispatcherTimer t_t = new DispatcherTimer();
            t_t.Interval = TimeSpan.FromSeconds(1);
            t_t.Tick += (s2, e2) =>
            {
                t_t.Stop();

                CarouselBanners();
            };

            t_t.Start();
        }
    }
}
