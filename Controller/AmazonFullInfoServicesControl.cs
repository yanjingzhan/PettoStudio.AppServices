using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using Models.AmazonFullInfoServices;
using System.Data;
using DataBaseLib;

namespace Controller
{
    public class AmazonFullInfoServicesControl
    {
        public AmazonFullInfoServicesModel GetAmazonFullInfo(string newStateAfterUse = "normal")
        {
            //newStateAfterUse = string.IsNullOrEmpty(newStateAfterUse) ? "已使用" : newStateAfterUse;

            //test
            newStateAfterUse = "normal";

            string sqlCmd = string.Format("select TOP 1 * from [dbo].[AmazonFullInfo] a,[dbo].[AndroidDeviceInfo] b where  a.[State]='normal' AND a.[AndroidDeviceInfoID]=b.[ID] order by a.[UpdateTime]");

            DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

            if (infoTable == null || infoTable.Rows.Count == 0)
            {
                throw new Exception("无数据");
            }

            AmazonFullInfoServicesModel info_t = new AmazonFullInfoServicesModel
            {
                ID = infoTable.Rows[0][0].ToString(),
                AmazonAccount = infoTable.Rows[0]["AmazonAccount"].ToString(),
                AmazonPassword = infoTable.Rows[0]["AmazonPassword"].ToString(),
                VPNAccount = infoTable.Rows[0]["VPNAccount"].ToString(),
                VPNPassword = infoTable.Rows[0]["VPNPassword"].ToString(),
                IP = infoTable.Rows[0]["IP"].ToString(),
                IMEI = infoTable.Rows[0]["序列号"].ToString(),
                AndroidID = infoTable.Rows[0]["android_id"].ToString(),
                PhoneNum = infoTable.Rows[0]["手机号码"].ToString(),
                SimSerialNum = infoTable.Rows[0]["手机卡序列号"].ToString(),
                IMSI = infoTable.Rows[0]["IMSI"].ToString(),
                SimCountry = infoTable.Rows[0]["手机卡国家"].ToString(),
                Operator = infoTable.Rows[0]["运营商"].ToString(),
                OperatorName = infoTable.Rows[0]["运营商名字"].ToString(),
                CountryISOCode = infoTable.Rows[0]["国家ISO代码"].ToString(),
                NetworkType = infoTable.Rows[0]["网络类型"].ToString(),
                NetworkTypeName = infoTable.Rows[0]["网络类型名"].ToString(),
                PhoneType = infoTable.Rows[0]["手机类型"].ToString(),
                PhoneCardStatus = infoTable.Rows[0]["手机卡状态"].ToString(),
                MacAddress = infoTable.Rows[0]["mac地址"].ToString(),
                WIFIName = infoTable.Rows[0]["无线路由器名"].ToString(),
                WIFIAddress = infoTable.Rows[0]["无线路由器地址"].ToString(),
                OSVersion = infoTable.Rows[0]["系统版本"].ToString(),
                OSVersionValue = infoTable.Rows[0]["系统版本值"].ToString(),
                OSStructure = infoTable.Rows[0]["系统架构"].ToString(),
                ScreenResolution = infoTable.Rows[0]["屏幕分辨率"].ToString(),
                FirmwareVersion = infoTable.Rows[0]["固件版本"].ToString(),
                Brand = infoTable.Rows[0]["品牌"].ToString(),
                Model = infoTable.Rows[0]["型号"].ToString(),
                ProductName = infoTable.Rows[0]["产品名"].ToString(),
                OEM = infoTable.Rows[0]["制造商"].ToString(),
                CPUModel = infoTable.Rows[0]["CPU型号"].ToString(),
                Hardware = infoTable.Rows[0]["硬件"].ToString(),
            };

            sqlCmd = string.Format("UPDATE [dbo].[AmazonFullInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [ID] = {2}",
                                 newStateAfterUse, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), info_t.ID);

            SqlHelper.Instance.ExecuteCommand(sqlCmd);

            return info_t;
        }

        public void UpdateAccountState(string account, string state)
        {
            try
            {
                string sqlCmd = string.Format("UPDATE [dbo].[AmazonFullInfo] SET [State] = '{0}',[UpdateTime] = '{1}' WHERE [AmazonAccount] = '{2}'",
                                                state,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), account);

                DataTable infoTable = SqlHelper.Instance.ExecuteDataTable(sqlCmd);

                SqlHelper.Instance.ExecuteCommand(sqlCmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
