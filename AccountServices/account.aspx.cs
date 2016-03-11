using AccountServices.Utility;
using Controller;
using Models.AccountServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace AccountServices
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, account, password, username, country, group, state, phonetype, accountcount, addTime;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                account = Request["account"] == null ? "" : Request["account"].Trim();
                password = Request["password"] == null ? "" : Request["password"].Trim();
                username = Request["username"] == null ? "" : Request["username"].Trim();
                country = Request["country"] == null ? "" : Request["country"].Trim();
                group = Request["group"] == null ? "" : Request["group"].Trim();
                state = Request["state"] == null ? "" : Request["state"].Trim();
                phonetype = Request["phonetype"] == null ? "" : Request["phonetype"].Trim();
                accountcount = Request["accountcount"] == null ? "" : Request["accountcount"].Trim();
                addTime = Request["addtime"] == null ? "" : Request["addtime"].Trim();

                switch (action.ToLower())
                {
                    case "getxboxstateaccountinfolist":
                        GetXboxStateAccountInfoList(username, accountcount);
                        break;

                    case "updateaccountstate":
                        UpdateAccountState(username, account, state);
                        break;

                    case "insertaccount":
                        InsertAccount(username, account, password, country, group, state, phonetype);
                        break;

                    case "getaccountinfolistbystate":
                        GetAccountInfoListByState(username, state, accountcount);
                        break;

                    case "getaccountinfolistbystatewithoutname":
                        GetAccountInfoListByStateWithOutName(state, accountcount);
                        break;

                    case "getaccountinfolistbystatewithoutnamebutcountry":
                        GetAccountInfoListByStateWithOutNameButCountry(state, accountcount, country);
                        break;

                    case "getaccountinfolistbystateandaddtime":
                        GetAccountInfoListByStateAndAddTime(state, accountcount, addTime);
                        break;


                    case "updateaccountstatephonetype":
                        UpdateAccountStatePhoneType(username, account, state, phonetype);
                        break;

                    case "updateaccountstatephonetypecountry":
                        UpdateAccountStatePhoneTypeCountry(username, account, state, phonetype, country);
                        break;

                    case "updateaccountstatewithoutusername":
                        UpdateAccountStateWithoutUserName(account, state);
                        break;

                    case "updateaccountcountryandgroup":
                        UpdateAccountCountryAndGroup(account, country, group);
                        break;

                    case "getaccountinfolistforshoudong":
                        GetAccountInfoListForShouDong(accountcount, country, username);
                        break;

                    case "checkaccount":
                        CheckAccount(accountcount);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        public void CheckAccount(string accountCount)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AccountControl().CheckAccount(accountCount));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "CheckAccount");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "CheckAccount");
            }
        }

        public void GetAccountInfoListForShouDong(string accountCount, string country, string userName)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AccountControl().GetAccountInfoListForShouDong(int.Parse(accountCount), country, userName));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAccountInfoListForShouDong");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAccountInfoListForShouDong");
            }
        }

        public void GetAccountInfoListByStateAndAddTime(string state, string accountCount, string addTime)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AccountControl().GetAccountInfoListByStateAndAddTime(state, int.Parse(accountCount), addTime));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAccountInfoListByStateAndAddTime");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAccountInfoListByStateAndAddTime");
            }
        }

        public void UpdateAccountCountryAndGroup(string account, string country, string group)
        {
            try
            {
                new AccountControl().UpdateAccountCountryAndGroup(account, country, group);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateAccountCountryAndGroup");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateAccountCountryAndGroup");
            }
        }
        private void UpdateAccountStatePhoneType(string username, string account, string state, string phonetype)
        {
            try
            {
                new AccountControl().UpdateAccountStatePhoneType(username, account, state, phonetype);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateAccountStatePhoneType");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateAccountStatePhoneType");
            }
        }

        private void UpdateAccountStatePhoneTypeCountry(string userName, string account, string state, string phoneType, string country)
        {
            try
            {
                new AccountControl().UpdateAccountStatePhoneTypeCountry(userName, account, state, phoneType, country);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateAccountStatePhoneTypeCountry");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateAccountStatePhoneTypeCountry");
            }
        }

        private void UpdateAccountStateWithoutUserName(string account, string state)
        {
            try
            {
                new AccountControl().UpdateAccountStateWithoutUserName(account, state);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateAccountStateWithoutUserName");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateAccountStateWithoutUserName");
            }


        }

        /// <summary>
        /// 获取待绑定的账户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accountcount"></param>
        private void GetXboxStateAccountInfoList(string username, string accountcount)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AccountControl().GetXboxStateAccountInfoList(username, int.Parse(accountcount)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetXboxStateAccountInfoList");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetXboxStateAccountInfoList");
            }
        }

        /// <summary>
        /// 根据员工和状态获取账户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="state"></param>
        /// <param name="accountcount"></param>
        private void GetAccountInfoListByState(string username, string state, string accountcount)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AccountControl().GetAccountInfoListByState(username, state, int.Parse(accountcount)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAccountInfoListByState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAccountInfoListByState");
            }
        }

        /// <summary>
        /// 根据状态获取账户
        /// </summary>
        /// <param name="state"></param>
        /// <param name="accountcount"></param>
        private void GetAccountInfoListByStateWithOutName(string state, string accountcount)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AccountControl().GetAccountInfoListByStateWithOutName(state, int.Parse(accountcount)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAccountInfoListByState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAccountInfoListByState");
            }
        }


        /// <summary>
        /// 根据状态获取账户
        /// </summary>
        /// <param name="state"></param>
        /// <param name="accountcount"></param>
        private void GetAccountInfoListByStateWithOutNameButCountry(string state, string accountcount, string country)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new AccountControl().GetAccountInfoListByStateWithOutNameButCountry(state, int.Parse(accountcount), country));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAccountInfoListByStateWithOutNameButGroup");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAccountInfoListByStateWithOutNameButGroup");
            }
        }


        private void UpdateAccountState(string username, string account, string state)
        {
            try
            {
                new AccountControl().UpdateAccountState(username, account, state);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateAccountState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateAccountState");
            }
        }

        private void InsertAccount(string username, string account, string password, string country, string group, string state, string phonetype)
        {
            try
            {
                new AccountControl().InsertAccount(
                    new AccountInfo
                    {
                        Account = account,
                        Country = country,
                        Group = group,
                        Password = password,
                        PhoneType = phonetype,
                        State = state,
                        UserName = username
                    }
                    );

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "InsertAccount");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "InsertAccount");
            }
        }
    }
}