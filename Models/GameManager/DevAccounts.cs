using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.GameManager
{
    public class DevAccounts
    {
        public class BaiduDevAccount
        {
            public string BaiduStoreDevAccount;
            public string BaiduStoreDevPassword;
        }

        public class SanLiuLingDevAccounts
        {
            public string SanLiuLingStoreDevAccount;
            public string SanLiuLingStoreDevPassword;
        }

        public class XiaoMiDevAccounts
        {
            public string XiaomiStoreDevAccount;
            public string XiaomiStoreDevPassword;
        }

        public List<BaiduDevAccount> BaiduDevList;
        public List<SanLiuLingDevAccounts> SanLiuLingDevList;
        public List<XiaoMiDevAccounts> XiaoMiDevList;

        public DevAccounts()
        {
            BaiduDevList = new List<BaiduDevAccount>();
            SanLiuLingDevList = new List<SanLiuLingDevAccounts>();
            XiaoMiDevList = new List<XiaoMiDevAccounts>();
        }

        public void AddBaiduDevAccout(string baiduDevAccount, string baiduDevPassword)
        {
            foreach (var baidu in BaiduDevList)
            {
                if (baidu.BaiduStoreDevAccount.ToLower() == baiduDevAccount.ToLower())
                {
                    return;
                }
            }
            BaiduDevList.Add(new BaiduDevAccount { BaiduStoreDevAccount = baiduDevAccount, BaiduStoreDevPassword = baiduDevPassword });
        }


        public void AddSanLiuLingDevAccout(string sanLiuLingDevAccount, string sanLiuLingDevPassword)
        {
            foreach (var san in SanLiuLingDevList)
            {
                if (san.SanLiuLingStoreDevAccount.ToLower() == sanLiuLingDevAccount.ToLower())
                {
                    return;
                }
            }
            SanLiuLingDevList.Add(new SanLiuLingDevAccounts { SanLiuLingStoreDevAccount = sanLiuLingDevAccount, SanLiuLingStoreDevPassword = sanLiuLingDevPassword });
        }

        public void AddXiaoMiDevAccount(string xiaomiDevAccount, string xiaomiDevPassword)
        {
            foreach (var xiao in XiaoMiDevList)
            {
                if (xiao.XiaomiStoreDevAccount.ToLower() == xiaomiDevAccount.ToLower())
                {
                    return;
                }
            }

            XiaoMiDevList.Add(new XiaoMiDevAccounts { XiaomiStoreDevAccount = xiaomiDevAccount, XiaomiStoreDevPassword = xiaomiDevPassword });
        }
    }
}
