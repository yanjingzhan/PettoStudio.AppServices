﻿using Controller;
using Models.IOSFullInfoServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            if (!IsPostBack)
            {
                string action, state, account, newstate, jsonstr, id, country, newcountry,applepersoninfoid,
                    oldchangecountrystate, newchangecountrystate, oldshuavunglestate, newshuavunglestate, changecountrystate, shuavunglestate;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                state = Request["state"] == null ? "" : Request["state"].Trim();
                account = Request["account"] == null ? "" : Request["account"].Trim();
                newstate = Request["newstate"] == null ? "" : Request["newstate"].Trim();
                jsonstr = Request["jsonstr"] == null ? "" : Request["jsonstr"].Trim();
                id = Request["id"] == null ? "" : Request["id"].Trim();

                country = Request["country"] == null ? "" : Request["country"].Trim();

                oldchangecountrystate = Request["oldchangecountrystate"] == null ? "" : Request["oldchangecountrystate"].Trim();
                newchangecountrystate = Request["newchangecountrystate"] == null ? "" : Request["newchangecountrystate"].Trim();
                oldshuavunglestate = Request["oldshuavunglestate"] == null ? "" : Request["oldshuavunglestate"].Trim();
                newshuavunglestate = Request["newshuavunglestate"] == null ? "" : Request["newshuavunglestate"].Trim();
                changecountrystate = Request["changecountrystate"] == null ? "" : Request["changecountrystate"].Trim();
                shuavunglestate = Request["shuavunglestate"] == null ? "" : Request["shuavunglestate"].Trim();
                newcountry = Request["newcountry"] == null ? "" : Request["newcountry"].Trim();
                applepersoninfoid = Request["applepersoninfoid"] == null ? "" : Request["applepersoninfoid"].Trim();

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

                    case "getappleaccountfullinfoandrefreshstatebystate":
                        GetAppleAccountFullInfoAndRefreshStateByState(state, newstate);
                        break;

                    case "updateaccountstate":
                        UpdateAccountState(account, state);
                        break;

                    case "getapplepersoninfoandrefreshstate":
                        GetApplePersonInfoAndRefreshState(state, newstate, country);
                        break;

                    case "addnewappleaccounttodb":
                        AddNewAppleAccountToDB(jsonstr, state);
                        break;

                    case "updateapplepersoninfostatebyid":
                        UpdateApplePersonInfoStateByID(state, id);
                        break;

                    case "getappaccountbychangecountrystate":
                        GetAppAccountByChangeCountryState(country, newcountry, state, oldchangecountrystate, newchangecountrystate);
                        break;

                    case "updatecountryandchangecountrystatebyid":
                        UpdateCountryAndChangeCountryStateByID(country, changecountrystate, applepersoninfoid,id);
                        break;

                    case "getappaccountbycountryandshuavunglestate":
                        GetAppAccountByCountryAndShuaVungleState(country, state, oldshuavunglestate, newshuavunglestate);
                        break;

                    case "updateshuavunglestatebyid":
                        UpdateShuaVungleStateByID(shuavunglestate, id);
                        break;
                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
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

        public void GetAppleAccountFullInfoAndRefreshStateByState(string state, string newstate)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new IOSFullInfoServicesControl().GetAppleAccountFullInfoAndRefreshStateByState(state, newstate));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAppleAccountFullInfoAndRefreshStateByState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAppleAccountFullInfoAndRefreshStateByState");
            }
        }


        public void GetIOSFullInfoByStateStr(string state)
        {
            try
            {
                var data = new IOSFullInfoServicesControl().GetAppleAccountFullInfoByState(state);

                string keyWords = string.Empty;
                string logoFileName = string.Empty;
                string gamecount = string.Empty;

                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "shuagame.txt"))
                {
                    string line = string.Empty;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.StartsWith(";") && !line.StartsWith("#"))
                        {
                            if (line.StartsWith("keywords="))
                            {
                                keyWords = line.Replace("keywords=", "").Trim();
                                continue;
                            }

                            if (line.StartsWith("gamelogo="))
                            {
                                logoFileName = line.Replace("gamelogo=", "").Trim();
                                continue;
                            }

                            if (line.StartsWith("gamecount="))
                            {
                                gamecount = line.Replace("gamecount=", "").Trim();
                                continue;
                            }
                        }
                    }
                }

                string result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                    //0~10
                    data.AppleAccount, data.ApplePassword, gamecount, data.FirstName, data.SecondName, data.Address, data.City, data.Province, data.ZipCode, data.PhoneNumber1, data.PhoneNumber2,
                    //11
                    keyWords,
                    //12
                    GetLogoUrls(logoFileName),
                    data.FirstQuestion, data.FirstAnswer, data.SecondQuestion, data.SecondAnswer, data.ThirdQuestion, data.ThirdAnswer, data.VerifyMail, data.VerifyPassword
                    );

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetIOSFullInfoByStateStr");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetIOSFullInfoByStateStr");
            }
        }


        private string GetLogoUrls(string logoFileName)
        {
            StringBuilder sb = new StringBuilder();

            string[] fileNames = logoFileName.Split('|');

            if (fileNames.Length > 0)
            {
                foreach (var fileName in fileNames)
                {
                    sb.Append(string.Format("http://ios.pettostudio.net/images/{0}", fileName) + "|");
                }
            }

            return sb.ToString().TrimEnd('|');
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

        public void GetApplePersonInfoAndRefreshState(string state, string newState, string country)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new IOSFullInfoServicesControl().GetApplePersonInfoAndRefreshState(state, newState, country));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetApplePersonInfoAndRefreshState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetApplePersonInfoAndRefreshState");
            }
        }

        public void AddNewAppleAccountToDB(string jsonStr, string state)
        {
            try
            {
                AppleAccountFullInfo t = JsonHelper.DeserializeObjectFromJson<AppleAccountFullInfo>(jsonStr);

                new IOSFullInfoServicesControl().AddNewAppleAccountToDB(t, state);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "AddNewAppleAccountToDB");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "AddNewAppleAccountToDB");
            }
        }

        public void UpdateApplePersonInfoStateByID(string state, string id)
        {
            try
            {
                new IOSFullInfoServicesControl().UpdateApplePersonInfoStateByID(state, id);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateApplePersonInfoStateByID");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateApplePersonInfoStateByID");
            }
        }

        public void GetAppAccountByChangeCountryState(string country, string newCountry, string state, string oldChangeCountryState, string newChangeCountryState)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new IOSFullInfoServicesControl().GetAppAccountByChangeCountryState(country, newCountry, state,
                    oldChangeCountryState, newChangeCountryState));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAppAccountByChangeCountryState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAppAccountByChangeCountryState");
            }
        }

        public void UpdateCountryAndChangeCountryStateByID(string country, string changeCountryState, string applePersonInfoID, string id)
        {
            try
            {
                new IOSFullInfoServicesControl().UpdateCountryAndChangeCountryStateByID(country, changeCountryState, applePersonInfoID, id);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateCountryAndChangeCountryStateByID");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateCountryAndChangeCountryStateByID");
            }
        }

        public void GetAppAccountByCountryAndShuaVungleState(string country, string state, string oldShuaVungleState, string newShuaVungleState)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(new IOSFullInfoServicesControl().GetAppAccountByCountryAndShuaVungleState(country, state,
                    oldShuaVungleState, newShuaVungleState));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "GetAppAccountByCountryAndShuaVungleState");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "GetAppAccountByCountryAndShuaVungleState");
            }
        }

        public void UpdateShuaVungleStateByID(string shuaVungleState, string id)
        {
            try
            {
                new IOSFullInfoServicesControl().UpdateShuaVungleStateByID(shuaVungleState, id);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "UpdateShuaVungleStateByID");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "UpdateShuaVungleStateByID");
            }
        }
    }
}