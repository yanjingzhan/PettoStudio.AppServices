using Controller;
using GamesManager.Utility;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace GamesManager
{
    public partial class DreamSparker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action, id, account, password, newpassword, state, devaccount, devpassword, sourcetype, addtime, updatetime,
                    count, token, domain, isdevaccount,pushcount;

                action = Request["action"] == null ? "" : Request["action"].Trim();
                id = Request["id"] == null ? "" : Request["id"].Trim();
                account = Request["account"] == null ? "" : Request["account"].Trim();
                password = Request["password"] == null ? "" : Request["password"].Trim();
                newpassword = Request["newpassword"] == null ? "" : Request["newpassword"].Trim();
                state = Request["state"] == null ? "" : Request["state"].Trim();
                devaccount = Request["devaccount"] == null ? "" : Request["devaccount"].Trim();
                devpassword = Request["devpassword"] == null ? "" : Request["devpassword"].Trim();
                sourcetype = Request["sourcetype"] == null ? "" : Request["sourcetype"].Trim();
                addtime = Request["addtime"] == null ? "" : Request["addtime"].Trim();
                updatetime = Request["updatetime"] == null ? "" : Request["updatetime"].Trim();
                count = Request["count"] == null ? "" : Request["count"].Trim();
                token = Request["token"] == null ? "" : Request["token"].Trim();
                domain = Request["domain"] == null ? "" : Request["domain"].Trim();
                isdevaccount = Request["isdevaccount"] == null ? "" : Request["isdevaccount"].Trim();
                pushcount = Request["pushcount"] == null ? "" : Request["pushcount"].Trim();

                switch (action.ToLower())
                {
                    case "getdreamsparkerlistbycount":
                        GetDreamSparkerListByCount(id, account, password, newpassword, state, devaccount,
                                                   devpassword, sourcetype, addtime, updatetime, count, token, domain,pushcount);
                        break;

                    case "updatedreamsparker":
                        UpdateDreamSparker(id, account, password, newpassword, state, devaccount, devpassword, sourcetype, addtime, updatetime, token, domain, pushcount);
                        break;

                    case "adddreamsparkermodel":
                        AddDreamSparkerModel(id, account, password, newpassword, state, devaccount, devpassword, sourcetype, addtime, updatetime, token, domain, pushcount);
                        break;

                    case "deletedreamsparkermodel":
                        DeleteDreamSparkerModel(id);
                        break;

                    case "getaccountinfobydevstate":
                        GetAccountInfoByDevState(isdevaccount, count);
                        break;

                    case "updateaccoundevstate":
                        UpdateAccounDevState(isdevaccount, id, state);
                        break;

                    case "updatedreamsparkerbydevaccount":
                        UpdateDreamSparkerByDevAccount(id, account, password, newpassword, state,
                                                       devaccount, devpassword, sourcetype,
                                                       addtime, updatetime, token, domain, pushcount);
                        break;

                    default:
                        Response.Write("-100:action is error!");
                        break;
                }
            }
        }

        private void UpdateAccounDevState(string isDevAccount, string id, string state)
        {
            try
            {
                new DreamSparkerControl().UpdateAccounDevState(isDevAccount, state, id);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "DreamSparker");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "DreamSparker");
            }
        }

        private void GetAccountInfoByDevState(string isDevAccount, string count)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                    new DreamSparkerControl().GetAccountInfoByDevState(isDevAccount, int.Parse(count)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "DreamSparker");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "DreamSparker");
            }
        }

        private void GetDreamSparkerListByCount(string id, string account, string password, string newpassword, string state,
                                                string devaccount, string devpassword, string sourcetype, string addtime,
                                                string updatetime, string count, string token, string domain, string pushCount)
        {
            try
            {
                string result = JsonHelper.SerializerToJson(
                        new DreamSparkerControl().GetDreamSparkerListByCount(
                new DreamSparkerModel
                {
                    Account = account,
                    AddTime = addtime,
                    DevAccount = devaccount,
                    DevPassword = devpassword,
                    ID = id,
                    NewPassword = newpassword,
                    Password = password,
                    SourceType = sourcetype,
                    State = state,
                    UpdateTime = updatetime,
                    Token = token,
                    Domain = domain,
                    PushCount = pushCount
                }, int.Parse(count)));

                Response.Write(result);
                LogWriter.WriteLog(result, Page, "DreamSparker");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "DreamSparker");
            }
        }

        private void UpdateDreamSparker(string id, string account, string password, string newpassword, string state,
                                        string devaccount, string devpassword, string sourcetype, string addtime,
                                        string updatetime, string token, string domain,string pushCount)
        {
            try
            {
                new DreamSparkerControl().UpdateDreamSparker(
                    new DreamSparkerModel
                    {
                        Account = account,
                        AddTime = addtime,
                        DevAccount = devaccount,
                        DevPassword = devpassword,
                        ID = id,
                        NewPassword = newpassword,
                        Password = password,
                        SourceType = sourcetype,
                        State = state,
                        UpdateTime = updatetime,
                        Token = token,
                        Domain = domain,
                        PushCount = pushCount
                    }, Page.Request.ServerVariables["REMOTE_ADDR"].ToString());

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "DreamSparker");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "DreamSparker");
            }
        }
        private void UpdateDreamSparkerByDevAccount(string id, string account, string password, string newpassword, string state,
                                                    string devaccount, string devpassword, string sourcetype, string addtime,
                                                    string updatetime, string token, string domain, string pushCount)
        {
            try
            {
                new DreamSparkerControl().UpdateDreamSparkerByDevAccount(
                    new DreamSparkerModel
                    {
                        Account = account,
                        AddTime = addtime,
                        DevAccount = devaccount,
                        DevPassword = devpassword,
                        ID = id,
                        NewPassword = newpassword,
                        Password = password,
                        SourceType = sourcetype,
                        State = state,
                        UpdateTime = updatetime,
                        Token = token,
                        Domain = domain,
                        PushCount = pushCount
                    });

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "DreamSparker");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "DreamSparker");
            }
        }

        private void AddDreamSparkerModel(string id, string account, string password, string newpassword, string state,
                                          string devaccount, string devpassword, string sourcetype, string addtime,
                                          string updatetime, string token, string domain, string pushCount)
        {
            try
            {
                new DreamSparkerControl().AddDreamSparkerModel(
                    new DreamSparkerModel
                    {
                        Account = account,
                        AddTime = addtime,
                        DevAccount = devaccount,
                        DevPassword = devpassword,
                        ID = id,
                        NewPassword = newpassword,
                        Password = password,
                        SourceType = sourcetype,
                        State = state,
                        UpdateTime = updatetime,
                        Token = token,
                        Domain = domain,
                        PushCount = pushCount
                    });

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "DreamSparker");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "DreamSparker");
            }
        }

        private void DeleteDreamSparkerModel(string id)
        {
            try
            {
                new DreamSparkerControl().DeleteDreamSparkerModel(id);

                Response.Write("200:ok");
                LogWriter.WriteLog("200:ok", Page, "DreamSparker");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                LogWriter.WriteLog(ex.Message, Page, "DreamSparker");
            }
        }

    }
}