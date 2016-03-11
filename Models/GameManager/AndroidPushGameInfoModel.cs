using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.GameManager
{
    public class AndroidPushGameInfoModel
    {
        public string FileName;
        public string PackageName;

        public string GameName;
        public string Version;

        /// <summary>
        /// 待提交
        /// 开发中
        /// 待审核
        /// 被拒绝
        /// 已上架
        /// 不可用
        /// </summary>
        public string State;
        public string GameID;
        public string PusherName;

        public string YouMiAppID;
        public string YouMiID;

        public string GoogleBanner;
        public string GoogleChaping;

        public string DuoMengAppID;
        public string DuoMengBannerID;
        public string DuoMengChaPingID;

        public string BaiDuAppID;

        public string SanLiuLingAppID;
        public string SanLiuLingBannerID;
        public string SanLiuLingChaPingID;

        public string BaiduStoreStatus;

        public string SanLiuLingStoreStatus;

        public string XiaomiStoreStatus;

        public string AddTime;
        public string UpdateTime;
        public string DevAccount;
        public string DevPassword;


        public string SanLiuLingStoreDevAccount;
        public string SanLiuLingStoreDevPassword;
        public string BaiduStoreDevAccount;
        public string BaiduStoreDevPassword;
        public string XiaomiStoreDevAccount;
        public string XiaomiStoreDevPassword;

        public string JingZhongAppId;
        public string IAdPushAppKey;

        public string DownloadAddress;
        public string AppType;
    }
}
