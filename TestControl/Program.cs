using Controller;
using Models.AccountServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace TestControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("asdasd".Split('|').Length);
            Console.WriteLine("|asdasd".Split('|').Length);
            Console.WriteLine("asdasd|".Split('|').Length);

            Console.ReadKey();

            string sqlCmd_Update = string.Format("UPDATE [dbo].[AndroidPushGameInfo] SET [State]='开发中',[BaiDuDevAccounts]='{0}',[BaiduStoreDevPassword]='{1}',[SanLiuLingStoreDevAccount]='{2}',[SanLiuLingStoreDevPassword]='{3}',[XiaomiStoreDevAccount]='{4}',[XiaomiStoreDevPassword]='{5}'",
                       "pushGameInfoModel_t.BaiduStoreDevAccount", "pushGameInfoModel_t.BaiduStoreDevPassword",
                       "pushGameInfoModel_t.SanLiuLingStoreDevAccount", "pushGameInfoModel_t.SanLiuLingStoreDevPassword",
                       "pushGameInfoModel_t.XiaomiStoreDevAccount", "pushGameInfoModel_t.XiaomiStoreDevPassword");

            //new AccountControl().InsertAccount(
            //    new AccountInfo
            //    {
            //        Account = "test",
            //        Country = "en-us",
            //        Group = "en-us_001",
            //        Password = "password",
            //        PhoneType = "wp8",
            //        State = "tobevia",
            //        UserName = "张三"
            //    }
            //    );

            //new AccountControl().UpdateAccountState("张三", "test", "xbox");

            //string s_t_1 = JsonHelper.SerializerToJson(new AccountControl().GetXboxStateAccountInfoList("张三", 4));
            //Console.WriteLine(s_t_1);

            //获取广告
            //string result = JsonHelper.SerializerToJson(
            //        new AdsControl().GetAdInfo
            //        (
            //             new Models.In.AdsGetter
            //             {
            //                 AppName = "tiequan3",
            //                 AppVersion = "1.0",
            //                 AdIndex = 1
            //             }
            //        ));

            //new AdsControl().PostAdShowCount
            //      (
            //           new Models.In.PostAdData
            //           {
            //               AppName = "tiequan3",
            //               AppVersion = "1.0",
            //               AdName = "admob_banner",
            //               AdType = "normal",
            //               AppId = "xx",
            //               ClickCount = 0,
            //               ShowCount = 1,
            //               AdIndex = 1
            //           }
            //      );

            //获取推荐列表
            //string result = JsonHelper.SerializerToJson(
            // new RecommendAppControl().GetRecommendAppList
            // (
            //      new Models.In.RecommendAppGetter
            //      {
            //          RecommendAppListId = "emu_en"
            //      }
            // ));

            //Console.WriteLine(result);


            //PlayControl pc = new PlayControl();
            //pc.AddAppsToSomeCountryIntoDataBase("testAppId", "testAppName", "a", new string[] { "zh-CN", "en-GB" });

            //List<AppModel> al = pc.GetCouldBePlayedAppListByCountry("en-GB");
            //foreach (var a in al)
            //{
            //    Console.WriteLine(a.AppName);

            //    pc.UpdateAppsCouldBePlayedByIdAndCountry(a.AppId, a.Country, false);
            //}

            //pc.UpdateCurrentGroupNumberToCountryGroupTable("3", "en-gb");

            //var cl = pc.GetCountryGroupInfoListFromDb();
            //foreach (var c in cl)
            //{
            //    Console.WriteLine(c.Country);
            //}

            //var ail = pc.GetAccountInfoListByCountryAndGroupNumber("en-gb", "3");
            //foreach (var a in ail)
            //{
            //    Console.WriteLine(a.Account);
            //}

            //AccountControl ac = new AccountControl();

            //ac.UpdateAccountStatePhoneTypeCountry("1", "steelworksui@hotmail.com", "binding", "WP7", "en-US");

            //ShuaControl sc = new ShuaControl();
            //sc.AddShuaRecordToDataBase("test_test2", "2", "1");

            //string s = JsonHelper.SerializerToJson(sc.GetShuaRecordFromDataBase("2015/5/30", "2015/7/31"));

            //PlayControl pc = new PlayControl();
            //pc.AddAppsToSomeCountryIntoDataBaseShouDong("test_ShouDong", "appName_ShouDOng", "Petto_ShouDOng", new string[] { "en-us", "zh-cn" }, "1");

            //int s = pc.GetShouDongCurrentGroupNumber();

            //pc.UpdateShouDongCurrentGroupNumber("2");

            //pc.DeleteAppFromDB("test_ShouDong");

            //string s = JsonHelper.SerializerToJson(pc.GetCouldBePlayedAppListByCountryShouDong("en-us"));
            //Console.WriteLine(s);

            //AccountControl ac = new AccountControl();
            //string s = JsonHelper.SerializerToJson(ac.GetAccountInfoListForShouDong(1, "en-us","1"));
            //Console.WriteLine(s);


            //PushGameInfoControl pc = new PushGameInfoControl();
            //string s = JsonHelper.SerializerToJson(pc.GetPushGameInfoModelListByCount(
            //    new Models.GameManager.PushGameInfoModel
            //    {
            //        AddTime = string.Empty,
            //        DevAccount = string.Empty,
            //        DevPassword = string.Empty,
            //        GameID = "",
            //        GameName = string.Empty,
            //        GoogleBanner = string.Empty,
            //        GoogleChaping = string.Empty,
            //        PubcenterAdID = string.Empty,
            //        PubcenterAppID = string.Empty,
            //        PusherName = string.Empty,
            //        State = string.Empty,
            //        SurfaceAccountID = string.Empty,
            //        SurfaceAdID = string.Empty,
            //        UpdateTime = string.Empty,
            //        Version = string.Empty
            //    },10));



            //pc.UpdatePushGameInfo(
            //    new Models.GameManager.PushGameInfoModel
            //    {
            //        AddTime = string.Empty,
            //        DevAccount = "DevAccount_Test_3",
            //        DevPassword = "DevPassword_Test_3",
            //        GameID = "GameID_Test_3",
            //        GameName = "GameName_Test_3",
            //        GoogleBanner = "GoogleBanner_Test_3",
            //        GoogleChaping = "GoogleChaping_Test_3",
            //        PubcenterAdID = "PubcenterAdID_Test_3",
            //        PubcenterAppID = "PubcenterAppID_Test_3",
            //        PusherName = "PusherName_Test_3",
            //        State = "State_Test_3",
            //        SurfaceAccountID = "SurfaceAccountID_Test_3",
            //        SurfaceAdID = "SurfaceAdID_Test_3",
            //        UpdateTime = string.Empty,
            //        Version = "10"
            //    });

            //pc.AddPushGameInfo(
            //     new Models.GameManager.PushGameInfoModel
            //{
            //    AddTime = string.Empty,
            //    DevAccount = "DevAccount_Test_3",
            //    DevPassword = "DevPassword_Test_3",
            //    GameID = "GameID_Test_3",
            //    GameName = "GameName_Test_3",
            //    GoogleBanner = "GoogleBanner_Test_3",
            //    GoogleChaping = "GoogleChaping_Test_3",
            //    PubcenterAdID = "PubcenterAdID_Test_3",
            //    PubcenterAppID = "PubcenterAppID_Test_3",
            //    PusherName = "PusherName_Test_3",
            //    State = "State_Test_3",
            //    SurfaceAccountID = "SurfaceAccountID_Test_3",
            //    SurfaceAdID = "SurfaceAdID_Test_3",
            //    UpdateTime = string.Empty,
            //    Version = "10"
            //});

            //pc.UpdatePusherUser(
            //    new Models.GameManager.PusherUserModel
            //    {
            //        Name = "fuck1",
            //        Password = "呵呵",
            //        Role = "鸡巴毛"

            //    });

            AndroidPushGameInfoControl apc = new AndroidPushGameInfoControl();

            string arg = "2";
            //apc.AddAndroidPushGameInfo(
            //    new Models.GameManager.AndroidPushGameInfoModel
            //    {
            //        AddTime = string.Empty,
            //        BaiDuAppID = "BaiDuAppID_" + arg,
            //        BaiduStoreDevAccount = "BaiduStoreDevAccount_" + arg,
            //        BaiduStoreDevPassword = "BaiduStoreDevPassword_" + arg,
            //        BaiduStoreStatus = "BaiduStoreStatus_" + arg,
            //        DevAccount = "DevAccount_" + arg,
            //        DevPassword = "DevPassword_" + arg,
            //        DuoMengAppID = "DuoMengAppID_" + arg,
            //        DuoMengBannerID = "DuoMengBannerID_" + arg,
            //        DuoMengChaPingID = "DuoMengChaPingID_" + arg,
            //        FileName = "FileName_" + arg,
            //        GameID = "GameID_" + arg,
            //        GameName = "GameName_" + arg,
            //        GoogleBanner = "GoogleBanner_" + arg,
            //        GoogleChaping = "GoogleChaping_" + arg,
            //        PackageName = "PackageName_" + arg,
            //        PusherName = "PusherName_" + arg,
            //        SanLiuLingAppID = "SanLiuLingAppID_" + arg,
            //        SanLiuLingBannerID = "SanLiuLingBannerID_" + arg,
            //        SanLiuLingChaPingID = "SanLiuLingChaPingID_" + arg,
            //        SanLiuLingStoreDevAccount = "SanLiuLingStoreDevAccount" + arg,
            //        SanLiuLingStoreDevPassword = "SanLiuLingStoreDevPassword_" + arg,
            //        SanLiuLingStoreStatus = "SanLiuLingStoreStatus_" + arg,
            //        State = "State_" + arg,
            //        UpdateTime = string.Empty,
            //        Version = arg,
            //        XiaomiStoreDevAccount = "XiaomiStoreDevAccount_" + arg,
            //        XiaomiStoreDevPassword = "XiaomiStoreDevPassword_" + arg,
            //        XiaomiStoreStatus = "XiaomiStoreStatus_" + arg,
            //        YouMiAppID = "YouMiAppID_" + arg,
            //        YouMiID = "YouMiID_" + arg
            //    });

            string s = JsonHelper.SerializerToJson(apc.GetAndroidPushGameInfoModelListByCount(new Models.GameManager.AndroidPushGameInfoModel
                {
                    GameName = "GameName_1",
                    Version = "1",
                    PackageName = "PackageName_1"
                }, 1));

            apc.GetOneFreeLiuMangGameInfo();

            apc.UpdateAndroidPushGameInfo(new Models.GameManager.AndroidPushGameInfoModel
                {
                    AddTime = string.Empty,
                    BaiDuAppID = "BaiDuAppID_Update_" + arg,
                    BaiduStoreDevAccount = "BaiduStoreDevAccount_Update_" + arg,
                    BaiduStoreDevPassword = "BaiduStoreDevPassword_Update_" + arg,
                    BaiduStoreStatus = "BaiduStoreStatus_Update_" + arg,
                    DevAccount = "DevAccount_Update_" + arg,
                    DevPassword = "DevPassword_Update_" + arg,
                    DuoMengAppID = "DuoMengAppID_Update_" + arg,
                    DuoMengBannerID = "DuoMengBannerID_Update_" + arg,
                    DuoMengChaPingID = "DuoMengChaPingID_Update_" + arg,
                    FileName = "FileName_Update_" + arg,
                    GameID = "GameID_Update_" + arg,
                    GameName = "GameName_" + arg,
                    GoogleBanner = "GoogleBanner_Update_" + arg,
                    GoogleChaping = "GoogleChaping_Update_" + arg,
                    PackageName = "PackageName_" + arg,
                    PusherName = "PusherName_Update_" + arg,
                    SanLiuLingAppID = "SanLiuLingAppID_Update_" + arg,
                    SanLiuLingBannerID = "SanLiuLingBannerID_Update_" + arg,
                    SanLiuLingChaPingID = "SanLiuLingChaPingID_Update_" + arg,
                    SanLiuLingStoreDevAccount = "SanLiuLingChaPingID_Update_" + arg,
                    SanLiuLingStoreDevPassword = "SanLiuLingStoreDevPassword_Update_" + arg,
                    SanLiuLingStoreStatus = "SanLiuLingStoreStatus_Update_" + arg,
                    State = "State_Update_" + arg,
                    UpdateTime = string.Empty,
                    Version = arg,
                    XiaomiStoreDevAccount = "XiaomiStoreDevAccount_Update_" + arg,
                    XiaomiStoreDevPassword = "XiaomiStoreDevPassword_Update_" + arg,
                    XiaomiStoreStatus = "XiaomiStoreStatus_Update_" + arg,
                    YouMiAppID = "YouMiAppID_Update_" + arg,
                    YouMiID = "YouMiID_Update_" + arg
                });

            Console.WriteLine(s);

            apc.DeleteGameInfoByNameAndVersionAndPackageName("GameName_" + arg, arg, "PackageName_" + arg);

            Console.ReadKey();
        }
    }
}
