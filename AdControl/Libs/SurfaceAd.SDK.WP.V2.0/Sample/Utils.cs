using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Info;
using SurfaceAd.SDK.WP;

/**
 * 创建时间：2014/11/10 11:39:55
 * 作者：yong.blackcore
 * Email：itblackhole@outlook.com
 * QQ：50404503
 */
namespace Sample
{
    public class Utils
    {
        public static string GetApplicationCurrentMemoryUsage()
        {
            return Math.Round(DeviceStatus.ApplicationCurrentMemoryUsage / (1024.0 * 1024.0), 2) + "MB";
        }


        public void BindSurfaceAdControlEvent(SurfaceAdControl surfaceAdControl)
        {
            surfaceAdControl.OnApplicationAuthEvent += surfaceAdControl_OnApplicationAuthEvent;
            surfaceAdControl.OnAdRequest += surfaceAdControl_OnAdRequest;
            surfaceAdControl.OnAdRequestLoaded += surfaceAdControl_OnAdRequestLoaded;
            surfaceAdControl.OnAdRequestFailed += surfaceAdControl_OnAdRequestFailed;
            surfaceAdControl.OnShowAdScreen += surfaceAdControl_OnShowAdScreen;
            surfaceAdControl.OnDismissAdScreen += surfaceAdControl_OnDismissAdScreen;
            surfaceAdControl.OnCloseAd += surfaceAdControl_OnCloseAd;
        }

        void surfaceAdControl_OnAdRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("ApplicationCurrentMemoryUsag:\t" + GetApplicationCurrentMemoryUsage());
            Debug.WriteLine("OnAdRequest:\t" + e.ToString());
        }

        void surfaceAdControl_OnDismissAdScreen(object sender, EventArgs e)
        {
            Debug.WriteLine("ApplicationCurrentMemoryUsag:\t" + GetApplicationCurrentMemoryUsage());
            Debug.WriteLine("OnDismissAdScreen:\t" + e.ToString());
        }

        void surfaceAdControl_OnAdRequestFailed(object sender, EventArgs e)
        {
            Debug.WriteLine("ApplicationCurrentMemoryUsag:\t" + GetApplicationCurrentMemoryUsage());
            Debug.WriteLine("OnAdRequestFailed:\t" + e.ToString());
        }

        void surfaceAdControl_OnAdRequestLoaded(object sender, EventArgs e)
        {
            Debug.WriteLine("ApplicationCurrentMemoryUsag:\t" + GetApplicationCurrentMemoryUsage());
            Debug.WriteLine("OnAdRequestLoaded:\t" + e.ToString());
        }

        void surfaceAdControl_OnCloseAd(object sender, EventArgs e)
        {
            Debug.WriteLine("ApplicationCurrentMemoryUsag:\t" + GetApplicationCurrentMemoryUsage());
            Debug.WriteLine("OnCloseAd:\t" + e.ToString());
        }

        void surfaceAdControl_OnShowAdScreen(object sender, EventArgs e)
        {
            Debug.WriteLine("ApplicationCurrentMemoryUsag:\t" + GetApplicationCurrentMemoryUsage());
            Debug.WriteLine("OnShowAdScreen:\t" + e.ToString());
        }

        void surfaceAdControl_OnApplicationAuthEvent(object sender, string message)
        {
            Debug.WriteLine("ApplicationCurrentMemoryUsag:\t" + Utils.GetApplicationCurrentMemoryUsage());
            Debug.WriteLine("OnApplicationAuthEvent:\t" + message);
        }

        #region **********插屏广告**********
        public void BindSurfaceAdInterstitialControlEvent(SurfaceAdInterstitialControl surfaceAdInterstitialControl)
        {
            surfaceAdInterstitialControl.OnApplicationAuthEvent += surfaceAdInterstitialControl_OnApplicationAuthEvent;
            surfaceAdInterstitialControl.OnAdRequest += surfaceAdInterstitialControl_OnAdRequest;
            surfaceAdInterstitialControl.OnAdRequestLoaded += surfaceAdInterstitialControl_OnAdRequestLoaded;
            surfaceAdInterstitialControl.OnAdRequestFailed += surfaceAdInterstitialControl_OnAdRequestFailed;
            surfaceAdInterstitialControl.OnShowAdScreen += surfaceAdInterstitialControl_OnShowAdScreen;
            surfaceAdInterstitialControl.OnDismissAdScreen += surfaceAdInterstitialControl_OnDismissAdScreen;
            surfaceAdInterstitialControl.OnCloseAd += surfaceAdInterstitialControl_OnCloseAd;
        }

        void surfaceAdInterstitialControl_OnAdRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("surfaceAdInterstitialControl_OnAdRequest:\t" + e.ToString());
        }

        void surfaceAdInterstitialControl_OnDismissAdScreen(object sender, EventArgs e)
        {
            Debug.WriteLine("OnDismissAdScreen:\t" + e.ToString());
        }

        void surfaceAdInterstitialControl_OnAdRequestFailed(object sender, EventArgs e)
        {
            Debug.WriteLine("OnAdRequestFailed:\t" + e.ToString());
        }

        void surfaceAdInterstitialControl_OnAdRequestLoaded(object sender, EventArgs e)
        {
            Debug.WriteLine("OnAdRequestLoaded:\t" + e.ToString());
        }

        void surfaceAdInterstitialControl_OnCloseAd(object sender, EventArgs e)
        {
            Debug.WriteLine("OnCloseAd:\t" + e.ToString());
        }

        void surfaceAdInterstitialControl_OnShowAdScreen(object sender, EventArgs e)
        {
            Debug.WriteLine("OnShowAdScreen:\t" + e.ToString());
        }

        void surfaceAdInterstitialControl_OnApplicationAuthEvent(object sender, string message)
        {
            Debug.WriteLine("OnApplicationAuthEvent:\t" + message);
        }
        #endregion **********插屏广告**********
    }
}
