using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace IOSFullInfoServices
{
    public partial class AccountInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action, state, account;

            action = Request["action"] == null ? "" : Request["action"].Trim();
            state = Request["state"] == null ? "" : Request["state"].Trim();
            account = Request["account"] == null ? "" : Request["account"].Trim();

            switch (action.ToLower())
            {
                case "getiosfullinfo":
                    GetIOSFullInfo();
                    break;

                case "getiosfullinfostr":
                    GetIOSFullInfoStr();
                    break;

                case "getiosfullinfobystate":
                    GetIOSFullInfoByState(state);
                    break;

                case "getiosfullinfobystatestr":
                    GetIOSFullInfoByStateStr(state);
                    break;

                case "updateaccountstate":
                    UpdateAccountState(account, state);
                    break;

                default:
                    Response.Write("-100:action is error!");
                    break;
            }
        }

        public void GetIOSFullInfo()
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new IOSFullInfoServicesControl().GetAppleAccountFullInfo());

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetIOSFullInfo");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetIOSFullInfo");
            }
        }

        public void GetIOSFullInfoStr()
        {
            try
            {
                var data = new IOSFullInfoServicesControl().GetAppleAccountFullInfo();
                string result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}",
                    data.AppleAccount, data.ApplePassword, data.FirstName, data.SecondName, data.Address, data.City, data.Province, data.ZipCode, data.PhoneNumber1, data.PhoneNumber2,
                    "angry bird",
                    "http://ios.pettostudio.net/images/gamelogo.png",
                    data.FirstQuestion, data.FirstAnswer, data.SecondQuestion, data.SecondAnswer, data.ThirdQuestion, data.ThirdAnswer, data.VerifyMail, data.VerifyPassword
                    );

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetIOSFullInfoStr");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetIOSFullInfoStr");
            }
        }

        public void GetIOSFullInfoByState(string state)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new IOSFullInfoServicesControl().GetAppleAccountFullInfoByState(state));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetIOSFullInfo");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetIOSFullInfo");
            }
        }

        public void GetIOSFullInfoByStateStr(string state)
        {
            try
            {
                var data = new IOSFullInfoServicesControl().GetAppleAccountFullInfoByState(state);
                string result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}",
                    data.AppleAccount, data.ApplePassword, data.FirstName, data.SecondName, data.Address, data.City, data.Province, data.ZipCode, data.PhoneNumber1, data.PhoneNumber2,
                    "angry bird",
                    "http://ios.pettostudio.net/images/gamelogo.png",
                    data.FirstQuestion, data.FirstAnswer, data.SecondQuestion, data.SecondAnswer, data.ThirdQuestion, data.ThirdAnswer, data.VerifyMail, data.VerifyPassword
                    );

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetIOSFullInfoStr");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetIOSFullInfoStr");
            }
        }

        public void UpdateAccountState(string account, string state)
        {
            try
            {
                new IOSFullInfoServicesControl().UpdateAccountState(account, state);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateAccountState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateAccountState");
            }
        }
    }
}